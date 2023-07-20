using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fun.Models;

namespace Fun.Repositories.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioModel>>BuscarTodosUsuarios();
        Task<UsuarioModel> Adicionar (UsuarioModel usuario);
        Task<UsuarioModel>Atualizar (UsuarioModel usuario,int id);
        Task <bool> Deletar(int id);
        Task<UsuarioModel> BuscarPorId(int id);
    }
}
