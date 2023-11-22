using Moq;
using Ninject;
using Ninject.MockingKernel.Moq;
using SonarImplementationServices.Services;
using SonarInterfaceServices.Services;
using SubmarineModules;

namespace SubmarineTest
{
    [TestFixture]
    public class Tests
    {
        private Measurement _highMesurement = new Measurement() { Depth = 10 };
        private Measurement _currentMesurement = new Measurement() { Depth = 20 };
        private Measurement _sameMesurement = new Measurement() { Depth = 20 };
        private Measurement _lowMesurement = new Measurement() { Depth = 30 };

        private MoqMockingKernel _kernel;
        private Mock<ISonarReaderService> _sonarReaderService = new Mock<ISonarReaderService>();
        private Mock<ISonarWriterService> _sonarWriterService = new Mock<ISonarWriterService>();
        //private Mock<IProcessingService> _processingService;

        [SetUp]
        public void Setup()
        {
            _kernel = new MoqMockingKernel();
            _kernel.Bind<ISonarReaderService>().To<SonarReaderService>();
            _kernel.Bind<ISonarWriterService>().To<SonarWriterService>();
        }

        [TestCase(10, 20, MovementType.Down)]
        [TestCase(20, 10, MovementType.Up)]
        [TestCase(20, 20, MovementType.NotMoved)]
        public void should_be_same(double prevDepth, double currentDepth,MovementType expectedResult)
        {
            var previous = new Measurement()
            {
                Depth = prevDepth,
            };

            var current = new Measurement()
            {
                Depth = currentDepth,
            };

            var processingService = new ProcessingService(_sonarReaderService.Object, _sonarWriterService.Object);
            var type = processingService.CalculateMovementType(previous, current);
            Assert.That(type, Is.EqualTo(expectedResult));
        }
    }
}