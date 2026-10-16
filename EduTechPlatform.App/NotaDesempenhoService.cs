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
    }
}