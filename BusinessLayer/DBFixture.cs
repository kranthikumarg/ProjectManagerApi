using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public class DBFixture
    {
        DBFixtureRepo _dbFixtureRepo = new DBFixtureRepo();



        public void DeleteTestData()
        {
            _dbFixtureRepo.DeleteTestData();
        }

    }
}
