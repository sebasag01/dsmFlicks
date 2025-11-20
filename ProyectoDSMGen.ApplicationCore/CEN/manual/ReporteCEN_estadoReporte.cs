
using System;
using System.Text;
using System.Collections.Generic;
using ProyectoDSMGen.ApplicationCore.Exceptions;
using ProyectoDSMGen.ApplicationCore.EN.Flicks;
using ProyectoDSMGen.ApplicationCore.IRepository.Flicks;


/*PROTECTED REGION ID(usingProyectoDSMGen.ApplicationCore.CEN.Flicks_Reporte_estadoReporte) ENABLED START*/
// references to other libraries
/*PROTECTED REGION END*/

namespace ProyectoDSMGen.ApplicationCore.CEN.Flicks
{
public partial class ReporteCEN
{
public void EstadoReporte (int p_oid)
{
        /*PROTECTED REGION ID(ProyectoDSMGen.ApplicationCore.CEN.Flicks_Reporte_estadoReporte) ENABLED START*/

        // Write here your custom code...


        //throw new NotImplementedException ("Method EstadoReporte() not yet implemented.");

        ReporteEN ReporteEn = _IReporteRepository.ReadID (p_oid);

        if (ReporteEn == null) {
                throw new ModelException ("Notificacion con id " + p_oid + "no encontrada.");
        }

        // If caller did not provide a desired state via method parameter (signature fixed),
        // attempt to derive the desired state here. By default use the current state.
        ProyectoDSMGen.ApplicationCore.Enumerated.Flicks.EstadoReporteEnum p_estado = ReporteEn.Estado;

        // cambiar estado a resuelto y rechaz.
        //ReporteEn.Estado = EstadoReporteEnum.resuelto;
        //ReporteEn.Estado = EstadoReporteEnum.rechazado;
        switch (p_estado) {
        case ProyectoDSMGen.ApplicationCore.Enumerated.Flicks.EstadoReporteEnum.pendiente:
                ReporteEn.Estado = ProyectoDSMGen.ApplicationCore.Enumerated.Flicks.EstadoReporteEnum.pendiente;
                break;

        case ProyectoDSMGen.ApplicationCore.Enumerated.Flicks.EstadoReporteEnum.resuelto:
                ReporteEn.Estado = ProyectoDSMGen.ApplicationCore.Enumerated.Flicks.EstadoReporteEnum.resuelto;
                break;

        case ProyectoDSMGen.ApplicationCore.Enumerated.Flicks.EstadoReporteEnum.rechazado:
                ReporteEn.Estado = ProyectoDSMGen.ApplicationCore.Enumerated.Flicks.EstadoReporteEnum.rechazado;
                break;

        default:
                throw new ModelException ("Estado de reporte no valido.");
        }

        _IReporteRepository.Modify (ReporteEn);

        /*PROTECTED REGION END*/
}
}
}
