resource "azurerm_resource_group" "prod" {
  name     = "${var.resource_group_name}-${terraform.workspace}"
  location = "${var.location}"
}

module "db" {
  source               = "./db"
  resource_group_name  = "${azurerm_resource_group.prod.name}"
  location             = "${azurerm_resource_group.prod.location}"
  service_principal_id = "${azurerm_user_assigned_identity.prod.id }"
  admin_password       = "${module.vault.admin_password}"
  dbsubnet_id          = "${module.vnet.db_subnet_id}"
}

resource "azurerm_app_service_plan" "prod" {
  name                = "appserviceplan"
  location            = "${azurerm_resource_group.prod.location}"
  resource_group_name = "${azurerm_resource_group.prod.name}"

  sku {
    tier = "Standard"
    size = "S1"
  }
}

resource "azurerm_app_service" "frontend" {
  name                = "frontend"
  location            = "${azurerm_resource_group.prod.location}"
  resource_group_name = "${azurerm_resource_group.prod.name}"
  app_service_plan_id = "${azurerm_app_service_plan.prod.id}"

  site_config {
    dotnet_framework_version = "v4.0"
  }

  app_settings = {
    "host" = "${azurerm.backend.default_site_hostname}"
    "DB" = "Server=${db.serverurl};Integrated Security=SSPI"
  }
}

resource "azurerm_app_service" "backend" {
  name                = "backend"
  location            = "${azurerm_resource_group.prod.location}"
  resource_group_name = "${azurerm_resource_group.prod.name}"
  app_service_plan_id = "${azurerm_app_service_plan.prod.id}"

  site_config {
    dotnet_framework_version = "v4.0"
  }

  app_settings = {
    "frontend" = "${azurerm.frontend.default_site_hostname}"
    "DB" = "Server=${db.serverurl};Integrated Security=SSPI"
  }
}
