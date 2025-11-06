

using ProyectoDSMGen.ApplicationCore.IRepository.Flicks;
using ProyectoDSMGen.Infraestructure.Repository.Flicks;
using ProyectoDSMGen.Infraestructure.CP;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoDSMGen.Infraestructure.Repository
{
public class UnitOfWorkRepository : GenericUnitOfWorkRepository
{
SessionCPNHibernate session;


public UnitOfWorkRepository(SessionCPNHibernate session)
{
        this.session = session;
}

public override IUsuarioRepository UsuarioRepository {
        get
        {
                this.usuariorepository = new UsuarioRepository ();
                this.usuariorepository.setSessionCP (session);
                return this.usuariorepository;
        }
}

public override IAdministradorRepository AdministradorRepository {
        get
        {
                this.administradorrepository = new AdministradorRepository ();
                this.administradorrepository.setSessionCP (session);
                return this.administradorrepository;
        }
}

public override IPeliculaRepository PeliculaRepository {
        get
        {
                this.pelicularepository = new PeliculaRepository ();
                this.pelicularepository.setSessionCP (session);
                return this.pelicularepository;
        }
}

public override IResenyaRepository ResenyaRepository {
        get
        {
                this.resenyarepository = new ResenyaRepository ();
                this.resenyarepository.setSessionCP (session);
                return this.resenyarepository;
        }
}

public override IListaRepository ListaRepository {
        get
        {
                this.listarepository = new ListaRepository ();
                this.listarepository.setSessionCP (session);
                return this.listarepository;
        }
}

public override IReporteRepository ReporteRepository {
        get
        {
                this.reporterepository = new ReporteRepository ();
                this.reporterepository.setSessionCP (session);
                return this.reporterepository;
        }
}

public override INotificacionRepository NotificacionRepository {
        get
        {
                this.notificacionrepository = new NotificacionRepository ();
                this.notificacionrepository.setSessionCP (session);
                return this.notificacionrepository;
        }
}

public override IMetricaRepository MetricaRepository {
        get
        {
                this.metricarepository = new MetricaRepository ();
                this.metricarepository.setSessionCP (session);
                return this.metricarepository;
        }
}
}
}

