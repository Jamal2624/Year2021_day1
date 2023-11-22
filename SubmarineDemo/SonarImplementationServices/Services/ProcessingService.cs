using SonarInterfaceServices.Services;
using SubmarineModules;

namespace SonarImplementationServices.Services
{
    /// <summary>
    /// Implementation of processing service
    /// </summary>
    public class ProcessingService : IProcessingService
    {
        //injected subservices
        private readonly ISonarReaderService _sonarReaderService;
        private readonly ISonarWriterService _sonarWriterService;

        public ProcessingService(ISonarReaderService sonarReaderService,
            ISonarWriterService sonarWriterService)
        {
            _sonarReaderService = sonarReaderService;
            _sonarWriterService = sonarWriterService;
        }

        //processing main functionality
        public void ProcessProgram()
        {
            var sonarMeasurements = _sonarReaderService.ReadData();
            CalculateAggregation(sonarMeasurements);
            _sonarWriterService.Report(sonarMeasurements);
        }

        /// <summary>
        /// Method converts measurements into movement type
        /// </summary>
        /// <param name="previous">Previous measurement</param>
        /// <param name="current">Current measurement</param>
        /// <returns></returns>
        public MovementType CalculateMovementType(Measurement previous, Measurement current)
        {

            return previous == null ? MovementType.Missing :
                current.Depth < previous.Depth ? MovementType.Up :
                current.Depth > previous.Depth ? MovementType.Down : MovementType.NotMoved;
        }

        /// <summary>
        /// Total calculations
        /// </summary>
        /// <param name="measurements">Sonar measurements</param>
        public void CalculateAggregation(SonarMeasurements measurements)
        {
            var orderedMeasurements = measurements.MeasurementItems.OrderBy(ms => ms.Id).ToArray();
            for (int i = 1; i < orderedMeasurements.Count(); i++)
            {
                orderedMeasurements[i].MovementType = CalculateMovementType(orderedMeasurements[i - 1], orderedMeasurements[i]);
            }

            measurements.TotalDown = orderedMeasurements.Count(ms => ms.MovementType == MovementType.Down);
            measurements.TotalUp = orderedMeasurements.Count(ms => ms.MovementType == MovementType.Up);
            measurements.TotalSame = orderedMeasurements.Count(ms => ms.MovementType == MovementType.NotMoved);
        }
    }
}
