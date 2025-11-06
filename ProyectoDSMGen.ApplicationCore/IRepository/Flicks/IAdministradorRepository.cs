
using System;
using ProyectoDSMGen.ApplicationCore.EN.Flicks;
using ProyectoDSMGen.ApplicationCore.CP.Flicks;

namespace ProyectoDSMGen.ApplicationCore.IRepository.Flicks
{
public partial interface IAdministradorRepository
{
void setSessionCP (GenericSessionCP session);

AdministradorEN ReadOIDDefault (int id
                                );

void ModifyDefault (AdministradorEN administrador);

System.Collections.Generic.IList<AdministradorEN> ReadAllDefault (int first, int size);



int New_ (AdministradorEN administrador);

void Modify (AdministradorEN administrador);



void Destroy (int id
              );


System.Collections.Generic.IList<AdministradorEN> ReadAll (int first, int size);


AdministradorEN ReadID (int id
                        );
}
}
