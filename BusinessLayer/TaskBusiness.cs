#region Assemblies
using BusinessEntities;
using DataAccessLayer;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace BusinessLayer
{
    public class TaskBusiness
    {
        #region Properties
        TaskRepository repoTask = new TaskRepository();
        ParentTaskRepository parent = new ParentTaskRepository();
        #endregion

        #region Public Methods

        /* To get the parent task */
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ParentTaskModel> GetAllParentTasks()
        {
            return parent.GetAllTasks().Select(x => new ParentTaskModel
            {

                Parent_ID = x.Parent_ID,
                Parent_Name = x.Parent_Task

            }).ToList();
        }

        /* To get all tasks details  */
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        public List<TaskModel> GetAllTasks()
        {
            return repoTask.GetAllTasks().Select(x => new TaskModel
            {
                End_Date = x.End_Date,
                Parent_ID = x.Parent_ID,
                Parent_Name = x.ParentTask?.Parent_Task,
                Priority = x.Priority,
                Project_ID = x.Project_ID,
                Project_Name = x.Project.Project1,
                Start_Date = x.Start_Date,
                Status = x.Status,
                TaskName = x.Task1,
                Task_ID = x.Task_ID,
                User_ID = x.User_ID,
                User_Name = x.User?.First_Name + " " + x.User?.Last_Name
            }).ToList();
        }




      



        /* To insert or update the task */

        public TaskUpdateModel InsertUpdateTask(TaskModel task_Model)
        {
            StatusModel _status = new StatusModel();
            if (task_Model.Parent_ID == null)
            {

                ParentTasks oParent = new ParentTasks()
                {
                    Parent_Task = task_Model.TaskName
                };
                oParent = parent.AddParentTask(oParent);
                task_Model.Parent_ID = oParent.Parent_ID;
            }
            Task task = new Task()
            {
                End_Date = task_Model.End_Date,
                Parent_ID = task_Model.Parent_ID,
                Priority = task_Model.Priority,
                Project_ID = task_Model.Project_ID,
                Start_Date = task_Model.Start_Date,
                Status = task_Model.Status,
                Task1 = task_Model.TaskName,
                User_ID = task_Model.User_ID
            };
            if (task_Model.Task_ID == 0)
            {
                task = repoTask.AddTask(task);
                _status = new StatusModel() { Message = "Task details are added successfully", Result = true };
            }
            else
            {
                task.Task_ID = task_Model.Task_ID;
                task = repoTask.UpdateTask(task);
                _status = new StatusModel() { Message = "Task details are updated successfully", Result = true };
            }

            return new TaskUpdateModel()
            {
                status = _status,
                task = null
            };

        }

        #endregion
    }

}
