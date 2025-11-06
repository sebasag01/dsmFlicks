

using System;
using System.Text;
using System.Collections.Generic;

using ProyectoDSMGen.ApplicationCore.Exceptions;

using ProyectoDSMGen.ApplicationCore.EN.Flicks;
using ProyectoDSMGen.ApplicationCore.IRepository.Flicks;


namespace ProyectoDSMGen.ApplicationCore.CEN.Flicks
{
/*
 *      Definition of the class PeliculaCEN
 *
 */
public partial class PeliculaCEN
{
private IPeliculaRepository _IPeliculaRepository;

public PeliculaCEN(IPeliculaRepository _IPeliculaRepository)
{
        this._IPeliculaRepository = _IPeliculaRepository;
}

public IPeliculaRepository get_IPeliculaRepository ()
{
        return this._IPeliculaRepository;
}

public int New_ (string p_titulo, string p_tituloOriginal, int p_anyo, int p_duracion, string p_pais, string p_director, string p_genero, string p_sinopsis, float p_valoracionMedia, int p_administrador)
{
        PeliculaEN peliculaEN = null;
        int oid;

        //Initialized PeliculaEN
        peliculaEN = new PeliculaEN ();
        peliculaEN.Titulo = p_titulo;

        peliculaEN.TituloOriginal = p_tituloOriginal;

        peliculaEN.Anyo = p_anyo;

        peliculaEN.Duracion = p_duracion;

        peliculaEN.Pais = p_pais;

        peliculaEN.Director = p_director;

        peliculaEN.Genero = p_genero;

        peliculaEN.Sinopsis = p_sinopsis;

        peliculaEN.ValoracionMedia = p_valoracionMedia;


        if (p_administrador != -1) {
                // El argumento p_administrador -> Property administrador es oid = false
                // Lista de oids id
                peliculaEN.Administrador = new ProyectoDSMGen.ApplicationCore.EN.Flicks.AdministradorEN ();
                peliculaEN.Administrador.Id = p_administrador;
        }



        oid = _IPeliculaRepository.New_ (peliculaEN);
        return oid;
}

public void Modify (int p_Pelicula_OID, string p_titulo, string p_tituloOriginal, int p_anyo, int p_duracion, string p_pais, string p_director, string p_genero, string p_sinopsis, float p_valoracionMedia)
{
        PeliculaEN peliculaEN = null;

        //Initialized PeliculaEN
        peliculaEN = new PeliculaEN ();
        peliculaEN.Id = p_Pelicula_OID;
        peliculaEN.Titulo = p_titulo;
        peliculaEN.TituloOriginal = p_tituloOriginal;
        peliculaEN.Anyo = p_anyo;
        peliculaEN.Duracion = p_duracion;
        peliculaEN.Pais = p_pais;
        peliculaEN.Director = p_director;
        peliculaEN.Genero = p_genero;
        peliculaEN.Sinopsis = p_sinopsis;
        peliculaEN.ValoracionMedia = p_valoracionMedia;
        //Call to PeliculaRepository

        _IPeliculaRepository.Modify (peliculaEN);
}

public void Destroy (int id
                     )
{
        _IPeliculaRepository.Destroy (id);
}

public System.Collections.Generic.IList<PeliculaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PeliculaEN> list = null;

        list = _IPeliculaRepository.ReadAll (first, size);
        return list;
}
public PeliculaEN ReadID (int id
                          )
{
        PeliculaEN peliculaEN = null;

        peliculaEN = _IPeliculaRepository.ReadID (id);
        return peliculaEN;
}

public System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN> ReadFilterGenero (int first, int size)
{
        return _IPeliculaRepository.ReadFilterGenero (first, size);
}
public System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN> ReadFilterValoracion (int first, int size)
{
        return _IPeliculaRepository.ReadFilterValoracion (first, size);
}
public System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN> ReadFIlterAnyo (int first, int size)
{
        return _IPeliculaRepository.ReadFIlterAnyo (first, size);
}
public System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN> ReadFilterTitulo (int first, int size)
{
        return _IPeliculaRepository.ReadFilterTitulo (first, size);
}
}
}
