
using EduTechPlatform.App; // Namespace do projeto principal

namespace EduTechPlatform.Tests
{
    public class NotaDesempenhoServiceTests
    {
        private readonly NotaDesempenhoService _service;

        public NotaDesempenhoServiceTests()
        {
            _service = new NotaDesempenhoService();
        }

        [Theory]
        [InlineData(7.0, 7.0, 7.0, 7.0)]
        [InlineData(10.0, 10.0, 5.0, 8.0)]
        public void CalcularMediaPonderada_DeveRetornarMediaCorreta(double nota1, double nota2, double nota3, double esperado)
        {
            double resultado = _service.CalcularMediaPonderada(nota1, nota2, nota3);
            Assert.Equal(esperado, resultado, 2);
        }

        [Theory]
        [InlineData(8.5, "APROVADO")]
        [InlineData(6.0, "RECUPERACAO")]
        [InlineData(4.2, "REPROVADO")]
        public void VerificarSituacaoAcademica_DeveRetornarSituacaoCorreta(double media, string situacaoEsperada)
        {
            string resultado = _service.VerificarSituacaoAcademica(media);
            Assert.Equal(situacaoEsperada, resultado);
        }
    }
}