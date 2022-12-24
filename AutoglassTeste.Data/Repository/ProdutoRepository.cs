using AutoglassTeste.Data.Config;
using AutoglassTeste.Data.Interface;
using AutoglassTeste.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoglassTeste.Data.Repository
{
    public class ProdutoRepository : BaseRepository<Produto>
    {
        public ProdutoRepository(ConfigDBContext context):base(context)
        {
        }
    }
}
