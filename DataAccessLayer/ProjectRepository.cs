#region Assemblies
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
#endregion

namespace DataAccessLayer
{
    public class ProjectRepository
    {
        #region Public Methods

        /// <summary>
        /// Get all project
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Project> GetAllProject()
        {
            using (var context = new ProjectManagerContext())
            {
                return context.Projects.Where(x => x.Status == "Active").Include(x => x.Users).Include(x => x.Tasks).ToList();
            }
        }

        /// <summary>
        /// Add project
        /// </summary>
        /// <param name="oProject"></param>
        /// <returns></returns>
        public Project AddProject(Project oProject)
        {
            using (var context = new ProjectManagerContext())
            {
                oProject = context.Projects.Add(oProject);
                context.SaveChanges();
                return oProject;
            }
        }

        /// <summary>
        /// Update Project
        /// </summary>
        /// <param name="oProject"></param>
        /// <returns></returns>
        public Project UpdateProject(Project oProject)
        {
            using (var context = new ProjectManagerContext())
            {
                context.Projects.Attach(oProject);
                context.Entry(oProject).State = EntityState.Modified;
                context.SaveChanges();
                return oProject;
            }
        }
        #endregion
    }
}
