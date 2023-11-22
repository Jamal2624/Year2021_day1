using SubmarineModules;

namespace SonarInterfaceServices.Services
{
    public interface ISonarReaderService
    {
        /// <summary>
        /// method reads input with collected measurents
        /// </summary>
        /// <returns></returns>
        SonarMeasurements ReadData();
    }
}
