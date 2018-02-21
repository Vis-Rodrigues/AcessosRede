using System.Collections.Generic;

namespace SDW.WebServiceJogoAPI.Models.Abstract
{
    public interface IColaboradorRepository
    {
        Colaborador FindById(int id);
        void Insert(Colaborador colaborador);
        ICollection<Colaborador> List();
        ICollection<Colaborador> Listar();
        void Delete(int id);
    }
}