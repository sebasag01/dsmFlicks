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
 CREATE LOGIN [" + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
 END" ;

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
 // Initialising CENs
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

 // Seed de ejemplo: crea un administrador, un usuario, varias peliculas y reseñas
 int adminId = -1;
 int userId = -1;

 try {
 adminId = administradorcen.New_("Admin", "admin@example.com", "adminpass");
 } catch (Exception) {
 // ignore if creation fails
 }

 try {
 userId = usuariocen.New_("Usuario", "user@example.com", "", "User bio", false, "userpass");
 } catch (Exception) {
 // ignore if creation fails
 }

 var peliculasEjemplo = new List<(string Titulo, string TituloOriginal, int Anyo, int Duracion, string Pais, string Director, string Genero, string Sinopsis)>() {
 ("Prueba Pelicula", "Prueba Original",2025,100, "Espana", "Director X", "Drama", "Sinopsis de prueba"),
 ("Aventura Espacial", "Space Adventure",2023,130, "EEUU", "Jane Doe", "Ciencia Ficcion", "Una odisea espacial llena de accion"),
 ("Comedia Local", "Local Comedy",2021,95, "Espana", "Juan Perez", "Comedia", "Risas y enredos en la ciudad"),
 ("Documental Naturaleza", "Nature Doc",2019,60, "Reino Unido", "Anne Green", "Documental", "Bellezas naturales alrededor del mundo"),
 ("Thriller Nocturno", "Night Thriller",2024,110, "Francia", "Pierre Noir", "Thriller", "Intriga y suspense en la noche")
 };

 var peliculaIds = new List<int>();

 foreach (var p in peliculasEjemplo) {
 int pid = -1;
 try {
 pid = peliculacen.New_(p.Titulo, p.TituloOriginal, p.Anyo, p.Duracion, p.Pais, p.Director, p.Genero, p.Sinopsis,0.0f, adminId);
 } catch (Exception) {
 // ignore
 }

 if (pid <=0) continue;
 peliculaIds.Add(pid);

 // añadir reseñas de ejemplo
 var puntuaciones = new List<int>();

 if (p.Titulo == "Prueba Pelicula") {
 resenyacen.New_(4, "Buena", DateTime.Now, pid, userId);
 resenyacen.New_(5, "Excelente", DateTime.Now, pid, userId);
 resenyacen.New_(3, "Correcta", DateTime.Now, pid, userId);
 puntuaciones.AddRange(new[] {4,5,3});
 } else if (p.Titulo == "Aventura Espacial") {
 resenyacen.New_(5, "Impresionante", DateTime.Now, pid, userId);
 resenyacen.New_(4, "Muy buena", DateTime.Now, pid, userId);
 puntuaciones.AddRange(new[] {5,4});
 } else if (p.Titulo == "Comedia Local") {
 resenyacen.New_(3, "Entretenida", DateTime.Now, pid, userId);
 resenyacen.New_(4, "Divertida", DateTime.Now, pid, userId);
 resenyacen.New_(2, "No tanto", DateTime.Now, pid, userId);
 puntuaciones.AddRange(new[] {3,4,2});
 } else if (p.Titulo == "Documental Naturaleza") {
 resenyacen.New_(5, "Asombroso", DateTime.Now, pid, userId);
 puntuaciones.Add(5);
 } else if (p.Titulo == "Thriller Nocturno") {
 resenyacen.New_(4, "Tenso", DateTime.Now, pid, userId);
 resenyacen.New_(4, "Mantiene el ritmo", DateTime.Now, pid, userId);
 puntuaciones.AddRange(new[] {4,4});
 }

 // calcular media y actualizar pelicula
 float media =0.0f;
 if (puntuaciones.Count >0) {
 float suma =0f;
 foreach (var v in puntuaciones) suma += v;
 media = suma / puntuaciones.Count;

 try {
 var peliculaToUpdate = peliculacen.ReadID(pid);
 if (peliculaToUpdate != null) {
 peliculacen.Modify(pid,
 peliculaToUpdate.Titulo,
 peliculaToUpdate.TituloOriginal,
 peliculaToUpdate.Anyo,
 peliculaToUpdate.Duracion,
 peliculaToUpdate.Pais,
 peliculaToUpdate.Director,
 peliculaToUpdate.Genero,
 peliculaToUpdate.Sinopsis,
 media);
 }
 } catch (Exception) {
 // ignore
 }
 }
 }

 System.Console.WriteLine("Seed inicial insertado (InitializeData)");

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


//wakakamole