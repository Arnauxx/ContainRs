using ContainRs.WebApp.Models;

namespace ContainRs.Testes
{
    public class EmailCtor
    {
        [Fact]
        public void DeveLancarArgumentExceptionQuandoValorInvalido()
        {
            // arrange
            string emailInvalido = "valor qualquer";

            //assert & act 
            Assert.Throws<ArgumentException>(() => new Email(emailInvalido));
        }
    }
}