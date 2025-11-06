
using System;
using ProyectoDSMGen.ApplicationCore.EN.Flicks;
using ProyectoDSMGen.ApplicationCore.CP.Flicks;

namespace ProyectoDSMGen.ApplicationCore.IRepository.Flicks
{
public partial interface IPeliculaRepository
{
void setSessionCP (GenericSessionCP session);

PeliculaEN ReadOIDDefault (int id
                           );

void ModifyDefault (PeliculaEN pelicula);

System.Collections.Generic.IList<PeliculaEN> ReadAllDefault (int first, int size);



int New_ (PeliculaEN pelicula);

void Modify (PeliculaEN pelicula);


void Destroy (int id
              );


System.Collections.Generic.IList<PeliculaEN> ReadAll (int first, int size);


PeliculaEN ReadID (int id
                   );


System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN> ReadFilterGenero (int first, int size);


System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN> ReadFilterValoracion (int first, int size);


System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN> ReadFIlterAnyo (int first, int size);



System.Collections.Generic.IList<ProyectoDSMGen.ApplicationCore.EN.Flicks.PeliculaEN> ReadFilterTitulo (int first, int size);
}
}
