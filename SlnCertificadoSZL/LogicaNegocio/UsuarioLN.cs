using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using AccesoDatos;
using LogicaNegocio;
using Infraestructura.Log;

namespace Negocio
{
    public class UsuarioLN : BaseLN
    {
        #region IUsuario Members

        public Usuario InsertarUsuario(Usuario usuario)
        {
            try
            {
                var persona = RecuperarPersona(usuario);
                if (persona.IdPersona == 0)
                {
                    new PersonaAD().InsertarPersona(persona);

                    usuario.IdPersona = persona.IdPersona;
                    new UsuarioAD().InsertarUsuario(usuario);
                }
                else
                {
                    new PersonaAD().ActualizarPersona(persona);
                }

                return usuario;

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        private Persona RecuperarPersona(Usuario usuario)
        {
            var persona = new PersonaLN().RecuperarPersonaPorCodigo(usuario.IdPersona);
            if (persona == null)
            {
                persona = new Persona
                {
                    IdPersona = usuario.IdPersona,
                    ApellidoPaterno = usuario.apellidoPaterno,
                    ApellidoMaterno = usuario.apellidoMaterno,
                    Nombres = usuario.nombre,
                    TipoDocIdentidad = 1,
                    NroDocidentidad = usuario.nroDocumento,
                    FechaNacimiento = DateTime.Now.AddYears(-18),
                    TipoEstadoCivil = 1,
                    Sexo = string.Empty,
                    Telefono1 = string.Empty,
                    Telefono2 = string.Empty
                };
                persona.NombreCompleto = persona.getRetornarNombreCompleto;
            }
            return persona;
        }

        public Usuario ActualizarUsuario(Usuario usuario)
        {
            try
            {
                var persona = RecuperarPersona(usuario);
                if (persona.IdPersona > 0)
                {
                    persona.ApellidoPaterno = usuario.apellidoPaterno;
                    persona.ApellidoMaterno = usuario.apellidoMaterno;
                    persona.Nombres = usuario.nombre;

                    new PersonaAD().ActualizarPersona(persona);
                    return new UsuarioAD().ActualizarUsuario(usuario);
                }

                return usuario;

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public List<Usuario> ListarUsuario()
        {
            try
            {
                return new UsuarioAD().ListarUsuario();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public Usuario AutenticarUsuario(string codigoUsuario, byte[] clave)
        {
            try
            {
                return new UsuarioAD().AutenticarUsuario(codigoUsuario, clave);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public int AnularUsuarioPorCodigo(int IdPersona)
        {
            try
            {
                return new UsuarioAD().BorrarUsuario(IdPersona);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public Usuario RecuperarUsuarioPorCodigo(int IdPersona)
        {
            try
            {
                return new UsuarioAD().RecuperarUsuarioPorCodigo(IdPersona);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }




        #endregion

    }
}
