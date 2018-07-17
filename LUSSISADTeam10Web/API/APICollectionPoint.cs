﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LUSSISADTeam10API.Models.APIModels;
using LUSSISADTeam10Web.Models.APIModels;
using Newtonsoft.Json;
using RestSharp;


namespace LUSSISADTeam10Web.API
{
    public class APICollectionPoint
    {
        public static List<CollectionPointModel> GetAllCollectionPoints(string token, out string error)
        {
            string url = APIHelper.Baseurl + "/collectionpoints/";
            List<CollectionPointModel> cpm = APIHelper.Execute<List<CollectionPointModel>>(token, url, out error);
            return cpm;
        }
        public static List<CollectionPointModel> GetCollectionPointBycpid(string token, int cpid, out string error)
        {
            string url = APIHelper.Baseurl + "/collectionpoint/" + cpid;
            List<CollectionPointModel> cpm = APIHelper.Execute<List<CollectionPointModel>>(token, url, out error);
            return cpm;
        }
        public static List<CollectionPointModel> GetCollectionPointByReqid(string token,int reqid, out string error)
        {
            string url = APIHelper.Baseurl + "/collectionpoint/requisition" + reqid;
            List<CollectionPointModel> cpm = APIHelper.Execute<List<CollectionPointModel>>(token, url, out error);
            return cpm;
        }

        public static List<CollectionPointModel> GetCollectionPointByDeptid(string token, int deptid, out string error)
        {
            string url = APIHelper.Baseurl + "/collectionpoint/department" + deptid;
            List<CollectionPointModel> cpm = APIHelper.Execute<List<CollectionPointModel>>(token, url, out error);
            return cpm;
        }

        public static List<CollectionPointModel> GetCollectionPointByLockerid(string token, int lockerid, out string error)
        {
            string url = APIHelper.Baseurl + "/collectionpoint/lockercollectionpoint" + lockerid;
            List<CollectionPointModel> cpm = APIHelper.Execute<List<CollectionPointModel>>(token, url, out error);
            return cpm;
        }

        public static DepartmentCollectionPointModel GetDepartmentCollectionPointByDcpid(string token, int dcpid, out string error)
        {
            string url = APIHelper.Baseurl + "/departmentcollection/" + dcpid;
            DepartmentCollectionPointModel dcpm = APIHelper.Execute<DepartmentCollectionPointModel>(token, url, out error);
            return dcpm;
        }
        public static CollectionPointModel CreateCollectionPoint(string token, CollectionPointModel cpm, out string error)
        {
            error = "";
            string url = APIHelper.Baseurl + "/collectionpoint/create";
            string objectstring = JsonConvert.SerializeObject(cpm);
            cpm = APIHelper.Execute<CollectionPointModel>(token, objectstring, url, out error);
            return cpm;
        }

        public static CollectionPointModel UpdateCollectionPoint(string token, CollectionPointModel cpm, out string error)
        {
            error = "";
            string url = APIHelper.Baseurl + "/collectionpoint/update";
            string objectstring = JsonConvert.SerializeObject(cpm);
            cpm = APIHelper.Execute<CollectionPointModel>(token, objectstring, url, out error);
            return cpm;
        }
    }
}