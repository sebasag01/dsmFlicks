
using System;
using ProyectoDSMGen.ApplicationCore.EN.Flicks;
using ProyectoDSMGen.ApplicationCore.CP.Flicks;

namespace ProyectoDSMGen.ApplicationCore.IRepository.Flicks
{
public partial interface IResenyaRepository
{
void setSessionCP (GenericSessionCP session);

ResenyaEN ReadOIDDefault (int id
                          );

void ModifyDefault (ResenyaEN resenya);

System.Collections.Generic.IList<ResenyaEN> ReadAllDefault (int first, int size);



int New_ (ResenyaEN resenya);

void Modify (ResenyaEN resenya);


void Destroy (int id
              );


System.Collections.Generic.IList<ResenyaEN> ReadAll (int first, int size);


ResenyaEN ReadID (int id
                  );


System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.ResenyaEN> ReadFilterByUsuario (int first, int size);


System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.ResenyaEN> ReadFIlterValoracion (int first, int size);


System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.ResenyaEN> ReadFilterByPelicula (int first, int size);
}
}
