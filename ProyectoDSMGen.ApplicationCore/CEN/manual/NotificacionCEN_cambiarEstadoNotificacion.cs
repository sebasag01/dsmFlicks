
using System;
using System.Text;
using System.Collections.Generic;
using ProyectoDSMGen.ApplicationCore.Exceptions;
using ProyectoDSMGen.ApplicationCore.EN.Flicks;
using ProyectoDSMGen.ApplicationCore.IRepository.Flicks;


/*PROTECTED REGION ID(usingProyectoDSMGen.ApplicationCore.CEN.Flicks_Notificacion_cambiarEstadoNotificacion) ENABLED START*/
// references to other libraries
/*PROTECTED REGION END*/

namespace ProyectoDSMGen.ApplicationCore.CEN.Flicks
{
public partial class NotificacionCEN
{
public void CambiarEstadoNotificacion (int p_oid)
{
        /*PROTECTED REGION ID(ProyectoDSMGen.ApplicationCore.CEN.Flicks_Notificacion_cambiarEstadoNotificacion) ENABLED START*/

        //leer la notificacion existente
        NotificacionEN notificacionEN = _INotificacionRepository.ReadID (p_oid);

        if (notificacionEN == null) {
                throw new ModelException ("Notification with id " + p_oid + " not found.");
        }

        // cambiar a leida
        notificacionEN.EstadoNoti = ProyectoDSMGen.ApplicationCore.Enumerated.Flicks.EstadoNotificacionEnum.leida;

        _INotificacionRepository.Modify (notificacionEN);

        /*PROTECTED REGION END*/
}
}
}
