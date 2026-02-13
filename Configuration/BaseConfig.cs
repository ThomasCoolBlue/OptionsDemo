namespace OptionsDemo.Configuration;

public class BaseConfig
{
    public const string FirstConfig = "FirstConfig";
    public const string SecondConfig = "SecondConfig";
    
    public required string ConfiguredValue { get; set; }
}

