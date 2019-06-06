#region Assemblies
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
#endregion

namespace DataAccessLayer
{
    public class TaskRepository
    {
        #region public Methods 
        /// <summary>
        /// To get all task
        /// </summary>
        /// <returns></returns>
        public List<Task> GetAllTasks()
        {
            using (var context = new ProjectManagerContext())
            {
                return context.Tasks.Include(x => x.User).Include(x => x.Project).Include(x => x.ParentTask).ToList();
            }
        }
        /// <summary>
        /// To add the task
        /// 
        /// </summary>
        /// <returns></returns>
        public Task AddTask(Task oTask)
        {
            using (var context = new ProjectManagerContext())
            {
                oTask = context.Tasks.Add(oTask);
                context.SaveChanges();
                return oTask;
            }
        }
        /// <summary>
        /// To update the task
        /// 
        /// </summary>
        /// <returns></returns>
        public Task UpdateTask(Task oTask)
        {
            using (var context = new ProjectManagerContext())
            {
                oTask = context.Tasks.Attach(oTask);
                context.Entry(oTask).State = EntityState.Modified;
                context.SaveChanges();
                return oTask;
            }
        }
        #endregion

    }
}
