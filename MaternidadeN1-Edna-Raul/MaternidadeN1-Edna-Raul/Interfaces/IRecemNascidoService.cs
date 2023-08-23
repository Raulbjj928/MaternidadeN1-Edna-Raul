using MaternidadeN1_Edna_Raul.DTOs;
using MaternidadeN1_Edna_Raul.Models;

namespace MaternidadeN1_Edna_Raul.Interfaces
{
    public interface IRecemNascidoService
    {
        Task<List<RecemNascidoModel>> GetAllRecemNascidos();//ok
        Task<List<RecemNascidoModel>> GetRecemNascidoPorTipoParto(string tipoDeParto); //tipo de parto selecionando a mãe
        Task<RecemNascidoModel> PostRecemNascido(RecemNascidoDTO recemNascidoRequest); //ok
        Task<RecemNascidoModel> UpdateRecemNascido(int id, RecemNascidoDTO recemNascidoRequest);//ok
        Task DeleteRecemNascido(int id);//ok
        Task<List<RecemNascidoModel>> GetRecemNascidoPorGenero(string Genero, int idMae);//ok
        Task<RecemNascidoModel> GetRecemNascidoByID(int id);//ok
        Task<List<RecemNascidoModel>> GetRecemNascidoPorPeso(int peso, int idMae);//selecionar bebe por peso selecionando a mãe

        Task<List<RecemNascidoModel>> GetRecemNascidoPorApgar(int apgar);//ok

    }
}
