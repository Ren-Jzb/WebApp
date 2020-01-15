using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.Collections;
using Models;
using System.Data.Sql;
using System.Data.SqlClient;

namespace DL
{
    public class UserInfoDL: CareHome
    {
        public List<Users> SearchByList(string name)
        {
            var ss = new Guid("c7137f8e-0080-49ea-bf1f-b66d22fb7132");
            //CareHome careHome = new CareHome();
            List<Users> list = new List<Users>();
            if (name.Length > 0)
            {
                list = Users.Where(c => c.RealName.Contains(name) && c.WelfareCentreID == ss && c.IsValid == 1).ToList();
            }
            else
            {
                list = Users.Where(c => c.WelfareCentreID == ss && c.IsValid == 1).ToList();
            }
            return list;
        }

    }
}
