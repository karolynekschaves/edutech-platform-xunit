namespace EduTechPlatform.App;

public class MatriculaFinanceiraService
{
    public decimal CalcularValorMensalidade(decimal valorBase, int diaPagamento, bool eBolsista)
    {
        if (eBolsista) return valorBase * 0.50m;
        if (diaPagamento <= 5) return valorBase * 0.90m;
        return valorBase;
    }

    public bool PodeRealizarRematricula(bool possuiPendenciaFinanceira, string situacaoAcademica)
    {
        return !possuiPendenciaFinanceira && situacaoAcademica != "REPROVADO";
    }
}