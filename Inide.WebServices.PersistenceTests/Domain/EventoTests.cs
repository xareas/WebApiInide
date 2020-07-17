using Inide.WebServices.Persistence.Domain;
using Moq;
using Xunit;

namespace Inide.WebServices.PersistenceTests.Domain
{
    public class EventoTests
    {
        private MockRepository mockRepository;



        public EventoTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private Evento CreateEvento()
        {
            return new Evento();
        }

        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var evento = this.CreateEvento();

            // Act
            evento.Nombre = "juan";
            
            // Assert
            Assert.True(evento.Nombre=="juan");
            this.mockRepository.VerifyAll();
        }
    }
}
