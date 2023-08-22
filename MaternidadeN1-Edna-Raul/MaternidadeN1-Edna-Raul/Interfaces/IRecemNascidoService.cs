using MaternidadeN1_Edna_Raul.DTOs;
using MaternidadeN1_Edna_Raul.Models;

namespace MaternidadeN1_Edna_Raul.Interfaces
{
    public interface IRecemNascidoService
    {
        Task<List<RecemNascidoModel>> GetRecemNascidoPorTipoParto(string tipoDeParto); //tipo de parto selecionando a mãe
        Task<RecemNascidoModel> PostRecemNascido(RecemNascidoModel recemNascido);
        Task UpdateRecemNascido(int id, RecemNascidoDTO recemNascidoRequest);
        Task DeleteRecemNascido(int id);
        Task<List<RecemNascidoModel>> GetRecemNascidoPorGenero(string Genero);//selecionar bebe por genero selecionando a mãe
        Task<RecemNascidoModel> GetRecemNascidoByID(int id);
        Task<List<RecemNascidoModel>> GetRecemNascidoPorPeso(int peso);//selecionar bebe por peso selecionando a mãe

        Task<List<RecemNascidoModel>> GetRecemNascidoPorApgar(int apgar);

    }
}
