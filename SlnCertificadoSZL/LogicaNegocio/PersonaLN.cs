using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using AccesoDatos;
using LogicaNegocio;
using Infraestructura.Log;
using System.Transactions;

namespace Negocio
{
    public class PersonaLN : BaseLN
    {
        #region IPersona Members

        public Persona InsertarPersona(Persona persona)
        {
            try
            {
                return new PersonaAD().InsertarPersona(persona);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public Persona ActualizarPersona(Persona persona)
        {
            try
            {
                return new PersonaAD().ActualizarPersona(persona);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public List<Persona> ListarPersona()
        {
            try
            {
                return new PersonaAD().ListarPersona();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public int AnularPersonaPorCodigo(int IdPersona)
        {
            try
            {
                return new PersonaAD().BorrarPersona(IdPersona);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public Persona RecuperarPersonaPorCodigo(int IdPersona)
        {
            try
            {
                return new PersonaAD().RecuperarPersonaPorCodigo(IdPersona);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public void GrabarInstructorCompleto(Persona persona)
        {
            using (var tx = new TransactionScope())
            {
                if (persona.IdPersona == 0)
                {
                    new PersonaLN().InsertarPersona(persona);
                    persona.Instructor.NombreInstructor = persona.getRetornarNombreCompleto;
                    persona.Instructor.IdPersona = persona.IdPersona;

                    new TblinstructorLN().InsertarTblinstructor(persona.Instructor);
                }
                else
                {
                    new PersonaLN().ActualizarPersona(persona);
                    new TblinstructorLN().ActualizarTblinstructor(persona.Instructor);
                }
                tx.Complete();
            }
        }

        #endregion
    }
}
