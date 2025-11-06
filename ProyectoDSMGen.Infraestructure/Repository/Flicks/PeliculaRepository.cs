
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
 * Clase Pelicula:
 *
 */

namespace ProyectoDSMGen.Infraestructure.Repository.Flicks
{
public partial class PeliculaRepository : BasicRepository, IPeliculaRepository
{
public PeliculaRepository() : base ()
{
}


public PeliculaRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public PeliculaEN ReadOIDDefault (int id
                                  )
{
        PeliculaEN peliculaEN = null;

        try
        {
                SessionInitializeTransaction ();
                peliculaEN = (PeliculaEN)session.Get (typeof(PeliculaNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return peliculaEN;
}

public System.Collections.Generic.IList<PeliculaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PeliculaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PeliculaNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<PeliculaEN>();
                        else
                                result = session.CreateCriteria (typeof(PeliculaNH)).List<PeliculaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in PeliculaRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PeliculaEN pelicula)
{
        try
        {
                SessionInitializeTransaction ();
                PeliculaNH peliculaNH = (PeliculaNH)session.Load (typeof(PeliculaNH), pelicula.Id);

                peliculaNH.Titulo = pelicula.Titulo;


                peliculaNH.TituloOriginal = pelicula.TituloOriginal;


                peliculaNH.Anyo = pelicula.Anyo;


                peliculaNH.Duracion = pelicula.Duracion;


                peliculaNH.Pais = pelicula.Pais;


                peliculaNH.Director = pelicula.Director;


                peliculaNH.Genero = pelicula.Genero;


                peliculaNH.Sinopsis = pelicula.Sinopsis;


                peliculaNH.ValoracionMedia = pelicula.ValoracionMedia;




                session.Update (peliculaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in PeliculaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (PeliculaEN pelicula)
{
        PeliculaNH peliculaNH = new PeliculaNH (pelicula);

        try
        {
                SessionInitializeTransaction ();
                if (pelicula.Administrador != null) {
                        // Argumento OID y no colección.
                        peliculaNH
                        .Administrador = (ProyectoDSMGen.ApplicationCore.EN.Flicks.AdministradorEN)session.Load (typeof(ProyectoDSMGen.ApplicationCore.EN.Flicks.AdministradorEN), pelicula.Administrador.Id);

                        peliculaNH.Administrador.Pelicula
                        .Add (peliculaNH);
                }

                session.Save (peliculaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in PeliculaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return peliculaNH.Id;
}

public void Modify (PeliculaEN pelicula)
{
        try
        {
                SessionInitializeTransaction ();
                PeliculaNH peliculaNH = (PeliculaNH)session.Load (typeof(PeliculaNH), pelicula.Id);

                peliculaNH.Titulo = pelicula.Titulo;


                peliculaNH.TituloOriginal = pelicula.TituloOriginal;


                peliculaNH.Anyo = pelicula.Anyo;


                peliculaNH.Duracion = pelicula.Duracion;


                peliculaNH.Pais = pelicula.Pais;


                peliculaNH.Director = pelicula.Director;


                peliculaNH.Genero = pelicula.Genero;


                peliculaNH.Sinopsis = pelicula.Sinopsis;


                peliculaNH.ValoracionMedia = pelicula.ValoracionMedia;

                session.Update (peliculaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in PeliculaRepository.", ex);
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
                PeliculaNH peliculaNH = (PeliculaNH)session.Load (typeof(PeliculaNH), id);
                session.Delete (peliculaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in PeliculaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<PeliculaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PeliculaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PeliculaNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<PeliculaEN>();
                else
                        result = session.CreateCriteria (typeof(PeliculaNH)).List<PeliculaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in PeliculaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

//Sin e: ReadID
//Con e: PeliculaEN
public PeliculaEN ReadID (int id
                          )
{
        PeliculaEN peliculaEN = null;

        try
        {
                SessionInitializeTransaction ();
                peliculaEN = (PeliculaEN)session.Get (typeof(PeliculaNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return peliculaEN;
}

public System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN> ReadFilterGenero (int first, int size)
{
        System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PeliculaNH self where FROM PeliculaNH as p WHERE p.Genero =:p_genero";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PeliculaNHreadFilterGeneroHQL");

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in PeliculaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN> ReadFilterValoracion (int first, int size)
{
        System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PeliculaNH self where FROM PeliculaNHas p WHERE p.ValoraciónMedia >= :p_valor";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PeliculaNHreadFilterValoracionHQL");

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in PeliculaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN> ReadFIlterAnyo (int first, int size)
{
        System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PeliculaNH self where FROM PeliculaNH as p WHERE p.Año = :p_año";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PeliculaNHreadFIlterAnyoHQL");

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in PeliculaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN> ReadFilterTitulo (int first, int size)
{
        System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PeliculaNH self where FROM PeliculaNHas p WHERE lower(p.Título) like lower(:p_titulo)";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PeliculaNHreadFilterTituloHQL");

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in PeliculaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
