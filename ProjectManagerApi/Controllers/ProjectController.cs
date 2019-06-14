using BusinessEntities;
using BusinessLayer;
using System.Collections.Generic;
using System.Web.Http;

namespace ProjectManagerApi.Controllers
{
    /// <summary>
    /// Project Controller 
    /// </summary>
    public class ProjectController : ApiController
    {
        ProjectBusiness _projectBusiness = new ProjectBusiness();

        /// <summary>  
        /// 
        /// To get all project details
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/getProjects")]
        public IEnumerable<ProjectModel> Get()
        {
            return _projectBusiness.GetAllProject();
        }


        /// <summary>
        /// Update project details
        /// </summary>
        /// <param name="_projectModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/updateProject")]
        public ProjectUpdateModel Post([FromBody]ProjectModel _projectModel)
        {
            return _projectBusiness.UpdateProject(_projectModel);
        }

    }
}