#region Assemblies
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
#endregion

namespace DataAccessLayer
{
    public class ParentTaskRepository
    {
        #region Public Methods
     
        /// <summary>
        /// To add parent task
        /// </summary>
        /// <param name="oTask"></param>
        /// <returns></returns>
        public ParentTasks AddParentTask(ParentTasks oTask)
        {
            using (var context = new ProjectManagerContext())
            {
                oTask = context.ParentTasks.Add(oTask);
                context.SaveChanges();
                return oTask;
            }
        }

        /// <summary>
        /// To fetch all task
        /// </summary>
        /// <returns></returns>
        public List<ParentTasks> GetAllTasks()
        {
            using (var context = new ProjectManagerContext())
            {
                return context.ParentTasks.ToList();
            }
        }

        /// <summary>
        /// to update parent task
        /// </summary>
        /// <param name="oTask"></param>
        /// <returns></returns>
        public ParentTasks UpdateParentTask(ParentTasks oTask)
        {
            using (var context = new ProjectManagerContext())
            {
                oTask = context.ParentTasks.Attach(oTask);
                context.Entry(oTask).State = EntityState.Modified;
                context.SaveChanges();
                return oTask;
            }
        }
        #endregion    
    }
}
