using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DBFixtureRepo
    {
        public void DeleteTestData()  
        {

            using (var context = new ProjectManagerContext())
            {
                var Task = context.Tasks.FirstOrDefault(x => x.Task1 == "XUnit-Test");
                if (Task != null)
                {
                    context.Tasks.Remove(Task);
                    context.SaveChanges();
                }

                var parentTask = context.ParentTasks.FirstOrDefault(x => x.Parent_Task == "XUnit-Test");
                if (parentTask != null)
                {
                    context.ParentTasks.Remove(parentTask);
                    context.SaveChanges();
                }

                var oUser = context.Users.FirstOrDefault(x => x.First_Name == "XUnit-Test");
                if (oUser != null)
                {
                    context.Users.Remove(oUser);
                    context.SaveChanges();
                }

                var Projects = context.Projects.FirstOrDefault(x => x.Project1 == "XUnit-Test");
                if (Projects != null)
                {
                    context.Projects.Remove(Projects);
                    context.SaveChanges();
                }
                

            }
        }
    }
}
