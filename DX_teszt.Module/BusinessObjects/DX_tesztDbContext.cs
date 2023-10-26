using DevExpress.ExpressApp.EFCore.Updating;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.ExpressApp.Design;
using DevExpress.ExpressApp.EFCore.DesignTime;

namespace DX_teszt.Module.BusinessObjects;

// This code allows our Model Editor to get relevant EF Core metadata at design time.
// For details, please refer to https://supportcenter.devexpress.com/ticket/details/t933891.
public class DX_tesztContextInitializer : DbContextTypesInfoInitializerBase {
	protected override DbContext CreateDbContext() {
		var optionsBuilder = new DbContextOptionsBuilder<DX_tesztEFCoreDbContext>()
            .UseSqlServer(";")
            .UseChangeTrackingProxies()
            .UseObjectSpaceLinkProxies();
        return new DX_tesztEFCoreDbContext(optionsBuilder.Options);
	}
}
//This factory creates DbContext for design-time services. For example, it is required for database migration.
public class DX_tesztDesignTimeDbContextFactory : IDesignTimeDbContextFactory<DX_tesztEFCoreDbContext>
{
    public DX_tesztEFCoreDbContext CreateDbContext(string[] args)
    {
        // Throw new InvalidOperationException ("Make sure that the database connection string and connection provider are correct. After that, uncomment the code below and remove this exception.")
        var optionsBuilder = new DbContextOptionsBuilder<DX_tesztEFCoreDbContext>();
        optionsBuilder.UseSqlServer("Integrated Security=SSPI;Pooling=false;Data Source=(localdb)\\mssqllocaldb;Initial Catalog=DX_teszt");
        //Automatically implements the INotifyPropertyChanged interface in the business objects
        optionsBuilder.UseChangeTrackingProxies();
        optionsBuilder.UseObjectSpaceLinkProxies();
        return new DX_tesztEFCoreDbContext(optionsBuilder.Options);
    }
}
[TypesInfoInitializer(typeof(DX_tesztContextInitializer))]
public class DX_tesztEFCoreDbContext : DbContext {
	public DX_tesztEFCoreDbContext(DbContextOptions<DX_tesztEFCoreDbContext> options) : base(options) {
	}
    //public DbSet<ModuleInfo> ModulesInfo { get; set; }
    public DbSet<ModelDifferenceAspect> ModelDifferenceAspects { get; set; }
    public DbSet<OrderInHeader> OrderInHeaders { get; set; }
    public DbSet<OrderInRows> OrderInRows { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues);
        modelBuilder.UsePropertyAccessMode(PropertyAccessMode.PreferFieldDuringConstruction);
    }
}
