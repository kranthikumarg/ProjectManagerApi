using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLayer;

namespace ProjectManagerApi.Controllers
{
    /// <summary>
    ///  
    /// </summary>
    public class DBFixtureController
    {
        DBFixture _dbFixture = new DBFixture();
        /// <summary>
        /// 
        /// </summary>
        public void DeleteTestData()
        {
            _dbFixture.DeleteTestData();
        }
    }
}