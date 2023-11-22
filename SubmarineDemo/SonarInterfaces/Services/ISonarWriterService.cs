using SubmarineModules;

namespace SonarInterfaceServices.Services
{
    public interface ISonarWriterService
    {
        /// <summary>
        /// Method writes details of calculations
        /// </summary>
        /// <param name="measurements"></param>
        void WriteData(SonarMeasurements measurements);

        /// <summary>
        /// Method writes aggregated values
        /// </summary>
        /// <param name="measurements">Calculated measurements</param>
        void WriteTotals(SonarMeasurements measurements);

        /// <summary>
        /// Methods writes reportes results of calculations
        /// </summary>
        /// <param name="measurements">Calculated measurements</param>
        void Report(SonarMeasurements measurements);

    }
}
