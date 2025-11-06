
using System;
// Definición clase MetricaEN
namespace ProyectoDSMGen.ApplicationCore.EN.Flicks
{
public partial class MetricaEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo usuario
 */
private System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.UsuarioEN> usuario;



/**
 *	Atributo estadisticas
 */
private string estadisticas;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.UsuarioEN> Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual string Estadisticas {
        get { return estadisticas; } set { estadisticas = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}





public MetricaEN()
{
        usuario = new System.Collections.Generic.List<ProyectoDSMGen.ApplicationCore.EN.Flicks.UsuarioEN>();
}



public MetricaEN(int id, System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.UsuarioEN> usuario, string estadisticas, Nullable<DateTime> fecha
                 )
{
        this.init (Id, usuario, estadisticas, fecha);
}


public MetricaEN(MetricaEN metrica)
{
        this.init (metrica.Id, metrica.Usuario, metrica.Estadisticas, metrica.Fecha);
}

private void init (int id
                   , System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.UsuarioEN> usuario, string estadisticas, Nullable<DateTime> fecha)
{
        this.Id = id;


        this.Usuario = usuario;

        this.Estadisticas = estadisticas;

        this.Fecha = fecha;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        MetricaEN t = obj as MetricaEN;
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
