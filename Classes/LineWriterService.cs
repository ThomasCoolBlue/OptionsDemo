using Microsoft.Extensions.Options;
using OptionsDemo.Classes.Interfaces;
using OptionsDemo.Configuration;

namespace OptionsDemo.Classes;

public class LineWriterService(IOptionsMonitor<BaseConfig> configurations, IOptionsMonitor<ValidatedConfig> configShipment): ILineWriter
{
    public async Task RunAsync()
    {
        while (true)
        {
            Console.WriteLine(configurations.Get(BaseConfig.FirstConfig).ConfiguredValue);
            Console.WriteLine(configShipment.CurrentValue.ShipmentCode);
            await Task.Delay(1000);
        }
    }
}