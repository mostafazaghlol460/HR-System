using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class Admin_Controller : Controller
    {
        pioneer db = new pioneer();
        private bool auth_display_user(int id)
        {
            if (id != 0)
            {
                Admin aa1 = db.Admins.Where(m => m.id_admin == id).FirstOrDefault();
                List<page> pp1 = db.pages.Where(m => m.id_group == aa1.id_group && m.name == "Users_Admin").ToList();
                foreach (var item in pp1)
                {
                    if (item.show == true)
                    {
                        return true;
                    }
                }
                return false;

            }
            else
                return false;
        }
        private bool auth_add_user(int id)
        {
            if (id != 0)
            {
                Admin aa1 = db.Admins.Where(m => m.id_admin == id).FirstOrDefault();
                List<page> pp1 = db.pages.Where(m => m.id_group == aa1.id_group && m.name == "Users_Admin").ToList();
                foreach (var item in pp1)
                {
                    if (item.insert == true)
                    {
                        return true;
                    }
                }
                return false;

            }
            else
                return false;
        }
        private bool auth_update_user(int id)
        {
            if (id != 0)
            {
                Admin aa1 = db.Admins.Where(m => m.id_admin == id).FirstOrDefault();
                List<page> pp1 = db.pages.Where(m => m.id_group == aa1.id_group && m.name == "Users_Admin").ToList();
                foreach (var item in pp1)
                {
                    if (item.update == true)
                    {
                        return true;
                    }
                }
                return false;

            }
            else
                return false;
        }
        private bool auth_delete_user(int id)
        {
            if (id != 0)
            {
                Admin aa1 = db.Admins.Where(m => m.id_admin == id).FirstOrDefault();
                List<page> pp1 = db.pages.Where(m => m.id_group == aa1.id_group && m.name == "Users_Admin").ToList();
                foreach (var item in pp1)
                {
                    if (item.delete == true)
                    {
                        return true;
                    }
                }
                return false;

            }
            else
                return false;
        }


        public ActionResult View_users()
        {

            if (Session["HR_id"] != null || Session["admin_id"] != null)
            {
                int admin_id = 0;
                if (Session["admin_id"] != null)
                    admin_id = (int)Session["admin_id"];


                bool auth = auth_display_user(admin_id);
                if (auth==true || Session["HR_id"] != null)
                {
                    List<Admin> admin_to_display = db.Admins.ToList();

                    return View(admin_to_display);
                }
                else
                {
                    TempData["Message"] = "un authorize to enter this page ";

                    return Redirect(Request.UrlReferrer.ToString());
                }
            }
            else
            {
                return RedirectToAction("login", "HR");
            }
            
        }
        // GET: Admin
        public ActionResult add_new_user()
        {
            if (Session["HR_id"] != null || Session["admin_id"] != null)
            {
                int admin_id = 0;
                if (Session["admin_id"] != null)
                    admin_id = (int)Session["admin_id"];
 
                bool auth = auth_add_user(admin_id);
                if (auth==true || Session["HR_id"] != null)
                {
                    Admin adding_Admin = new Admin();
                    SelectList st = new SelectList(db.Group.ToList(), "id_group", "name_group");
                    ViewBag.cat = st;


                    return View(adding_Admin);
                }
                else
                {
                    TempData["Message"] = "un authorize to enter this page ";

                    return Redirect(Request.UrlReferrer.ToString());
                }
            }
            else
            {
                return RedirectToAction("login", "HR");
            }
        }

        [HttpPost]
        public ActionResult add_new_user(Admin adding1)
        {
            if (ModelState.IsValid)
            {

                db.Admins.Add(adding1);
                db.SaveChanges();
                return RedirectToAction("View_users");
            }
            return RedirectToAction("home","HR");

        }

        public ActionResult Edit_admin(int id )
        {
            if (Session["HR_id"] != null || Session["admin_id"] != null)
            {
                int admin_id = 0;
                if (Session["admin_id"] != null)
                    admin_id = (int)Session["admin_id"];


                bool auth = auth_update_user(admin_id);
                if (auth==true || Session["HR_id"] != null)
                {
                    Admin admin_edit = db.Admins.Where(m => m.id_admin == id).FirstOrDefault();
                    SelectList st = new SelectList(db.Group.ToList(), "id_group", "name_group");
                    ViewBag.cat = st;

                    return View(admin_edit);
                }
                else
                {
                    TempData["Message"] = "un authorize to enter this page ";

                    return Redirect(Request.UrlReferrer.ToString());
                }
            }
            else
            {
                return RedirectToAction("login", "HR");
            }

           
        }
        [HttpPost]
        public ActionResult Edit_admin(Admin update_admin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(update_admin).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("View_users");

            }
            return View();
        }
        public ActionResult Delete_admin(int id)
        {
            if (Session["HR_id"] != null || Session["admin_id"] != null)
            {
                int admin_id = 0;
                if (Session["admin_id"] != null)
                    admin_id = (int)Session["admin_id"];


                bool auth = auth_delete_user(admin_id);
                if (auth==true || Session["HR_id"] != null)
                {
                    if (id != 0)
                    {
                        Admin admin_delete = db.Admins.Where(m => m.id_admin == id).FirstOrDefault();
                        db.Admins.Remove(admin_delete);
                        db.SaveChanges();

                        return RedirectToAction("View_users");
                    }
                    else
                    {
                        return RedirectToAction("home", "HR");
                    }
                }
                else
                {
                    TempData["Message"] = "un authorize to enter this page ";

                    return Redirect(Request.UrlReferrer.ToString());
                }
            }
            else
            {
                return RedirectToAction("login", "HR");
            }
            
        }


    }
    }