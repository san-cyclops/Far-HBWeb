
using HB.HotelRez.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using HB.Utility;
using System.Data;
using System.Transactions;

namespace HB.HotelRez.Controllers
{
    public enum formId
    {
        Login = 1,
        RoomMaster = 2,
        HotelSupplier = 3,
        UserForm = 4,
        RoomUnavailable = 5,
        Promotion = 6,
        RoomPayment = 7,
        BookingCancellation = 8,
        RoomBooking = 9,

    }

    public class HomeController : Controller
    {
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            ViewBag.Message = "Login page.";

            return View();
        }

        [Route("home/login")]
        [HttpPost]
        public JsonResult login(LoginData model)
        {
            var db = new HBNEWEntities();
            try
            {

                var logindata = db.HRZUsers.Where(x => x.UserName == model.username && x.PassWord == model.password).FirstOrDefault();

                if (logindata != null)
                {
                    if (logindata.UserType == 1)
                    {
                        Session["HotelCodeSession"] = logindata.HotelCode;
                        Session["LoginUser"] = logindata.UserType;
                        return Json("0");
                    }
                    else if (logindata.UserType == 2)
                    {
                        Session["HotelCodeSession"] = logindata.HotelCode;
                        Session["LoginUser"] = logindata.UserType;
                        return Json("1");
                    }

                    else if (logindata.UserType == 3)
                    {
                        Session["HotelCodeSession"] = logindata.HotelCode;
                        Session["LoginUser"] = logindata.UserType;
                        return Json("2");
                    }

                    else
                    {
                        return Json("User Type not inserted by the admin!");
                    }


                }
                else
                {
                    return Json("You are not registered!! Intruder Detected!! Taking defensive actions!!");
                }


            }
            catch (Exception ex)
            {


            }

            return Json("Wrong username or password", JsonRequestBehavior.AllowGet);
        }

        public ActionResult RoomMaster()
        {
            var db = new HBNEWEntities();
            try
            {
                var hotelCode = Convert.ToString(Session["HotelCodeSession"]);
                var user = Convert.ToInt32(Session["LoginUser"]);
                var userint = Convert.ToInt32(user);
                var formIdx = Convert.ToInt32(formId.RoomMaster);
                var privilage = db.HRZUserPrivileges.Where(x => x.UserType == user && x.FormID == formIdx).FirstOrDefault();
                if (privilage.IsAccess == 1)
                {
                    UnabailableList rm = new UnabailableList();
                    rm.Rooms = GetRoomId(hotelCode);
                    return View(rm);
                }
                else if (privilage.IsAccess == 0)
                {
                    return RedirectToAction("NoPermission", "Home");
                }
                else
                    return RedirectToAction("NoPermission", "Home");


            }
            catch (Exception ex)
            {
                return RedirectToAction("NoPermission", "Home");
            }


        }

        public ActionResult HotelSupplier()
        {
            var db = new HBNEWEntities();
            HotelSupplierData hotelsupplier = new HotelSupplierData();
            try
            {
                var user = Convert.ToInt32(Session["LoginUser"]);
                hotelsupplier.HotelCode = Convert.ToString(Session["HotelCodeSession"]);
                var userint = Convert.ToInt32(user);
                var formIdx = Convert.ToInt32(formId.HotelSupplier);
                var privilage = db.HRZUserPrivileges.Where(x => x.UserType == user && x.FormID == formIdx).FirstOrDefault();
                if (privilage.IsAccess == 1)
                {
                    return View(hotelsupplier);

                }
                else if (privilage.IsAccess == 0)
                {
                    return RedirectToAction("NoPermission", "Home");
                }
                else
                    return RedirectToAction("NoPermission", "Home");


            }
            catch (Exception ex)
            {
                return RedirectToAction("NoPermission", "Home");
            }
        }

        public ActionResult NoPermission()
        {
            return View();
        }


        [HttpPost]
        public JsonResult GetHotelSupplierData(HotelSupplierData hotelSupplierData)
        {
            try

            {
                HRZHotelSupplier hotelsupplier = new HRZHotelSupplier();
                HRZHotelImage hotelimage = new HRZHotelImage();
                HRZLanguage languages = new HRZLanguage();

                //hotelsupplier.HotelCode = hotelSupplierData.HotelCode;
                hotelsupplier.HotelCode = Convert.ToString(Session["HotelCodeSession"]);
                hotelsupplier.HotelName = hotelSupplierData.HotelName;
                hotelsupplier.Address = hotelSupplierData.Address;
                hotelsupplier.StarRating = hotelSupplierData.StarRating;
                hotelsupplier.ContactPerson = hotelSupplierData.Contactperson;
                hotelsupplier.Owner = hotelSupplierData.OwnerName;
                hotelsupplier.Email = hotelSupplierData.Email;
                hotelsupplier.Telephone = hotelSupplierData.Telephone;
                hotelsupplier.Latitude = hotelSupplierData.Lat;
                hotelsupplier.Longitude = hotelSupplierData.Long;
                hotelsupplier.Description = hotelSupplierData.Description;
                hotelsupplier.IsInternetAvailable = hotelSupplierData.IsInternetAvailable;
                hotelsupplier.TypeOfInternet = hotelSupplierData.TypeOfInternet;
                hotelsupplier.WhereIsInternet = hotelSupplierData.WhereIsInternet;
                hotelsupplier.IsParkingAvailable = hotelSupplierData.IsParkAvailable;
                hotelsupplier.ParkingPrivateOrOnSite = hotelSupplierData.ParkingPrivateOrOnSite;
                hotelsupplier.ReservationNeedForParking = hotelSupplierData.ReservationNeedForParking;
                hotelsupplier.PriceForParking = hotelSupplierData.PriceForParking;
                hotelsupplier.AccomodateChildren = hotelSupplierData.AccomodateChildren;
                hotelsupplier.PetsAllowed = hotelSupplierData.PetsAllowed;
                hotelsupplier.SpeakingLanguage = hotelSupplierData.SpeakingLanguage;
                hotelsupplier.CheckInTime = hotelSupplierData.CheckInTime;
                hotelsupplier.CheckOutTime = hotelSupplierData.CheckOutTime;

                using (var db = new HBNEWEntities())
                {
                    foreach (var x in hotelSupplierData.UrlList)
                    {
                        string output = x.Substring(x.IndexOf(',') + 1);
                        hotelimage.HotelImage = Convert.FromBase64String(output);
                        hotelimage.HotelCode = Convert.ToString(Session["HotelCodeSession"]);
                        db.HRZHotelImages.Add(hotelimage);
                        db.SaveChanges();
                    }
                    foreach (var y in hotelSupplierData.OtherLanguages)
                    {
                        languages.Language = y;
                        languages.HotelCode = Convert.ToString(Session["HotelCodeSession"]);
                        db.HRZLanguages.Add(languages);
                        db.SaveChanges();
                    }


                    db.HRZHotelSuppliers.Add(hotelsupplier);
                    db.SaveChanges();

                }



                return Json("Successfully Saved");

            }



            catch (Exception ex)
            {


                return Json("oOps! something went wrong");

            }
        }

