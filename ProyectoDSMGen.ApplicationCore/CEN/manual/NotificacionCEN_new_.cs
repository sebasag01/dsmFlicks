
using System;
using System.Text;
using System.Collections.Generic;
using ProyectoDSMGen.ApplicationCore.Exceptions;
using ProyectoDSMGen.ApplicationCore.EN.Flicks;
using ProyectoDSMGen.ApplicationCore.IRepository.Flicks;


/*PROTECTED REGION ID(usingProyectoDSMGen.ApplicationCore.CEN.Flicks_Notificacion_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProyectoDSMGen.ApplicationCore.CEN.Flicks
{
public partial class NotificacionCEN
{
public int New_ (int p_usuario, string p_mensaje, Nullable<DateTime> p_fecha, ProyectoDSMGen.ApplicationCore.Enumerated.Flicks.TipoNotificacionEnum p_tipoNotificacion, long p_IdOrigen)
{
        /*PROTECTED REGION ID(ProyectoDSMGen.ApplicationCore.CEN.Flicks_Notificacion_new__customized) START*/

        NotificacionEN notificacionEN = null;

        int oid;

        //Initialized NotificacionEN
        notificacionEN = new NotificacionEN ();

        if (p_usuario != -1) {
                notificacionEN.Usuario = new ProyectoDSMGen.ApplicationCore.EN.Flicks.UsuarioEN ();
                notificacionEN.Usuario.Id = p_usuario;
        }

        notificacionEN.Mensaje = p_mensaje;

        notificacionEN.Fecha = p_fecha;

        notificacionEN.TipoNotificacion = p_tipoNotificacion;

        notificacionEN.IdOrigen = p_IdOrigen;

        //Call to NotificacionRepository

        oid = _INotificacionRepository.New_ (notificacionEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
