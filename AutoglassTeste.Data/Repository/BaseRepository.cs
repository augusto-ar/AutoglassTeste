using AutoglassTeste.Data.Config;
using AutoglassTeste.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoglassTeste.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly ConfigDBContext _context;
        public BaseRepository(ConfigDBContext context)
        {
            _context = context;
        }

        public void Excluir(int id)
        {
            var entidade = Ler(id);
            _context.Set<T>().Remove(entidade);
        }

        public T Ler(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> Listar()
        {
           return _context.Set<T>();
        }

        public void Salvar(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public void Atualizar(T entity)
        {
            _context.Set<T>().Add(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
