using Microsoft.Extensions.Logging;
using SonarImplementationServices;
using SonarInterfaceServices.Extentions;
using SonarInterfaceServices.Services;
using SubmarineModules;

namespace SonarImplementationServices.Services
{
    public class SonarWriterService : ISonarWriterService
    {
        //private readonly ILogger<SonarWriterService> _logger;

        //public SonarWriterService(ILoggerFactory loggerFactory)
        public SonarWriterService()
        {
            //_logger = loggerFactory.CreateLogger<SonarWriterService>();
        }

        public void WriteData(SonarMeasurements measurements)
        {
            measurements.MeasurementItems.ForEach(item =>
            {
                Console.WriteLine($"Sonar measurement: {item.Depth} {item.MovementType.ToLabel()}");
            });
        }
        public void WriteTotals(SonarMeasurements measurements)
        {
            Console.WriteLine($"Total down: {measurements.TotalDown}");
            Console.WriteLine($"Total up: {measurements.TotalUp}");
            Console.WriteLine($"Total on the same level: {measurements.TotalSame}");

        }

        public void Report(SonarMeasurements measurements)
        {
            WriteData(measurements);
            WriteTotals(measurements);
        }
    }
}
