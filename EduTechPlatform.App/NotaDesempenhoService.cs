<<<<<<< HEAD
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
=======
namespace EduTechPlatform.App
{
    public class NotaDesempenhoService
    {
        public double CalcularMediaPonderada(double nota1, double nota2, double nota3)
        {
            return (nota1 * 3.0 + nota2 * 3.0 + nota3 * 4.0) / 10.0;
        }

        public string VerificarSituacaoAcademica(double media)
        {
            if (media >= 7.0) return "APROVADO";
            if (media >= 5.0) return "RECUPERACAO";
            return "REPROVADO";
        }
>>>>>>> 1af2c1ec0496e281b1c644456fe596955628da00
    }
}