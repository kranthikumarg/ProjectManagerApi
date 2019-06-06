namespace DataAccessLayer
{
    using System.Data.Entity;
    public partial class ProjectManagerContext : DbContext
    {
        public ProjectManagerContext()
            : base("name=ProjectManagerContext")
        {
            Configuration.LazyLoadingEnabled = false;
            
        }
        public virtual DbSet<ParentTasks> ParentTasks { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParentTasks>()
                .Property(e => e.Parent_Task)
                .IsUnicode(false);
        }
    }
}
