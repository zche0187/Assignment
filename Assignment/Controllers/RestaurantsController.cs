using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Assignment.Models;

namespace Assignment.Controllers
{
    public class RestaurantsController : Controller
    {
        private RestaurantBookingModelContainer db = new RestaurantBookingModelContainer();

        // GET: Restaurants
        public ActionResult Index()
        {
            return View(db.RestaurantsSet.ToList());
        }

        public ActionResult Search()
        {
            return View(db.RestaurantsSet.ToList());
        }

        // GET: Restaurants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurants restaurants = db.RestaurantsSet.Find(id);
            if (restaurants == null)
            {
                return HttpNotFound();
            }
            return View(restaurants);
        }

        // GET: Restaurants/Create
        public ActionResult Create()
        {
            ViewBag.date = DateTime.Now;
            return View();
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Location,Signaturedish,ReceptionCapacity,PerCapitaConsumption,OpeningHours,Date")] Restaurants restaurants)
        {
            if (ModelState.IsValid)
            {
                restaurants.Date = DateTime.Now.ToLongDateString();
                db.RestaurantsSet.Add(restaurants);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.date = ViewBag.CurrentDate.ToLongDateString();
            restaurants.Date = ViewBag.CurrentDate.ToLongDateString();
            return View(restaurants);
        }

        // GET: Restaurants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurants restaurants = db.RestaurantsSet.Find(id);
            if (restaurants == null)
            {
                return HttpNotFound();
            }
            return View(restaurants);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Location,Signaturedish,ReceptionCapacity,PerCapitaConsumption,OpeningHours,Date")] Restaurants restaurants)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurants).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurants);
        }

        // GET: Restaurants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurants restaurants = db.RestaurantsSet.Find(id);
            if (restaurants == null)
            {
                return HttpNotFound();
            }
            return View(restaurants);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurants restaurants = db.RestaurantsSet.Find(id);
            db.RestaurantsSet.Remove(restaurants);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        // GET: SendEmail
        public ActionResult SendMessage()
        {
            return View(new SendEmailViewModel());
        }
        [HttpPost]
        public ActionResult SendMessage(SendEmailViewModel model)
        {
            MailAddress MessageFrom = new MailAddress("q7044566909@163.com"); //发件人邮箱地址
            string MessageTo = model.ToEmail; //收件人邮箱地址
            string MessageSubject = model.Subject; //邮件主题
            string MessageBody = model.Contents; //邮件内容 （一般是一个网址链接，生成随机数加验证id参数，点击去网站验证。）

            if (SendMail(MessageFrom, MessageTo, MessageSubject, MessageBody))
            {
                ViewBag.Result = "Success!";
            }
            else
            {
                ViewBag.Result = "Fail!";
            }

            return View(new SendEmailViewModel());
        }
        public bool SendMail(MailAddress MessageFrom, string MessageTo, string MessageSubject, string MessageBody)   //发送验证邮件
        {
            MailMessage message = new MailMessage();
            message.To.Add(MessageTo);
            message.From = MessageFrom;
            message.Subject = MessageSubject;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.Body = MessageBody;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = false; //是否为html格式
            message.Priority = MailPriority.High; //发送邮件的优先等级
            SmtpClient sc = new SmtpClient();
            sc.EnableSsl = false;//是否SSL加密
            sc.Host = "smtp.163.com"; //指定发送邮件的服务器地址或IP
            sc.Port = 25; //指定发送邮件端口
            sc.Credentials = new System.Net.NetworkCredential("q7044566909@163.com", "KDPJAJZUZAXIHLGG"); //指定登录服务器的用户名和密码(注意：这里的密码是开通上面的pop3/smtp服务提供给你的授权密码，不是你的qq密码)

            try
            {
                sc.Send(message); //发送邮件
            }
            catch (Exception e)
            {
                Response.Write(e.Message);
                return false;
            }
            return true;

        }
        
    }
}
