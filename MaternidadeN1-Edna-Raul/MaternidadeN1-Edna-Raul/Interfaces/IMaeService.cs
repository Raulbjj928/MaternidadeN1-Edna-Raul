using MaternidadeN1_Edna_Raul.DTOs;
using MaternidadeN1_Edna_Raul.Models;

namespace MaternidadeN1_Edna_Raul.Interfaces
{
    public interface IMaeService
    {
        Task<MaeModel> GetMaeByID(int id);
        Task<MaeModel> GetMaeByCPF(string cpf);
        Task<List<MaeModel>> GetMaesEstadoCivil(string estadoCivil);
        Task<List<MaeModel>> GetAllMaes();
        Task<List<RecemNascidoModel>> GetRNsPorMae(int id);
        Task<MaeModel> PostMae(MaeDTO maeRequest);
        Task<MaeModel> UpdateMae(int id, MaeDTO maeRequest);
        Task<MaeModel> PatchMaeHistoricoMedico(int id, string historicoRequest);
        Task DeleteMae(int id);
    }
}
