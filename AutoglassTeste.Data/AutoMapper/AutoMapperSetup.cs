using AutoglassTeste.Domain;
using AutoglassTeste.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoglassTeste.Data.AutoMapper
{
   public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            CreateMap<Produto, ProdutoModel>();
            CreateMap<ProdutoModel, Produto>();
        }
    }
}
