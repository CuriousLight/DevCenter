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
     * Controller welche die Anfragen für die Domain Seite behandelt
     */
    public class DomainController : Controller
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
        [Route("/DomainList")]
        public IActionResult DomainList()
        {
            ldt = new List<string[]>();
             ldt = trep.GetTable("select Table_name from User_tables");
            ViewData["DomainList"]=ldt;
            return View();
        }
        [Route("/DomainDetail/{Domain=}")]
        public IActionResult DomainDetail(string domain)
        {
            ldt = new List<string[]>();
            ldt = trep.GetTable($"select * from {domain.ToString()}");
            ViewData["DomainDetail"] = ldt;
            return View();
        }
        [HttpPost]
        public ActionResult Filter(string filterv)
        {
            ldt = new List<string[]>();
            if(filterv == null)
                ldt = trep.GetTable("select name,version from CI_APPLICATION_SYSTEMS order by version desc");
            else
                ldt = trep.GetTable($"select Table_name from User_tables where Table_name like '{filterv}'");
            ViewData["DomainList"] = ldt;
            return View();
        }
    }
}
