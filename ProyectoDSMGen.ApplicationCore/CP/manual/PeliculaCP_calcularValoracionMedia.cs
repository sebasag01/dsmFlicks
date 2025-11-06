
using System;
using System.Text;

using System.Collections.Generic;
using ProyectoDSMGen.ApplicationCore.Exceptions;
using ProyectoDSMGen.ApplicationCore.EN.Flicks;
using ProyectoDSMGen.ApplicationCore.IRepository.Flicks;
using ProyectoDSMGen.ApplicationCore.CEN.Flicks;



/*PROTECTED REGION ID(usingProyectoDSMGen.ApplicationCore.CP.Flicks_Pelicula_calcularValoracionMedia) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProyectoDSMGen.ApplicationCore.CP.Flicks
{
public partial class PeliculaCP : GenericBasicCP
{
public void CalcularValoracionMedia (int p_oid)
{
        /*PROTECTED REGION ID(ProyectoDSMGen.ApplicationCore.CP.Flicks_Pelicula_calcularValoracionMedia) ENABLED START*/

        PeliculaCEN peliculaCEN = null;



        try
        {
                CPSession.SessionInitializeTransaction ();
                peliculaCEN = new PeliculaCEN (CPSession.UnitRepo.PeliculaRepository);
                ResenyaCEN resenyaCEN = new ResenyaCEN (CPSession.UnitRepo.ResenyaRepository);

                PeliculaEN peliculaEN = peliculaCEN.ReadID (p_oid);

                // Validaci n
                if (peliculaEN == null)
                        throw new ModelException ("Pel cula no encontrada: " + p_oid);

                // float y contador
                float suma = 0f;
                int contador = 0;

                // Si no hay rese as, la colecci n puede ser null o vac a
                if (peliculaEN.Resenya != null) {
                        foreach (ResenyaEN resenya in peliculaEN.Resenya) {
                                if (resenya == null) continue;
                                int puntu = resenya.Puntuacion;
                                if (puntu < 0 || puntu > 5) continue;

                                suma += puntu;
                                contador++;
                        }
                }

                float media = 0f;
                if (contador > 0) media = suma / contador;

                // Actualizar el campo ValoracionMedia
                var peliculaRepo = CPSession.UnitRepo ?.PeliculaRepository;
                if (peliculaRepo == null)
                        throw new ModelException ("Dependencia IPeliculaRepository no iniciada en UnitRepo.");

                PeliculaEN pelicula = peliculaRepo.ReadOIDDefault (p_oid);
                if (pelicula == null) throw new ModelException ("Pelicula no encontrada: " + p_oid);
                pelicula.ValoracionMedia = media;
                peliculaRepo.Modify (pelicula);



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
