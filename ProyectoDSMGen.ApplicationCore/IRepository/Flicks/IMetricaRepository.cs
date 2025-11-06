
using System;
using ProyectoDSMGen.ApplicationCore.EN.Flicks;
using ProyectoDSMGen.ApplicationCore.CP.Flicks;

namespace ProyectoDSMGen.ApplicationCore.IRepository.Flicks
{
public partial interface IMetricaRepository
{
void setSessionCP (GenericSessionCP session);

MetricaEN ReadOIDDefault (int id
                          );

void ModifyDefault (MetricaEN metrica);

System.Collections.Generic.IList<MetricaEN> ReadAllDefault (int first, int size);



System.Collections.Generic.IList<MetricaEN> ReadAll (int first, int size);


MetricaEN ReadID (int id
                  );


int New_ (MetricaEN metrica);

void Modify (MetricaEN metrica);


void Destroy (MetricaEN metrica);
}
}
