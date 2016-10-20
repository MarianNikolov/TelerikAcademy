using Moq;
using NUnit.Framework;
using SchoolSystem.Contracts;
using SchoolSystem.Core;

namespace SchoolSystemTests
{
    [TestFixture]
    public class EngineTests
    {
        [Test]
        public void Engine_whenValueParameterIsCorrect_ShoudMakeNewEngine()
        {
            var reader = new Mock<IReader>();
            var writer = new Mock<IWriter>();

            var engine = new Engine(reader.Object, writer.Object);

            Assert.IsInstanceOf<Engine>(engine);
        }

        [Test]
        public void Start_ShoudStartReadAndWrete()
        {
            string inputValue = "CreateStudent Pesho Peshev 11";

            var reader = new Mock<IReader>();
            var writer = new Mock<IWriter>();

            reader.Setup(x => x.ReadCommand()).Returns(inputValue);

            var engine = new Engine(reader.Object, writer.Object);

            //Assert.Verify(engine.Start());
        }
    }
}
