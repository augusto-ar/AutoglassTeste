using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoglassTeste.Data.Interface
{
    public interface IRepository<T> where T : class
    {
        T Ler(int id);
        IEnumerable<T> Listar();
        void Salvar(T entity);
        void Excluir(int id);
    }
}
