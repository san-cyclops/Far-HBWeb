﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HB.Utility;
using Repositories.Model;

namespace Repositories.Service
{
    public class HotelRepositoryService
    {
        public HotelRsRep getHotelDetails(string des)
        {
            using (var db = new HBNEWEntities())
            {
                List<HotelRep> hotelRepList = new List<HotelRep>();
                List<ImageRep> imageRepsList = new List<ImageRep>();



                hotelRepList = db.HotelReps.Where(p => p.destinationCode.Equals(des)).ToList();
                imageRepsList = db.ImageReps.ToList();
                imageRepsList.ToList().ForEach(c => c.path = "http://www.hotelbeds.com/giata/" + c.path.ToString());



                foreach (var avarImg in hotelRepList)
                {

                    avarImg.imagepath = imageRepsList.Where(a => a.HotelCode == avarImg.code).Select(a => a.path).FirstOrDefault();
                    avarImg.hotelstar = db.CategoryReps.Where(a => a.code == avarImg.categoryCode)
                            .Select(a => a.simpleCode)
                            .FirstOrDefault();

                }



                //hotel_star


                //HotelRsRep hotelRepList = new Availability();
                var hotelRsRepList = new HotelRsRep();
                hotelRsRepList.hotel = new List<HotelRep>();
                hotelRsRepList.hotel = db.HotelReps.Where(p => p.destinationCode.Equals(des)).ToList();
                hotelRsRepList.images = new List<ImageRep>();
                hotelRsRepList.images =
                    imageRepsList.Where(p => hotelRepList.Any(p2 => p2.code == p.HotelCode)).ToList();
                hotelRsRepList.boardCodes = new List<HotelBoardCodesRep>();
                hotelRsRepList.boardCodes = db.HotelBoardCodesReps.ToList();
                //hotelRsRepList.country = db.CountryReps.ToList();

                //if (hotelsRs.hotels[imgx].images.Count > 0)
                //{

                //}





                return hotelRsRepList;
            }
        }

        public List<DestinationsRep> getDestinations()
        {
            using (var db = new HBNEWEntities())
            {
                List<DestinationsRep> destinationsRepsList = new List<DestinationsRep>();
                destinationsRepsList = db.DestinationsReps.ToList();
                return destinationsRepsList;
            }
        }

        public DocumentRep GetDocumentNoByForm(string docType)
        {
            using (var db = new HBNEWEntities())
            {
                DocumentRep documentRep = new DocumentRep();
                documentRep = db.DocumentReps.Where(ai => ai.DocumentType == docType).FirstOrDefault();
                UpdateDocumentNo(docType);

                return documentRep;
            }
        }

        public void UpdateDocumentNo(string docType)
        {
            try
            {
                ExecuteSqlstatement("UPDATE dbo.DocumentReps SET DocumentNo = DocumentNo+1 WHERE  DocumentType='" + docType + "'");

            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), "", Logger.logtype.ErrorLog);
            }
        }


        public void UpdateHotelPaymentDetail(HotelPaymentDetail model)
        {
            try
            {
                ExecuteSqlstatement("Insert into HotelPaymentDetails(clientID,currency,holderName,number,paymentAmount,responseCode,responseText,txnReference,type) values('" + model.clientID + "','" + model.currency + "','" + model.holderName + "','" + model.number + "','" + model.paymentAmount + "','" + model.responseCode + "','" + model.responseText + "','" + model.txnReference + "','" + model.type + "')");
            }

            catch (Exception ex)
            {

            }

        }


        public decimal GetCurrencyRate()
        {
            using (var db = new HBNEWEntities())
            {
                ConvertRate newCurrency = new ConvertRate();
                //newCurrency = (from d in db.CurrencyRates select new { d.Currency, d.Value, });

                var xnewCurrency = db.CurrencyRates.Where(ai => ai.Currency == "LKR").FirstOrDefault();

                var value = Convert.ToDecimal(xnewCurrency.Value);
                return value;
            }

        }



        public void ExecuteSqlstatement(string sqlstatement)
        {

            int result;
            using (var db = new HBNEWEntities())
            {
                using (db.Database.Connection)
                {
                    try
                    {

                        db.Database.Connection.Open();
                        IDbCommand cmd = db.Database.Connection.CreateCommand();
                        cmd.CommandText = sqlstatement;
                        cmd.CommandType = CommandType.Text;

                        cmd.CommandTimeout = 0;
                        result = cmd.ExecuteNonQuery();

                    }

                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        db.Database.Connection.Close();
                    }
                }
            }
        }

        public class ConvertRate
        {
        }

        public void GetCurrency()
        {
            throw new NotImplementedException();
        }
    }
}
