
#region Assemblies
using BusinessEntities;
using DataAccessLayer;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace BusinessLayer
{
    public class ProjectBusiness
    {
       

        ProjectRepository repoProject = new ProjectRepository();


       


        /// <summary>
        /// To update the project details to db
        /// </summary>
        /// <param name="oProj"></param>
        /// <returns></returns>
        public ProjectUpdateModel UpdateProject(ProjectModel project_Model)
        {
            StatusModel _status = new StatusModel();
            Project proj = new Project()
            {
                End_Date = project_Model.End_Date,
                Priority = project_Model.Priority,
                Project1 = project_Model.ProjectName,
                Start_Date = project_Model.Start_Date,
                Status = project_Model.Status

            };
            if (project_Model.Project_ID == 0)
            {
                proj = repoProject.AddProject(proj);
                _status = new StatusModel() { Message = "Project details are added successfully", Result = true };
            }
            else
            {
                proj.Project_ID = project_Model.Project_ID;
                proj = repoProject.UpdateProject(proj);
                _status = new StatusModel() { Message = "Project details are updated successfully", Result = true };
            }
            if (project_Model.Manager_ID != null)
            {
                UserRepository repoUser = new UserRepository();
                User ouser = repoUser.GetUserById(project_Model.Manager_ID.Value);
                ouser.Project_ID = proj.Project_ID;
                repoUser.UpdateUser(ouser);
            }
            return new ProjectUpdateModel()
            {
                status = _status,
                project = new BusinessEntities.ProjectModel
                {
                    Project_ID = proj.Project_ID,
                    ProjectName = proj.Project1,
                    Priority = proj.Priority,
                    End_Date = proj.End_Date,
                    NumberOfTasks = proj.Tasks.Count,
                    Start_Date = proj.Start_Date,
                    Status = proj.Status
                }
            };

        }

        #region Public Methods
        /// <summary>
        /// To get all projects infromations 
        /// </summary>
        /// <returns></returns>
        public List<ProjectModel> GetAllProject()
        {
            return repoProject.GetAllProject().Select(x => new ProjectModel
            {
                Project_ID = x.Project_ID,
                ProjectName = x.Project1,
                Priority = x.Priority,
                End_Date = x.End_Date,
                NumberOfTasks = x.Tasks.Count,
                Start_Date = x.Start_Date,
                Status = x.Status,
                Manager_ID = x.Users.Where(l => l.Project_ID == x.Project_ID).Select(m => m.User_ID).FirstOrDefault(),
                Manager_Name = x.Users.Where(l => l.Project_ID == x.Project_ID).Select(m => m.First_Name).FirstOrDefault()+ x.Users.Where(l => l.Project_ID == x.Project_ID).Select(m => m.Last_Name).FirstOrDefault(),

            }).ToList();
        }

        #endregion
    }
}
