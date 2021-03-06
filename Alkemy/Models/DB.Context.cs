﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Alkemy.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SubjectsEntities : DbContext
    {
        public SubjectsEntities()
            : base("name=SubjectsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<Teachers> Teachers { get; set; }
        public virtual DbSet<Type_User> Type_User { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    
        public virtual int SP_Quota(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Quota", idParameter);
        }
    
        public virtual int SP_StudentxSubject(Nullable<int> id_Student, Nullable<int> id_Subject)
        {
            var id_StudentParameter = id_Student.HasValue ?
                new ObjectParameter("Id_Student", id_Student) :
                new ObjectParameter("Id_Student", typeof(int));
    
            var id_SubjectParameter = id_Subject.HasValue ?
                new ObjectParameter("Id_Subject", id_Subject) :
                new ObjectParameter("Id_Subject", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_StudentxSubject", id_StudentParameter, id_SubjectParameter);
        }
    }
}
