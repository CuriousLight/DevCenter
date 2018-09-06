using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dev_Center.Repository;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Dev_Center.Models;
using System.Diagnostics;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dev_Center.Controllers
{
    /*
     * Controller welche die Anfragen für die Table Seite behandelt
     */
    public class TableController : Controller
    {
        TableRepository trep = new TableRepository();
        public List<string[]> ldt;

        public IActionResult Index()
        {
            ldt = new List<string[]>();
            ldt = trep.GetTable("select name,version from CI_APPLICATION_SYSTEMS order by version desc");
            ViewData["List"] = ldt;
            return View();
        }
        [Route("/TableList")]
        public IActionResult TableList()
        {
            ldt = new List<string[]>();
             ldt = trep.GetTable("select Table_name from User_tables");
            ViewData["TableList"]=ldt;
            return View();
        }
        [Route("/TableDetail/{Table=}")]
        public IActionResult TableDetail(string Table)
        {
            ldt = new List<string[]>();
            ldt = trep.GetTable($"select * from {Table.ToString()}");
            ViewData["TableDetail"] = ldt;
            return View();
        }
        [HttpPost]
        public ActionResult Filter(string filterv)
        {
            ldt = new List<string[]>();
            if(filterv == null)
                ldt = trep.GetTable("select Table_name from User_tables");
            else
                ldt = trep.GetTable($"select Table_name from User_tables where Table_name like '{filterv}'");
            ViewData["TableList"] = ldt;
            return View();
        }
    }
}
