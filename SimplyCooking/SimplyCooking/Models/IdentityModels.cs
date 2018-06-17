using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace SimplyCooking.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        //public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        //{
        //    // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        //    var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        //    // Add custom user claims here
        //    return userIdentity;
        //}
      
        public virtual List<Recipe> Recipes { get; set; }
        //public virtual List<Comment> Comments { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Recipe> Recipe { get; set; }
        //public DbSet<Comment> Comment { get; set; }
        public DbSet<Component> Component { get; set; }
        //public DbSet<Equipment> Equipment { get; set; }
        public DbSet<EquipmentV2> Equipment { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Typeofdish> Typeofdish { get; set; }
        public DbSet<Typeofmeal> Typeofmeal { get; set; }
        public DbSet<Photo> Photo { get; set; }      


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    var recipeEntity = modelBuilder.Entity<Recipe>();

        //    recipeEntity.HasMany(x => x.Photos)
        //        .WithRequired(x => x.Recipe)
        //        .HasForeignKey(x => x.RecipeId);

        //    var photoEntity = modelBuilder.Entity<Photo>();

        //    photoEntity.HasRequired(x => x.Recipe)
        //        .WithMany(x => x.Photos)
        //        .HasForeignKey(x => x.RecipeId);
        //}
    }
}