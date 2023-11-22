namespace SubmarineModules
{
    /// <summary>
    /// Single sonar measurement
    /// </summary>
    public class Measurement
    {
        /// <summary>
        /// Id of the measurement
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Measured  depth
        /// </summary>
        public double Depth { get; set; }

        /// <summary>
        /// Type of movement
        /// </summary>
        public MovementType MovementType { get; set; } = MovementType.Missing;
    }
}
