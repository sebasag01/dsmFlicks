
using System;
// Definición clase ListaEN
namespace ProyectoDSMGen.ApplicationCore.EN.Flicks
{
public partial class ListaEN
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
 *	Atributo tipo
 */
private ProyectoDSMGen.ApplicationCore.Enumerated.Flicks.TipoListaEnum tipo;



/**
 *	Atributo pelicula
 */
private System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN> pelicula;



/**
 *	Atributo usuario
 */
private System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.UsuarioEN> usuario;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual ProyectoDSMGen.ApplicationCore.Enumerated.Flicks.TipoListaEnum Tipo {
        get { return tipo; } set { tipo = value;  }
}



public virtual System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN> Pelicula {
        get { return pelicula; } set { pelicula = value;  }
}



public virtual System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.UsuarioEN> Usuario {
        get { return usuario; } set { usuario = value;  }
}





public ListaEN()
{
        pelicula = new System.Collections.Generic.List<ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN>();
        usuario = new System.Collections.Generic.List<ProyectoDSMGen.ApplicationCore.EN.Flicks.UsuarioEN>();
}



public ListaEN(int id, string nombre, ProyectoDSMGen.ApplicationCore.Enumerated.Flicks.TipoListaEnum tipo, System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN> pelicula, System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.UsuarioEN> usuario
               )
{
        this.init (Id, nombre, tipo, pelicula, usuario);
}


public ListaEN(ListaEN lista)
{
        this.init (lista.Id, lista.Nombre, lista.Tipo, lista.Pelicula, lista.Usuario);
}

private void init (int id
                   , string nombre, ProyectoDSMGen.ApplicationCore.Enumerated.Flicks.TipoListaEnum tipo, System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN> pelicula, System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.UsuarioEN> usuario)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Tipo = tipo;

        this.Pelicula = pelicula;

        this.Usuario = usuario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ListaEN t = obj as ListaEN;
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