        public byte[] ConvertToBytes(HttpPostedFileBase image)

        {

            byte[] imageBytes = null;

            BinaryReader reader = new BinaryReader(image.InputStream);

            imageBytes = reader.ReadBytes((int)image.ContentLength);

            return imageBytes;

        }


        public ActionResult UserForm()
        {
            var db = new HBNEWEntities();
            try
            {
                var user = Convert.ToInt32(Session["LoginUser"]);
                var userint = Convert.ToInt32(user);
                var formIdx = Convert.ToInt32(formId.UserForm);
                var privilage = db.HRZUserPrivileges.Where(x => x.UserType == user && x.FormID == formIdx).FirstOrDefault();
                if (privilage.IsAccess == 1)
                {
                    UserFormData hc = new UserFormData();
                    hc.HotelCodes = GetHotelCode();
                    hc.UserNames = GetUserName();

                    return View(hc);

                }
                else if (privilage.IsAccess == 0)
                {
                    return RedirectToAction("NoPermission", "Home");
                }
                else
                    return RedirectToAction("NoPermission", "Home");


            }
            catch (Exception ex)
            {
                return RedirectToAction("NoPermission", "Home");
            }
        }

        private static List<SelectListItem> GetHotelCode()
        {
            try
            {
                List<SelectListItem> items = new List<SelectListItem>();
                using (var db = new HBNEWEntities())
                {
                    var roomid = db.HRZHotelSuppliers.Select(x => new
                    {
                        rId = x.HotelCode

                    }).ToList();
                    foreach (var x in roomid)
                    {
                        items.Add(new SelectListItem
                        {
                            Text = x.rId
                        });
                    }
                }
                return items;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static List<SelectListItem> GetUserName()
        {
            try
            {
                List<SelectListItem> items = new List<SelectListItem>();
                using (var db = new HBNEWEntities())
                {
                    var userName = db.HRZUsers.Select(x => new
                    {
                        rId = x.UserName

                    }).ToList();
                    foreach (var x in userName)
                    {
                        items.Add(new SelectListItem
                        {
                            Text = x.rId
                        });
                    }
                }
                return items;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public JsonResult GetUserFormData(UserFormData userFormData)
        {

            try

            {
                HRZUser user = new HRZUser();


                if (userFormData.UserType == "Admin")
                {
                    user.UserType = 1;
                }
                if (userFormData.UserType == "User")
                {
                    user.UserType = 2;
                }
                if (userFormData.UserType == "Guest")
                {
                    user.UserType = 3;
                }

                user.UserName = userFormData.UserName;
                user.PassWord = userFormData.Password;
                user.HotelCode = userFormData.HotelCode;

                using (var db = new HBNEWEntities())
                {
                    using (TransactionScope transaction = new TransactionScope()) { }
                    bool IsExist = IsExistuser(userFormData);
                    if (!IsExist)
                    {
                        db.HRZUsers.Add(user);
                        db.SaveChanges();

                    }
                    else
                    {
                        user = new HRZUser();
                        user = db.HRZUsers.Where(x => x.UserName == userFormData.UserName && x.HotelCode == userFormData.HotelCode).FirstOrDefault();
                        user.UserName = userFormData.UserName;
                        user.PassWord = userFormData.Password;
                        user.HotelCode = userFormData.HotelCode;
                        db.SaveChanges();

                    }


                }

                return Json("Successfully Saved");

            }

            catch (Exception ex)
            {


                return Json("oOps! something went wrong");

            }
        }

        public bool IsExistuser(UserFormData userfrmData)
        {

            if (GetUserByUserByuserName(userfrmData) != null) { return true; }
            else { return false; }

        }
        public HRZUser GetUserByUserByuserName(UserFormData userdata)
        {
            using (var db = new HBNEWEntities())
            {
                // var hotelcode = Session["HotelCodeSession"].ToString();
                return db.HRZUsers.Where(x => x.UserName == userdata.UserName && x.HotelCode == userdata.HotelCode).FirstOrDefault();
            }
        }


        public ActionResult RoomUnavailable()
        {

            try
            {
                var hotelCode = Convert.ToString(Session["HotelCodeSession"]);
                var db = new HBNEWEntities();
                var user = Convert.ToInt32(Session["LoginUser"]);
                var userint = Convert.ToInt32(user);
                var formIdx = Convert.ToInt32(formId.HotelSupplier);
                var privilage = db.HRZUserPrivileges.Where(x => x.UserType == user && x.FormID == formIdx).FirstOrDefault();
                if (privilage.IsAccess == 1)
                {
                    UnabailableList rm = new UnabailableList();
                    rm.Rooms = GetRoomId(hotelCode);
                    return View(rm);
                }
                else if (privilage.IsAccess == 0)
                {
                    return RedirectToAction("NoPermission", "Home");
                }
                else
                {
                    return RedirectToAction("NoPermission", "Home");
                }



            }
            catch (Exception ex)
            {
                return RedirectToAction("NoPermission", "Home");
            }
            //try
            //{


            //    // ViewBag.Message = "Room Unavailable Master page.";
            //    //  return View();
            //    UnabailableList rm = new UnabailableList();
            //            rm.Rooms = GetRoomId();
            //            return View(rm);


            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

        }
        public ActionResult AdminDashboard()
        {
            ViewBag.Message = "Admin Dashboard page.";

            return View();
        }
        public ActionResult Promotion()
        {
            var db = new HBNEWEntities();
            try
            {
                var hotelCode = Convert.ToString(Session["HotelCodeSession"]);
                var user = Convert.ToInt32(Session["LoginUser"]);
                var userint = Convert.ToInt32(user);
                var formIdx = Convert.ToInt32(formId.Promotion);
                var privilage = db.HRZUserPrivileges.Where(x => x.UserType == user && x.FormID == formIdx).FirstOrDefault();
                if (privilage.IsAccess == 1)
                {
                    PromotionData promodata = new PromotionData();
                    promodata.Rooms = GetRoomId(hotelCode);
                    return View(promodata);

                }
                else if (privilage.IsAccess == 0)
                {
                    return RedirectToAction("NoPermission", "Home");
                }
                else
                    return RedirectToAction("NoPermission", "Home");


            }
            catch (Exception ex)
            {
                return RedirectToAction("NoPermission", "Home");
            }
        }

        public ActionResult RoomPayment()
        {
            var db = new HBNEWEntities();
            try
            {
                var user = Convert.ToInt32(Session["LoginUser"]);
                var userint = Convert.ToInt32(user);
                var formIdx = Convert.ToInt32(formId.RoomPayment);
                var privilage = db.HRZUserPrivileges.Where(x => x.UserType == user && x.FormID == formIdx).FirstOrDefault();
                if (privilage.IsAccess == 1)
                {
                    return View();

                }
                else if (privilage.IsAccess == 0)
                {
                    return RedirectToAction("NoPermission", "Home");
                }
                else
                    return RedirectToAction("NoPermission", "Home");


            }
            catch (Exception ex)
            {
                return RedirectToAction("NoPermission", "Home");
            }
        }
        [HttpPost]
        public JsonResult SavePromotion(PromotionData promotiondata)
        {
            try
            {
                var hotelcode = Session["HotelCodeSession"].ToString();
                HRZPromotion promotionDb = new HRZPromotion();
                if (promotiondata.PromotionType == "1")
                {
                    foreach (var x in promotiondata.RoomID)
                    {
                        promotionDb.DiscountPercentage = promotiondata.DiscountPercentage;
                        promotionDb.DiscountValue = promotiondata.DiscountValue;
                        promotionDb.HotelCode = hotelcode;
                        promotionDb.DateFrom = promotiondata.PromoDate;
                        promotionDb.DateTo = promotiondata.PromoDate;
                        promotionDb.Hours = promotiondata.Hours;
                        promotionDb.PromotionType = promotiondata.PromotionType;
                        promotionDb.RoomID = x;

                        using (var db = new HBNEWEntities())
                        {
                            db.HRZPromotions.Add(promotionDb);
                            db.SaveChanges();
                        }
                    }

                }

                else
                {
                    foreach (var y in promotiondata.RoomID)
                    {
                        promotionDb.HotelCode = hotelcode;
                        promotionDb.DateFrom = promotiondata.DateFrom;
                        promotionDb.DateTo = promotiondata.DateTo;
                        promotionDb.DiscountPercentage = promotiondata.DiscountPercentage;
                        promotionDb.DiscountValue = promotiondata.DiscountValue;
                        promotionDb.PromotionType = promotiondata.PromotionType;
                        promotionDb.RoomID = y;
                        using (var db = new HBNEWEntities())
                        {
                            db.HRZPromotions.Add(promotionDb);
                            db.SaveChanges();
                        }
                    }
                }


            }
            catch (Exception ex)
            {

            }

            return Json("Successfully Saved");
        }

        /// <summary>
        /// edited by Anu
        /// </summary>
        /// <param name="hotelRezData"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetHotelRezData(HotelRezData hotelRezData)
        {
            try
            {
                var hotelcode = Session["HotelCodeSession"].ToString();
                using (var db = new HBNEWEntities())
                {

                    using (TransactionScope transaction = new TransactionScope())
                    {


                        HRZRoomMaster roomaster = new HRZRoomMaster();
                        roomaster.Address = hotelRezData.Address;
                        roomaster.HotelName = hotelRezData.HotelName;
                        roomaster.RoomID = hotelRezData.RoomId;
                        roomaster.RoomType = hotelRezData.RoomType;
                        roomaster.Refference = hotelRezData.Refference;
                        roomaster.Price = hotelRezData.Price;
                        roomaster.BoardType = hotelRezData.BoardType;
                        roomaster.HotelCode = hotelcode;


                        bool isExist = IsExistsRooms(hotelRezData);
                        if (!isExist)
                        {
                            db.HRZRoomMasters.Add(roomaster);
                            db.SaveChanges();

                        }
                        else
                        {
                            roomaster = new HRZRoomMaster();
                            roomaster = db.HRZRoomMasters.Where(x => x.RoomID == hotelRezData.RoomId && x.HotelCode == hotelcode).FirstOrDefault();
                            roomaster.Address = hotelRezData.Address;
                            roomaster.HotelName = hotelRezData.HotelName;
                            roomaster.RoomID = hotelRezData.RoomId;
                            roomaster.RoomType = hotelRezData.RoomType;
                            roomaster.Refference = hotelRezData.Refference;
                            roomaster.Price = hotelRezData.Price;
                            roomaster.BoardType = hotelRezData.BoardType;
                            roomaster.HotelCode = hotelcode;
                            db.SaveChanges();
                        }



                        foreach (var aminity in hotelRezData.Aminitylist)
                        {
                            HRZAminity amminity = new HRZAminity();

                            amminity.RoomID = hotelRezData.RoomId;
                            amminity.Name = aminity.aminities;
                            amminity.Type = aminity.amitype;
                            amminity.HotelCode = hotelcode;

                            if (!isExist)
                            {
                                db.HRZAminities.Add(amminity);
                                db.SaveChanges();
                            }
                            else
                            {

                                amminity = new HRZAminity();
                                amminity = db.HRZAminities.Where(x => x.RoomID == hotelRezData.RoomId && x.HotelCode == hotelcode).FirstOrDefault();
                                amminity.RoomID = hotelRezData.RoomId;
                                amminity.Name = aminity.aminities;
                                amminity.Type = aminity.amitype;
                                amminity.HotelCode = hotelcode;
                                db.SaveChanges();
                            }

                        }


                        if (hotelRezData.NearByPlaces != null)
                        {

                            foreach (var nearbyplaces in hotelRezData.NearByPlaces)
                            {
                                HRZNearbyPlace nearbyplace = new HRZNearbyPlace();

                                nearbyplace.RoomID = hotelRezData.RoomId;
                                nearbyplace.NearbyName = nearbyplaces.name;
                                nearbyplace.NearbyDistance = nearbyplaces.distance;
                                nearbyplace.HotelCode = hotelcode;
                                if (!isExist)
                                {
                                    db.HRZNearbyPlaces.Add(nearbyplace);
                                    db.SaveChanges();
                                }
                                else
                                {
                                    nearbyplace = new HRZNearbyPlace();
                                    nearbyplace = db.HRZNearbyPlaces.Where(x => x.RoomID == hotelRezData.RoomId && x.HotelCode == hotelcode).FirstOrDefault();
                                    if (nearbyplace == null)
                                    {
                                        nearbyplace = new HRZNearbyPlace();
                                        nearbyplace.RoomID = hotelRezData.RoomId;
                                        nearbyplace.NearbyName = nearbyplaces.name;
                                        nearbyplace.NearbyDistance = nearbyplaces.distance;
                                        nearbyplace.HotelCode = hotelcode;
                                        db.HRZNearbyPlaces.Add(nearbyplace);
                                        db.SaveChanges();
                                    }
                                    else
                                    {
                                        nearbyplace = new HRZNearbyPlace();
                                        nearbyplace.RoomID = hotelRezData.RoomId;
                                        nearbyplace.NearbyName = nearbyplaces.name;
                                        nearbyplace.NearbyDistance = nearbyplaces.distance;
                                        nearbyplace.HotelCode = hotelcode;
                                        db.SaveChanges();
                                    }

                                }

                            }

                        }
                        transaction.Complete();

                    }
                }
                return Json("Successfully Saved");
            }

            catch (Exception ex)
            {
                return Json("oOps! something went wrong");
            }

        }


        public bool IsExistsRooms(HotelRezData hotelRezData)
        {
            if (GetRoomMasterByCode(hotelRezData) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public HRZRoomMaster GetRoomMasterByCode(HotelRezData hotelRezData)
        {
            using (var db = new HBNEWEntities())
            {
                var hotelcode = Session["HotelCodeSession"].ToString();
                return db.HRZRoomMasters.Where(x => x.RoomID == hotelRezData.RoomId && x.HotelCode == hotelcode).FirstOrDefault();

            }
        }


        [HttpPost]
        public JsonResult GetunAvailableDates(string roomID)
        {
            try
            {

                UnabailableList datelist = new UnabailableList();
                datelist.Rooms = unAvailableDateLst(roomID);

                return Json(datelist.Rooms.ToArray());
            }
            catch (Exception ex)
            {
                UnabailableList datelist = new UnabailableList();
                return Json(datelist.Rooms);
            }

        }


        [HttpPost]
        public JsonResult GetUserDetails(string userName)
        {

            UserFormData userFormdata = new UserFormData();
            using (HBNEWEntities context = new HBNEWEntities())
            {
                var query = (from cd in context.HRZUsers
                             where cd.UserName.Equals(userName)
                             select new
                             {
                                 cd.UserType,
                                 cd.PassWord,
                                 cd.UserName,
                                 cd.HotelCode
                             }).ToArray();

                foreach (var Userdetail in query)
                {
                    userFormdata = new UserFormData();
                    userFormdata.UserName = Userdetail.UserName;
                    //    userFormdata.UserType = Convert.ToString(Userdetail.UserType);
                    if (Userdetail.UserType == 1)
                    {
                        userFormdata.UserType = "Admin";
                    }
                    else if (Userdetail.UserType == 2)
                    {
                        userFormdata.UserType = "User";
                    }
                    else if (Userdetail.UserType == 3)
                    {
                        userFormdata.UserType = "Guest";
                    }
                    userFormdata.Password = Userdetail.PassWord;

                    userFormdata.HotelCode = Userdetail.HotelCode;
                }
            }

            return Json(userFormdata);
        }

        //public DataTable GetUserDetailsToTable(string username)
        //{
        //    using (HBNEWEntities context = new HBNEWEntities())
        //    {
        //        var query = (from cd in context.HRZUsers
        //                     where cd.UserName.Equals(username)
        //                     select new
        //                     {
        //                         cd.UserType,
        //                         cd.PassWord,
        //                         cd.UserName

        //                     }).ToArray();
        //                     return query;
        //    }


        //}
        public bool CheckDateisUnavailable(string roomId, string fromdate, string todate)
        {

            List<DateTime> allDates = new List<DateTime>();
            DateTime strat = DateTime.Parse(fromdate);
            DateTime end = DateTime.Parse(todate);
            UnabailableList datelist = new UnabailableList();

            for (DateTime date = strat; date <= end; date = date.AddDays(1))
            {
                allDates.Add(date);
            }

            datelist.Rooms = unAvailableDateLst(roomId);
            datelist.Rooms.ToArray();

            foreach (var z in allDates)
            {
                foreach (var item in datelist.Rooms)
                {
                    string T = z.ToString();
                    T = T.Substring(0, T.Length - 12);
                    // if (T == item.Text.Trim())
                    if (T.Equals(item.Text.Trim()))
                    {
                        return false;
                    }

                }
            }

            return true;
        }
        public string getNewBookingNo()
        {
            string DocNo = "";
            string GetNewCode = "";
            using (var db = new HBNEWEntities())
            {
                DocumentRep documentRep = new DocumentRep();
                documentRep = GetDocumentNoByForm("BookingConferm");
                GetNewCode = "B" + new StringBuilder().Insert(0, "0", (6 - (1 + DocNo.Length))) +
                                documentRep.DocumentNo;

            }
            return GetNewCode;

        }
        public DocumentRep GetDocumentNoByForm(string docType)
        {
            using (var db = new HBNEWEntities())
            {
                DocumentRep documentRep = new DocumentRep();
                var documentReps = db.DocumentReps.Where(ai => ai.DocumentType == docType).FirstOrDefault();
                if (documentReps != null)
                {

                    documentReps.DocumentNo = documentReps.DocumentNo + 1;
                    var Entry = db.Entry(documentRep);
                    db.Entry(documentReps).State = EntityState.Modified;
                    db.SaveChanges();

                }

                // UpdateDocumentNo(docType);

                return documentReps;
            }
        }



        [HttpPost]
        public JsonResult GetRoomBookingDetails(RoomBookingData roombookingdata)
        {
            try
            {
                string hotelcode = Session["HotelCodeSession"].ToString();
                bool isExsistBookingDate = CheckDateisUnavailable(roombookingdata.RoomID, roombookingdata.DateFrom, roombookingdata.DateTo);
                if (isExsistBookingDate == false)
                {

                    return Json("Please Select different DateRange! These dates are alreadybooked!");

                }

                bool updatermunavailable = updateRoomUnavailable(roombookingdata.DateFrom, roombookingdata.DateTo, roombookingdata.RoomID, hotelcode);
                if (updatermunavailable == false)
                {

                    return Json("something went wrong in saving data!");

                }
                string bookingNumber = getNewBookingNo();

                if (bookingNumber != null)
                {
                    using (var db = new HBNEWEntities())
                    {
                        HRZRoomBooking rmbking = new HRZRoomBooking();

                        var objRmMaster = db.HRZRoomMasters.Where(s => s.RoomID.Equals(roombookingdata.RoomID)).FirstOrDefault();

                        rmbking.BookingNo = bookingNumber;
                        rmbking.HotelCode = hotelcode;
                        rmbking.RoomID = roombookingdata.RoomID;
                        rmbking.DateFrom = roombookingdata.DateFrom;
                        rmbking.DateTo = roombookingdata.DateTo;
                        rmbking.Adult1Address = roombookingdata.Adult1Address;
                        rmbking.Adult1Email = roombookingdata.Adult1Email;
                        rmbking.Adult1FirstName = roombookingdata.Adult1FirastName;
                        rmbking.Adult1LastName = roombookingdata.Adult1LastName;
                        rmbking.Adult1NICNo = roombookingdata.Adult1NICNo;
                        rmbking.Adult1Telephone = roombookingdata.Adult1Telephone;
                        rmbking.Adult2FirstName = roombookingdata.Adult2FirastName;
                        rmbking.Adult2LastName = roombookingdata.Adult2LastName;
                        rmbking.Adult3FirstName = roombookingdata.Adult3FirastName;
                        rmbking.Adult3LastName = roombookingdata.Adult3LastName;
                        rmbking.Chidl3Name = roombookingdata.Child3Name;
                        rmbking.Child3Age = roombookingdata.Child3Age;
                        rmbking.Chil21Name = roombookingdata.Child2Name;
                        rmbking.child2Age = roombookingdata.Child2Age;
                        rmbking.Child1Name = roombookingdata.Child1Name;
                        rmbking.Child1Age = roombookingdata.Child1Age;
                        rmbking.Price = objRmMaster.Price.ToString();
                        rmbking.IsActive = true;

                        db.HRZRoomBookings.Add(rmbking);
                        db.SaveChanges();

                    }

                }
                return Json("Successfully Saved");
            }
            catch (Exception ex)
            {

                return Json("oOps! something went wrong");
            }

        }
        [HttpPost]
        public JsonResult GetBookingDetails()
        {

            Payment roombookingdata = new Payment();
            try
            {

                string hotelcode = Session["HotelCodeSession"].ToString();

                using (HBNEWEntities context = new HBNEWEntities())
                {



                    var query = (
                        from cd in context.HRZRoomBookings
                        join od in context.HRZRoomMasters on cd.HotelCode equals od.HotelCode
                        where cd.Ispaid.Equals(0)
                        orderby cd.RoomBookingID descending
                        select new
                        {

                            od.RoomType,
                            od.BoardType,
                            cd.Adult1FirstName,
                            cd.RoomID,
                            cd.BookingNo,
                            cd.Price,
                            cd.DateFrom,
                            cd.DateTo,
                            cd.Adult1Telephone,
                            cd.Adult1Email,
                            cd.Adult1NICNo,


                        }

                    ).Take(20).ToList();



                    return Json(query);
                }




            }
            catch (Exception ex)
            {

                return Json("oOps! something went wrong");
            }

        }

        [HttpPost]
        public JsonResult GetBookingDetailsCount()
        {

            Payment roombookingdata = new Payment();
            try
            {
                string hotelcode = Session["HotelCodeSession"].ToString();

                using (HBNEWEntities context = new HBNEWEntities())
                {



                    var query = (
                        from cd in context.HRZRoomBookings
                        select cd.RoomID


                    );

                    int x = query.Count();


                    return Json(query.Count());
                }

            }
            catch (Exception ex)
            {
                return Json("oOps! something went wrong");
            }

        }

        public bool updateRoomUnavailable(string datefrom, string dateto, string roomid, string hotelcode)
        {
            List<DateTime> allDates = new List<DateTime>();
            DateTime strat = DateTime.Parse(datefrom);
            DateTime end = DateTime.Parse(dateto);

            for (DateTime date = strat; date <= end; date = date.AddDays(1))
            {
                allDates.Add(date);
            }

            if (roomid != null)
            {
                using (TransactionScope tranceaction = new TransactionScope())
                {
                    using (var db = new HBNEWEntities())
                    {
                        HRZRoomUnavailable rmUnavailable = new HRZRoomUnavailable();
                        foreach (var date in allDates)
                        {
                            string dt = date.ToString();
                            dt = dt.Substring(0, dt.Length - 12);

                            rmUnavailable.RoomID = roomid;
                            rmUnavailable.Date = dt;
                            rmUnavailable.HotelCode = hotelcode;

                            db.HRZRoomUnavailables.Add(rmUnavailable);
                            db.SaveChanges();

                        }

                    }
                    tranceaction.Complete();
                    return true;
                }

            }
            return false;
        }
        public ActionResult BookingCancellation()
        {
            var db = new HBNEWEntities();
            try
            {
                var user = Convert.ToInt32(Session["LoginUser"]);
                var userint = Convert.ToInt32(user);
                var formIdx = Convert.ToInt32(formId.BookingCancellation);
                var privilage = db.HRZUserPrivileges.Where(x => x.UserType == user && x.FormID == formIdx).FirstOrDefault();
                if (privilage.IsAccess == 1)
                {
                    return View();

                }
                else if (privilage.IsAccess == 0)
                {
                    return RedirectToAction("NoPermission", "Home");
                }
                else
                    return RedirectToAction("NoPermission", "Home");


            }
            catch (Exception ex)
            {
                return RedirectToAction("NoPermission", "Home");
            }
        }
        public ActionResult RoomBooking()
        {
            var db = new HBNEWEntities();
            try
            {
                var hotelcode = Convert.ToString(Session["HotelCodeSession"]);
                var user = Convert.ToInt32(Session["LoginUser"]);
                var userint = Convert.ToInt32(user);
                var formIdx = Convert.ToInt32(formId.RoomBooking);
                var privilage = db.HRZUserPrivileges.Where(x => x.UserType == user && x.FormID == formIdx).FirstOrDefault();
                if (privilage.IsAccess == 1)
                {
                    UnabailableList rmid = new UnabailableList();

                    rmid.Rooms = GetRoomId(hotelcode);
                    return View(rmid);

                }
                else if (privilage.IsAccess == 0)
                {
                    return RedirectToAction("NoPermission", "Home");
                }
                else
                    return RedirectToAction("NoPermission", "Home");


            }
            catch (Exception ex)
            {
                return RedirectToAction("NoPermission", "Home");
            }

        }

        /// <summary>
        /// use to save unavailable date list
        /// </summary>
        /// <param name="unabailableList"></param>
        /// <returns>By Anu</returns>
        [HttpPost]
        public JsonResult SaveToDatabase(UnabailableList unabailableList)
        {
            try
            {
                var hotelCode = Convert.ToString(Session["HotelCodeSession"]); ;
                string roomId = unabailableList.RoomID.Trim().ToString();
                using (var db = new HBNEWEntities())
                {

                    isExistRoomId(roomId);

                    if (unabailableList.UnavailableDates == null)
                    {
                        return Json("Please select unavailable dates.");
                    }
                    else
                    {
                        foreach (var item in unabailableList.UnavailableDates)
                        {
                            DateTime enteredDate = DateTime.Parse(item);
                            string a = enteredDate.ToShortDateString();
                            //DateTime uDate = UnixTimeStampToDateTime(double.Parse(item.Trim().ToString().Substring(0, 10)));
                            db.HRZRoomUnavailables.Add(new HRZRoomUnavailable { RoomID = roomId, Date = a.Trim(), HotelCode = hotelCode });
                            db.SaveChanges();
                        }
                    }


                }
                return Json("Successfully Saved");
            }
            catch (Exception ex)
            {
                return Json("oOps! something went wrong");
            }
        }

        /// <summary>
        /// use to convert date from milisecond to date
        /// by Anu
        /// </summary>
        /// <param name="unixTimeStamp"></param>
        /// <returns></returns>
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        /// <summary>
        /// Use to get unavailable date list
        /// by Anu
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult getUnavailableDateLst(string roomId)
        {
            try
            {

                UnabailableList x = new UnabailableList();
                x.Rooms = unAvailableDateLst(roomId);

                // var a = x.Rooms.Select(s => s.Text);

                return Json(x.Rooms.ToArray());
            }
            catch (Exception ex)
            {
                return Json("oOps! something went wrong");
            }
        }
        public static List<SelectListItem> unAvailableDateLst(string roomId)
        {
            try
            {

                List<SelectListItem> items = new List<SelectListItem>();
                using (var db = new HBNEWEntities())
                {

                    var unDate = db.HRZRoomUnavailables.Where(x => x.RoomID.Equals(roomId)).ToList();


                    foreach (var x in unDate)
                    {


                        items.Add(new SelectListItem
                        {
                            Text = x.Date
                        });
                    }

                }

                return items;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        /// <summary>
        /// Use to convert date to milisecond
        /// by anu
        /// </summary>
        /// <param name="localDateTime"></param>
        /// <returns></returns>
        public static long GetCurrentUnixTimestampMillis(DateTime localDateTime)
        {
            DateTime univDateTime;
            univDateTime = localDateTime.ToUniversalTime();
            return (long)(univDateTime - UnixEpoch).TotalMilliseconds;
        }

        [HttpPost]
        public JsonResult BookingList(string selectedDate)
        {
            try
            {

                DateTime sDate = Convert.ToDateTime(selectedDate.Trim());

                string date = sDate.ToShortDateString();
                using (var db = new HBNEWEntities())
                {
                    var bookingLst = db.HRZRoomBookings.Where(x => x.DateFrom.Equals(date) && x.IsActive == true).ToList();


                    return Json(bookingLst);
                }
            }
            catch (Exception ex)
            {

                return Json("oOps! something went wrong");
            }
        }

        //[HttpGet]
        //public List<UnabailableList> GetRoomId()
        //{
        //    try
        //    {
        //        List<UnabailableList> unabailableList = new List<UnabailableList>();
        //        using (var db = new HBNEWEntities())
        //        {

        //            var roomid = db.HRZRoomMasters.Select(x => new
        //            {
        //                id = x.RoomId

        //            }).ToList();

        //            foreach (var x in roomid)
        //            {
        //                unabailableList.Add(new UnabailableList
        //                {
        //                    RoomID = x.id

        //                });
        //            }

        //        }


        //        return unabailableList;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        private static List<SelectListItem> GetRoomId(string hotelCode)
        {
            try
            {

                List<SelectListItem> items = new List<SelectListItem>();
                using (var db = new HBNEWEntities())
                {

                    var roomid = db.HRZRoomMasters.Where(x => x.HotelCode.Equals(hotelCode)).Select(x => new
                    {

                        rId = x.RoomID

                    }).ToList();

                    foreach (var x in roomid)
                    {
                        items.Add(new SelectListItem
                        {
                            Text = x.rId

                        });
                    }

                }
                return items;
            }
            catch (Exception ex)
            {

                throw;
            }
        }



        private bool isExistRoomId(string roomId)
        {
            try
            {
                bool isExit = false;

                using (var db = new HBNEWEntities())
                {
                    var rm = db.HRZRoomUnavailables.Where(s => s.RoomID.Equals(roomId)).FirstOrDefault();

                    if (rm == null) { return false; }
                    if (!string.IsNullOrEmpty(rm.RoomID.ToString()))
                    {
                        db.HRZRoomUnavailables.RemoveRange(db.HRZRoomUnavailables.Where(c => c.RoomID == roomId));
                        db.SaveChanges();
                        isExit = true;
                    }
                    else
                    {
                        isExit = false;
                    }
                }

                return isExit;
            }
            catch (Exception ex)
            {

                return false;
            }

        }

        /// <summary>
        /// by Anu
        /// </summary>
        /// <param name="bookingNo"></param>
        /// <param name="roomId"></param>
        /// <param name="sdate"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult cancelBooking(string bookingNo, string roomId, string sdate)
        {
            try
            {

                string successMsg = null;
                using (var db = new HBNEWEntities())
                {

                    var isExist = db.HRZRoomBookings.Where(x => x.BookingNo.Equals(bookingNo)).FirstOrDefault();

                    if (isExist == null)
                    {
                        successMsg = "Invalid booking No";
                    }
                    else
                    {
                        //remove from room booking table


                        HRZRoomBooking objHRZRoomBookings = db.HRZRoomBookings.Where(c => c.BookingNo == bookingNo).FirstOrDefault();
                        objHRZRoomBookings.IsActive = false;
                        db.SaveChanges();



                        // db.HRZRoomBookings.RemoveRange(db.HRZRoomBookings.Where(c => c.BookingNo == bookingNo));
                        // db.SaveChanges();

                        //remove from room unavailable table 
                        db.HRZRoomUnavailables.RemoveRange(db.HRZRoomUnavailables.Where(a => a.RoomID == roomId && a.Date == sdate));
                        db.SaveChanges();

                        successMsg = "Successfully Cancelled";
                    }

                }
                return Json(successMsg);
            }
            catch (Exception ex)
            {
                return Json("oOps! something went wrong");
            }
        }

        /// <summary>
        /// by Anu
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult recallRoomMaster(string roomId)
        {
            try
            {

                HotelRezData hotelRezData = new HotelRezData();
                var hotelCode = Convert.ToString(Session["HotelCodeSession"]);

                using (var db = new HBNEWEntities())
                {

                    var isExist = db.HRZRoomMasters.Where(x => x.RoomID.Equals(roomId) && x.HotelCode.Equals(hotelCode)).FirstOrDefault();

                    if (isExist == null)
                    {
                        hotelRezData = null;
                    }
                    else
                    {

                        var query = (from cd in db.HRZRoomMasters
                                     where cd.RoomID.Equals(roomId) && cd.HotelCode.Equals(hotelCode)
                                     select new
                                     {
                                         cd.Address,
                                         cd.RoomID,
                                         cd.Refference,
                                         cd.HotelCode,
                                         cd.RoomType,
                                         cd.BoardType,
                                         cd.Price,

                                     }).ToArray();

                        foreach (var roommaster in query)
                        {
                            hotelRezData = new HotelRezData();
                            hotelRezData.Address = roommaster.Address;
                            hotelRezData.RoomId = roommaster.RoomID;
                            hotelRezData.Refference = roommaster.Refference;
                            hotelRezData.RoomType = roommaster.RoomType;
                            hotelRezData.BoardType = roommaster.BoardType;
                            hotelRezData.Price = roommaster.Price;

                        }
                    }

                }
                return Json(hotelRezData);
            }
            catch (Exception ex)
            {
                return Json("oOps! something went wrong");
            }
        }


        /// <summary>
        /// By Anu
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult getNearByPlaces(string roomId)
        {
            try
            {
                var hotelCode = Convert.ToString(Session["HotelCodeSession"]);
                List<HotelRezData> items = new List<HotelRezData>();
                using (var db = new HBNEWEntities())
                {

                    var roomid = db.HRZNearbyPlaces.Where(x => x.HotelCode.Equals(hotelCode) && x.RoomID.Equals(roomId)).Select(x => new
                    {

                        rDistance = x.NearbyDistance,
                        rName = x.NearbyName

                    }).ToList();

                    foreach (var x in roomid)
                    {
                        items.Add(new HotelRezData
                        {
                            NearbyDistance = x.rDistance,
                            NearbyName = x.rName

                        });
                    }

                }
                return Json(items);
            }
            catch (Exception ex)
            {

                return Json("oOps! something went wrong");
            }
        }

        /// <summary>
        /// by Anu
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult getAminities(string roomId)
        {
            try
            {
                var hotelCode = Convert.ToString(Session["HotelCodeSession"]);
                List<HotelRezData> items = new List<HotelRezData>();
                using (var db = new HBNEWEntities())
                {

                    var roomid = db.HRZAminities.Where(x => x.HotelCode.Equals(hotelCode) && x.RoomID.Equals(roomId)).Select(x => new
                    {

                        rName = x.Name,
                        rType = x.Type

                    }).ToList();

                    foreach (var x in roomid)
                    {
                        items.Add(new HotelRezData
                        {
                            Aminities = x.rName,
                            AminityType = x.rType

                        });
                    }

                }
                return Json(items);
            }
            catch (Exception ex)
            {

                return Json("oOps! something went wrong");
            }
        }
        [Route("home/PostHotelPaymentData")]
        [HttpPost]
        public JsonResult PostHotelPaymentData(Payment payment)
        {
            try
            {

                using (var db = new HBNEWEntities())
                {

                    using (TransactionScope transaction = new TransactionScope())
                    {

                        HRZPayment hrzpayment = new HRZPayment();
                        HRZRoomBooking objHRZRoomBookings = new HRZRoomBooking();
                       
                        //HRZRoomMaster roomaster = new HRZRoomMaster();

                        var objRmpayment = db.HRZRoomBookings.Where(s => s.BookingNo.Equals(payment.BookingNo)).FirstOrDefault();


                        if (objRmpayment != null)
                        {
                            hrzpayment = new HRZPayment();
                            hrzpayment.BookingNo = payment.BookingNo;
                            hrzpayment.Amount = Convert.ToDecimal(payment.Amount);
                            hrzpayment.Tax = Convert.ToDecimal(payment.Tax);
                            hrzpayment.TotalAmount = Convert.ToDecimal(payment.TotalAmount);
                            hrzpayment.RoomId = payment.RoomID;
                            hrzpayment.Name = payment.Name;
                            hrzpayment.TelephoneNo = Convert.ToInt32(payment.TelephoneNo);
                            hrzpayment.Email = payment.Email;
                            hrzpayment.CreditCardNo = payment.CreditCardNo;



                            db.HRZPayments.Add(hrzpayment);
                            db.SaveChanges();

                            objRmpayment.Ispaid = 1;
                            //update roombooking table ispaid flag
                            db.HRZRoomBookings.Attach(objRmpayment);
                            var entry = db.Entry(objRmpayment);
                            entry.Property(e => e.Ispaid).IsModified = true;
                            // other changed properties
                            db.SaveChanges();
          

                            transaction.Complete();
                        }
                        else
                        {
                            return Json("oOps! something went wrong");
                        }
                    }
                }

                return Json("Successfully Saved");
            }

            catch (Exception ex)
            {
                return Json("oOps! something went wrong");
            }


        }
    }
}