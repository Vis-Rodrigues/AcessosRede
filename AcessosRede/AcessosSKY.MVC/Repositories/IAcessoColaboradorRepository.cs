using SDW.WebServiceJogo.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDW.WebServiceJogo.MVC.Repositories
{
    public interface IAcessoColaboradorRepository
    {
        void Insert(AcessoColaborador acessando);

        AcessoColaborador FindViewById(int id);

        int FindIdByAcesso(int id);

        int FindIdByColaborador(int id);

        void Delete(int id);

        void Update(AcessoColaborador acessoColaborador);

        ICollection<AcessoColaborador> List();
    }
}
