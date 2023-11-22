using SubmarineModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonarInterfaceServices.Extentions
{
    public static class GeneralExtentions
    {
        /// <summary>
        /// Method converts enumeration into string
        /// </summary>
        /// <param name="measurement"></param>
        /// <returns></returns>
        public static string ToLabel(this MovementType  measurement)
        {
            return measurement == MovementType.Missing ? "N/A - no previous measurement" : (
                measurement == MovementType.Up? "decreased" : 
                (measurement == MovementType.Down? "increased" :
                (measurement == MovementType.NotMoved ? "same level": "")));
        }
    }
}
