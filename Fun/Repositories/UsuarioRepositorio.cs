using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fun.Data;
using Fun.Models;
using Fun.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fun.Repositories
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        protected readonly FunContext _dbContext;

        public static object Usuario { get; internal set; }

        public UsuarioRepositorio(FunContext funContext)
        {
            _dbContext = funContext;
        }
        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }
        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UsuarioModel> Adicionar (UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
            return (usuario);
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            if(usuarioPorId == null)
            {
                usuarioPorId.Nome = usuario.Nome;
                usuarioPorId.Email = usuario.Email;
                _dbContext.Update(usuarioPorId);
                await _dbContext.SaveChangesAsync();
            }
            return (usuarioPorId);
        }


        public async Task<bool> Deletar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            if(usuarioPorId == null)
            {
               throw new ArgumentException($"O Id: {id} não Foi encontrado na base de dados");
            }
            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
