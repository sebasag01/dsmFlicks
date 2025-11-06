
using System;
// Definición clase ReporteEN
namespace ProyectoDSMGen.ApplicationCore.EN.Flicks
{
public partial class ReporteEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo motivo
 */
private string motivo;



/**
 *	Atributo estado
 */
private ProyectoDSMGen.ApplicationCore.Enumerated.Flicks.EstadoReporteEnum estado;



/**
 *	Atributo fecha
 */
private string fecha;



/**
 *	Atributo usuario
 */
private ProyectoDSMGen.ApplicationCore.EN.Flicks.UsuarioEN usuario;



/**
 *	Atributo resenya
 */
private System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.ResenyaEN> resenya;



/**
 *	Atributo administrador
 */
private ProyectoDSMGen.ApplicationCore.EN.Flicks.AdministradorEN administrador;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Motivo {
        get { return motivo; } set { motivo = value;  }
}



public virtual ProyectoDSMGen.ApplicationCore.Enumerated.Flicks.EstadoReporteEnum Estado {
        get { return estado; } set { estado = value;  }
}



public virtual string Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual ProyectoDSMGen.ApplicationCore.EN.Flicks.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.ResenyaEN> Resenya {
        get { return resenya; } set { resenya = value;  }
}



public virtual ProyectoDSMGen.ApplicationCore.EN.Flicks.AdministradorEN Administrador {
        get { return administrador; } set { administrador = value;  }
}





public ReporteEN()
{
        resenya = new System.Collections.Generic.List<ProyectoDSMGen.ApplicationCore.EN.Flicks.ResenyaEN>();
}



public ReporteEN(int id, string motivo, ProyectoDSMGen.ApplicationCore.Enumerated.Flicks.EstadoReporteEnum estado, string fecha, ProyectoDSMGen.ApplicationCore.EN.Flicks.UsuarioEN usuario, System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.ResenyaEN> resenya, ProyectoDSMGen.ApplicationCore.EN.Flicks.AdministradorEN administrador
                 )
{
        this.init (Id, motivo, estado, fecha, usuario, resenya, administrador);
}


public ReporteEN(ReporteEN reporte)
{
        this.init (reporte.Id, reporte.Motivo, reporte.Estado, reporte.Fecha, reporte.Usuario, reporte.Resenya, reporte.Administrador);
}

private void init (int id
                   , string motivo, ProyectoDSMGen.ApplicationCore.Enumerated.Flicks.EstadoReporteEnum estado, string fecha, ProyectoDSMGen.ApplicationCore.EN.Flicks.UsuarioEN usuario, System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.ResenyaEN> resenya, ProyectoDSMGen.ApplicationCore.EN.Flicks.AdministradorEN administrador)
{
        this.Id = id;


        this.Motivo = motivo;

        this.Estado = estado;

        this.Fecha = fecha;

        this.Usuario = usuario;

        this.Resenya = resenya;

        this.Administrador = administrador;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ReporteEN t = obj as ReporteEN;
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
