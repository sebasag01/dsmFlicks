

using System;
using System.Text;
using System.Collections.Generic;

using ProyectoDSMGen.ApplicationCore.Exceptions;

using ProyectoDSMGen.ApplicationCore.EN.Flicks;
using ProyectoDSMGen.ApplicationCore.IRepository.Flicks;


namespace ProyectoDSMGen.ApplicationCore.CEN.Flicks
{
/*
 *      Definition of the class NotificacionCEN
 *
 */
public partial class NotificacionCEN
{
private INotificacionRepository _INotificacionRepository;

public NotificacionCEN(INotificacionRepository _INotificacionRepository)
{
        this._INotificacionRepository = _INotificacionRepository;
}

public INotificacionRepository get_INotificacionRepository ()
{
        return this._INotificacionRepository;
}

public void Modify (int p_Notificacion_OID, string p_mensaje, Nullable<DateTime> p_fecha, ProyectoDSMGen.ApplicationCore.Enumerated.Flicks.TipoNotificacionEnum p_tipoNotificacion, long p_IdOrigen, ProyectoDSMGen.ApplicationCore.Enumerated.Flicks.EstadoNotificacionEnum p_estadoNoti)
{
        NotificacionEN notificacionEN = null;

        //Initialized NotificacionEN
        notificacionEN = new NotificacionEN ();
        notificacionEN.Id = p_Notificacion_OID;
        notificacionEN.Mensaje = p_mensaje;
        notificacionEN.Fecha = p_fecha;
        notificacionEN.TipoNotificacion = p_tipoNotificacion;
        notificacionEN.IdOrigen = p_IdOrigen;
        notificacionEN.EstadoNoti = p_estadoNoti;
        //Call to NotificacionRepository

        _INotificacionRepository.Modify (notificacionEN);
}

public void Destroy (int id
                     )
{
        _INotificacionRepository.Destroy (id);
}

public System.Collections.Generic.IList<NotificacionEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<NotificacionEN> list = null;

        list = _INotificacionRepository.ReadAll (first, size);
        return list;
}
public NotificacionEN ReadID (int id
                              )
{
        NotificacionEN notificacionEN = null;

        notificacionEN = _INotificacionRepository.ReadID (id);
        return notificacionEN;
}

public System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.NotificacionEN> ReadFilterEstado (int first, int size)
{
        return _INotificacionRepository.ReadFilterEstado (first, size);
}
public System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.NotificacionEN> ReadFIlterOrigen (int first, int size)
{
        return _INotificacionRepository.ReadFIlterOrigen (first, size);
}
}
}
