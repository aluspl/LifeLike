﻿using Api.Models.Base;

namespace Api.Models.Config
{
    public class ConfigResponseModel : BaseResponseModel
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public string DisplayName { get; set; }

        public string Type { get; set; }

    }
}
