using Dapper;
using Livraria.Domain.Entidades;
using Livraria.Domain.Interfaces.Respositories;
using Livraria.Domain.Query;
using Livraria.Infra.Data.DataContexts;
using Livraria.Infra.Data.Respositories.Queries;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Livraria.Infra.Data.Respositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly DynamicParameters _parameters = new DynamicParameters();
        private readonly DataContext _dataContext;

        public LivroRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public long Inserir(Livro livro)
        {
            _parameters.Add("Nome", livro.Nome, DbType.String);
            _parameters.Add("Autor", livro.Autor, DbType.String);
            _parameters.Add("Edicao", livro.Edicao, DbType.Int32);
            _parameters.Add("Isbn", livro.Isbn, DbType.String);
            _parameters.Add("Imagem", livro.Imagem, DbType.String);

            return _dataContext.SqlServerConexao.ExecuteScalar<long>(LivroQueries.Inserir, _parameters);
        }

        public void Atualizar(Livro livro)
        {
            _parameters.Add("Id", livro.Id, DbType.Int64);
            _parameters.Add("Nome", livro.Nome, DbType.String);
            _parameters.Add("Autor", livro.Autor, DbType.String);
            _parameters.Add("Edicao", livro.Edicao, DbType.Int32);
            _parameters.Add("Isbn", livro.Isbn, DbType.String);
            _parameters.Add("Imagem", livro.Imagem, DbType.String);

            _dataContext.SqlServerConexao.Execute(LivroQueries.Atualizar, _parameters);
        }

        public void Excluir(long id)
        {
            _parameters.Add("Id", id, DbType.Int64);

            _dataContext.SqlServerConexao.Execute(LivroQueries.Excluir, _parameters);
        }

        public List<LivroQueryResult> Listar()
        {
            var livros = _dataContext.SqlServerConexao.Query<LivroQueryResult>(LivroQueries.Listar).ToList();
            return livros;
        }

        public LivroQueryResult Obter(long id)
        {
            _parameters.Add("Id", id, DbType.Int64);

            var livro = _dataContext.SqlServerConexao.Query<LivroQueryResult>(LivroQueries.Obter, _parameters).FirstOrDefault();
            return livro;
        }

        public bool CheckId(long id)
        {
            _parameters.Add("Id", id, DbType.Int64);

            return _dataContext.SqlServerConexao.Query<bool>(LivroQueries.CheckId, _parameters).FirstOrDefault();
        }
    }
}