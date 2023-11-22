using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubmarineModules
{
    public class SonarMeasurements
    {
        /// <summary>
        /// List of collected measurements
        /// </summary>
        public List<Measurement> MeasurementItems { get; set; } = new List<Measurement>();

        /// <summary>
        /// count of movements with decreasing depth
        /// </summary>
        public int TotalUp { get; set; } = 0;

        /// <summary>
        /// count of movements with increasing depth
        /// </summary>
        public int TotalDown { get; set; } = 0;

        /// <summary>
        /// count of movements with not changing of depth
        /// </summary>
        public int TotalSame { get; set; } = 0;
    }
}
