namespace Service.Interfaces
{
    public interface ICalcularJurosService
    {
        decimal CalcularJuros(int prazo, decimal Vlr_Solicitado);
    }
}