using Azure.Core;
using MaternidadeN1_Edna_Raul.Data;
using MaternidadeN1_Edna_Raul.DTOs;
using MaternidadeN1_Edna_Raul.Interfaces;
using MaternidadeN1_Edna_Raul.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace MaternidadeN1_Edna_Raul.Services
{
    public class RecemNascidoServices : IRecemNascidoService
    {
        private readonly DataContext _context;

        public RecemNascidoServices(DataContext context) { _context = context; }

        public async Task<List<RecemNascidoModel>> GetAllRecemNascidos()
        {
            return await _context.Bebe.ToListAsync();
        }
        public async Task<RecemNascidoModel> PostRecemNascido(RecemNascidoDTO recemNascidoRequest)
        {

            var mae = await _context.Mae.FirstOrDefaultAsync(m => m.Id == recemNascidoRequest.MaeId);
            if(mae is not null)

            {
                var bebe = new RecemNascidoModel()
                {
                    Nome = recemNascidoRequest.Nome,
                    Genero = recemNascidoRequest.Genero,
                    DataNascimento = recemNascidoRequest.DataNascimento,
                    Peso = recemNascidoRequest.Peso,
                    Altura = recemNascidoRequest.Altura,
                    TipoDeParto = recemNascidoRequest.TipoDeParto,
                    Apgar = recemNascidoRequest.Apgar,
                    CondicaoMedica = recemNascidoRequest.CondicaoMedica,
                    MaeId = recemNascidoRequest.MaeId,
                    Mae = mae

                };

                _context.Bebe.Add(bebe);
                await _context.SaveChangesAsync();
                return bebe;

            }

            return new RecemNascidoModel();

            
        }
        public async Task<RecemNascidoModel> GetRecemNascidoByID(int id)
        { 
            return await _context.Bebe.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<RecemNascidoModel>> GetRecemNascidoPorApgar(int apgar)
        {
            return await _context.Bebe.Include(b => b.Apgar).ToListAsync();
        }

        public async Task DeleteRecemNascido(int id)
        {
            var recemNascido = await _context.Bebe.FindAsync(id);
            if (recemNascido != null)
            {
                _context.Bebe.Remove(recemNascido);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<RecemNascidoModel> UpdateRecemNascido(int id, RecemNascidoDTO recemNascidoRequest)
        {
            var bebe = await GetRecemNascidoByID(id);
            if (bebe != null)
            {
                bebe.Nome = recemNascidoRequest.Nome; 
                bebe.Genero = recemNascidoRequest.Genero;
                bebe.DataNascimento = recemNascidoRequest.DataNascimento;
                bebe.TipoDeParto = recemNascidoRequest.TipoDeParto;
                bebe.Apgar = recemNascidoRequest.Apgar;
                bebe.Altura = recemNascidoRequest.Altura;
                bebe.Peso = recemNascidoRequest.Peso;
                bebe.CondicaoMedica = recemNascidoRequest.CondicaoMedica;

                _context.Bebe.Update(bebe);
                await _context.SaveChangesAsync();
                return bebe;
            }

            return new RecemNascidoModel();
            
        }

        public async Task<List<RecemNascidoModel>> GetRecemNascidoPorGenero(string genero, int idMae)//listar pela mae
        {
            return await _context.Bebe.Include(b => b.Mae)
                .Where(b => b.Mae.Id == idMae && b.Genero == genero)
                .ToListAsync();
        }

        public async Task<List<RecemNascidoModel>> GetRecemNascidoPorPeso(int peso, int idMae)//listar pela mae
        {
            return await _context.Bebe.Include(b => b.Mae)
                .Where(b => b.Mae.Id == idMae && b.Peso > peso)
                .ToListAsync();
        }

        public Task<List<RecemNascidoModel>> GetRecemNascidoPorTipoParto(string tipoDeParto)//listar pela mae
        {
            throw new NotImplementedException();
        }

        

        
    }
}
