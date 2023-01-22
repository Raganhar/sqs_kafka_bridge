namespace WebApplication1.Config;

public class ServiceConfiguration
{
    public AWSSQS AWSSQS { get; set; }
}

public class AWSSQS
{
    public string QueueUrl { get; set; }
}
