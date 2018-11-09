using AutoMapper;
using ProjectDD.MVC.ViewModels;
using ProjectDDD.Application.Interfaces;
using ProjectDDD.Domain.Entities;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjectDD.MVC.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteAppService _clientApp;

        public ClienteController(IClienteAppService clientApp)
        {
            _clientApp = clientApp;
        }

        // GET: Cliente
        public ActionResult Index()
        {
            var clientViewModel = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clientApp.GetAll());
            return View(clientViewModel);
        }

        public ActionResult Especials()
        {
            var clientViewModel = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clientApp.ObterClientsEspecials());
            return View(clientViewModel);
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            var client = _clientApp.GetById(id);
            var clientViewModel = Mapper.Map<Cliente, ClienteViewModel>(client);
            return View(clientViewModel);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel cliente)
        {
            // TODO: Add insert logic here
            if (ModelState.IsValid)
            {
                var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(cliente);
                _clientApp.Add(clienteDomain);

                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            var client = _clientApp.GetById(id);
            var clientViewModel = Mapper.Map<Cliente, ClienteViewModel>(client);
            return View(clientViewModel);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(cliente);
                _clientApp.Update(clienteDomain);

                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            var client = _clientApp.GetById(id);
            var clientViewModel = Mapper.Map<Cliente, ClienteViewModel>(client);

            return View(clientViewModel);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var client = _clientApp.GetById(id);
            _clientApp.Remove(client);

            return RedirectToAction("Index");
        }
    }
}
