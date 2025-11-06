using System;
using System.Text;
using System.Collections.Generic;
using ProyectoDSMGen.ApplicationCore.Exceptions;
using ProyectoDSMGen.ApplicationCore.EN.Flicks;
using ProyectoDSMGen.ApplicationCore.IRepository.Flicks;


/*PROTECTED REGION ID(usingProyectoDSMGen.ApplicationCore.CEN.Flicks_Reporte_new_) ENABLED START*/
// references to other libraries
/*PROTECTED REGION END*/

namespace ProyectoDSMGen.ApplicationCore.CEN.Flicks
{
public partial class ReporteCEN
{
public int New_ (string p_motivo, string p_fecha, int p_usuario, System.Collections.Generic.IList<int> p_resenya, int p_administrador)
{
        /*PROTECTED REGION ID(ProyectoDSMGen.ApplicationCore.CEN.Flicks_Reporte_new__customized) START*/

        ReporteEN reporteEN = null;

        int oid;

        //Initialized ReporteEN
        reporteEN = new ReporteEN ();
        reporteEN.Motivo = p_motivo;

        reporteEN.Fecha = p_fecha;


        if (p_usuario != -1) {
                reporteEN.Usuario = new ProyectoDSMGen.ApplicationCore.EN.Flicks.UsuarioEN ();
                reporteEN.Usuario.Id = p_usuario;
        }


        reporteEN.Resenya = new System.Collections.Generic.List<ProyectoDSMGen.ApplicationCore.EN.Flicks.ResenyaEN>();
        if (p_resenya != null) {
                foreach (int item in p_resenya) {
                        ProyectoDSMGen.ApplicationCore.EN.Flicks.ResenyaEN en = new ProyectoDSMGen.ApplicationCore.EN.Flicks.ResenyaEN ();
                        en.Id = item;
                        reporteEN.Resenya.Add (en);
                }
        }

        else{
                reporteEN.Resenya = new System.Collections.Generic.List<ProyectoDSMGen.ApplicationCore.EN.Flicks.ResenyaEN>();
        }


        if (p_administrador != -1) {
                reporteEN.Administrador = new ProyectoDSMGen.ApplicationCore.EN.Flicks.AdministradorEN ();
                reporteEN.Administrador.Id = p_administrador;
        }

        //Call to ReporteRepository

        oid = _IReporteRepository.New_ (reporteEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
