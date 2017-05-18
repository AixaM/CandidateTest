using System.Configuration;
using System.Web.Mvc;
using PairingTest.Web.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PairingTest.Web.Controllers
{
    public class QuestionnaireController : Controller
    {
        public async Task<ViewResult> Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["QuestionnaireServiceBaseAddress"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/questions/");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<QuestionnaireViewModel>();
                   if (result != null)
                       return View(result);
                }
            }

            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(QuestionnaireViewModel customer)
        {

            return RedirectToAction("Index", "Questionnaire");
        }

    }
}
