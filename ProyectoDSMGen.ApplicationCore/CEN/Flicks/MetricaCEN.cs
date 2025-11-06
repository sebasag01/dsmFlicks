

using System;
using System.Text;
using System.Collections.Generic;

using ProyectoDSMGen.ApplicationCore.Exceptions;

using ProyectoDSMGen.ApplicationCore.EN.Flicks;
using ProyectoDSMGen.ApplicationCore.IRepository.Flicks;


namespace ProyectoDSMGen.ApplicationCore.CEN.Flicks
{
/*
 *      Definition of the class MetricaCEN
 *
 */
public partial class MetricaCEN
{
private IMetricaRepository _IMetricaRepository;

public MetricaCEN(IMetricaRepository _IMetricaRepository)
{
        this._IMetricaRepository = _IMetricaRepository;
}

public IMetricaRepository get_IMetricaRepository ()
{
        return this._IMetricaRepository;
}

public System.Collections.Generic.IList<MetricaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<MetricaEN> list = null;

        list = _IMetricaRepository.ReadAll (first, size);
        return list;
}
public MetricaEN ReadID (int id
                         )
{
        MetricaEN metricaEN = null;

        metricaEN = _IMetricaRepository.ReadID (id);
        return metricaEN;
}

public int New_ (System.Collections.Generic.IList<int> p_usuario, string p_estadisticas, Nullable<DateTime> p_fecha)
{
        MetricaEN metricaEN = null;
        int oid;

        //Initialized MetricaEN
        metricaEN = new MetricaEN ();

        metricaEN.Usuario = new System.Collections.Generic.List<ProyectoDSMGen.ApplicationCore.EN.Flicks.UsuarioEN>();
        if (p_usuario != null) {
                foreach (int item in p_usuario) {
                        ProyectoDSMGen.ApplicationCore.EN.Flicks.UsuarioEN en = new ProyectoDSMGen.ApplicationCore.EN.Flicks.UsuarioEN ();
                        en.Id = item;
                        metricaEN.Usuario.Add (en);
                }
        }

        else{
                metricaEN.Usuario = new System.Collections.Generic.List<ProyectoDSMGen.ApplicationCore.EN.Flicks.UsuarioEN>();
        }

        metricaEN.Estadisticas = p_estadisticas;

        metricaEN.Fecha = p_fecha;



        oid = _IMetricaRepository.New_ (metricaEN);
        return oid;
}

public void Modify (int p_Metrica_OID, string p_estadisticas, Nullable<DateTime> p_fecha)
{
        MetricaEN metricaEN = null;

        //Initialized MetricaEN
        metricaEN = new MetricaEN ();
        metricaEN.Id = p_Metrica_OID;
        metricaEN.Estadisticas = p_estadisticas;
        metricaEN.Fecha = p_fecha;
        //Call to MetricaRepository

        _IMetricaRepository.Modify (metricaEN);
}

public void Destroy (int p_Metrica_OID, string p_estadisticas, Nullable<DateTime> p_fecha)
{
        MetricaEN metricaEN = null;

        //Initialized MetricaEN
        metricaEN = new MetricaEN ();
        metricaEN.Id = p_Metrica_OID;
        metricaEN.Estadisticas = p_estadisticas;
        metricaEN.Fecha = p_fecha;
        //Call to MetricaRepository

        _IMetricaRepository.Destroy (metricaEN);
}
}
}
