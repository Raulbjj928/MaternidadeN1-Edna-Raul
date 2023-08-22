using MaternidadeN1_Edna_Raul.Data;
using MaternidadeN1_Edna_Raul.DTOs;
using MaternidadeN1_Edna_Raul.Interfaces;
using MaternidadeN1_Edna_Raul.Models;

namespace MaternidadeN1_Edna_Raul.Services
{
    public class RecemNascidoServices : IRecemNascidoService
    {
        private readonly DataContext _context;

        public RecemNascidoServices(DataContext context) { _context = context; }

        public Task<RecemNascidoModel> DeleteRecemNascido(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RecemNascidoModel> GetRecemNascidoByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<RecemNascidoModel>> GetRecemNascidoPorApgar(int apgar)
        {
            throw new NotImplementedException();
        }

        public Task<List<RecemNascidoModel>> GetRecemNascidoPorGenero(string Genero)
        {
            throw new NotImplementedException();
        }

        public Task<List<RecemNascidoModel>> GetRecemNascidoPorPeso(int peso)
        {
            throw new NotImplementedException();
        }

        public Task<List<RecemNascidoModel>> GetRecemNascidoPorTipoParto(string tipoDeParto)
        {
            throw new NotImplementedException();
        }

        public Task<RecemNascidoModel> PostRecemNascido(RecemNascidoDTO recemNascidoRequest)
        {
            throw new NotImplementedException();
        }

        public Task<RecemNascidoModel> UpdateRecemNascido(int id, RecemNascidoDTO recemNascidoRequest)
        {
            throw new NotImplementedException();
        }
    }
}
