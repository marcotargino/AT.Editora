using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Editora.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace Editora.WEB.Controllers
{
    public class LivroController : Controller
    {
        // GET: LivroController
        public ActionResult Index()
        {
            var client = new RestClient();
            var request = new RestRequest("http://localhost:63955/api/livro", DataFormat.Json);
            var response = client.Get<List<Livro>>(request);
   
            return View(response.Data);
        }

        // GET: LivroController/Details/5
        public ActionResult Details(int id)
        {

            var client = new RestClient();
            var request = new RestRequest("http://localhost:63955/api/livro/" + id, DataFormat.Json);
            var response = client.Get<Livro>(request);
            ViewBag.Autores = response.Data;

            return View(response.Data);
        }

        // GET: LivroController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: LivroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Livro livro)
        {
            try
            {
                if (ModelState.IsValid == false)
                    return View(livro);


                var client = new RestClient();
                var request = new RestRequest("http://localhost:63955/api/livro/", DataFormat.Json);
                request.AddJsonBody(livro);

                var response = client.Post<Livro>(request);
                return RedirectToAction(nameof(Index));


            }
            catch(System.Exception ex)
            {
                ModelState.AddModelError("AppError", ex.Message);
                return View(livro);
            }
        }

        // GET: LivroController/Edit/5
        public ActionResult Edit(int id )
        {
            var client = new RestClient();
            var request = new RestRequest("http://localhost:63955/api/livro/" + id, DataFormat.Json);
            var response = client.Get<Livro>(request);

            return View(response.Data);
        }

        // POST: LivroController/Edit/5
        // POST: AutorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Livro livro)
        {
            try
            {
                if (ModelState.IsValid == false)
                    return View(livro);


                var client = new RestClient();

                var request = new RestRequest("http://localhost:63955/api/livro/" + id, Method.PUT, DataFormat.Json);

                request.AddJsonBody(livro);

                var response = client.Execute(request);


                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AppError", ex.Message);
                return View(livro);
            }
        }

        // GET: LivroController/Delete/5
        public ActionResult Delete(int id)
        {
            var client = new RestClient();
            var request = new RestRequest("http://localhost:63955/api/livro/" + id, DataFormat.Json);
            var response = client.Get<Livro>(request);

            return View(response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Livro livro)
        {
            try
            {
                var client = new RestClient();
                var request = new RestRequest("http://localhost:63955/api/livro/" + id, DataFormat.Json);
                request.AddJsonBody(livro.Id);

                var response = client.Delete(request);


                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AppError", ex.Message);
                return View(livro);
            }
        }
    }
}
