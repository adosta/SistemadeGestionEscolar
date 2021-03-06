﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;

namespace SistemadeGestionEscolar.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        //private RegisterViewModel model;

        public ApplicationUser(RegisterViewModel model)
        {
            this.UserName = model.Email;
            this.Email = model.Email;
            this.nombre = model.nombre;
            this.apellidoPaterno = model.apellidoPaterno;
            this.apellidoMaterno = model.apellidoMaterno;
            this.fechaDeNacimiento = model.fechaDeNacimiento;    
           
        }

        public ApplicationUser()
        {

        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser>manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
       

        //Datos de profesor
        public string nombre { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public DateTime fechaDeNacimiento { get; set; }
        //public string carreraPreferida { get; set; }
        //public string grupoID { get; set; }
        //public string especialidad { get; set; }
        //public string grado { get; set; }
        public string rol { get; set; }


        public static class RoleNames
        {
            public static String ALUMNO = "Alumno";
            public static String ADMIN = "Admin";
            public static String PROFESOR = "Profesor";
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Alumno> alumnos { get; set; }
        public DbSet<Grupo> grupos { get; set; }
        public DbSet<Profesor> profesores { get; set; }
        public DbSet<Clase> clases { get; set; }
        public DbSet<Asignatura> asignaturas { get; set; }
        public DbSet<Carrera> carreras { get; set; }
        public DbSet<Calificacion> calificaciones { get; set; }
        
       


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //public System.Data.Entity.DbSet<SistemadeGestionEscolar.Models.ApplicationUser> ApplicationUsers { get; set; }
        
    }
}