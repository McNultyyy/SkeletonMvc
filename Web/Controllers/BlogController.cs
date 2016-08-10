using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DAL.Models.Entities;
using DAL.Repository;
using Web.ViewFactory;
using Web.ViewModels;
using Web.ViewModels.Blog;

namespace Web.Controllers
{
    public class BlogController : SkeletonMvcControllerBase
    {
        private readonly IRepository<Blog> _blogRepo;
        private readonly IViewFactory _factory;

        public BlogController(IRepository<Blog> blogRepo, IViewFactory factory)
        {
            _blogRepo = blogRepo;
            _factory = factory;
        }

        // GET: Blogs
        public ActionResult Index()
        {
            var vm = _factory.CreateView<BlogIndexModel>();
            return View(vm);
        }

        // GET: Blogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var blog = _factory.CreateView<int, BlogDetailsModel>(id.Value);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Blogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BlogCreateModel vm)
        {
            if (ModelState.IsValid)
            {
                var blog = AutoMapper.Mapper.Map<Blog>(vm);
                _blogRepo.Add(blog);
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        // GET: Blogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = _blogRepo.GetById(id.Value);
            var vm = AutoMapper.Mapper.Map<BlogEditModel>(blog);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(vm);
        }

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BlogEditModel vm)
        {
            if (ModelState.IsValid)
            {
                var blog = AutoMapper.Mapper.Map<Blog>(vm);
                _blogRepo.Update(blog);
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        // GET: Blogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = _blogRepo.GetById(id.Value);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = _blogRepo.GetById(id);
            return RedirectToAction("Index");
        }
    }
}
