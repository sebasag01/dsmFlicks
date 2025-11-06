
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
 * Clase Resenya:
 *
 */

namespace ProyectoDSMGen.Infraestructure.Repository.Flicks
{
public partial class ResenyaRepository : BasicRepository, IResenyaRepository
{
public ResenyaRepository() : base ()
{
}


public ResenyaRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ResenyaEN ReadOIDDefault (int id
                                 )
{
        ResenyaEN resenyaEN = null;

        try
        {
                SessionInitializeTransaction ();
                resenyaEN = (ResenyaEN)session.Get (typeof(ResenyaNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return resenyaEN;
}

public System.Collections.Generic.IList<ResenyaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ResenyaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ResenyaNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ResenyaEN>();
                        else
                                result = session.CreateCriteria (typeof(ResenyaNH)).List<ResenyaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ResenyaRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ResenyaEN resenya)
{
        try
        {
                SessionInitializeTransaction ();
                ResenyaNH resenyaNH = (ResenyaNH)session.Load (typeof(ResenyaNH), resenya.Id);

                resenyaNH.Puntuacion = resenya.Puntuacion;


                resenyaNH.Comentario = resenya.Comentario;


                resenyaNH.Fecha = resenya.Fecha;




                session.Update (resenyaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ResenyaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ResenyaEN resenya)
{
        ResenyaNH resenyaNH = new ResenyaNH (resenya);

        try
        {
                SessionInitializeTransaction ();
                if (resenya.Pelicula != null) {
                        // Argumento OID y no colección.
                        resenyaNH
                        .Pelicula = (ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN)session.Load (typeof(ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN), resenya.Pelicula.Id);

                        resenyaNH.Pelicula.Resenya
                        .Add (resenyaNH);
                }
                if (resenya.Usuario != null) {
                        // Argumento OID y no colección.
                        resenyaNH
                        .Usuario = (ProyectoDSMGen.ApplicationCore.EN.Flicks.UsuarioEN)session.Load (typeof(ProyectoDSMGen.ApplicationCore.EN.Flicks.UsuarioEN), resenya.Usuario.Id);

                        resenyaNH.Usuario.Resenya
                        .Add (resenyaNH);
                }

                session.Save (resenyaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ResenyaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return resenyaNH.Id;
}

public void Modify (ResenyaEN resenya)
{
        try
        {
                SessionInitializeTransaction ();
                ResenyaNH resenyaNH = (ResenyaNH)session.Load (typeof(ResenyaNH), resenya.Id);

                resenyaNH.Puntuacion = resenya.Puntuacion;


                resenyaNH.Comentario = resenya.Comentario;


                resenyaNH.Fecha = resenya.Fecha;

                session.Update (resenyaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ResenyaRepository.", ex);
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
                ResenyaNH resenyaNH = (ResenyaNH)session.Load (typeof(ResenyaNH), id);
                session.Delete (resenyaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ResenyaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<ResenyaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ResenyaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ResenyaNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<ResenyaEN>();
                else
                        result = session.CreateCriteria (typeof(ResenyaNH)).List<ResenyaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ResenyaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

//Sin e: ReadID
//Con e: ResenyaEN
public ResenyaEN ReadID (int id
                         )
{
        ResenyaEN resenyaEN = null;

        try
        {
                SessionInitializeTransaction ();
                resenyaEN = (ResenyaEN)session.Get (typeof(ResenyaNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return resenyaEN;
}

public System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.ResenyaEN> ReadFilterByUsuario (int first, int size)
{
        System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.ResenyaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ResenyaNH self where FROM ResenyaNH r WHERE r.Usuario.Id = :idUsuario";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ResenyaNHreadFilterByUsuarioHQL");

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<ProyectoDSMGen.ApplicationCore.EN.Flicks.ResenyaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ResenyaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.ResenyaEN> ReadFIlterValoracion (int first, int size)
{
        System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.ResenyaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ResenyaNH self where FROM ResenyaNH r WHERE r.Puntuacion = :puntuacion";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ResenyaNHreadFIlterValoracionHQL");

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<ProyectoDSMGen.ApplicationCore.EN.Flicks.ResenyaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ResenyaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.ResenyaEN> ReadFilterByPelicula (int first, int size)
{
        System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.ResenyaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ResenyaNH self where FROM ResenyaNH r WHERE r.pelicula.id = :idPelicula";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ResenyaNHreadFilterByPeliculaHQL");

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<ProyectoDSMGen.ApplicationCore.EN.Flicks.ResenyaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ResenyaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
