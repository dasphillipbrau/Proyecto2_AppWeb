using Proyecto2_AppWeb.BusinessLogic;
using Proyecto2_AppWeb.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;

namespace Proyecto2_AppWeb.Controllers
{
    public class ClientsController : Controller
    {
        // GET: Clients
        static RequestHandler requestHandler = new RequestHandler();
        readonly Client emptyModel = new Client();

        [HttpGet]
        public ActionResult Home()
        {
            var res = requestHandler.GetAllClients();
            return View("Home", res.Content.ReadAsAsync<List<Client>>().Result);
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View(emptyModel);
        }
        [HttpPost]
        public ActionResult Register(Client client)
        {
            if (ModelState.IsValid)
            {
                if (requestHandler.FindClient(client.Id).StatusCode == HttpStatusCode.NotFound)
                {
                    if (requestHandler.AddClient(client).StatusCode == HttpStatusCode.Created)
                    {
                        TempData["RecordInserted"] = "Cliente Registrado";
                        return RedirectToAction("Register", emptyModel);
                    }
                    TempData["NotInserted"] = "NOT INSERTED";
                    return View(client);
                }
                else
                {
                    TempData["IdExists"] = "Client Found";
                }
            }
            return View(client);
        }

        [HttpGet]
        public ActionResult Search()
        {
            return View("Search", emptyModel);
        }
        [HttpPost]
        public ActionResult Search(string SearchId)
        {
            if (SearchId.Length == 0)
            {
                TempData["StringEmpty"] = "String Empty";
                return View("Search", emptyModel);
            }
            HttpResponseMessage res;
            if ((res = requestHandler.FindClient(SearchId)).IsSuccessStatusCode)
            {
                TempData["ResultFound"] = "Client Found";

                return View("Search", res.Content.ReadAsAsync<Client>().Result);
            }
            TempData["IdNotExists"] = "ID Not Found";
            return View("Search", emptyModel);
        }
        [HttpPost]
        public ActionResult Edit(Client client)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage res = requestHandler.UpdateClient(client);
                if (res.IsSuccessStatusCode)
                {
                    TempData["SuccessFulUpdate"] = "Cliente Actualizado";
                    return View("Search", emptyModel);
                }
                TempData["NoUpdate"] = "No Update";
                TempData["ResultFound"] = "Client Found";
            }
            else
            {
                TempData["ResultFound"] = "Client Found";
            }

            return View("Search", client);
        }
        [HttpGet]
        public ActionResult Prospects()
        {
            var res = requestHandler.GetAllProspects();
            if (res.IsSuccessStatusCode)
            {
                TempData["ResultFound"] = "Result Found";
                return View("Prospects", res.Content.ReadAsAsync<IEnumerable<Prospect>>().Result);
            }
            TempData["ResultFound"] = null;
            return View("Prospects");
        }

        [HttpGet]
        public ActionResult BadProspects()
        {
            var res = requestHandler.GetAllBadProspects();
            if (res.IsSuccessStatusCode)
            {
                TempData["ResultFound"] = "Result Found";
                return View("BadProspects", res.Content.ReadAsAsync<IEnumerable<BadProspect>>().Result);
            }
            TempData["ResultFound"] = null;
            return View("BadProspects");
        }
    }
}