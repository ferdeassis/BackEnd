using Entities;

namespace ORM.Interfaces
{
    public interface IParametroRepository
    {
        Parametro GetParametro();
        void Update(Parametro obj);
    }
}