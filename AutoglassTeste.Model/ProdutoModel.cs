using AutoglassTeste.Model.Enumerations;
using System;

namespace AutoglassTeste.Model
{
    public class ProdutoModel
    {
        public int Codigo { get; set; }
        public string DescricaoProduto { get; set; }
        public SituacaoProdutoModel SituacaoProduto { get; set; }
        public DateTime DataValidade { get; set; }
        public DateTime DataFabricacao { get; set; }
        public int CodigoFornecedor { get; set; }
        public string DescricaoFornecedor { get; set; }
        public string CNPJFornecedor { get; set; }
    }
}
