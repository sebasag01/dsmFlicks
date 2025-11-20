
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ProyectoDSMGen.ApplicationCore.EN.Flicks;
using ProyectoDSMGen.ApplicationCore.CEN.Flicks;
using ProyectoDSMGen.Infraestructure.Repository.Flicks;
using ProyectoDSMGen.Infraestructure.CP;
using ProyectoDSMGen.ApplicationCore.Exceptions;

using ProyectoDSMGen.ApplicationCore.CP.Flicks;
using ProyectoDSMGen.Infraestructure.Repository;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local)\sqlexpress; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception)
        {
                throw;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        try
        {
                // Initialising  CENs
                UsuarioRepository usuariorepository = new UsuarioRepository ();
                UsuarioCEN usuariocen = new UsuarioCEN (usuariorepository);
                AdministradorRepository administradorrepository = new AdministradorRepository ();
                AdministradorCEN administradorcen = new AdministradorCEN (administradorrepository);
                PeliculaRepository pelicularepository = new PeliculaRepository ();
                PeliculaCEN peliculacen = new PeliculaCEN (pelicularepository);
                ResenyaRepository resenyarepository = new ResenyaRepository ();
                ResenyaCEN resenyacen = new ResenyaCEN (resenyarepository);
                ListaRepository listarepository = new ListaRepository ();
                ListaCEN listacen = new ListaCEN (listarepository);
                ReporteRepository reporterepository = new ReporteRepository ();
                ReporteCEN reportecen = new ReporteCEN (reporterepository);
                NotificacionRepository notificacionrepository = new NotificacionRepository ();
                NotificacionCEN notificacioncen = new NotificacionCEN (notificacionrepository);
                MetricaRepository metricarepository = new MetricaRepository ();
                MetricaCEN metricacen = new MetricaCEN (metricarepository);



                /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/

                // You must write the initialisation of the entities inside the PROTECTED comments.
                // IMPORTANT:please do not delete them.

                // admin y usuario
                int adminId = administradorcen.New_ ("Admin", "admin@example.com", "adminpass");
                int userId = usuariocen.New_ ("Usuario", "user@example.com", "", "Bio de usuario", false, "userpass");

                // Creaci�n de varias pel�culas de ejemplo
                var peliculasEjemplo = new List<(string Titulo, string TituloOriginal, int Anyo, int Duracion, string Pais, string Director, string Genero, string Sinopsis)>() {
                        ("Prueba Pelicula", "Prueba Original", 2025, 100, "Espa�a", "Director X", "Drama", "Sinopsis de prueba"),
                        ("Aventura Espacial", "Space Adventure", 2023, 130, "EEUU", "Jane Doe", "Ciencia Ficci�n", "Una odisea espacial llena de acci�n"),
                        ("Comedia Local", "Local Comedy", 2021, 95, "Espa�a", "Juan P�rez", "Comedia", "Risas y enredos en la ciudad"),
                        ("Documental Naturaleza", "Nature Doc", 2019, 60, "Reino Unido", "Anne Green", "Documental", "Bellezas naturales alrededor del mundo"),
                        ("Thriller Nocturno", "Night Thriller", 2024, 110, "Francia", "Pierre Noir", "Thriller", "Intriga y suspense en la noche")
                };

                var peliculaIds = new List<int>();
                var resenyasIds = new List<int>();

                // Crear pel�culas y asociar rese�as de ejemplo
                foreach (var p in peliculasEjemplo) {
                        int pid = peliculacen.New_ (p.Titulo, p.TituloOriginal, p.Anyo, p.Duracion, p.Pais, p.Director, p.Genero, p.Sinopsis, 0.0f, adminId);
                        peliculaIds.Add (pid);

                        // A�adir entre 2 y 4 rese�as de ejemplo por pel�cula
                        var puntuaciones = new List<int>();

                        if (p.Titulo == "Prueba Pelicula") {
                                int rid1 = resenyacen.New_ (4, "Buena", DateTime.Now, pid, userId);
                                int rid2 = resenyacen.New_ (5, "Excelente", DateTime.Now, pid, userId);
                                int rid3 = resenyacen.New_ (3, "Correcta", DateTime.Now, pid, userId);
                                resenyasIds.AddRange (new[] { rid1, rid2, rid3 });
                                puntuaciones.AddRange (new[] { 4, 5, 3 });
                        }
                        else if (p.Titulo == "Aventura Espacial") {
                                int rid1 = resenyacen.New_ (5, "Impresionante", DateTime.Now, pid, userId);
                                int rid2 = resenyacen.New_ (4, "Muy buena", DateTime.Now, pid, userId);
                                resenyasIds.AddRange (new[] { rid1, rid2 });
                                puntuaciones.AddRange (new[] { 5, 4 });
                        }
                        else if (p.Titulo == "Comedia Local") {
                                int rid1 = resenyacen.New_ (3, "Entretenida", DateTime.Now, pid, userId);
                                int rid2 = resenyacen.New_ (4, "Divertida", DateTime.Now, pid, userId);
                                int rid3 = resenyacen.New_ (2, "No tanto", DateTime.Now, pid, userId);
                                resenyasIds.AddRange (new[] { rid1, rid2, rid3 });
                                puntuaciones.AddRange (new[] { 3, 4, 2 });
                        }
                        else if (p.Titulo == "Documental Naturaleza") {
                                int rid1 = resenyacen.New_ (5, "Asombroso", DateTime.Now, pid, userId);
                                resenyasIds.Add (rid1);
                                puntuaciones.Add (5);
                        }
                        else if (p.Titulo == "Thriller Nocturno") {
                                int rid1 = resenyacen.New_ (4, "Tenso", DateTime.Now, pid, userId);
                                int rid2 = resenyacen.New_ (4, "Mantiene el ritmo", DateTime.Now, pid, userId);
                                resenyasIds.AddRange (new[] { rid1, rid2 });
                                puntuaciones.AddRange (new[] { 4, 4 });
                        }

                        // Calcular media usando rese�as insertadas
                        float media = 0.0f;
                        try {
                                if (puntuaciones.Count > 0) {
                                        float suma = 0f;
                                        foreach (var v in puntuaciones) suma += v;
                                        media = suma / puntuaciones.Count;
                                }
                                else {
                                        var peliculaEN = peliculacen.ReadID (pid);
                                        if (peliculaEN != null) media = peliculaEN.ValoracionMedia;
                                }

                                var peliculaToUpdate = peliculacen.ReadID (pid);
                                if (peliculaToUpdate != null) {
                                        peliculacen.Modify (pid,
                                                peliculaToUpdate.Titulo,
                                                peliculaToUpdate.TituloOriginal,
                                                peliculaToUpdate.Anyo,
                                                peliculaToUpdate.Duracion,
                                                peliculaToUpdate.Pais,
                                                peliculaToUpdate.Director,
                                                peliculaToUpdate.Genero,
                                                peliculaToUpdate.Sinopsis,
                                                media);

                                        System.Console.WriteLine ($"Pelicula {pid} ('{peliculaToUpdate.Titulo}') actualizada: ValoracionMedia = {media}");
                                }
                        }
                        catch (Exception ex) {
                                System.Console.WriteLine ($"Error actualizando media para pelicula {pid}: {ex.Message}");
                        }
                }

                // ============================================
                // PRUEBA DE M�TODOS MANUALES
                // ============================================

                // 1. Crear reportes para probar ReporteCEN.EstadoReporte
                System.Console.WriteLine ("\n--- Creando reportes para pruebas ---");
                var reporteIds = new List<int>();

                if (resenyasIds.Count >= 2) {
                        var reporteId1 = reportecen.New_ (
                                "Contenido inapropiado en rese�a",
                                DateTime.Now.ToString (),
                                userId,
                                new List<int> { resenyasIds [0] },
                                -1
                                );
                        reporteIds.Add (reporteId1);
                        System.Console.WriteLine ($"Reporte 1 creado con ID: {reporteId1} (pendiente)");

                        var reporteId2 = reportecen.New_ (
                                "Spoilers sin advertencia",
                                DateTime.Now.ToString (),
                                userId,
                                new List<int> { resenyasIds [1] },
                                -1
                                );
                        reporteIds.Add (reporteId2);
                        System.Console.WriteLine ($"Reporte 2 creado con ID: {reporteId2} (pendiente)");
                }

                // 2. Crear notificaciones de prueba para probar NotificacionCEN.CambiarEstadoNotificacion
                System.Console.WriteLine ("\n--- Creando notificaciones para pruebas ---");
                var notificacionIds = new List<int>();

                var notif1 = notificacioncen.New_ (
                        userId,
                        "Tienes un nuevo reporte por revisar",
                        DateTime.Now,
                        ProyectoDSMGen.ApplicationCore.Enumerated.Flicks.TipoNotificacionEnum.reporte,
                        0
                        );
                notificacionIds.Add (notif1);
                System.Console.WriteLine ($"Notificaci�n 1 creada con ID: {notif1} (tipo: reporte)");

                var notif2 = notificacioncen.New_ (
                        userId,
                        "Tu rese�a ha sido reportada",
                        DateTime.Now,
                        ProyectoDSMGen.ApplicationCore.Enumerated.Flicks.TipoNotificacionEnum.anuncio,
                        0
                        );
                notificacionIds.Add (notif2);
                System.Console.WriteLine ($"Notificaci�n 2 creada con ID: {notif2} (tipo: anuncio)");

                // 3. Informaci�n sobre pel�culas para prueba de CalcularValoracionMedia
                System.Console.WriteLine ("\n--- Pel�culas con rese�as para pruebas de valoraci�n media ---");
                foreach (var peliculaId in peliculaIds) {
                        var pelicula = peliculacen.ReadID (peliculaId);
                        if (pelicula != null) {
                                System.Console.WriteLine ($"Pel�cula '{pelicula.Titulo}' (ID: {peliculaId}) - ValoracionMedia: {pelicula.ValoracionMedia}");
                        }
                }

                System.Console.WriteLine ("\n========================================");
                System.Console.WriteLine ("RESUMEN DE DATOS DE PRUEBA CREADOS");
                System.Console.WriteLine ("========================================");
                System.Console.WriteLine ($"Total de pel�culas creadas: {peliculaIds.Count}");
                System.Console.WriteLine ($"Total de rese�as creadas: {resenyasIds.Count}");
                System.Console.WriteLine ($"Total de reportes creados: {reporteIds.Count}");
                System.Console.WriteLine ($"Total de notificaciones creadas: {notificacionIds.Count}");

                System.Console.WriteLine ("\n========================================");
                System.Console.WriteLine ("PRUEBAS DE M�TODOS MANUALES A EJECUTAR");
                System.Console.WriteLine ("========================================");
                System.Console.WriteLine ("1. NotificacionCEN.CambiarEstadoNotificacion(id)");
                System.Console.WriteLine ($"   - Cambia el estado de una notificaci�n a 'le�da'");
                System.Console.WriteLine ($"   - Ejemplo: CambiarEstadoNotificacion({(notificacionIds.Count > 0 ? notificacionIds[0] : "ID_NOTIFICACION ")})");

                System.Console.WriteLine ("\n2. ReporteCEN.EstadoReporte(id)");
                System.Console.WriteLine ($"   - Consulta y mantiene el estado actual del reporte");
                System.Console.WriteLine ($"   - Ejemplo: EstadoReporte({(reporteIds.Count > 0 ? reporteIds[0] : "ID_REPORTE ")})");

                System.Console.WriteLine ("\n3. AdministradorCP.ResolverReporteEnviarNotificacion(adminId)");
                System.Console.WriteLine ($"   - Resuelve todos los reportes pendientes y env�a notificaciones");
                System.Console.WriteLine ($"   - Ejemplo: ResolverReporteEnviarNotificacion({adminId})");
                System.Console.WriteLine ($"   - Reportes disponibles para resolver: {reporteIds.Count}");

                System.Console.WriteLine ("\n4. PeliculaCP.CalcularValoracionMedia(peliculaId)");
                System.Console.WriteLine ($"   - Calcula la media de puntuaciones de rese�as");
                System.Console.WriteLine ($"   - Ejemplo: CalcularValoracionMedia({(peliculaIds.Count > 0 ? peliculaIds[0] : "ID_PELICULA ")})");
                System.Console.WriteLine ($"   - Pel�culas disponibles: {peliculaIds.Count}");

                /*PROTECTED REGION END*/
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw;
        }
}
}
}
