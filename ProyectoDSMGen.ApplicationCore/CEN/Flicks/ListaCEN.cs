

using System;
using System.Text;
using System.Collections.Generic;

using ProyectoDSMGen.ApplicationCore.Exceptions;

using ProyectoDSMGen.ApplicationCore.EN.Flicks;
using ProyectoDSMGen.ApplicationCore.IRepository.Flicks;


namespace ProyectoDSMGen.ApplicationCore.CEN.Flicks
{
/*
 *      Definition of the class ListaCEN
 *
 */
public partial class ListaCEN
{
private IListaRepository _IListaRepository;

public ListaCEN(IListaRepository _IListaRepository)
{
        this._IListaRepository = _IListaRepository;
}

public IListaRepository get_IListaRepository ()
{
        return this._IListaRepository;
}

public int New_ (string p_nombre, ProyectoDSMGen.ApplicationCore.Enumerated.Flicks.TipoListaEnum p_tipo, System.Collections.Generic.IList<int> p_pelicula, System.Collections.Generic.IList<int> p_usuario)
{
        ListaEN listaEN = null;
        int oid;

        //Initialized ListaEN
        listaEN = new ListaEN ();
        listaEN.Nombre = p_nombre;

        listaEN.Tipo = p_tipo;


        listaEN.Pelicula = new System.Collections.Generic.List<ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN>();
        if (p_pelicula != null) {
                foreach (int item in p_pelicula) {
                        ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN en = new ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN ();
                        en.Id = item;
                        listaEN.Pelicula.Add (en);
                }
        }

        else{
                listaEN.Pelicula = new System.Collections.Generic.List<ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN>();
        }


        listaEN.Usuario = new System.Collections.Generic.List<ProyectoDSMGen.ApplicationCore.EN.Flicks.UsuarioEN>();
        if (p_usuario != null) {
                foreach (int item in p_usuario) {
                        ProyectoDSMGen.ApplicationCore.EN.Flicks.UsuarioEN en = new ProyectoDSMGen.ApplicationCore.EN.Flicks.UsuarioEN ();
                        en.Id = item;
                        listaEN.Usuario.Add (en);
                }
        }

        else{
                listaEN.Usuario = new System.Collections.Generic.List<ProyectoDSMGen.ApplicationCore.EN.Flicks.UsuarioEN>();
        }



        oid = _IListaRepository.New_ (listaEN);
        return oid;
}

public void Modify (int p_Lista_OID, string p_nombre, ProyectoDSMGen.ApplicationCore.Enumerated.Flicks.TipoListaEnum p_tipo)
{
        ListaEN listaEN = null;

        //Initialized ListaEN
        listaEN = new ListaEN ();
        listaEN.Id = p_Lista_OID;
        listaEN.Nombre = p_nombre;
        listaEN.Tipo = p_tipo;
        //Call to ListaRepository

        _IListaRepository.Modify (listaEN);
}

public void Destroy (int id
                     )
{
        _IListaRepository.Destroy (id);
}

public System.Collections.Generic.IList<ListaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ListaEN> list = null;

        list = _IListaRepository.ReadAll (first, size);
        return list;
}
public ListaEN ReadID (int id
                       )
{
        ListaEN listaEN = null;

        listaEN = _IListaRepository.ReadID (id);
        return listaEN;
}

public void AnyadirPelicula (int p_Lista_OID, System.Collections.Generic.IList<int> p_pelicula_OIDs)
{
        //Call to ListaRepository

        _IListaRepository.AnyadirPelicula (p_Lista_OID, p_pelicula_OIDs);
}
}
}
