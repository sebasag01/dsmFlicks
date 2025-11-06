
using System;
using System.Text;
using System.Collections.Generic;
using ProyectoDSMGen.ApplicationCore.Exceptions;
using ProyectoDSMGen.ApplicationCore.EN.Flicks;
using ProyectoDSMGen.ApplicationCore.IRepository.Flicks;
using ProyectoDSMGen.ApplicationCore.CP.Flicks;
using ProyectoDSMGen.ApplicationCore.Enumerated.Flicks;


/*PROTECTED REGION ID(usingProyectoDSMGen.ApplicationCore.CEN.Flicks_Reporte_estadoReporte) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProyectoDSMGen.ApplicationCore.CEN.Flicks
{
public partial class ReporteCEN
{
public void EstadoReporte (int p_oid, EstadoReporteEnum p_estado) //anyadido p_estado
{
        /*PROTECTED REGION ID(ProyectoDSMGen.ApplicationCore.CEN.Flicks_Reporte_estadoReporte) ENABLED START*/

        // Write here your custom code...

        //throw new NotImplementedException ("Method EstadoReporte() not yet implemented.");
        
            ReporteEN ReporteEn = _IReporteRepository.ReadID (p_oid);
            if(ReporteEn == null)
            {
                throw new ModelException ("Notificacion con id " + p_oid + "no encontrada.");
            }

            // cambiar estado a resuelto y rechaz.
            //ReporteEn.Estado = EstadoReporteEnum.resuelto;
            //ReporteEn.Estado = EstadoReporteEnum.rechazado;
            switch (p_estado)
            {
                case EstadoReporteEnum.pendiente:
                    ReporteEn.Estado = EstadoReporteEnum.pendiente;
                    break;

                case EstadoReporteEnum.resuelto:
                    ReporteEn.Estado = EstadoReporteEnum.resuelto;
                    break;

                case EstadoReporteEnum.rechazado:
                    ReporteEn.Estado = EstadoReporteEnum.rechazado;
                    break;

                default:
                    throw new ModelException("Estado de reporte no válido.");
            }

            _IReporteRepository.Modify(ReporteEn);

            /*PROTECTED REGION END*/
        }
}
}
