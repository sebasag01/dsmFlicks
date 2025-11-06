
using System;
using ProyectoDSMGen.ApplicationCore.EN.Flicks;
using ProyectoDSMGen.ApplicationCore.CP.Flicks;

namespace ProyectoDSMGen.ApplicationCore.IRepository.Flicks
{
public partial interface IListaRepository
{
void setSessionCP (GenericSessionCP session);

ListaEN ReadOIDDefault (int id
                        );

void ModifyDefault (ListaEN lista);

System.Collections.Generic.IList<ListaEN> ReadAllDefault (int first, int size);



int New_ (ListaEN lista);

void Modify (ListaEN lista);


void Destroy (int id
              );


System.Collections.Generic.IList<ListaEN> ReadAll (int first, int size);


ListaEN ReadID (int id
                );


void AnyadirPelicula (int p_Lista_OID, System.Collections.Generic.IList<int> p_pelicula_OIDs);
}
}
