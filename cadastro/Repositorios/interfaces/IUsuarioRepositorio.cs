using cadastro.Models;

namespace cadastro.Repositorios.interfaces
{
    public interface IUsuarioRepositorio
    {
        //contratos de usuarios

        Task<List<UsuarioModel>> BuscarTodosUsuarios();
        Task<UsuarioModel> BuscarPorId(int Id);
        Task<UsuarioModel> Adicionar(UsuarioModel usuario);
        Task<UsuarioModel> Atualizar(UsuarioModel usuario);
        Task<bool> Apagar(int id); 
    }
}
