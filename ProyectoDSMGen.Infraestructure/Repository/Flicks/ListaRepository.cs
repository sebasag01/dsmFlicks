
using System;
using System.Text;
using ProyectoDSMGen.ApplicationCore.CEN.Flicks;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using ProyectoDSMGen.ApplicationCore.EN.Flicks;
using ProyectoDSMGen.ApplicationCore.Exceptions;
using ProyectoDSMGen.ApplicationCore.IRepository.Flicks;
using ProyectoDSMGen.ApplicationCore.CP.Flicks;
using ProyectoDSMGen.Infraestructure.EN.Flicks;


/*
 * Clase Lista:
 *
 */

namespace ProyectoDSMGen.Infraestructure.Repository.Flicks
{
public partial class ListaRepository : BasicRepository, IListaRepository
{
public ListaRepository() : base ()
{
}


public ListaRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ListaEN ReadOIDDefault (int id
                               )
{
        ListaEN listaEN = null;

        try
        {
                SessionInitializeTransaction ();
                listaEN = (ListaEN)session.Get (typeof(ListaNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return listaEN;
}

public System.Collections.Generic.IList<ListaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ListaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ListaNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ListaEN>();
                        else
                                result = session.CreateCriteria (typeof(ListaNH)).List<ListaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ListaRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ListaEN lista)
{
        try
        {
                SessionInitializeTransaction ();
                ListaNH listaNH = (ListaNH)session.Load (typeof(ListaNH), lista.Id);

                listaNH.Nombre = lista.Nombre;


                listaNH.Tipo = lista.Tipo;



                session.Update (listaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ListaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ListaEN lista)
{
        ListaNH listaNH = new ListaNH (lista);

        try
        {
                SessionInitializeTransaction ();
                if (lista.Pelicula != null) {
                        for (int i = 0; i < lista.Pelicula.Count; i++) {
                                lista.Pelicula [i] = (ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN)session.Load (typeof(ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN), lista.Pelicula [i].Id);
                                lista.Pelicula [i].Lista.Add (listaNH);
                        }
                }
                if (lista.Usuario != null) {
                        for (int i = 0; i < lista.Usuario.Count; i++) {
                                lista.Usuario [i] = (ProyectoDSMGen.ApplicationCore.EN.Flicks.UsuarioEN)session.Load (typeof(ProyectoDSMGen.ApplicationCore.EN.Flicks.UsuarioEN), lista.Usuario [i].Id);
                                lista.Usuario [i].Lista.Add (listaNH);
                        }
                }

                session.Save (listaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ListaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return listaNH.Id;
}

public void Modify (ListaEN lista)
{
        try
        {
                SessionInitializeTransaction ();
                ListaNH listaNH = (ListaNH)session.Load (typeof(ListaNH), lista.Id);

                listaNH.Nombre = lista.Nombre;


                listaNH.Tipo = lista.Tipo;

                session.Update (listaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ListaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                ListaNH listaNH = (ListaNH)session.Load (typeof(ListaNH), id);
                session.Delete (listaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ListaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<ListaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ListaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ListaNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<ListaEN>();
                else
                        result = session.CreateCriteria (typeof(ListaNH)).List<ListaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ListaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

//Sin e: ReadID
//Con e: ListaEN
public ListaEN ReadID (int id
                       )
{
        ListaEN listaEN = null;

        try
        {
                SessionInitializeTransaction ();
                listaEN = (ListaEN)session.Get (typeof(ListaNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return listaEN;
}

public void AnyadirPelicula (int p_Lista_OID, System.Collections.Generic.IList<int> p_pelicula_OIDs)
{
        ProyectoDSMGen.ApplicationCore.EN.Flicks.ListaEN listaEN = null;
        try
        {
                SessionInitializeTransaction ();
                listaEN = (ListaEN)session.Load (typeof(ListaNH), p_Lista_OID);
                ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN peliculaENAux = null;
                if (listaEN.Pelicula == null) {
                        listaEN.Pelicula = new System.Collections.Generic.List<ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN>();
                }

                foreach (int item in p_pelicula_OIDs) {
                        peliculaENAux = new ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN ();
                        peliculaENAux = (ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN)session.Load (typeof(ProyectoDSMGen.Infraestructure.EN.Flicks.PeliculaNH), item);
                        peliculaENAux.Lista.Add (listaEN);

                        listaEN.Pelicula.Add (peliculaENAux);
                }


                session.Update (listaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ListaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
