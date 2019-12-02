using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Web.Proxy;


namespace Web.Controllers
{
    public class LoginController : Controller
    {
       // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        //// GET: Login/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Login/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Login/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Login/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Login/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Login/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Login/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        [HttpPost]
        public ActionResult Login(string userName, string password)
        {
            var token = TokenDetails(userName, password);
            return Json(token);
        }

        public Dictionary<string, string> TokenDetails(string userName, string password)
        {
            Dictionary<string, string> tokenDetails = null;
            try
            {
                using (var client = new HttpClient())
                {
                    var login = new Dictionary<string, string>
                   {
                       {"grant_type", "password"},
                       {"username", userName},
                       {"password", password},
                   };

                    var resp = client.PostAsync("http://localhost:52663/token", new FormUrlEncodedContent(login));
                    resp.Wait(TimeSpan.FromSeconds(10));

                    if (resp.IsCompleted)
                    {
                        if (resp.Result.Content.ReadAsStringAsync().Result.Contains("access_token"))
                        {
                            tokenDetails = JsonConvert.DeserializeObject<Dictionary<string, string>>(resp.Result.Content.ReadAsStringAsync().Result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return tokenDetails;
        }
    }
}
