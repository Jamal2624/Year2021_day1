using Microsoft.Extensions.Logging;
using SonarInterfaceServices.Services;
using SubmarineModules;
using System.Reflection;

namespace SonarImplementationServices.Services
{
    public class SonarReaderService : ISonarReaderService
    {
        private readonly ILogger<SonarReaderService> _logger;

        public SonarReaderService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<SonarReaderService>();
        }
        public SonarMeasurements ReadData()
        {
            var measurements = new SonarMeasurements();
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (!string.IsNullOrEmpty(path))
            {
                var filepath = Path.Combine(path, @"SonarData.txt");
                var fileInfo = new FileInfo(filepath);
                if (fileInfo.Exists)
                {
                    int i = 0;
                    string text = File.ReadAllText(filepath);
                    measurements.MeasurementItems = text.Split(';', StringSplitOptions.RemoveEmptyEntries).Select(s => new Measurement
                    {
                        Id = i++,
                        Depth = int.Parse(s.Trim()),
                        MovementType = MovementType.Missing
                    }).ToList();

                }
            }
            return measurements;
        }
    }
}
