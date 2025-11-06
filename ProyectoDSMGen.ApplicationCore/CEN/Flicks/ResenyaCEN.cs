

using System;
using System.Text;
using System.Collections.Generic;

using ProyectoDSMGen.ApplicationCore.Exceptions;

using ProyectoDSMGen.ApplicationCore.EN.Flicks;
using ProyectoDSMGen.ApplicationCore.IRepository.Flicks;


namespace ProyectoDSMGen.ApplicationCore.CEN.Flicks
{
/*
 *      Definition of the class ResenyaCEN
 *
 */
public partial class ResenyaCEN
{
private IResenyaRepository _IResenyaRepository;

public ResenyaCEN(IResenyaRepository _IResenyaRepository)
{
        this._IResenyaRepository = _IResenyaRepository;
}

public IResenyaRepository get_IResenyaRepository ()
{
        return this._IResenyaRepository;
}

public int New_ (int p_puntuacion, string p_comentario, Nullable<DateTime> p_fecha, int p_pelicula, int p_usuario)
{
        ResenyaEN resenyaEN = null;
        int oid;

        //Initialized ResenyaEN
        resenyaEN = new ResenyaEN ();
        resenyaEN.Puntuacion = p_puntuacion;

        resenyaEN.Comentario = p_comentario;

        resenyaEN.Fecha = p_fecha;


        if (p_pelicula != -1) {
                // El argumento p_pelicula -> Property pelicula es oid = false
                // Lista de oids id
                resenyaEN.Pelicula = new ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN ();
                resenyaEN.Pelicula.Id = p_pelicula;
        }


        if (p_usuario != -1) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                resenyaEN.Usuario = new ProyectoDSMGen.ApplicationCore.EN.Flicks.UsuarioEN ();
                resenyaEN.Usuario.Id = p_usuario;
        }



        oid = _IResenyaRepository.New_ (resenyaEN);
        return oid;
}

public void Modify (int p_Resenya_OID, int p_puntuacion, string p_comentario, Nullable<DateTime> p_fecha)
{
        ResenyaEN resenyaEN = null;

        //Initialized ResenyaEN
        resenyaEN = new ResenyaEN ();
        resenyaEN.Id = p_Resenya_OID;
        resenyaEN.Puntuacion = p_puntuacion;
        resenyaEN.Comentario = p_comentario;
        resenyaEN.Fecha = p_fecha;
        //Call to ResenyaRepository

        _IResenyaRepository.Modify (resenyaEN);
}

public void Destroy (int id
                     )
{
        _IResenyaRepository.Destroy (id);
}

public System.Collections.Generic.IList<ResenyaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ResenyaEN> list = null;

        list = _IResenyaRepository.ReadAll (first, size);
        return list;
}
public ResenyaEN ReadID (int id
                         )
{
        ResenyaEN resenyaEN = null;

        resenyaEN = _IResenyaRepository.ReadID (id);
        return resenyaEN;
}

public System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.ResenyaEN> ReadFilterByUsuario (int first, int size)
{
        return _IResenyaRepository.ReadFilterByUsuario (first, size);
}
public System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.ResenyaEN> ReadFIlterValoracion (int first, int size)
{
        return _IResenyaRepository.ReadFIlterValoracion (first, size);
}
public System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.ResenyaEN> ReadFilterByPelicula (int first, int size)
{
        return _IResenyaRepository.ReadFilterByPelicula (first, size);
}
}
}
