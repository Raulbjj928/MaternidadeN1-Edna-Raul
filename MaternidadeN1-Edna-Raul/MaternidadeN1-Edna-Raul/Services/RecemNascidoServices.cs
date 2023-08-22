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

        public async Task<RecemNascidoModel> GetRecemNascidoByID(int id)
        {
            var recemNascido = await _context.Bebe.Include(b => b.Mae)
                .FirstOrDefaultAsync(b => b.Id == id);
            if (recemNascido == null) return recemNascido;
            return recemNascido;
        }

        public async Task<List<RecemNascidoModel>> GetRecemNascidoPorApgar(int apgar)
        {
            return await _context.Bebe.Include(b => b.Mae).ToListAsync();
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

        

        

        public Task<List<RecemNascidoModel>> GetRecemNascidoPorGenero(string Genero)//listar pela mae
        {
            throw new NotImplementedException();
        }

        public async Task<List<RecemNascidoModel>> GetRecemNascidoPorPeso(int peso)//listar pela mae
        {
            var recemNascidos = await _context.Bebe.Include(b => b.Mae)
                .Where(b => b.Peso > peso)
                .ToListAsync();

            return recemNascidos;
        }

        public Task<List<RecemNascidoModel>> GetRecemNascidoPorTipoParto(string tipoDeParto)//listar pela mae
        {
            throw new NotImplementedException();
        }

        public async Task<RecemNascidoModel> PostRecemNascido(RecemNascidoModel recemNascido)
        {
            _context.Bebe.Add(recemNascido);
            await _context.SaveChangesAsync();
            return recemNascido;
        }

        public async Task UpdateRecemNascido(int id, RecemNascidoDTO recemNascidoRequest)
        {
            var recemNascido = await _context.Bebe.FirstOrDefaultAsync(b => b.Id == id);
            _context.Entry(recemNascidoRequest).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
