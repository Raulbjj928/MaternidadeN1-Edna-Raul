using MaternidadeN1_Edna_Raul.DTOs;
using MaternidadeN1_Edna_Raul.Models;

namespace MaternidadeN1_Edna_Raul.Interfaces
{
    public interface IMaeService
    {
        Task<MaeModel> GetMaeByID(int id);
        Task<MaeModel> GetMaeByCPF(int id);
        Task<List<RecemNascidoModel>> GetMaesEstadoCivil(string estadoCivil);
        Task<List<RecemNascidoModel>> GetAllMaes();
        Task<List<RecemNascidoModel>> GetRNsPorMae(int id);
        Task<MaeModel> PostMae(MaeDTO maeRequest);
        Task<MaeModel> UpdateMae(int id, MaeDTO maeRequest);

        //todo fazer PATCH
    }
}
