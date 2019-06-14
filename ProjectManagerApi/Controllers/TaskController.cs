using BusinessEntities;
using BusinessLayer;
using System.Collections.Generic;
using System.Web.Http;

namespace ProjectManagerApi.Controllers
{
    /// <summary>
    /// Task Controller
    /// </summary>
    public class TaskController : ApiController
    {
        #region Declarations
        TaskBusiness _taskBusiness = new TaskBusiness();
        #endregion


        /// <summary>
        /// To get all parent tasks
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/getParentTasks")]
        public IHttpActionResult GetParentTasks()
        {
            return Ok(_taskBusiness.GetAllParentTasks());
        }
      
        /// <summary>
        /// To get all tasks
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/getTasks")]
        public IEnumerable<TaskModel> Get()
        {
            return _taskBusiness.GetAllTasks();
        }
         
        /// <summary>
        ///  To update task
        /// </summary>
        /// <param name="oTask"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/updateTask")]
        public TaskUpdateModel Post(TaskModel oTask)
        {
            return _taskBusiness.InsertUpdateTask(oTask);

        }
    }
}
