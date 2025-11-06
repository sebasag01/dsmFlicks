
using System;
// Definición clase NotificacionEN
namespace ProyectoDSMGen.ApplicationCore.EN.Flicks
{
public partial class NotificacionEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo usuario
 */
private ProyectoDSMGen.ApplicationCore.EN.Flicks.UsuarioEN usuario;



/**
 *	Atributo mensaje
 */
private string mensaje;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo tipoNotificacion
 */
private ProyectoDSMGen.ApplicationCore.Enumerated.Flicks.TipoNotificacionEnum tipoNotificacion;



/**
 *	Atributo idOrigen
 */
private long idOrigen;



/**
 *	Atributo estadoNoti
 */
private ProyectoDSMGen.ApplicationCore.Enumerated.Flicks.EstadoNotificacionEnum estadoNoti;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual ProyectoDSMGen.ApplicationCore.EN.Flicks.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual string Mensaje {
        get { return mensaje; } set { mensaje = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual ProyectoDSMGen.ApplicationCore.Enumerated.Flicks.TipoNotificacionEnum TipoNotificacion {
        get { return tipoNotificacion; } set { tipoNotificacion = value;  }
}



public virtual long IdOrigen {
        get { return idOrigen; } set { idOrigen = value;  }
}



public virtual ProyectoDSMGen.ApplicationCore.Enumerated.Flicks.EstadoNotificacionEnum EstadoNoti {
        get { return estadoNoti; } set { estadoNoti = value;  }
}





public NotificacionEN()
{
}



public NotificacionEN(int id, ProyectoDSMGen.ApplicationCore.EN.Flicks.UsuarioEN usuario, string mensaje, Nullable<DateTime> fecha, ProyectoDSMGen.ApplicationCore.Enumerated.Flicks.TipoNotificacionEnum tipoNotificacion, long idOrigen, ProyectoDSMGen.ApplicationCore.Enumerated.Flicks.EstadoNotificacionEnum estadoNoti
                      )
{
        this.init (Id, usuario, mensaje, fecha, tipoNotificacion, idOrigen, estadoNoti);
}


public NotificacionEN(NotificacionEN notificacion)
{
        this.init (notificacion.Id, notificacion.Usuario, notificacion.Mensaje, notificacion.Fecha, notificacion.TipoNotificacion, notificacion.IdOrigen, notificacion.EstadoNoti);
}

private void init (int id
                   , ProyectoDSMGen.ApplicationCore.EN.Flicks.UsuarioEN usuario, string mensaje, Nullable<DateTime> fecha, ProyectoDSMGen.ApplicationCore.Enumerated.Flicks.TipoNotificacionEnum tipoNotificacion, long idOrigen, ProyectoDSMGen.ApplicationCore.Enumerated.Flicks.EstadoNotificacionEnum estadoNoti)
{
        this.Id = id;


        this.Usuario = usuario;

        this.Mensaje = mensaje;

        this.Fecha = fecha;

        this.TipoNotificacion = tipoNotificacion;

        this.IdOrigen = idOrigen;

        this.EstadoNoti = estadoNoti;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        NotificacionEN t = obj as NotificacionEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
