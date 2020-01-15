using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;
using Models;

namespace BL
{
    public class UserInfoBll
    {
        public List<Users> SearchByList(string name, ref int count)
        {
            UserInfoDL uDal = new UserInfoDL();
            var list = uDal.SearchByList(name);
            count = list.Count();
            return list;
        }

    }
}
