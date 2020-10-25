using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiPlaceMyBet.Models;

namespace WebApiPlaceMyBet.Controllers
{
    public class UsuariosController : ApiController
    {
        //GET: api/Usuarios
        public IEnumerable<Usuario> Get()
        {
            var repoUsuario = new UsuarioRepository();
            List<Usuario> usuarios = repoUsuario.Retrieve();
            //List<UsuarioDTO> usuarios = repoUsuario.RetrieveDTO();
 
        // GET: api/Usuarios
        public IEnumerable<UsuarioDTO> Get()
        {
            var repo = new UsuarioRepository();
            //List<Usuario> usuarios = repo.Retrieve();
            List<UsuarioDTO> usuarios = repo.RetrieveDTO();
            return usuarios;
        }

        // GET: api/Usuarios/5
       public Usuario Get(int id)
        {
            /*var repoUsuario = new UsuarioRepository();
            Usuario u = repoUsuario.Retrieve();
            return u;*/
            return null;
            
        }

        // POST: api/Usuarios
        public void Post([FromBody]Usuario usuario)
        {
            var repoUsuario = new UsuarioRepository();
            repoUsuario.Save(usuario);
        }

        // PUT: api/Usuarios/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Usuarios/5
        public void Delete(int id)
        {
        }
    }
}
