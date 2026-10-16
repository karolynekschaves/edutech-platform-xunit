namespace EduTechPlatform.App;

public class FrequenciaService
{
    public double CalcularPorcentagemPresenca(int aulasTotais, int faltas)
    {
        if (aulasTotais <= 0)
            throw new ArgumentException("aulasTotais deve ser maior que zero.", nameof(aulasTotais));

        return ((aulasTotais - faltas) / (double)aulasTotais) * 100;
    }

    public bool AprovadoPorFrequencia(int aulasTotais, int faltas)
    {
        return CalcularPorcentagemPresenca(aulasTotais, faltas) >= 75.0;
    }
}