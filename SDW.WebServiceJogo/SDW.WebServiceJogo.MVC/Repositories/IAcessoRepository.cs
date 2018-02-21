using SDW.WebServiceJogoAPI.Contexts;
using SDW.WebServiceJogoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDW.WebServiceJogo.MVC.Repositories
{
    public interface IAcessoRepository
    {
        void Insert(Acesso acesso);
        ICollection<Acesso> list();
        Acesso FindById(int id);
        void Delete(int id);
        void Update(Acesso acesso);
    }
}
