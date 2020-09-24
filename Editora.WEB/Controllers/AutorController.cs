using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Editora.Domain;

namespace Editora.WEB.Controllers.Autor
{
    public class AutorController : Controller
    {
        // GET: AutorController
        public ActionResult Index()
        {
            var client = new RestClient();
            var request = new RestRequest("http://localhost:63955/api/autor", DataFormat.Json);
            var response = client.Get<List<Domain.Autor>>(request);

            return View(response.Data);
        }

        // GET: AutorController/Details/5
        public ActionResult Details(int id)
        {
            var client = new RestClient();
            var request = new RestRequest("http://localhost:63955/api/autor/" + id, DataFormat.Json);
            var response = client.Get<Domain.Autor>(request);

            return View(response.Data);
        }

        // GET: AutorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AutorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Domain.Autor autor)
        {
            try
            {
                if (ModelState.IsValid == false)
                    return View(autor);


                var client = new RestClient();
                var request = new RestRequest("http://localhost:63955/api/autor/", DataFormat.Json);
                request.AddJsonBody(autor);

                var response = client.Post<Domain.Autor>(request);
                return RedirectToAction(nameof(Index));


            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AppError", ex.Message);
                return View(autor);
            }
        }

        // GET: AutorController/Edit/5
        public ActionResult Edit(int id)
        {
            var client = new RestClient();
            var request = new RestRequest("http://localhost:63955/api/autor/" + id, DataFormat.Json);
            var response = client.Get<Domain.Autor>(request);

            return View(response.Data);
        }

        // POST: AutorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( int id, Domain.Autor autor)
        {
            try
            {
                if (ModelState.IsValid == false)
                    return View(autor);


                var client = new RestClient();

                var request = new RestRequest("http://localhost:63955/api/autor/" +id, Method.PUT,DataFormat.Json);

                request.AddJsonBody(autor);

                var response = client.Execute(request);
                

                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AppError", ex.Message);
                return View(autor);
            }
        }

        // GET: AutorController/Delete/5
        public ActionResult Delete(int id )
        {
            var client = new RestClient();
            var request = new RestRequest("http://localhost:63955/api/autor/" + id, DataFormat.Json);
            var response = client.Get<Domain.Autor>(request);

            return View(response.Data);
        }

        // POST: AutorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Domain.Autor autor)
        {
            try
            {
                var client = new RestClient();
                var request = new RestRequest("http://localhost:63955/api/autor/" + id, DataFormat.Json);
                request.AddJsonBody(autor);

                var response = client.Delete(request);


                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AppError", ex.Message);
                return View(autor);
            }
        }
    }
}
