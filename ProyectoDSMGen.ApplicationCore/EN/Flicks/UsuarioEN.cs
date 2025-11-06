
using System;
// Definición clase UsuarioEN
namespace ProyectoDSMGen.ApplicationCore.EN.Flicks
{
public partial class UsuarioEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo fotoPerfil
 */
private string fotoPerfil;



/**
 *	Atributo biografia
 */
private string biografia;



/**
 *	Atributo modoBlancoYNegro
 */
private bool modoBlancoYNegro;



/**
 *	Atributo lista
 */
private System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.ListaEN> lista;



/**
 *	Atributo reporte
 */
private System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.ReporteEN> reporte;



/**
 *	Atributo notificacion
 */
private System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.NotificacionEN> notificacion;



/**
 *	Atributo metrica
 */
private ProyectoDSMGen.ApplicationCore.EN.Flicks.MetricaEN metrica;



/**
 *	Atributo pass
 */
private String pass;



/**
 *	Atributo resenya
 */
private System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.ResenyaEN> resenya;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual string FotoPerfil {
        get { return fotoPerfil; } set { fotoPerfil = value;  }
}



public virtual string Biografia {
        get { return biografia; } set { biografia = value;  }
}



public virtual bool ModoBlancoYNegro {
        get { return modoBlancoYNegro; } set { modoBlancoYNegro = value;  }
}



public virtual System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.ListaEN> Lista {
        get { return lista; } set { lista = value;  }
}



public virtual System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.ReporteEN> Reporte {
        get { return reporte; } set { reporte = value;  }
}



public virtual System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.NotificacionEN> Notificacion {
        get { return notificacion; } set { notificacion = value;  }
}



public virtual ProyectoDSMGen.ApplicationCore.EN.Flicks.MetricaEN Metrica {
        get { return metrica; } set { metrica = value;  }
}



public virtual String Pass {
        get { return pass; } set { pass = value;  }
}



public virtual System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.ResenyaEN> Resenya {
        get { return resenya; } set { resenya = value;  }
}





public UsuarioEN()
{
        lista = new System.Collections.Generic.List<ProyectoDSMGen.ApplicationCore.EN.Flicks.ListaEN>();
        reporte = new System.Collections.Generic.List<ProyectoDSMGen.ApplicationCore.EN.Flicks.ReporteEN>();
        notificacion = new System.Collections.Generic.List<ProyectoDSMGen.ApplicationCore.EN.Flicks.NotificacionEN>();
        resenya = new System.Collections.Generic.List<ProyectoDSMGen.ApplicationCore.EN.Flicks.ResenyaEN>();
}



public UsuarioEN(int id, string nombre, string email, string fotoPerfil, string biografia, bool modoBlancoYNegro, System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.ListaEN> lista, System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.ReporteEN> reporte, System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.NotificacionEN> notificacion, ProyectoDSMGen.ApplicationCore.EN.Flicks.MetricaEN metrica, String pass, System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.ResenyaEN> resenya
                 )
{
        this.init (Id, nombre, email, fotoPerfil, biografia, modoBlancoYNegro, lista, reporte, notificacion, metrica, pass, resenya);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (usuario.Id, usuario.Nombre, usuario.Email, usuario.FotoPerfil, usuario.Biografia, usuario.ModoBlancoYNegro, usuario.Lista, usuario.Reporte, usuario.Notificacion, usuario.Metrica, usuario.Pass, usuario.Resenya);
}

private void init (int id
                   , string nombre, string email, string fotoPerfil, string biografia, bool modoBlancoYNegro, System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.ListaEN> lista, System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.ReporteEN> reporte, System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.NotificacionEN> notificacion, ProyectoDSMGen.ApplicationCore.EN.Flicks.MetricaEN metrica, String pass, System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.ResenyaEN> resenya)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Email = email;

        this.FotoPerfil = fotoPerfil;

        this.Biografia = biografia;

        this.ModoBlancoYNegro = modoBlancoYNegro;

        this.Lista = lista;

        this.Reporte = reporte;

        this.Notificacion = notificacion;

        this.Metrica = metrica;

        this.Pass = pass;

        this.Resenya = resenya;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UsuarioEN t = obj as UsuarioEN;
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
