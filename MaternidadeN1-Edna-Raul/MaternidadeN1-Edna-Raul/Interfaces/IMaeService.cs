using MaternidadeN1_Edna_Raul.Models;

namespace MaternidadeN1_Edna_Raul.Interfaces
{
    public interface IMaeService
    {
        Task<MaeModel> GetMaeByID(int id);
        Task<List<RecemNascidoModel>> GetRNsPorMae(int id);
        Task<List<RecemNascidoModel>> GetRNsPorMae(int id);
    }
}
