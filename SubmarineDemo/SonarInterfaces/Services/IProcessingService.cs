using SubmarineModules;

namespace SonarInterfaceServices.Services
{
    public interface IProcessingService
    {
        /// <summary>
        /// runs main functionality
        /// </summary>
        void ProcessProgram();

        /// <summary>
        /// Calculates movement type
        /// </summary>
        /// <param name="previous"> previous measurement</param>
        /// <param name="current">current measurement</param>
        /// <returns></returns>
        MovementType CalculateMovementType(Measurement previous, Measurement current);

        /// <summary>
        /// Method calculates movement type for all measurements and all aggregated values
        /// </summary>
        /// <param name="measurements"></param>
        void CalculateAggregation(SonarMeasurements measurements);
    }
}
