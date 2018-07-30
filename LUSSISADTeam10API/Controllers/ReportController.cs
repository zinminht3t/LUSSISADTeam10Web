﻿using LUSSISADTeam10API.Constants;
using LUSSISADTeam10API.Models.APIModels;
using LUSSISADTeam10API.Models.DBModels;
using LUSSISADTeam10API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
namespace LUSSISADTeam10API.Controllers
{
    [Authorize]
    public class ReportController :ApiController
    {
        // start zmh
        [HttpGet]
        [Route("api/poforfivemonths")]
        public IHttpActionResult GetPOFor5Months()
        {
            string error = "";
            List<PurchaseOrderFor5MonthModel> rl = ReportRepo.GetPOFor5Months(out error);
            if (error != "" || rl == null)
            {
                if (error == ConError.Status.NOTFOUND)
                    return Content(HttpStatusCode.NotFound, "Report Is Not Found");
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(rl);
        }

        [HttpGet]
        [Route("api/itemtrendanalysis/{d1}/{d2}/{d3}/{category}")]
        public IHttpActionResult ItemTrend(int d1, int d2, int d3, int category)
        {
            string error = "";
            List<ItemTrendAnalysisModel> rl = ReportRepo.ItemTrendAnalysis(d1, d2, d3, category, out error);
            if (error != "" || rl == null)
            {
                if (error == ConError.Status.NOTFOUND)
                    return Content(HttpStatusCode.NotFound, "Report Is Not Found");
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(rl);
        }

        // end zmh

        // start hwy

        [HttpGet]
        [Route("api/frequentlyordered5hod/{id}")]
        public IHttpActionResult GetFreqOrdered5ItemHod(int id)
        {
            string error = "";
            List<RequisitionDetailsModel> rdms = new List<RequisitionDetailsModel>();
            List<RequisitionModel> rm = RequisitionRepo.GetRequisitionByDepid(id, out error)
                .Where(x => x.Reqdate.Value.Year == DateTime.Today.Year).ToList();
            foreach (RequisitionModel x in rm)
            {
                foreach (RequisitionDetailsModel xx in x.Requisitiondetails)
                {
                    rdms.Add(xx);
                }
            }
            var result = rdms.GroupBy(x => new { x.Itemid, x.Itemname })
                .Select(xx => new {
                    Quantity = xx.Sum(y => y.Qty),
                    description = xx.Key.Itemname
                }).OrderByDescending(x => x.Quantity);

            if (error != "" || rm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                    return Content(HttpStatusCode.NotFound, "Report Is Not Found");
                return Content(HttpStatusCode.BadRequest, error);
            }
            if (result.Count() < 6)
                return Ok(result);
            else
                return Ok(result.Take(5));
        }


        // end hwy


    }
}