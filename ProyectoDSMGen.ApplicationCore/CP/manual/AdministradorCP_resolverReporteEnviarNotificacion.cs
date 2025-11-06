
using System;
using System.Text;

using System.Collections.Generic;
using ProyectoDSMGen.ApplicationCore.Exceptions;
using ProyectoDSMGen.ApplicationCore.EN.Flicks;
using ProyectoDSMGen.ApplicationCore.IRepository.Flicks;
using ProyectoDSMGen.ApplicationCore.CEN.Flicks;
using ProyectoDSMGen.ApplicationCore.Enumerated.Flicks;



/*PROTECTED REGION ID(usingProyectoDSMGen.ApplicationCore.CP.Flicks_Administrador_resolverReporteEnviarNotificacion) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProyectoDSMGen.ApplicationCore.CP.Flicks
{
public partial class AdministradorCP : GenericBasicCP
{
public void ResolverReporteEnviarNotificacion (int p_oid)
{
        /*PROTECTED REGION ID(ProyectoDSMGen.ApplicationCore.CP.Flicks_Administrador_resolverReporteEnviarNotificacion) ENABLED START*/

        AdministradorCEN administradorCEN = null;
        ReporteCEN reporteCEN = null;
        NotificacionCEN notificacionCEN = null;


        try
        {
                CPSession.SessionInitializeTransaction ();
                administradorCEN = new  AdministradorCEN (CPSession.UnitRepo.AdministradorRepository);
                reporteCEN = new ReporteCEN(CPSession.UnitRepo.ReporteRepository);
                notificacionCEN = new NotificacionCEN(CPSession.UnitRepo.NotificacionRepository);

                UsuarioCEN usuarioEn = new UsuarioCEN(CPSession.UnitRepo.UsuarioRepository);

                AdministradorEN adminEN = administradorCEN.ReadID(p_oid);

                if (adminEN == null)
                    throw new Exception("Administrador no encontrado.");

                // Leer todos los reportes pendientes
                IList<ReporteEN> listaReportes = CPSession.UnitRepo.ReporteRepository.ReadFilterEstado(0, -1); //"pendiente"

                foreach (ReporteEN reporte in listaReportes)
                {
                    if (reporte == null) continue;

                    // cambiar estado del reporte a resuelto
                    reporte.Estado = EstadoReporteEnum.resuelto; //ProyectoDSMGen.ApplicationCore.Enumerated.Flicks;
                    reporteCEN.Modify(reporte.Id, reporte.Motivo, reporte.Estado, reporte.Fecha);

                    string mensaje = $"El reporte con motivo '{reporte.Motivo}' ha sido resuelto por el administrador {adminEN.Nombre}.";

                    NotificacionEN notificacion = new NotificacionEN()
                    {
                        Mensaje = mensaje,
                        Fecha = DateTime.Now,
                        TipoNotificacion = Enumerated.Flicks.TipoNotificacionEnum.reporte,
                        IdOrigen = reporte.Id//,
                        //EstadoNoti = Enumerated.Flicks.EstadoNotificacionEnum.leida
                    };

                    notificacionCEN.New_(
                        reporte.Usuario.Id, 
                        notificacion.Mensaje, //notificacion.Mensaje,
                        notificacion.Fecha, //notificacion.Fecha,
                        notificacion.TipoNotificacion, //notificacion.TipoNotificacion,
                        Convert.ToInt64(notificacion.IdOrigen) //notificacion.IdOrigen,
                        //notificacion.EstadoNoti
                    );
                }


                // Write here your custom transaction ...

                //throw new NotImplementedException ("Method ResolverReporteEnviarNotificacion() not yet implemented.");



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
