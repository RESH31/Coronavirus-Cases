using Covid_Status.Models;
using Covid_Status.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Covid_Status.Controllers
{
    public class HomeController : Controller
    {
        private SortByLocation sort = new SortByLocation();

        public ActionResult Home()
        {
            Task<Global> task = DataService.fetchAllCountryCoronaData();
            task.Wait();
            Global globalData = task.Result;
            List<Data> datas = globalData.data;
            if(datas!=null)
            {
                datas.Sort(sort);
                return View(datas);
            }
            return View("Error");
        }

        public ActionResult CountryCoronaDetails(string id)
        {
           if (id != null)
            {
                Task<Country> task = DataService.fetchCountryCoronaData(id);
                task.Wait();
                Country countryData = task.Result;
                if (countryData.data != null)
                    return View(countryData.data);
                
            }
            return View("Error");
        }
    }
}