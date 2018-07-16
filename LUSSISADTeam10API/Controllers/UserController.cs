﻿using LUSSISADTeam10API.Constants;
using LUSSISADTeam10API.Models;
using LUSSISADTeam10API.Models.APIModels;
using LUSSISADTeam10API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LUSSISADTeam10API.Models.DBModels;
using LUSSISADTeam10API.Repositories;
using LUSSISADTeam10API.Constants;
using LUSSISADTeam10API.Models;


namespace LUSSISADTeam10API.Controllers
{
    public class UserController : ApiController
    {
        // Start Phyo2

        [HttpGet]
        [Route("api/user/role/{role}/{deptid}")]
        public IHttpActionResult GetUserByRole(int role,int deptid)
        {
            string error = "";
            List<UserModel> usm = UserRepo.GetUserByRoleandDeptid(role,deptid, out error);
            if (error != "" || usm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "User Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(usm);
        }


      
        // End Phyo2


        // Start TAZ
        [HttpGet]
        [Route("api/user/depid/{depid}")]
        public IHttpActionResult GetRequisitionByDepid(int depid)
        {
            string error = "";
            
            List<UserModel> usm = UserRepo.GetUserByDeptid(depid, out error);
            if (error != "" || usm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "User Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(usm);
        }

       
        // End TAZ
    }
}