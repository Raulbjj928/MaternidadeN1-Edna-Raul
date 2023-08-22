using MaternidadeN1_Edna_Raul.DTOs;
using MaternidadeN1_Edna_Raul.Interfaces;
using MaternidadeN1_Edna_Raul.Models;

namespace MaternidadeN1_Edna_Raul.Services
{
    public class MaeServices : IMaeService
    {
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

        public Task<MaeModel> PostMae(MaeDTO maeRequest)
        {
            throw new NotImplementedException();
        }

        public Task<MaeModel> UpdateMae(int id, MaeDTO maeRequest)
        {
            throw new NotImplementedException();
        }
    }
}
