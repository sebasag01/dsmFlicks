
using System;
using System.Text;
using System.Collections.Generic;
using ProyectoDSMGen.ApplicationCore.Exceptions;
using ProyectoDSMGen.ApplicationCore.EN.Flicks;
using ProyectoDSMGen.ApplicationCore.IRepository.Flicks;


/*PROTECTED REGION ID(usingProyectoDSMGen.ApplicationCore.CEN.Flicks_Usuario_modoBlancoYNegro) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProyectoDSMGen.ApplicationCore.CEN.Flicks
{
public partial class UsuarioCEN
{
public void ModoBlancoYNegro (int p_oid)
{
        /*PROTECTED REGION ID(ProyectoDSMGen.ApplicationCore.CEN.Flicks_Usuario_modoBlancoYNegro) ENABLED START*/

        // Write here your custom code...

        //throw new NotImplementedException ("Method ModoBlancoYNegro() not yet implemented.");
        
        UsuarioEN usuarioEN = _IUsuarioRepository.ReadID (p_oid);

        if (usuarioEN == null)
        {
            throw new ModelException("Usuario con id " + p_oid + "no encontrado.");
        }
            usuarioEN.ModoBlancoYNegro = !usuarioEN.ModoBlancoYNegro;
            //usuarioEN.ModoBlancoYNegro = false;

        _IUsuarioRepository.Modify (usuarioEN);


            /*PROTECTED REGION END*/
        }
    }
}
