
using System;
// Definición clase PeliculaEN
namespace ProyectoDSMGen.ApplicationCore.EN.Flicks
{
public partial class PeliculaEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo titulo
 */
private string titulo;



/**
 *	Atributo tituloOriginal
 */
private string tituloOriginal;



/**
 *	Atributo anyo
 */
private int anyo;



/**
 *	Atributo duracion
 */
private int duracion;



/**
 *	Atributo pais
 */
private string pais;



/**
 *	Atributo director
 */
private string director;



/**
 *	Atributo genero
 */
private string genero;



/**
 *	Atributo sinopsis
 */
private string sinopsis;



/**
 *	Atributo valoracionMedia
 */
private float valoracionMedia;



/**
 *	Atributo lista
 */
private System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.ListaEN> lista;



/**
 *	Atributo administrador
 */
private ProyectoDSMGen.ApplicationCore.EN.Flicks.AdministradorEN administrador;



/**
 *	Atributo resenya
 */
private System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.ResenyaEN> resenya;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Titulo {
        get { return titulo; } set { titulo = value;  }
}



public virtual string TituloOriginal {
        get { return tituloOriginal; } set { tituloOriginal = value;  }
}



public virtual int Anyo {
        get { return anyo; } set { anyo = value;  }
}



public virtual int Duracion {
        get { return duracion; } set { duracion = value;  }
}



public virtual string Pais {
        get { return pais; } set { pais = value;  }
}



public virtual string Director {
        get { return director; } set { director = value;  }
}



public virtual string Genero {
        get { return genero; } set { genero = value;  }
}



public virtual string Sinopsis {
        get { return sinopsis; } set { sinopsis = value;  }
}



public virtual float ValoracionMedia {
        get { return valoracionMedia; } set { valoracionMedia = value;  }
}



public virtual System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.ListaEN> Lista {
        get { return lista; } set { lista = value;  }
}



public virtual ProyectoDSMGen.ApplicationCore.EN.Flicks.AdministradorEN Administrador {
        get { return administrador; } set { administrador = value;  }
}



public virtual System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.ResenyaEN> Resenya {
        get { return resenya; } set { resenya = value;  }
}





public PeliculaEN()
{
        lista = new System.Collections.Generic.List<ProyectoDSMGen.ApplicationCore.EN.Flicks.ListaEN>();
        resenya = new System.Collections.Generic.List<ProyectoDSMGen.ApplicationCore.EN.Flicks.ResenyaEN>();
}



public PeliculaEN(int id, string titulo, string tituloOriginal, int anyo, int duracion, string pais, string director, string genero, string sinopsis, float valoracionMedia, System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.ListaEN> lista, ProyectoDSMGen.ApplicationCore.EN.Flicks.AdministradorEN administrador, System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.ResenyaEN> resenya
                  )
{
        this.init (Id, titulo, tituloOriginal, anyo, duracion, pais, director, genero, sinopsis, valoracionMedia, lista, administrador, resenya);
}


public PeliculaEN(PeliculaEN pelicula)
{
        this.init (pelicula.Id, pelicula.Titulo, pelicula.TituloOriginal, pelicula.Anyo, pelicula.Duracion, pelicula.Pais, pelicula.Director, pelicula.Genero, pelicula.Sinopsis, pelicula.ValoracionMedia, pelicula.Lista, pelicula.Administrador, pelicula.Resenya);
}

private void init (int id
                   , string titulo, string tituloOriginal, int anyo, int duracion, string pais, string director, string genero, string sinopsis, float valoracionMedia, System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.ListaEN> lista, ProyectoDSMGen.ApplicationCore.EN.Flicks.AdministradorEN administrador, System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.ResenyaEN> resenya)
{
        this.Id = id;


        this.Titulo = titulo;

        this.TituloOriginal = tituloOriginal;

        this.Anyo = anyo;

        this.Duracion = duracion;

        this.Pais = pais;

        this.Director = director;

        this.Genero = genero;

        this.Sinopsis = sinopsis;

        this.ValoracionMedia = valoracionMedia;

        this.Lista = lista;

        this.Administrador = administrador;

        this.Resenya = resenya;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PeliculaEN t = obj as PeliculaEN;
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
