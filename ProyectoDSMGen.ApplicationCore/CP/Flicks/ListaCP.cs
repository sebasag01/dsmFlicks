
using System;
using System.Text;
using System.Collections.Generic;
using ProyectoDSMGen.ApplicationCore.Exceptions;
using ProyectoDSMGen.ApplicationCore.EN.Flicks;
using ProyectoDSMGen.ApplicationCore.IRepository.Flicks;
using ProyectoDSMGen.ApplicationCore.CEN.Flicks;
using ProyectoDSMGen.ApplicationCore.Utils;



namespace ProyectoDSMGen.ApplicationCore.CP.Flicks
{
public partial class ListaCP : GenericBasicCP
{
public ListaCP(GenericSessionCP currentSession)
        : base (currentSession)
{
}

public ListaCP(GenericSessionCP currentSession, GenericUnitOfWorkUtils unitUtils)
        : base (currentSession, unitUtils)
{
}
}
}
