
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
public partial class ResenyaCP : GenericBasicCP
{
public ResenyaCP(GenericSessionCP currentSession)
        : base (currentSession)
{
}

public ResenyaCP(GenericSessionCP currentSession, GenericUnitOfWorkUtils unitUtils)
        : base (currentSession, unitUtils)
{
}
}
}
