using AutoglassTeste.Data.Config;
using AutoglassTeste.Data.Interface;
using AutoglassTeste.Data.Repository;
using AutoglassTeste.Domain;
using AutoglassTeste.Domain.Enumerations;
using AutoglassTeste.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoglassTeste.Data.BLL
{
    public class ProdutoBLL : BaseBLL<Produto>
    {
        protected readonly ProdutoRepository produtoRepository;

        public ProdutoBLL(ConfigDBContext context, IMapper mapper) : base(mapper)
        {
            produtoRepository = new ProdutoRepository(context);
        }

        public ProdutoModel Ler(int codigo)
        {
            var domain = produtoRepository.Ler(codigo);
            return ConvertObj<ProdutoModel>(domain);
        }
        public void Salvar(ProdutoModel model)
        {
            if (ValidarModel(model))
            {
                var domain = ConvertObj<Produto>(model);
                produtoRepository.Salvar(domain);
                produtoRepository.Commit();
            }
        }
        public void Atualizar(ProdutoModel model)
        {
            if (ValidarModel(model))
            {
                try
                {
                    var domain = ConvertObj<Produto>(model);
                    produtoRepository.Atualizar(domain);
                    produtoRepository.Commit();
                }
                catch
                {
                    Notificacao.Adicionar("Erro! não foi possivel fazer a alteração, verifique se os campos estão preenchidos corretamente, e so o produto esta cadastrado no sistema.");
                }
            }
        }

        public List<ProdutoModel> Listar(FilterModel filterModel, int take, int skip)
        {
            var query = (from p in produtoRepository.Listar()
                         select p);

            if (filterModel.DataValidade.HasValue)
                query = query.Where(p => p.DataValidade.Date == filterModel.DataValidade.Value.Date);
            if (filterModel.DataFabricacao.HasValue)
                query = query.Where(p => p.DataValidade.Date == filterModel.DataFabricacao.Value.Date);
            if (filterModel.CodigoFornecedor.HasValue)
                query = query.Where(p => p.CodigoFornecedor == filterModel.CodigoFornecedor.Value);
            if (!string.IsNullOrEmpty(filterModel.DescricaoFornecedor))
                query = query.Where(p => p.DescricaoFornecedor.Contains(filterModel.DescricaoFornecedor));
            if (!string.IsNullOrEmpty(filterModel.DescricaoProduto))
                query = query.Where(p => p.DescricaoProduto.Contains(filterModel.DescricaoProduto));


            return query.Select(p => ConvertObj<ProdutoModel>(p))
                .Take(take)
                .Skip(skip)
                .ToList();
        }

        public void Excluir(int codigo)
        {
            var domain = produtoRepository.Ler(codigo);
            domain.SituacaoProduto = SituacaoProduto.Inativo;
            produtoRepository.Salvar(domain);
            produtoRepository.Commit();
        }

        private bool ValidarModel(ProdutoModel model)
        {
            if (model.DataFabricacao.Date >= model.DataValidade.Date)
            {
                Notificacao.Adicionar("Data de fabricação tem quer ser inferio a data de validade");
            }

            return !Notificacao.HasErro;
        }
    }
}
