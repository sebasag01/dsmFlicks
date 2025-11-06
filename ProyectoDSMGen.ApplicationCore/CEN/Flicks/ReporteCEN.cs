

using System;
using System.Text;
using System.Collections.Generic;

using ProyectoDSMGen.ApplicationCore.Exceptions;

using ProyectoDSMGen.ApplicationCore.EN.Flicks;
using ProyectoDSMGen.ApplicationCore.IRepository.Flicks;


namespace ProyectoDSMGen.ApplicationCore.CEN.Flicks
{
/*
 *      Definition of the class ReporteCEN
 *
 */
public partial class ReporteCEN
{
private IReporteRepository _IReporteRepository;

public ReporteCEN(IReporteRepository _IReporteRepository)
{
        this._IReporteRepository = _IReporteRepository;
}

public IReporteRepository get_IReporteRepository ()
{
        return this._IReporteRepository;
}

public void Modify (int p_Reporte_OID, string p_motivo, ProyectoDSMGen.ApplicationCore.Enumerated.Flicks.EstadoReporteEnum p_estado, string p_fecha)
{
        ReporteEN reporteEN = null;

        //Initialized ReporteEN
        reporteEN = new ReporteEN ();
        reporteEN.Id = p_Reporte_OID;
        reporteEN.Motivo = p_motivo;
        reporteEN.Estado = p_estado;
        reporteEN.Fecha = p_fecha;
        //Call to ReporteRepository

        _IReporteRepository.Modify (reporteEN);
}

public void Destroy (int id
                     )
{
        _IReporteRepository.Destroy (id);
}

public System.Collections.Generic.IList<ReporteEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ReporteEN> list = null;

        list = _IReporteRepository.ReadAll (first, size);
        return list;
}
public ReporteEN ReadID (int id
                         )
{
        ReporteEN reporteEN = null;

        reporteEN = _IReporteRepository.ReadID (id);
        return reporteEN;
}

public System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.ReporteEN> ReadFilterEstado (int first, int size)
{
        return _IReporteRepository.ReadFilterEstado (first, size);
}
}
}
