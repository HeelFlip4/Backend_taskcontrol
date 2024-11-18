using cadastro.Data;
using cadastro.Data.Map;
using cadastro.Models;
using cadastro.Repositorios.interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace cadastro.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly CadastroDBcontex _dbContext;
        public UsuarioRepositorio(CadastroDBcontex cadastroDBcontex) 
        { 
            _dbContext = cadastroDBcontex;
        }


        public async Task<UsuarioModel> BuscarPorId(int Id)
        {
            return  await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == Id);
        }


        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }


        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }


        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int Id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(Id);

            if (usuarioPorId == null)
            {
                throw new Exception($"O usuario do Id:{Id} nao foi encontrado no banco de dados");
            }

            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;

            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return usuarioPorId;

        }


        public async Task<bool> Apagar(int Id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(Id);

            if (usuarioPorId == null)
            {
                throw new Exception($"O usuario do Id:{Id} nao foi encontrado no banco de dados");
            }

            _dbContext.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public Task<UsuarioModel> Atualizar(UsuarioModel usuario)
        {
            throw new NotImplementedException();
        }
    }
}
