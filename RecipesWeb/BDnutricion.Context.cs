﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RecipesWeb
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BDnutricionEntities : DbContext
    {
        public BDnutricionEntities()
            : base("name=BDnutricionEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Administrador> Administrador { get; set; }
        public virtual DbSet<Ingrediente> Ingrediente { get; set; }
        public virtual DbSet<IngredienteListaSuper> IngredienteListaSuper { get; set; }
        public virtual DbSet<ListaSuper> ListaSuper { get; set; }
        public virtual DbSet<Nutriologo> Nutriologo { get; set; }
        public virtual DbSet<PlanDia> PlanDia { get; set; }
        public virtual DbSet<Receta> Receta { get; set; }
        public virtual DbSet<RecetaEtiqueta> RecetaEtiqueta { get; set; }
        public virtual DbSet<RecetaIngrediente> RecetaIngrediente { get; set; }
        public virtual DbSet<RegistroReceta> RegistroReceta { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
    }
}