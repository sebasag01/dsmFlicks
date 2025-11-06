
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoDSMGen.ApplicationCore.IRepository.Flicks
{
public abstract class GenericUnitOfWorkRepository
{
protected IUsuarioRepository usuariorepository;
protected IAdministradorRepository administradorrepository;
protected IPeliculaRepository pelicularepository;
protected IResenyaRepository resenyarepository;
protected IListaRepository listarepository;
protected IReporteRepository reporterepository;
protected INotificacionRepository notificacionrepository;
protected IMetricaRepository metricarepository;


public abstract IUsuarioRepository UsuarioRepository {
        get;
}
public abstract IAdministradorRepository AdministradorRepository {
        get;
}
public abstract IPeliculaRepository PeliculaRepository {
        get;
}
public abstract IResenyaRepository ResenyaRepository {
        get;
}
public abstract IListaRepository ListaRepository {
        get;
}
public abstract IReporteRepository ReporteRepository {
        get;
}
public abstract INotificacionRepository NotificacionRepository {
        get;
}
public abstract IMetricaRepository MetricaRepository {
        get;
}
}
}
