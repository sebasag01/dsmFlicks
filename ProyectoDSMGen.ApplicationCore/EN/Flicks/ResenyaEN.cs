
using System;
// Definición clase ResenyaEN
namespace ProyectoDSMGen.ApplicationCore.EN.Flicks
{
public partial class ResenyaEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo puntuacion
 */
private int puntuacion;



/**
 *	Atributo comentario
 */
private string comentario;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo pelicula
 */
private ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN pelicula;



/**
 *	Atributo reporte
 */
private ProyectoDSMGen.ApplicationCore.EN.Flicks.ReporteEN reporte;



/**
 *	Atributo usuario
 */
private ProyectoDSMGen.ApplicationCore.EN.Flicks.UsuarioEN usuario;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual int Puntuacion {
        get { return puntuacion; } set { puntuacion = value;  }
}



public virtual string Comentario {
        get { return comentario; } set { comentario = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN Pelicula {
        get { return pelicula; } set { pelicula = value;  }
}



public virtual ProyectoDSMGen.ApplicationCore.EN.Flicks.ReporteEN Reporte {
        get { return reporte; } set { reporte = value;  }
}



public virtual ProyectoDSMGen.ApplicationCore.EN.Flicks.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}





public ResenyaEN()
{
}



public ResenyaEN(int id, int puntuacion, string comentario, Nullable<DateTime> fecha, ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN pelicula, ProyectoDSMGen.ApplicationCore.EN.Flicks.ReporteEN reporte, ProyectoDSMGen.ApplicationCore.EN.Flicks.UsuarioEN usuario
                 )
{
        this.init (Id, puntuacion, comentario, fecha, pelicula, reporte, usuario);
}


public ResenyaEN(ResenyaEN resenya)
{
        this.init (resenya.Id, resenya.Puntuacion, resenya.Comentario, resenya.Fecha, resenya.Pelicula, resenya.Reporte, resenya.Usuario);
}

private void init (int id
                   , int puntuacion, string comentario, Nullable<DateTime> fecha, ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN pelicula, ProyectoDSMGen.ApplicationCore.EN.Flicks.ReporteEN reporte, ProyectoDSMGen.ApplicationCore.EN.Flicks.UsuarioEN usuario)
{
        this.Id = id;


        this.Puntuacion = puntuacion;

        this.Comentario = comentario;

        this.Fecha = fecha;

        this.Pelicula = pelicula;

        this.Reporte = reporte;

        this.Usuario = usuario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ResenyaEN t = obj as ResenyaEN;
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
