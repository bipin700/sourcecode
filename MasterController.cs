using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using Assignment.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Assignment.Controllers
{
    public class MasterController : Controller
    {
        AssignmentContext db = new AssignmentContext();
        // GET: Master
        public ActionResult Index()
        {
            var Friendlist = db.Frnds.OrderByDescending(i => i.id).ToList();
            return View(Friendlist);
        }

        public JsonResult ShowRecord(long FrndId)
        {
            try
            {
                var FrndList = db.Frnds.Where(p => p.id == FrndId).ToList();
                return Json(FrndList, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }            
        }

        public JsonResult AddRecord(tblFriends frnds,string Datalist)
        {
            try
            {
                Random rnd = new Random();
                long FrndId = rnd.Next();
                tblFriends tblFriend = new tblFriends();
                tblPhones tblPhone = new tblPhones();
                JObject Obj = JObject.Parse(Datalist);
                JArray Arr = (JArray)Obj["PhoneData"];     
                
                IList<tblPhones> phone = Arr.ToObject<IList<tblPhones>>().ToList();
                frnds.FriendId = FrndId;
                db.Frnds.Add(frnds);
                db.SaveChanges();
                foreach (var v in phone)
                {
                    tblPhone.AreaCode = v.AreaCode;
                    tblPhone.Phone = v.Phone;
                    tblPhone.PhoneType = v.PhoneType;
                    tblPhone.FriendId = FrndId;
                    db.Phone.Add(tblPhone);
                    db.SaveChanges();
                }
                var FrndList = db.Frnds.OrderByDescending(i => i.id).ToList();
                return Json(FrndList, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult UpdateRecord(tblFriends frnds)
        {
            try
            {
                tblFriends tblFriend = db.Frnds.Where(p => p.id == frnds.id).FirstOrDefault();
                DateTime DateOfBirth = Convert.ToDateTime(frnds.DOB);                
                tblFriend.Mobile = frnds.Mobile;
                tblFriend.Name = frnds.Name;
                tblFriend.CountryCode = frnds.CountryCode;
                tblFriend.DOB = frnds.DOB;
                db.SaveChanges();
                var FrndList = db.Frnds.OrderByDescending(i => i.id).ToList();
                return Json(FrndList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
    }
}