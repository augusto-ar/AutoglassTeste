using AutoglassTeste.Domain.Enumerations;
using System;

namespace AutoglassTeste.Domain
{
    public class Produto
    {
        public int Codigo { get; set; }
        public string DescricaoProduto { get; set; }
        public SituacaoProduto SituacaoProduto { get; set; }
        public DateTime DataValidade { get; set; }
        public DateTime DataFabricacao { get; set; }
        public int CodigoFornecedor { get; set; }
        public string DescricaoFornecedor { get; set; }
        public string CNPJFornecedor { get; set; }
    }
}
