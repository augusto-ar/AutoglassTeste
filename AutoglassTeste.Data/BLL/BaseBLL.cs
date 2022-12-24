using AutoglassTeste.Data.Interface;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoglassTeste.Data.BLL
{
   public class BaseBLL<T>  where T : class
    {
        protected readonly IMapper _mapper;
        public readonly Notificacao Notificacao;
        public BaseBLL(IMapper mapper)
        {
            _mapper = mapper ;
            Notificacao = new Notificacao();
        }

        public T ConvertObj<T>(object obj) => _mapper.Map<T>(obj);
    }
}
