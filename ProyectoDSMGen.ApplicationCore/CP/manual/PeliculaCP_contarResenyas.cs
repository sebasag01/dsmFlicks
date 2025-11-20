
using System;
using System.Text;

using System.Collections.Generic;
using ProyectoDSMGen.ApplicationCore.Exceptions;
using ProyectoDSMGen.ApplicationCore.EN.Flicks;
using ProyectoDSMGen.ApplicationCore.IRepository.Flicks;
using ProyectoDSMGen.ApplicationCore.CEN.Flicks;



/*PROTECTED REGION ID(usingProyectoDSMGen.ApplicationCore.CP.Flicks_Pelicula_contarResenyas) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProyectoDSMGen.ApplicationCore.CP.Flicks
{
public partial class PeliculaCP : GenericBasicCP
{
public void ContarResenyas (int p_oid)
{
        /*PROTECTED REGION ID(ProyectoDSMGen.ApplicationCore.CP.Flicks_Pelicula_contarResenyas) ENABLED START*/

        PeliculaCEN peliculaCEN = null;



        try
        {
                CPSession.SessionInitializeTransaction ();
                peliculaCEN = new PeliculaCEN (CPSession.UnitRepo.PeliculaRepository);



                // Write here your custom transaction ...

                PeliculaEN peliculaEN = peliculaCEN.ReadID (p_oid);
                if (peliculaEN == null) throw new ModelException ("Pelicula no encontrada: " + p_oid);

                int contador = 0;
                if (peliculaEN.Resenya != null) {
                        contador = peliculaEN.Resenya.Count;
                }



                CPSession.Commit ();
        }
        catch (Exception ex)
        {
                CPSession.RollBack ();
                throw ex;
        }
        finally
        {
                CPSession.SessionClose ();
        }


        /*PROTECTED REGION END*/
}
}
}
