using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL;
using Models;
using System.Text;
using System.Collections;
using Newtonsoft.Json;
using System.IO;


namespace netMvc.Controllers
{
    public class TestController : Controller
    {
        public ActionResult List()
        {
            return View();
        }

        public ActionResult Detail()
        {
            return View();
        }

        public JsonResult SeachList(string name, int page, int pageSize)
        {
            //string name = Request.Form["name"];

            ListPage lp = new ListPage();
            UserInfoBll uBll = new UserInfoBll();
            page = page <= 0 ? 1 : page;
            //索引页
            int iPageIndex = page - 1;
            //总记录数量
            int count = 0;

            var list = uBll.SearchByList(name.Trim(), ref count).Skip(iPageIndex * pageSize).Take(pageSize).ToList();

            pageSize = pageSize == 0 ? count : pageSize;
            int pageCount = count % pageSize == 0 ? count / pageSize : count / pageSize + 1;

            //lp.PageSize = pageSize;
            lp.CurrentPage = page;
            lp.TotalRecord = count;
            lp.PageCount = pageCount;
            lp.Data = list;

            return Json(lp);
        }

        public class ListPage
        {
            public ListPage()
            {
                CurrentPage = 1;
                PageSize = 1;
            }

            /// <summary>
            /// 当前页码默认1
            /// </summary>
            public int CurrentPage { get; set; }
            /// <summary>
            /// 分页条数，默认20条
            /// </summary>
            public int PageSize { get; set; }
            /// <summary>
            /// 总记录数
            /// </summary>
            public int TotalRecord { get; set; }
            /// <summary>
            /// 页的总数
            /// </summary>
            public int PageCount { get; set; }
            /// <summary>
            /// 数据内容
            /// </summary>
            public object Data { get; set; }
        }

        #region   webApi
        [Route("/api")]
        public JsonResult apiUserInfo()
        {

            return Json("");
        }
        #endregion


    }
}