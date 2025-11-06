
using System;
// Definición clase AdministradorEN
namespace ProyectoDSMGen.ApplicationCore.EN.Flicks
{
public partial class AdministradorEN
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
 *	Atributo pelicula
 */
private System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN> pelicula;



/**
 *	Atributo reporte
 */
private System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.ReporteEN> reporte;



/**
 *	Atributo pass
 */
private String pass;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN> Pelicula {
        get { return pelicula; } set { pelicula = value;  }
}



public virtual System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.ReporteEN> Reporte {
        get { return reporte; } set { reporte = value;  }
}



public virtual String Pass {
        get { return pass; } set { pass = value;  }
}





public AdministradorEN()
{
        pelicula = new System.Collections.Generic.List<ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN>();
        reporte = new System.Collections.Generic.List<ProyectoDSMGen.ApplicationCore.EN.Flicks.ReporteEN>();
}



public AdministradorEN(int id, string nombre, string email, System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN> pelicula, System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.ReporteEN> reporte, String pass
                       )
{
        this.init (Id, nombre, email, pelicula, reporte, pass);
}


public AdministradorEN(AdministradorEN administrador)
{
        this.init (administrador.Id, administrador.Nombre, administrador.Email, administrador.Pelicula, administrador.Reporte, administrador.Pass);
}

private void init (int id
                   , string nombre, string email, System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN> pelicula, System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.ReporteEN> reporte, String pass)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Email = email;

        this.Pelicula = pelicula;

        this.Reporte = reporte;

        this.Pass = pass;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AdministradorEN t = obj as AdministradorEN;
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
