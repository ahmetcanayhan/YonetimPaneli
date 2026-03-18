using Business.Services;
using Core.Abstracts.IServices;
using Core.Concrete.DTOs;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostService service;
        public PostsController()
        {
            service = new PostService();
        }
        // GET: Posts
        public ActionResult Index()
        {
            return View(service.GetPostList(User.Identity.GetUserId()));
        }
        public ActionResult Details(int? id)
        {
            if (id== null)
            
                return HttpNotFound();

                var post = service.GetPostDetail((int)id);
                if (post == null)
                    return HttpNotFound();
                return View(post);
            
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewPostDto model, HttpPostedFileBase CoverImage)
        {
            ModelState["CoverImageUrl"].Errors.Clear();

            string[] file_ext = { ".jpg", ".png", ".bmp" };
            if (CoverImage != null && CoverImage.ContentLength > 0)
            {
                if (file_ext.Contains(Path.GetExtension(CoverImage.FileName).ToLower()))
                {
                    try
                    {
                        string fileName = Guid.NewGuid() + Path.GetExtension(CoverImage.FileName);
                        string folder = Server.MapPath("~/uploads");
                        if (!Directory.Exists(folder))
                        {
                            Directory.CreateDirectory(folder);
                        }
                        string fullPath = Path.Combine(folder, fileName);
                        CoverImage.SaveAs(fullPath);
                        model.CoverImageUrl = "/uploads/" + fileName;

                        ModelState.Remove("CoverImageUrl");
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("CoverImageUrl", ex.Message);
                    }
                }
                else
                {
                    ModelState.AddModelError("CoverImageUrl", "Dosya uzantısı geçersiz! (\".jpg\", \".png\", \".bmp\")");
                }

            }
            else
            {
                ModelState.AddModelError("CoverImageUrl", "Dosya yükleme başarısız!");
            }
            if (ModelState.IsValid)
            {
                model.AuthorId = User.Identity.GetUserId();
                service.CreatePost(model);
                return RedirectToAction("index");
            }
            return View(model);
        } 
         
        
        public ActionResult Edit (int? id)
        {
            if (id == null)

                return HttpNotFound();
            var post = service.GetPostEdit((int)id);
            if (id == null)

                return HttpNotFound();
            return View(post);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UpdatePostDto model, HttpPostedFileBase CoverImage)
        {
            string[] file_ext = { ".jpg", ".png", ".bmp" };
            if (CoverImage != null && CoverImage.ContentLength > 0)
            {
                if (file_ext.Contains(Path.GetExtension(CoverImage.FileName).ToLower()))
                {
                    try
                    {
                        string fileName = Guid.NewGuid() + Path.GetExtension(CoverImage.FileName);
                        string folder = Server.MapPath("~/uploads");
                        if (!Directory.Exists(folder))
                        {
                            Directory.CreateDirectory(folder);
                        }
                        string fullPath = Path.Combine(folder, fileName);
                        CoverImage.SaveAs(fullPath);
                        model.CoverImageUrl = "/uploads/" + fileName;

                        ModelState.Remove("CoverImageUrl");
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("CoverImageUrl", ex.Message);
                    }
                }
                else
                {
                    ModelState.AddModelError("CoverImageUrl", "Dosya uzantısı geçersiz! (\".jpg\", \".png\", \".bmp\")");
                }

            }
            if (ModelState.IsValid)
            {
                service.UpdatePost(model);
                return RedirectToAction("index");
            }
            return View(model);
        }
        
            
        public ActionResult Delete (int? id)
        {
            if (id == null)

                return HttpNotFound();

            var post = service.GetPostDetail((int)id);
            if (post == null)
                return HttpNotFound();
            return View(post);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            service.DeletePost(id, User.Identity.GetUserId());
            return RedirectToAction("Index");
        }
    }
}