
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{

    public class employeeController : Controller
    {
        pioneer db = new pioneer();
        
        // GET: employee
        private bool auth_display_employee(int  id)
        {
            if (id != 0)
            {
                Admin aa1 = db.Admins.Where(m => m.id_admin == id).FirstOrDefault();
                List<page> pp1 = db.pages.Where(m => m.id_group == aa1.id_group && m.name == "Add employee").ToList();
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
        private bool auth_add_employee(int id)
        {
            if (id != 0)
            {
                Admin aa1 = db.Admins.Where(m => m.id_admin == id).FirstOrDefault();
                List<page> pp1 = db.pages.Where(m => m.id_group == aa1.id_group && m.name == "Add employee").ToList();
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
        private bool auth_update_employee(int  id)
        {
            if (id != 0)
            {
                Admin aa1 = db.Admins.Where(m => m.id_admin == id).FirstOrDefault();
                List<page> pp1 = db.pages.Where(m => m.id_group == aa1.id_group && m.name == "Add employee").ToList();
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
        private bool auth_delete_employee(int  id)
        {
            if (id != 0)
            {
                Admin aa1 = db.Admins.Where(m => m.id_admin == id).FirstOrDefault();
                List<page> pp1 = db.pages.Where(m => m.id_group == aa1.id_group && m.name == "Add employee").ToList();
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

        private bool auth_display_genral_setting(int  id)
        {
            if (id != 0)
            {
                Admin aa1 = db.Admins.Where(m => m.id_admin == id).FirstOrDefault();
                List<page> pp1 = db.pages.Where(m => m.id_group == aa1.id_group && m.name == "Genral Settings").ToList();
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
        private bool auth_display_show_attendance(int id)
        {
            if (id != 0)
            {
                Admin aa1 = db.Admins.Where(m => m.id_admin == id).FirstOrDefault();
                List<page> pp1 = db.pages.Where(m => m.id_group == aa1.id_group && m.name == "Attendance").ToList();
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
        private bool auth_add_show_attendance(int  id)
        {
            if (id != 0)
            {
                Admin aa1 = db.Admins.Where(m => m.id_admin == id).FirstOrDefault();
                List<page> pp1 = db.pages.Where(m => m.id_group == aa1.id_group && m.name == "Attendance").ToList();
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

        private bool auth_update_show_attendance(int  id)
        {
            if (id != 0)
            {
                Admin aa1 = db.Admins.Where(m => m.id_admin == id).FirstOrDefault();
                List<page> pp1 = db.pages.Where(m => m.id_group == aa1.id_group && m.name == "Attendance").ToList();
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
        private bool auth_delete_show_attendance(int  id)
        {
            if (id != 0)
            {
                Admin aa1 = db.Admins.Where(m => m.id_admin == id).FirstOrDefault();
                List<page> pp1 = db.pages.Where(m => m.id_group == aa1.id_group && m.name == "Attendance").ToList();
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
        private bool auth_show_salary_report(int  id)
        {
            if (id != 0)
            {
                Admin aa1 = db.Admins.Where(m => m.id_admin == id).FirstOrDefault();
                List<page> pp1 = db.pages.Where(m => m.id_group == aa1.id_group && m.name == "Salary report").ToList();
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
        public ActionResult Employee()
        {
            if (Session["HR_id"] != null || Session["admin_id"] != null)
            {
                int admin_id = 0;
                if (Session["admin_id"] != null)
                    admin_id = (int)Session["admin_id"];



                bool auth = auth_display_employee(admin_id);
                if (auth==true|| Session["HR_id"] != null)
                {
                    List<employee> employee_to_display = db.employee.ToList();
                    return View(employee_to_display);
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

        public ActionResult Add_employee()
        {
            
            if (Session["HR_id"] != null || Session["admin_id"] != null)
            {
                int admin_id = 0;
                if (Session["admin_id"] != null)
                    admin_id = (int)Session["admin_id"];

                bool auth = auth_add_employee(admin_id);
                if (auth==true|| Session["HR_id"] != null)
                {
                    employee emp1 = new employee();
                    //this to create list without id or any thing to attch it  and you should decalre the select list like this
                    SelectList st = new SelectList(new[] { "Male", "Female" });
                    ViewBag.gender = st;

                    return View(emp1);
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
        public ActionResult Add_employee(employee Employee1)
        {

            if (Session["HR_id"] != null)
            {
                Employee1.id_HR = (int)Session["HR_id"];


                if (ModelState.IsValid)
                {
                    if (!Check_Holiday_date_of_conference(Employee1))
                    {

                        db.employee.Add(Employee1);
                        db.SaveChanges();
                        return RedirectToAction("Employee");
                    }
                    else
                    {
                        ViewBag.error_of_date_conference = "this day is holiday please enter another day of conference ";
                        employee emp1 = new employee();
                        //this to create list without id or any thing to attch it  and you should decalre the select list like this
                        SelectList st1 = new SelectList(new[] { "Male", "Female" });
                        ViewBag.gender = st1;

                        return View(emp1);
                    }

                }
            }
            SelectList st = new SelectList(new[] { "Male", "Female" });
            ViewBag.gender = st;

            return View();
        }
        public ActionResult Edit_emp(int id)
        {
            
            if (Session["HR_id"] != null || Session["admin_id"] != null)
            {
                int admin_id = 0;
                if (Session["admin_id"] != null)
                    admin_id = (int)Session["admin_id"];

                bool auth = auth_update_employee(admin_id);

                if (auth==true|| Session["HR_id"] != null)
                {
                    if (id != 0)
                    {


                        employee employee_edit = db.employee.Where(m => m.id_employee == id).FirstOrDefault();
                        SelectList st = new SelectList(new[] { "Male", "Female" });
                        ViewBag.gender = st;

                        return View(employee_edit);
                    } else
                        return RedirectToAction("home", "HR");
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
        public ActionResult Edit_emp(employee update_employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(update_employee).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("Employee");

            }
            return View();
        }
        public ActionResult Delete_employee(int id)
        {
            
            if (Session["HR_id"] != null || Session["admin_id"] != null)
            {
                int admin_id = 0;
                if (Session["admin_id"] != null)
                    admin_id = (int)Session["admin_id"];

                bool auth = auth_delete_employee(admin_id);


                if (auth==true|| Session["HR_id"] != null)
                {

                    if (id != 0)
                    {
                        employee employee_delete = db.employee.Where(m => m.id_employee == id).FirstOrDefault();
                        db.employee.Remove(employee_delete);
                        db.SaveChanges();

                        return RedirectToAction("Employee");
                    }
                    else
                        return RedirectToAction("home", "HR");

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


        public ActionResult view_general_setting()
        {
            if (Session["HR_id"] != null || Session["admin_id"] != null)
            {
                int admin_id = 0;
                if (Session["admin_id"] != null)
                    admin_id = (int)Session["admin_id"];

                bool auth = auth_display_genral_setting(admin_id);
                if (auth==true || Session["HR_id"] != null)
                {

                    general_setting gs1 = db.general_setting.FirstOrDefault();


                    Holiday_Days h2= Convert_To_HolidayDay(gs1);
                    Holiday_Days H1 = new Holiday_Days()
                    {
                        Saturday=h2.Saturday,
                        Sunday = h2.Sunday,
                        Monday = h2.Monday,
                        Tuesday = h2.Tuesday,
                        Wednesday = h2.Wednesday,
                        Thursday = h2.Thursday,
                        Friday = h2.Friday,
                        g1 =gs1
                    };

                    return View(H1);
                }
                else
                {
                    TempData["Message"] = "un authorize to enter this page ";

                    return Redirect(Request.UrlReferrer.ToString());
                }

            }
            return RedirectToAction("login", "HR");
        }
        private Holiday_Days Convert_To_HolidayDay(general_setting g1)
        {

            Holiday_Days H1 = new Holiday_Days();
            if (g1.hoilday_day.Contains("Saturday"))
                H1.Saturday = true;
            if (g1.hoilday_day.Contains("Sunday"))
                H1.Sunday = true;
            if (g1.hoilday_day.Contains("Monday"))
                H1.Monday = true;
            if (g1.hoilday_day.Contains("Tuesday"))
                H1.Tuesday = true;
            if (g1.hoilday_day.Contains("Wednesday"))
                H1.Wednesday = true;
            if (g1.hoilday_day.Contains("Thursday"))
                H1.Thursday = true;
            if (g1.hoilday_day.Contains("Friday"))
                H1.Friday = true;

            return H1;

        }
        private string Convert_To_general_setting(Holiday_Days h1)
        {
            string general_setting1 = "";
            if (h1.Saturday == true)
                general_setting1 += "Saturday";
            if (h1.Sunday == true)
                general_setting1 += "Sunday";
            if (h1.Monday == true)
                general_setting1 += "Monday";
            if (h1.Tuesday == true)
                general_setting1 += "Tuesday";
            if (h1.Wednesday == true)
                general_setting1 += "Wednesday";
            if (h1.Thursday == true)
                general_setting1 += "Thursday";
            if (h1.Friday == true)
                general_setting1 += "Friday";
            return general_setting1;

        }

        private bool Check_if_enter_one_day(Holiday_Days h1)
        {
            if (h1.Saturday || h1.Sunday || h1.Monday || h1.Tuesday || h1.Wednesday || h1.Thursday || h1.Friday)
                return true;
            return false;
        }
        [HttpPost]
        // this function used to add genral setting and display  it
        public ActionResult view_general_setting(Holiday_Days holiday_Days)
        {
            bool SelectedDays = Check_if_enter_one_day(holiday_Days);

            if (SelectedDays != false )
            {

                general_setting g1 = holiday_Days.g1;
                

                g1.hoilday_day = Convert_To_general_setting(holiday_Days);

                db.Entry(g1).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("home", "HR");
            }
            ViewBag.select_day = "please insert at least one day";
            return View();
        }


        //this function responsable for call static data 
        private void call_default()
        {
            // this list used to select list of name of employee ...
            SelectList st = new SelectList(db.employee.ToList(), "id_employee", "name_emp");
            ViewBag.cat = st;

            List<employee> list_EM = db.employee.ToList();
            ViewBag.list_employee_view = list_EM;


            //this is used to display employee report
            List<report_employee> list_E = db.report_employee.ToList();
            ViewBag.list_employee = list_E;

        }
        public ActionResult Show_Attendance()
        {
            if (Session["HR_id"] != null || Session["admin_id"] != null)
            {
                int admin_id = 0;
                if (Session["admin_id"] != null)
                    admin_id = (int)Session["admin_id"];


                bool auth = auth_display_show_attendance(admin_id);
                
        
                if (auth==true || Session["HR_id"] != null)
                {
                    // this is used to add employee report 
                    report_employee Re1 = new report_employee();
                    call_default();
                    return View(Re1);
                }
                else
                {
                    TempData["Message"] = "un authorize to enter this page ";

                    return Redirect(Request.UrlReferrer.ToString());
                }
            }
            return RedirectToAction("login", "HR");
        }

        // this function used to add attendace report and display it
        private void adding_attendance_ideal(report_employee employee_add)
        {
            general_setting g1 = db.general_setting.Where(m => m.id_genral_setting == 1).FirstOrDefault();
            employee_add.attend_days = true;
            employee_add.absent_days = false;

            employee_add.id_general = g1.id_genral_setting;



        }
        private void adding_attendance_bouns(report_employee employee_add)
        {
            general_setting g1 = db.general_setting.Where(m => m.id_genral_setting == 1).FirstOrDefault();
            employee e1 = db.employee.Where(m => m.id_employee == employee_add.id_emp).FirstOrDefault();
            employee_add.attend_days = true;
            employee_add.absent_days = false;

            employee_add.id_general = g1.id_genral_setting;
            //this bouns is daily 
            TimeSpan difference_bouns_attend = e1.attend_time- employee_add.time_attendance ;
            double totalHours_attend = difference_bouns_attend.TotalHours;
            double extra_attend = (g1.extra * totalHours_attend);

            TimeSpan difference_bouns_leave = employee_add.time_leave - e1.leave_time;
            double totalHours_leave = difference_bouns_leave.TotalHours;
            double extra_leave = (g1.extra * totalHours_leave);
            

            if (extra_leave > 0)
                employee_add.extra += extra_leave;
            if (extra_attend > 0)
                employee_add.extra += extra_attend;
            if (extra_leave > 0 && extra_attend > 0)
                employee_add.extra += extra_attend + extra_leave;



        }
 
        private void adding_attendance_discount(report_employee employee_add)
        {
            general_setting g1 = db.general_setting.Where(m => m.id_genral_setting == 1).FirstOrDefault();
            employee e1 = db.employee.Where(m => m.id_employee == employee_add.id_emp).FirstOrDefault();
            employee_add.attend_days = true;
            employee_add.absent_days = false;

            //this discount is daily 



            TimeSpan difference_discount_leave = e1.leave_time- employee_add.time_leave;
            double totalHours_leave = difference_discount_leave.TotalHours;
            double discount_leave = (g1.discount * totalHours_leave);

            TimeSpan difference_discount_attend =   employee_add.time_attendance - e1.attend_time;
            double totalHours_attend = difference_discount_attend.TotalHours;
            double discount_attend = (g1.discount * totalHours_attend);

            if(discount_leave > 0)
                employee_add.discount += discount_leave;
            if(discount_attend>0)
                employee_add.discount += discount_attend;
            if(discount_leave>0 && discount_attend>0)
                employee_add.discount += discount_attend + discount_leave;



            employee_add.id_general = g1.id_genral_setting;

        }

       
        [HttpPost]
        public ActionResult Show_Attendance(report_employee employee_add)
        {
            if (Session["HR_id"] != null || Session["admin_id"] != null)
            {
                int admin_id = 0;
                if (Session["admin_id"] != null)
                    admin_id = (int)Session["admin_id"];

                bool auth = auth_add_show_attendance(admin_id);
                if (auth==true|| Session["HR_id"] != null)
                {
                    general_setting g1 = db.general_setting.Where(m => m.id_genral_setting == 1).FirstOrDefault();

                    bool ind = Check_if_enter_before_or_not(employee_add);
                    if (ind)
                    {
                        ViewBag.insert_before = "this employee you added before in this day";
                        call_default();
                        return View();
                    }


                    //check before adding attendance if hoilday or not 
                    DateTime date = employee_add.date_of_today;


                    if (Check_Holiday(employee_add))
                    {
                        // the selected day is a holiday
                        ViewBag.Holiday = "This day is a holiday";
                        call_default();
                        return View();
                    }
                    else
                    {


                        var em11 = db.employee.ToList();
                        
                        Isempty(em11);





                        if (employee_add.time_leave >= employee_add.time_attendance)
                        {


                            employee e1 = db.employee.Where(m => m.id_employee == employee_add.id_emp).FirstOrDefault();

                            if (employee_add.date_of_today >= e1.date_of_conference)
                            {


                                //check for the ideal operation 
                                if (e1.attend_time == employee_add.time_attendance && e1.leave_time == employee_add.time_leave)
                                {
                                    adding_attendance_ideal(employee_add);
                                    //adding attend day 

                                }
                                //second check if difference more than  8h then make attend  and bouns
                                if (e1.attend_time > employee_add.time_attendance || employee_add.time_leave > e1.leave_time)
                                {
                                    adding_attendance_bouns(employee_add);

                                }


                                if (e1.attend_time < employee_add.time_attendance || employee_add.time_leave < e1.leave_time)
                                {
                                    adding_attendance_discount(employee_add);

                                }

                                db.report_employee.Add(employee_add);
                                db.SaveChanges();

                                return RedirectToAction("Show_Attendance");
                            }
                            else
                            {
                                report_employee Re1 = new report_employee();
                                call_default();
                                ViewBag.error_message = "please insert date after date of conference  "+e1.date_of_conference.ToString("yyyy-MM-dd");

                                return View(Re1);
                            }
                            //this is else of time of leave greater than time attend 
                        }
                        else
                        {
                            report_employee Re1 = new report_employee();
                            call_default();
                            //error if time of leave greater than time attend 
                            ViewBag.eror = "you must the leave time is greate than attend time ";
                            return View(Re1);
                        }




                        
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

        public ActionResult update_attendance(int id)
        {
            if (Session["HR_id"] != null || Session["admin_id"] != null)
            {
                int admin_id = 0;
                if (Session["admin_id"] != null)
                    admin_id = (int)Session["admin_id"];

                bool auth = auth_update_show_attendance(admin_id);
                if (auth==true||Session["HR_id"] != null)
                {
                    // this list used to select list of name of employee ...
                    SelectList st = new SelectList(db.employee.ToList(), "id_employee", "name_emp");
                    ViewBag.cat = st;

                    List<employee> list_EM = db.employee.ToList();
                    ViewBag.list_employee_view = list_EM;


                    //this is used to display employee report
                    List<report_employee> list_E = db.report_employee.ToList();
                    ViewBag.list_employee = list_E;

                    report_employee emp_edit = db.report_employee.Where(m => m.id_report == id).FirstOrDefault();

                    return View(emp_edit);
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
        public ActionResult update_attendance(report_employee employee_add)
        {
            bool check_if_enter_before_or_not = db.report_employee.Where(m => m.id_emp == employee_add.id_emp).Any(m => m.date_of_today == employee_add.date_of_today);


            //check before adding attendance if hoilday or not 
            DateTime date = employee_add.date_of_today;
            DayOfWeek day = date.DayOfWeek;
            general_setting g1 = db.general_setting.Where(m => m.id_genral_setting == 1).FirstOrDefault();


            string holidayDay = g1.hoilday_day;
            if (holidayDay.Contains(day.ToString()))
            {
                // the selected day is a holiday
                return View();
            }
            else
            {



                TimeSpan eightHours = new TimeSpan(8, 0, 0);
                TimeSpan absent = new TimeSpan(0, 0, 0);


                if (employee_add.time_leave >= employee_add.time_attendance)
                {
                    TimeSpan difference = employee_add.time_leave - employee_add.time_attendance;

                    //indcate bouns and discount by using attend and leave time and date of general setting 
                    //this is depend on the 30day and after that retrun to 0 ,,I mean monthly 

                    // we have three condition 


                    //first check if difference equal 8h then make only attend 

                    if (difference == eightHours)
                    {
                        //adding attend day 
                        employee_add.attend_days = true;
                        employee_add.absent_days = false;

                        employee_add.id_general = g1.id_genral_setting;
                        db.Entry(employee_add).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        return RedirectToAction("Show_Attendance");


                    }
                    //second check if difference more than  8h then make attend  and bouns
                    else if (difference >= eightHours)
                    {
                        employee_add.attend_days = true;
                        employee_add.absent_days = false;
                        //this bouns is daily 



                        employee_add.id_general = g1.id_genral_setting;


                        TimeSpan difference_bouns = difference - eightHours;
                        double totalHours = difference_bouns.TotalHours;
                        employee_add.extra = (g1.extra * totalHours);
                        employee_add.discount = 0;




                        db.Entry(employee_add).State = System.Data.Entity.EntityState.Modified;

                        db.SaveChanges();

                        return RedirectToAction("Show_Attendance");




                    }
                    //third check if difference less than  8h then make attend  and discount

                    else if (difference == absent)
                    {
                        employee_add.attend_days = false;
                        employee_add.absent_days = true;


                        employee_add.id_general = g1.id_genral_setting;
                        db.Entry(employee_add).State = System.Data.Entity.EntityState.Modified;

                        db.SaveChanges();

                        return RedirectToAction("Show_Attendance");

                    }
                    //this else for check (difference <= eightHours)
                    else
                    {
                        employee_add.attend_days = true;
                        employee_add.absent_days = false;

                        //this discount is daily 



                        TimeSpan difference_discount = eightHours - difference;
                        double totalHours = difference_discount.TotalHours;
                        employee_add.extra = (g1.extra * totalHours);
                        employee_add.discount = 0;



                        employee_add.id_general = g1.id_genral_setting;
                        db.Entry(employee_add).State = System.Data.Entity.EntityState.Modified;

                        db.SaveChanges();

                        return RedirectToAction("Show_Attendance");
                    }


                }
                //this is else of time of leave greater than time attend 
                else
                {
                    report_employee Re1 = new report_employee();


                    // this list used to select list of name of employee ...
                    SelectList st = new SelectList(db.employee.ToList(), "id_employee", "name_emp");
                    ViewBag.cat = st;

                    List<employee> list_EM = db.employee.ToList();
                    ViewBag.list_employee_view = list_EM;


                    //this is used to display employee report
                    List<report_employee> list_E = db.report_employee.ToList();
                    ViewBag.list_employee = list_E;


                    //error if time of leave greater than time attend 
                    ViewBag.eror = "you must the leave time is greate than attend time ";
                    return View();
                }





            }






        }
        public ActionResult delete_attendance(int id)
        {
            if (Session["HR_id"] != null || Session["admin_id"] != null)
            {
                int admin_id = 0;
                if (Session["admin_id"] != null)
                    admin_id = (int)Session["admin_id"];

                bool auth = auth_delete_show_attendance(admin_id);

                if (auth==true|| Session["HR_id"] != null)
                {
                    report_employee emp_delete = db.report_employee.Where(m => m.id_report == id).FirstOrDefault();
                    employee ee1 = db.employee.Where(m => m.id_employee == emp_delete.id_emp).FirstOrDefault();
                    ee1.total_attend -= 1;
                    ee1.total_absent += 1;
                    db.Entry(ee1).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    db.report_employee.Remove(emp_delete);
                    db.SaveChanges();
                    return RedirectToAction("Show_Attendance");
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
        //search in golabal not one
        
        public ActionResult salary_report()
        {
            if (Session["HR_id"] != null || Session["admin_id"] != null)
            {
                int admin_id = 0;
                if (Session["admin_id"] != null)
                    admin_id = (int)Session["admin_id"];

                bool auth = auth_show_salary_report(admin_id);
                if (auth==true || Session["HR_id"] != null)
                {

                    List<employee> em1 = db.employee.ToList();
                    List<report_employee> r_m1 = db.report_employee.ToList();
                    foreach (var item in em1)
                    {
                        //bool ad = true;
                        double hour_per_day = item.salary / 30;
                        foreach (var item2 in r_m1)
                        {
                            if ((item2.id_emp==item.id_employee ) && (item2.attend_days == true))
                            {


                                if (item2.active == false)
                                {

                                    item.total_attend += 1;

                                    item2.active = true;
                                }

                                item.total_hour_bouns = item.total_hour_bouns + (double)item2.extra;
                                item.total_hour_discount = item.total_hour_discount + (double)item2.discount;
                            }


                        }
                        item.total_hour_bouns_salary = ((hour_per_day / 8) * item.total_hour_bouns);
                        item.total_hour_discount_salary = ((hour_per_day / 8) * item.total_hour_discount);

                        double salary_ = hour_per_day * (double)item.total_attend;
                        item.salary_real = salary_ + item.total_hour_bouns_salary - item.total_hour_discount_salary;

                        db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    }
                    db.SaveChanges();
                    return View(em1);
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
        public ActionResult Detail(int id)
        {
            employee em1 = db.employee.Where(m=>m.id_employee==id).FirstOrDefault();
            List<report_employee> r_m1 = db.report_employee.Where(m=>m.id_emp==id).ToList();

                //bool ad = true;
                double hour_per_day = em1.salary / 30;
               
            ViewBag.general_setting = db.general_setting.Where(m => m.id_genral_setting == 1).FirstOrDefault();
            ViewBag.salary_per_day = hour_per_day;
            ViewBag.emm = em1;
            return View(r_m1);

        }

        public ActionResult Search_employee_name(string name_employee)
        {
            if (Session["HR_id"] != null || Session["admin_id"] != null)
            {
                int admin_id = 0;
                if (Session["admin_id"] != null)
                    admin_id = (int)Session["admin_id"];

                bool auth = auth_show_salary_report(admin_id);
                if (auth==true || Session["HR_id"] != null)
                {
                    if (name_employee != null)
                    {
                        List<report_employee> r_m1 = db.report_employee.ToList();

                        employee em1 = db.employee.Where(n => n.name_emp == name_employee).FirstOrDefault();

                        double hour_per_day = em1.salary / 30;
                        foreach (var item2 in r_m1)
                        {
                            if ((item2.id_emp == em1.id_employee) && (item2.attend_days == true))
                            {


                                em1.total_hour_bouns = em1.total_hour_bouns + (double)item2.extra;
                                em1.total_hour_discount = em1.total_hour_discount + (double)item2.discount;

                            }

                        }
                        em1.total_hour_bouns_salary = ((hour_per_day / 8) * em1.total_hour_bouns);
                        em1.total_hour_discount_salary = ((hour_per_day / 8) * em1.total_hour_discount);

                        double salary_ = hour_per_day * (double)em1.total_attend;
                        em1.salary_real = salary_ + em1.total_hour_bouns_salary - em1.total_hour_discount_salary;

                        return View(em1);

                    }
                    else
                    {
                        TempData["Message"] = "the name is not founded ";

                        return Redirect(Request.UrlReferrer.ToString());
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
        public ActionResult Search_employee_by_date( DateTime startDate, DateTime endDate)
        {
            if (Session["HR_id"] != null || Session["admin_id"] != null)
            {
                int admin_id = 0;
                if (Session["admin_id"] != null)
                    admin_id = (int)Session["admin_id"];

                bool auth = auth_show_salary_report(admin_id);
                
                if (auth==true || Session["HR_id"] != null)
                {
                    List<employee> em1 = db.employee.ToList();
                    List<report_employee> r_m1 = db.report_employee.Where(d => d.date_of_today >= startDate && d.date_of_today <= endDate).ToList();

                    foreach (var item in em1)
                    {
                        double hour_per_day = item.salary / 30;
                        foreach (var item2 in r_m1)
                        {
                            if ((item2.id_emp == item.id_employee) && (item2.attend_days == true))
                            {
                                item.total_hour_bouns = item.total_hour_bouns + (double)item2.extra;
                                item.total_hour_discount = item.total_hour_discount + (double)item2.discount;
                            }

                        }
                        item.total_hour_bouns_salary = ((hour_per_day / 8) * item.total_hour_bouns);
                        item.total_hour_discount_salary = ((hour_per_day / 8) * item.total_hour_discount);

                        double salary_ = hour_per_day * (double)item.total_attend;
                        item.salary_real = salary_ + item.total_hour_bouns_salary - item.total_hour_discount_salary;


                    }
                    List<employee> ee1 = new List<employee>();

                    foreach (var item in r_m1)
                    {
                        employee e1 = db.employee.Where(m => m.id_employee == item.id_emp).FirstOrDefault();
                        ee1.Add(e1);
                    }

                    return View("salary_report", ee1);
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
       
        private bool Check_if_enter_before_or_not(report_employee emp)
        {
            return db.report_employee.Where(m => m.id_emp == emp.id_emp).Any(m => m.date_of_today == emp.date_of_today);
        }
        private bool Check_Holiday_date_of_conference(employee employee_add)
        {
            DateTime date = employee_add.date_of_conference;
            DayOfWeek day = date.DayOfWeek;

            general_setting g1 = db.general_setting.Where(m => m.id_genral_setting == 1).FirstOrDefault();
            string holidayDay = g1.hoilday_day;
            return (holidayDay.Contains(day.ToString()));


        }
        private bool Check_Holiday(report_employee employee_add)
        {
            DateTime date = employee_add.date_of_today;
            DayOfWeek day = date.DayOfWeek;

            general_setting g1 = db.general_setting.Where(m => m.id_genral_setting == 1).FirstOrDefault();
            string holidayDay = g1.hoilday_day;
            return (holidayDay.Contains(day.ToString()));


        }

        private void check_absent(report_employee emp)
        {
            bool make_absent = db.report_employee.Any(m => m.date_of_today == emp.date_of_today);
            if (make_absent == false)
            {
                List<employee> absent_employee;
                var em11 = db.employee.ToList();
                //this functin for check if empty or not and put default value for it 
                Isempty(em11);
                absent_employee = em11.Select(m =>
                {
                    m.total_absent += 1;
                    return m;
                }).ToList();


                foreach (var item in em11)
                {
                    db.Entry(item).State = System.Data.Entity.EntityState.Modified;

                }

                // your code that saves changes to the database
                db.SaveChanges();



            }

        }
        private void Isempty(List<employee> list)
        {
            bool isEmpty = !db.report_employee.Any();

            if (isEmpty)
            {
                
                List<employee> absent_employee;
                absent_employee = list.Select(m =>
                {
                    m.total_absent = 0;
                    m.total_attend = 0;
                    return m;
                }).ToList();
                foreach (var item in list)
                {
                    db.Entry(item).State = System.Data.Entity.EntityState.Modified;

                }

                // your code that saves changes to the database
                db.SaveChanges();
            }
            return;
        }
    }

}