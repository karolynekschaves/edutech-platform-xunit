using Xunit;
using EduTechPlatform.App;

namespace EduTechPlatform.Tests
{
    public class MatriculaFinanceiraServiceTests
    {
        private readonly MatriculaFinanceiraService _service;

        public MatriculaFinanceiraServiceTests()
        {
            _service = new MatriculaFinanceiraService();
        }

        [Theory]
        [InlineData(1000, 10, true, 500)]
        [InlineData(1000, 4, false, 900)]
        [InlineData(1000, 10, false, 1000)]
        public void CalcularValorMensalidade_DeveRetornarValorComDescontoCorreto(decimal valorBase, int diaPagamento, bool eBolsista, decimal valorEsperado)
        {
            // Act
            decimal resultado = _service.CalcularValorMensalidade(valorBase, diaPagamento, eBolsista);

            // Assert
            Assert.Equal(valorEsperado, resultado);
        }

        [Theory]
        [InlineData(false, "APROVADO", true)]
        [InlineData(true, "APROVADO", false)]
        [InlineData(false, "REPROVADO", false)]
        public void PodeRealizarRematricula_DeveRetornarStatusCorreto(bool possuiPendenciaFinanceira, string situacaoAcademica, bool elegivelEsperado)
        {
            // Act
            bool resultado = _service.PodeRealizarRematricula(possuiPendenciaFinanceira, situacaoAcademica);

            // Assert
            Assert.Equal(elegivelEsperado, resultado);
        }
    }
}