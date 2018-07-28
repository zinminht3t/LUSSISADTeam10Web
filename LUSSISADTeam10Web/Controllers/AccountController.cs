﻿using LUSSISADTeam10Web.API;
using LUSSISADTeam10Web.Constants;
using LUSSISADTeam10Web.Models;
using LUSSISADTeam10Web.Models.Account;
using LUSSISADTeam10Web.Models.APIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.SessionState;

namespace LUSSISADTeam10Web.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return PartialView(new UserViewModel());
        }

        [HttpPost]
        public ActionResult Login(UserViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                string username = model.Username;
                string password = model.Password;

                string token = "";

                token = APIAccount.GetToken(username, password, out string error);

                // User found in the database
                if (error == "" || token != "")
                {
                    FormsAuthentication.SetAuthCookie(token, false);
                    Session["token"] = token;

                    UserModel um = APIAccount.GetUserProfile(token, out error);
                    Session["user"] = um;
                    Session["role"] = um.Role;
                    Session["department"] = um.Deptname;


                    //if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                    //    && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    //{
                    //    return Redirect(returnUrl);
                    //}
                    //else
                    //{


             

                    switch (um.Role)
                    {
                        case ConUser.Role.CLERK:
                            return RedirectToAction("Index", "Clerk");
                        case ConUser.Role.SUPERVISOR:
                            return RedirectToAction("Index", "Supervisor");
                        case ConUser.Role.DEPARTMENTREP:
                            return RedirectToAction("Index", "DepartmentRep");
                        case ConUser.Role.EMPLOYEE:
                            return RedirectToAction("Index", "Employee");
                        case ConUser.Role.HOD:
                            return RedirectToAction("Index", "HOD");
                        case ConUser.Role.MANAGER:
                            return RedirectToAction("Index", "Manager");
                        case ConUser.Role.TEMPHOD:
                            return RedirectToAction("Index", "Employee");
                    }
                    return RedirectToAction("Login", "Account");
                    //}
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }
            return PartialView(model);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        public PartialViewResult GetNotifications()
        {
            string token = GetToken();
            UserModel um = GetUser();
            string error = "";
            List<NotificationModel> notis = new List<NotificationModel>();


            notis = APINotification.GetNotiByunread(false, um.Deptid, um.Role, token, out error);



            ViewBag.NotiCount = notis.Count;
            ViewBag.Notifications = notis;
            return PartialView();
        }


        #region Utilities
        public string GetToken()
        {
            string token = "";
            token = (string)Session["token"];
            if (string.IsNullOrEmpty(token))
            {
                token = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
                Session["token"] = token;
                UserModel um = APIAccount.GetUserProfile(token, out string error);
                Session["user"] = um;
                Session["role"] = um.Role;
            }
            return token;
        }
        public UserModel GetUser()
        {
            UserModel um = (UserModel)Session["user"];
            if (um == null)
            {
                GetToken();
                um = (UserModel)Session["user"];
            }
            return um;
        }
        #endregion

    }
}