using MaternidadeN1_Edna_Raul.Data;
using MaternidadeN1_Edna_Raul.DTOs;
using MaternidadeN1_Edna_Raul.Interfaces;
using MaternidadeN1_Edna_Raul.Models;
using Microsoft.EntityFrameworkCore;

namespace MaternidadeN1_Edna_Raul.Services
{
    public class MaeServices : IMaeService
    {
        private readonly DataContext _dataContext;

        public MaeServices(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<MaeModel> PostMae(MaeDTO maeRequest)
        {
            bool validar = await ValidarPost(maeRequest);

            if (!validar) { return new MaeModel(); }

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

            _dataContext.Mae.Add(mae);
            await _dataContext.SaveChangesAsync();

            return mae;
        }

        public async Task<List<MaeModel>> GetAllMaes()
        {
            return await _dataContext.Mae.ToListAsync();
        }

        public async Task<MaeModel> GetMaeByCPF(string cpf)
        {
            return await _dataContext.Mae.FirstOrDefaultAsync(m => m.CPF == cpf);
        }

        public async Task<MaeModel> GetMaeByID(int id)
        {
            return await _dataContext.Mae.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<MaeModel>> GetMaesEstadoCivil(string estadoCivil)
        {
            return await _dataContext.Mae.Where(m => m.EstadoCivil == estadoCivil).ToListAsync();
        }

        public async Task<List<RecemNascidoModel>> GetRNsPorMae(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<MaeModel> UpdateMae(int id, MaeDTO maeRequest)
        {
            var maeDB = await GetMaeByID(id);

            if (maeDB is not null)
            {
                maeDB.Nome = maeRequest.Nome;
                maeDB.Sobrenome = maeRequest.Sobrenome;
                maeDB.DataNascimento = maeRequest.DataNascimento;
                maeDB.RegistroGeral = maeRequest.RegistroGeral;
                maeDB.CPF = maeRequest.CPF;
                maeDB.Telefone = maeRequest.Telefone;
                maeDB.EstadoCivil = maeRequest.EstadoCivil;
                maeDB.Profissao = maeRequest.Profissao;
                maeDB.HistoricoMedico = maeRequest.HistoricoMedico;

                _dataContext.Update(maeDB);
                await _dataContext.SaveChangesAsync();

                return maeDB;
            }

            return new MaeModel();
        }

        private async Task<bool> ValidarPost(MaeDTO maeRequest)
        {
            var maeDB = await GetMaeByCPF(maeRequest.CPF);

            bool invalido = false;

            if (maeDB is not null)
            {
                invalido = true;
            }

            return invalido ? false : true;
        }
    }
}
