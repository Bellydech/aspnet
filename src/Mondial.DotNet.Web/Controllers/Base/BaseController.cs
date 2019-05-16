using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mondial.DotNet.Web.Models;
using Mondial.DotNet.Library.Models;
using Mondial.DotNet.Library.Repositories.InMemory;
using Mondial.DotNet.Library.Repositories.Interfaces;
using System.Dynamic;

namespace Mondial.DotNet.Web.Controllers.Base
{
    public abstract class BaseController<T, TRepo> : Controller 
        where T : BaseModel<T>
        where TRepo : IBaseRepository<T>
    {
        protected readonly TRepo Repository;

        protected BaseController(TRepo repository)
        {
            Repository = repository;
        }

        public virtual IActionResult Index() => View(Repository.GetAll());

        [HttpGet]
        public virtual IActionResult Edit(int? id) 
        {
            if(id == null) return View();
            return View(Repository.Single(id.Value));
        }

        [HttpPost]
        public virtual IActionResult Edit(int id, [Bind]T model) 
        {
            Repository.Update(model);
            Repository.SaveChanges();
            return RedirectToAction("Index");
        }

        public virtual IActionResult Delete(int? id)
        {
            if(id != null)
            {
                Repository.Delete(id.Value);
                Repository.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("api/[controller]/status")] // redéfinition Route
        public virtual JsonResult Status()
        {
            // dynamic pour coller à l'esprit de Json et ajouter des objets dynamiquement
            dynamic result = new ExpandoObject();
            result.serverTime = DateTime.Now;
            result.controller = typeof(T).Name;
            return Json(result);
        }

        [HttpGet]
        [Route("api/[controller]/{id}")] // redéfinition Route
        public virtual JsonResult GetById(int id)
        {
            var entity = Repository.Single(id);
            if(entity == null) return Json(new {});
            return Json(entity.ToDynamic());
        }

        [HttpGet]
        [Route("api/[controller]")] // redéfinition Route
        public virtual JsonResult GetAll()
        {
            var allDyn = Repository.GetAll()
                .Select(e => e.ToDynamic())
                .ToList();
            return Json(allDyn);
        }
    }
} 