using MaternidadeN1_Edna_Raul.Data;
using MaternidadeN1_Edna_Raul.DTOs;
using MaternidadeN1_Edna_Raul.Interfaces;
using MaternidadeN1_Edna_Raul.Models;

namespace MaternidadeN1_Edna_Raul.Services
{
    public class MaeServices : IMaeService
    {
        private readonly DataContext _dataContext;

        public MaeServices(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task<MaeModel> PostMae(MaeDTO maeRequest)
        {
            //bool validar = await ValidarPost(maeRequest);

            //if (!validar) { return new MaeModel(); }

            var mae = new MaeModel()
            {
                Nome = maeRequest.Nome,
                Sobrenome = maeRequest.Sobrenome,
                DataNascimento = maeRequest.DataNascimento,
                RegistroGeral = maeRequest.RegistroGeral,
                CPF = maeRequest.CPF,
                Endereco = maeRequest.Endereco,
                Telefone = maeRequest.Telefone,
                EstadoCivil = maeRequest.EstadoCivil,
                Profissao = maeRequest.Profissao,
                Etnia = maeRequest.Etnia,
                HistoricoMedico = maeRequest.HistoricoMedico
            };

            //_dataContext.Musicas.Add(musica);
            //await _dataContext.SaveChangesAsync();

            throw new NotImplementedException();
        }

        private Task<bool> ValidarPost(object musicaRequest)
        {
            throw new NotImplementedException();
        }

        public Task<List<RecemNascidoModel>> GetAllMaes()
        {
            throw new NotImplementedException();
        }

        public Task<MaeModel> GetMaeByCPF(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MaeModel> GetMaeByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<RecemNascidoModel>> GetMaesEstadoCivil(string estadoCivil)
        {
            throw new NotImplementedException();
        }

        public Task<List<RecemNascidoModel>> GetRNsPorMae(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MaeModel> UpdateMae(int id, MaeDTO maeRequest)
        {
            throw new NotImplementedException();
        }
    }
}
