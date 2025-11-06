
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
 * Clase Notificacion:
 *
 */

namespace ProyectoDSMGen.Infraestructure.Repository.Flicks
{
public partial class NotificacionRepository : BasicRepository, INotificacionRepository
{
public NotificacionRepository() : base ()
{
}


public NotificacionRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public NotificacionEN ReadOIDDefault (int id
                                      )
{
        NotificacionEN notificacionEN = null;

        try
        {
                SessionInitializeTransaction ();
                notificacionEN = (NotificacionEN)session.Get (typeof(NotificacionNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return notificacionEN;
}

public System.Collections.Generic.IList<NotificacionEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<NotificacionEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(NotificacionNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<NotificacionEN>();
                        else
                                result = session.CreateCriteria (typeof(NotificacionNH)).List<NotificacionEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in NotificacionRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (NotificacionEN notificacion)
{
        try
        {
                SessionInitializeTransaction ();
                NotificacionNH notificacionNH = (NotificacionNH)session.Load (typeof(NotificacionNH), notificacion.Id);


                notificacionNH.Mensaje = notificacion.Mensaje;


                notificacionNH.Fecha = notificacion.Fecha;


                notificacionNH.TipoNotificacion = notificacion.TipoNotificacion;


                notificacionNH.IdOrigen = notificacion.IdOrigen;


                notificacionNH.EstadoNoti = notificacion.EstadoNoti;

                session.Update (notificacionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in NotificacionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (NotificacionEN notificacion)
{
        NotificacionNH notificacionNH = new NotificacionNH (notificacion);

        try
        {
                SessionInitializeTransaction ();
                if (notificacion.Usuario != null) {
                        // Argumento OID y no colección.
                        notificacionNH
                        .Usuario = (ProyectoDSMGen.ApplicationCore.EN.Flicks.UsuarioEN)session.Load (typeof(ProyectoDSMGen.ApplicationCore.EN.Flicks.UsuarioEN), notificacion.Usuario.Id);

                        notificacionNH.Usuario.Notificacion
                        .Add (notificacionNH);
                }

                session.Save (notificacionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in NotificacionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return notificacionNH.Id;
}

public void Modify (NotificacionEN notificacion)
{
        try
        {
                SessionInitializeTransaction ();
                NotificacionNH notificacionNH = (NotificacionNH)session.Load (typeof(NotificacionNH), notificacion.Id);

                notificacionNH.Mensaje = notificacion.Mensaje;


                notificacionNH.Fecha = notificacion.Fecha;


                notificacionNH.TipoNotificacion = notificacion.TipoNotificacion;


                notificacionNH.IdOrigen = notificacion.IdOrigen;


                notificacionNH.EstadoNoti = notificacion.EstadoNoti;

                session.Update (notificacionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in NotificacionRepository.", ex);
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
                NotificacionNH notificacionNH = (NotificacionNH)session.Load (typeof(NotificacionNH), id);
                session.Delete (notificacionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in NotificacionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<NotificacionEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<NotificacionEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(NotificacionNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<NotificacionEN>();
                else
                        result = session.CreateCriteria (typeof(NotificacionNH)).List<NotificacionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in NotificacionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

//Sin e: ReadID
//Con e: NotificacionEN
public NotificacionEN ReadID (int id
                              )
{
        NotificacionEN notificacionEN = null;

        try
        {
                SessionInitializeTransaction ();
                notificacionEN = (NotificacionEN)session.Get (typeof(NotificacionNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return notificacionEN;
}

public System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.NotificacionEN> ReadFilterEstado (int first, int size)
{
        System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.NotificacionEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM NotificacionNH self where FROM NotificacionNH n WHERE n.EstadoNoti = :estado";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("NotificacionNHreadFilterEstadoHQL");

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<ProyectoDSMGen.ApplicationCore.EN.Flicks.NotificacionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in NotificacionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.NotificacionEN> ReadFIlterOrigen (int first, int size)
{
        System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.NotificacionEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM NotificacionNH self where FROM NotificacionNH n WHERE n.IdOrigen = :idOrigen";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("NotificacionNHreadFIlterOrigenHQL");

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<ProyectoDSMGen.ApplicationCore.EN.Flicks.NotificacionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in NotificacionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
