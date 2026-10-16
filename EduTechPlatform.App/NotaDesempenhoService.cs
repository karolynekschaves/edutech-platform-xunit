namespace EduTechPlatform.App;

public class NotaDesempenhoService
{
    public decimal CalcularMediaPonderada(decimal nota1, decimal nota2, decimal notaProjeto)
    {
        return ((nota1 * 3) + (nota2 * 3) + (notaProjeto * 4)) / 10;
    }

    public string ObterSituacaoAcademica(decimal mediaFinal)
    {
        if (mediaFinal >= 7.0m) return "APROVADO";
        if (mediaFinal >= 5.0m) return "RECUPERACAO";
        return "REPROVADO";
    }
}