using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HRController : Controller
    {
        pioneer db = new pioneer();
        // GET: HR
        private bool auth_display_permission(int id)
        {
            if (id != 0)
            {
                Admin aa1 = db.Admins.Where(m => m.id_admin == id).FirstOrDefault();
                List<page> pp1 = db.pages.Where(m => m.id_group == aa1.id_group && m.name == "Premissions").ToList();
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
        private bool auth_add_permission(int id)
        {
            if (id != 0)
            {
                Admin aa1 = db.Admins.Where(m => m.id_admin == id).FirstOrDefault();
                List<page> pp1 = db.pages.Where(m => m.id_group == aa1.id_group && m.name == "Premissions").ToList();
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
        private bool auth_update_permission(int id)
        {
            if (id != 0)
            {
                Admin aa1 = db.Admins.Where(m => m.id_admin == id).FirstOrDefault();
                List<page> pp1 = db.pages.Where(m => m.id_group == aa1.id_group && m.name == "Premissions").ToList();
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
        private bool auth_delete_permission(int id)
        {
            if (id != 0)
            {
                Admin aa1 = db.Admins.Where(m => m.id_admin == id).FirstOrDefault();
                List<page> pp1 = db.pages.Where(m => m.id_group == aa1.id_group && m.name == "Premissions").ToList();
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
        public ActionResult login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult login(Admin Admins)
        {
            //check if user name is HR or not
            
            HR hr1=db.HR.Where(n=>n.user_name == Admins.email && n.password == Admins.password).FirstOrDefault();
            if (hr1 != null)
            {
                Session.Add("HR_id", hr1.id_HR);
                 return RedirectToAction("home","HR");
            }
            else
            {
                //check if user name is admins or not 
             //check if email is admin or not 
                Admin admin1 = db.Admins.Where(n => n.email == Admins.email || n.user_name == Admins.email && n.password == Admins.password).FirstOrDefault();

                if (admin1!=null)
                {
                    Session.Add("admin_id", admin1.id_admin);
                    return RedirectToAction("home", "HR");
                }
                else
                {
                    ViewBag.stutas = "Email or Password is incorrect";
                }


            }



            return View();
        }
        public ActionResult home()
        {
            if (Session["HR_id"] != null || Session["admin_id"] !=null)
            {
                return View();
            }

            return RedirectToAction("login");
        }
        public ActionResult Premissions()
        {

            if (Session["HR_id"] != null || Session["admin_id"] != null)
            {
                int admin_id = 0;
                if (Session["admin_id"] != null)
                    admin_id = (int)Session["admin_id"];

               
                bool auth = auth_display_permission(admin_id);
                if (auth==true || Session["HR_id"] != null)
                {
                    // you should return the all Group you created it from DB
                    List<Group> Group_for_show = db.Group.ToList();
                    return View(Group_for_show);
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



        public static bool error_1 = false;
        //*******************************************you should add authorization after end Hr ******************************
        public ActionResult add_group()
        {

            if (Session["HR_id"] != null || Session["admin_id"] != null)
            {
                int admin_id = 0;
                if (Session["admin_id"] != null)
                    admin_id = (int)Session["admin_id"];

                bool auth = auth_add_permission(admin_id);
                if (auth==true|| Session["HR_id"] != null)
                {
                    //show for the first seven element this is const to only show
                    List<page> p1 = db.pages.Where(x => x.id_page <= 7).ToList();


                    Add_Group add1 = new Add_Group()
                    {
                        page1 = p1

                    };
                    //this is handle the privilage when you dont't indicate it .....
                    if (error_1 == true)
                    {
                        ViewBag.erorr = "you should choice privilage to add group ";

                    }
                    return View(add1);
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

                //convert to page you are not allow to enter here 
               
            }
        [HttpPost]
        public ActionResult add_group(Add_Group g1)
        {
            List<page> page_enter = g1.page1;

            Group group_enter = g1.group1;
            // to add hr_id to table of group to know who is the hr is added this group 
            group_enter.id_HR = (int)Session["HR_id"];
            bool flag_for_checking = false;
            foreach (var item in page_enter)
            {
                if(item.insert==true || item.show == true || item.update == true || item.delete == true)
                {
                    flag_for_checking = true;
                }
            }

            
            if (ModelState.IsValid && flag_for_checking==true)
            {
                db.Group.Add(group_enter);
                foreach (var item in page_enter)
                {
                    //to add group id to table of group 
                    item.id_group = group_enter.id_group;

                    db.pages.Add(item);
                }
                db.SaveChanges();
                return RedirectToAction("Premissions");

            }
            else
            {

                error_1 = true;
                return RedirectToAction("add_group");
                
            }
            
        }
        public ActionResult edit_Group(int? id)
        {
            if (Session["HR_id"] != null || Session["admin_id"] != null)
            {
                int admin_id = 0;
                if (Session["admin_id"] != null)
                    admin_id = (int)Session["admin_id"];


                bool auth = auth_update_permission(admin_id);
                if (auth==true || Session["HR_id"] != null)
                {

                    if (id.HasValue)
                    {
                        List<page> page_edit = db.pages.Where(x => x.id_group == id).ToList();
                        Group Group_edit = db.Group.Where(x => x.id_group == id).FirstOrDefault();

                        Add_Group g1 = new Add_Group()
                        {
                            page1 = page_edit
                            ,
                            group1 = Group_edit
                        };

                        return View(g1);
                    }
                    else
                    {
                        return RedirectToAction("Premissions", "HR");
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
        [HttpPost]
        public ActionResult edit_Group(Add_Group g1)
        {
            List<page> p1 = db.pages.Where(x => x.id_group == g1.group1.id_group).ToList();
            int count = 0;
            foreach (var item in g1.page1)
            {
                
                p1[count].insert = item.insert;
                p1[count].update = item.update;
                p1[count].delete = item.delete;
                p1[count].show = item.show;

                count++;

            }


            Group group_save = g1.group1;
            db.Entry(group_save).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();



            return RedirectToAction("Premissions");
        }
        //for delete group by HR
        public ActionResult delete_Group(int id)
        {
            if (Session["HR_id"] != null || Session["admin_id"] != null)
            {
                int admin_id = 0;
                if (Session["admin_id"] != null)
                    admin_id = (int)Session["admin_id"];


                bool auth = auth_delete_permission(admin_id);
                if (auth==true|| Session["HR_id"] != null)
                {
                    Group g1 = db.Group.Where(x => x.id_group == id).FirstOrDefault();
                    Admin aa1 = db.Admins.Where(n => n.id_group == g1.id_group).FirstOrDefault();
                    if (aa1 !=null)
                    {
                        TempData["myData"] = "you should delete the user before delete group";
                        //ViewBag.message1 = "you should delete the user before delete group";
                        return Redirect(Request.UrlReferrer.ToString());
                    }
                    else
                    {

                        List<page> p1 = db.pages.Where(x => x.id_group == g1.id_group).ToList();


                        page p3 = new page();
                        foreach (var item in p1)
                        {
                            p3 = db.pages.Where(x => x.id_group == item.id_group && x.id_page == item.id_page).FirstOrDefault();

                            db.pages.Remove(p3);


                        }
                        db.Group.Remove(g1);
                        db.SaveChanges();


                        return RedirectToAction("Premissions");

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
        
        // this the page for any error happen in permission 
        public ActionResult error()
        {
            return View();
        }
        public ActionResult log_out()
        {
            if (Session["HR_id"] != null)
                Session["HR_id"] = null;
            if (Session["admin_id"] != null)
                Session["admin_id"] = null;
            return RedirectToAction("login", "HR");
        }
    }
}