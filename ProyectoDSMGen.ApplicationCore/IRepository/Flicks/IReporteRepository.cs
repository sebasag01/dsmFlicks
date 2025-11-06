
using System;
using ProyectoDSMGen.ApplicationCore.EN.Flicks;
using ProyectoDSMGen.ApplicationCore.CP.Flicks;

namespace ProyectoDSMGen.ApplicationCore.IRepository.Flicks
{
public partial interface IReporteRepository
{
void setSessionCP (GenericSessionCP session);

ReporteEN ReadOIDDefault (int id
                          );

void ModifyDefault (ReporteEN reporte);

System.Collections.Generic.IList<ReporteEN> ReadAllDefault (int first, int size);



int New_ (ReporteEN reporte);

void Modify (ReporteEN reporte);


void Destroy (int id
              );


System.Collections.Generic.IList<ReporteEN> ReadAll (int first, int size);


ReporteEN ReadID (int id
                  );


System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.ReporteEN> ReadFilterEstado (int first, int size);
}
}
