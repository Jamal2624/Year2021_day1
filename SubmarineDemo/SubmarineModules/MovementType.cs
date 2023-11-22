using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubmarineModules
{
    /// <summary>
    /// Type of movement
    /// </summary>
    public enum MovementType
    {
        /// <summary>
        /// Movement type not defined
        /// </summary>
        Missing = 0,

        /// <summary>
        /// Depth decreased
        /// </summary>
        Up = 1,

        /// <summary>
        /// Depth not changed
        /// </summary>
        NotMoved = 2,

        /// <summary>
        /// Depth increased
        /// </summary>
        Down = 3
    }
}
