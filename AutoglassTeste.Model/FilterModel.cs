using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoglassTeste.Model
{
  public  class FilterModel
    {
        public DateTime? DataFabricacao { get; set; }
        public DateTime? DataValidade { get; set; }
        public string DescricaoProduto { get; set; }
        public string DescricaoFornecedor { get; set; }
        public int? CodigoFornecedor { get; set; }
    }
}
