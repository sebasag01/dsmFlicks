
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
 * Clase Reporte:
 *
 */

namespace ProyectoDSMGen.Infraestructure.Repository.Flicks
{
public partial class ReporteRepository : BasicRepository, IReporteRepository
{
public ReporteRepository() : base ()
{
}


public ReporteRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ReporteEN ReadOIDDefault (int id
                                 )
{
        ReporteEN reporteEN = null;

        try
        {
                SessionInitializeTransaction ();
                reporteEN = (ReporteEN)session.Get (typeof(ReporteNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return reporteEN;
}

public System.Collections.Generic.IList<ReporteEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ReporteEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ReporteNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ReporteEN>();
                        else
                                result = session.CreateCriteria (typeof(ReporteNH)).List<ReporteEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ReporteRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ReporteEN reporte)
{
        try
        {
                SessionInitializeTransaction ();
                ReporteNH reporteNH = (ReporteNH)session.Load (typeof(ReporteNH), reporte.Id);

                reporteNH.Motivo = reporte.Motivo;


                reporteNH.Estado = reporte.Estado;


                reporteNH.Fecha = reporte.Fecha;




                session.Update (reporteNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ReporteRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ReporteEN reporte)
{
        ReporteNH reporteNH = new ReporteNH (reporte);

        try
        {
                SessionInitializeTransaction ();
                if (reporte.Usuario != null) {
                        // Argumento OID y no colección.
                        reporteNH
                        .Usuario = (ProyectoDSMGen.ApplicationCore.EN.Flicks.UsuarioEN)session.Load (typeof(ProyectoDSMGen.ApplicationCore.EN.Flicks.UsuarioEN), reporte.Usuario.Id);

                        reporteNH.Usuario.Reporte
                        .Add (reporteNH);
                }
                if (reporte.Resenya != null) {
                        for (int i = 0; i < reporte.Resenya.Count; i++) {
                                reporte.Resenya [i] = (ProyectoDSMGen.ApplicationCore.EN.Flicks.ResenyaEN)session.Load (typeof(ProyectoDSMGen.ApplicationCore.EN.Flicks.ResenyaEN), reporte.Resenya [i].Id);
                                reporte.Resenya [i].Reporte = reporte;
                        }
                }
                if (reporte.Administrador != null) {
                        // Argumento OID y no colección.
                        reporteNH
                        .Administrador = (ProyectoDSMGen.ApplicationCore.EN.Flicks.AdministradorEN)session.Load (typeof(ProyectoDSMGen.ApplicationCore.EN.Flicks.AdministradorEN), reporte.Administrador.Id);

                        reporteNH.Administrador.Reporte
                        .Add (reporteNH);
                }

                session.Save (reporteNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ReporteRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return reporteNH.Id;
}

public void Modify (ReporteEN reporte)
{
        try
        {
                SessionInitializeTransaction ();
                ReporteNH reporteNH = (ReporteNH)session.Load (typeof(ReporteNH), reporte.Id);

                reporteNH.Motivo = reporte.Motivo;


                reporteNH.Estado = reporte.Estado;


                reporteNH.Fecha = reporte.Fecha;

                session.Update (reporteNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ReporteRepository.", ex);
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
                ReporteNH reporteNH = (ReporteNH)session.Load (typeof(ReporteNH), id);
                session.Delete (reporteNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ReporteRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<ReporteEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ReporteEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ReporteNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<ReporteEN>();
                else
                        result = session.CreateCriteria (typeof(ReporteNH)).List<ReporteEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ReporteRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

//Sin e: ReadID
//Con e: ReporteEN
public ReporteEN ReadID (int id
                         )
{
        ReporteEN reporteEN = null;

        try
        {
                SessionInitializeTransaction ();
                reporteEN = (ReporteEN)session.Get (typeof(ReporteNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return reporteEN;
}

public System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.ReporteEN> ReadFilterEstado (int first, int size)
{
        System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.ReporteEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ReporteNH self where FROM ReporteNH as r WHERE r.Estado = :p_estado";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ReporteNHreadFilterEstadoHQL");

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<ProyectoDSMGen.ApplicationCore.EN.Flicks.ReporteEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ReporteRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
