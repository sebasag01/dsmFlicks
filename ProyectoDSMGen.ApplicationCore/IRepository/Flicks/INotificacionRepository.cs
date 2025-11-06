
using System;
using ProyectoDSMGen.ApplicationCore.EN.Flicks;
using ProyectoDSMGen.ApplicationCore.CP.Flicks;

namespace ProyectoDSMGen.ApplicationCore.IRepository.Flicks
{
public partial interface INotificacionRepository
{
void setSessionCP (GenericSessionCP session);

NotificacionEN ReadOIDDefault (int id
                               );

void ModifyDefault (NotificacionEN notificacion);

System.Collections.Generic.IList<NotificacionEN> ReadAllDefault (int first, int size);



int New_ (NotificacionEN notificacion);

void Modify (NotificacionEN notificacion);


void Destroy (int id
              );


System.Collections.Generic.IList<NotificacionEN> ReadAll (int first, int size);


NotificacionEN ReadID (int id
                       );


System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.NotificacionEN> ReadFilterEstado (int first, int size);


System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.NotificacionEN> ReadFIlterOrigen (int first, int size);
}
}
