namespace LifeLike.Data.Models
{
   

public class LinkDataModel
{
    public string method { get; set; }
    public string href { get; set; }
}


public class LinksDataModel
{
    public LinkDataModel api_self { get; set; }
    public LinkDataModel dashboard_url { get; set; }
    public LinkDataModel dashboard_project { get; set; }
    public LinkDataModel dashboard_summary { get; set; }
    public LinkDataModel dashboard_log { get; set; }
}

    public class WebHookDataModel
    {
          public string projectName { get; set; }
    public string buildTargetName { get; set; }
    public string projectGuid { get; set; }
    public string orgForeignKey { get; set; }
    public int buildNumber { get; set; }
    public string buildStatus { get; set; }
    public string startedBy { get; set; }
    public string platform { get; set; }
    public LinksDataModel links { get; set; }
    }
}