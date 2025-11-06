
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
 * Clase Metrica:
 *
 */

namespace ProyectoDSMGen.Infraestructure.Repository.Flicks
{
public partial class MetricaRepository : BasicRepository, IMetricaRepository
{
public MetricaRepository() : base ()
{
}


public MetricaRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public MetricaEN ReadOIDDefault (int id
                                 )
{
        MetricaEN metricaEN = null;

        try
        {
                SessionInitializeTransaction ();
                metricaEN = (MetricaEN)session.Get (typeof(MetricaNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return metricaEN;
}

public System.Collections.Generic.IList<MetricaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<MetricaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(MetricaNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<MetricaEN>();
                        else
                                result = session.CreateCriteria (typeof(MetricaNH)).List<MetricaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in MetricaRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (MetricaEN metrica)
{
        try
        {
                SessionInitializeTransaction ();
                MetricaNH metricaNH = (MetricaNH)session.Load (typeof(MetricaNH), metrica.Id);


                metricaNH.Estadisticas = metrica.Estadisticas;


                metricaNH.Fecha = metrica.Fecha;

                session.Update (metricaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in MetricaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public System.Collections.Generic.IList<MetricaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<MetricaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(MetricaNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<MetricaEN>();
                else
                        result = session.CreateCriteria (typeof(MetricaNH)).List<MetricaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in MetricaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

//Sin e: ReadID
//Con e: MetricaEN
public MetricaEN ReadID (int id
                         )
{
        MetricaEN metricaEN = null;

        try
        {
                SessionInitializeTransaction ();
                metricaEN = (MetricaEN)session.Get (typeof(MetricaNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return metricaEN;
}

public int New_ (MetricaEN metrica)
{
        MetricaNH metricaNH = new MetricaNH (metrica);

        try
        {
                SessionInitializeTransaction ();
                if (metrica.Usuario != null) {
                        for (int i = 0; i < metrica.Usuario.Count; i++) {
                                metrica.Usuario [i] = (ProyectoDSMGen.ApplicationCore.EN.Flicks.UsuarioEN)session.Load (typeof(ProyectoDSMGen.ApplicationCore.EN.Flicks.UsuarioEN), metrica.Usuario [i].Id);
                                metrica.Usuario [i].Metrica = metrica;
                        }
                }

                session.Save (metricaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in MetricaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return metricaNH.Id;
}

public void Modify (MetricaEN metrica)
{
        try
        {
                SessionInitializeTransaction ();
                MetricaNH metricaNH = (MetricaNH)session.Load (typeof(MetricaNH), metrica.Id);

                metricaNH.Estadisticas = metrica.Estadisticas;


                metricaNH.Fecha = metrica.Fecha;

                session.Update (metricaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in MetricaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (MetricaEN metrica)
{
        try
        {
                SessionInitializeTransaction ();
                MetricaNH metricaNH = (MetricaNH)session.Load (typeof(MetricaNH), metrica.Id);

                metricaNH.Estadisticas = metrica.Estadisticas;


                metricaNH.Fecha = metrica.Fecha;

                session.Update (metricaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ProyectoDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in MetricaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
