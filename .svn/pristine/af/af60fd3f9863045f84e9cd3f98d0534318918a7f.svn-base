using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HB.ApiSync;
using HB.ApiSyncService;
using System.Data.SqlClient;
using System.Net;
using System.Text.RegularExpressions;

namespace HB.ApiSync
{
    public partial class FrmSync : Form
    {
        string filePath = @"C:\Test\ErrorSync.txt";
        public FrmSync()
        {
            InitializeComponent();
        }

        private void BtnSync_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {




                    SyncService syncService = new SyncService();
                    //if (syncService.SyncDestinations())
                    //{
                    //    writer.WriteLine("SyncDestinations");
                    //}


                    if (syncService.SyncTerminals())
                    {
                        writer.WriteLine("SyncTerminals");
                    }
                    
                    if (syncService.SyncCountry())
                    {
                        writer.WriteLine("SyncCountry");
                    }


                    if (syncService.SyncCurrencies())
                    {
                        writer.WriteLine("SyncCurrencies");
                    }


                    if (syncService.SyncAccommodations())
                    {
                        writer.WriteLine("SyncAccommodations");
                    }


                    if (syncService.Syncboards())
                    {
                        writer.WriteLine("Syncboards");
                    }
                    if (syncService.SyncCategories())
                    {
                        writer.WriteLine("SyncCategories");
                    }
                    if (syncService.SyncChains())
                    {
                        writer.WriteLine("SyncChains");
                    }
                    if (syncService.SyncRatecomments())
                    {
                        writer.WriteLine("SyncRatecomments");
                    }
                    if (syncService.SyncCurrencies())
                    {
                        writer.WriteLine("SyncCurrencies");
                    }
                    if (syncService.SyncFacilities())
                    {
                        writer.WriteLine("SyncFacilities");
                    }
                    if (syncService.SyncFacilitygroups())
                    {
                        writer.WriteLine("SyncFacilitygroups");
                    }
                    if (syncService.Syncacilitytypologies())
                    {
                        writer.WriteLine("Syncacilitytypologies");
                    }
                    if (syncService.SyncIssuess())
                    {
                        writer.WriteLine("SyncIssuess");
                    }
                    if (syncService.SyncLanguages())
                    {
                        writer.WriteLine("SyncLanguages");
                    }
                    if (syncService.SyncPromotions())
                    {
                        writer.WriteLine("SyncPromotions");
                    }
                    if (syncService.SyncRooms())
                    {
                        writer.WriteLine("SyncRooms");
                    }
                    if (syncService.SyncSegment())
                    {
                        writer.WriteLine("SyncSegment");
                    }

                    if (syncService.SyncImagetypes())
                    {
                        writer.WriteLine("SyncImagetypes");
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void btnSyncHotel_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {

                    SyncService syncService = new SyncService();
                    string val = syncService.SyncHotel(Convert.ToInt32(txtFrom.Text));
                    {
                        writer.WriteLine(val);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSyncHotelDtls_Click(object sender, EventArgs e)
        {
            try
            {
                //SyncService_t syncService = new SyncService_t();
                //using (StreamWriter writer = new StreamWriter(filePath, true))
                //{

                //    string val = syncService.SyncHotelDetails(Convert.ToInt64(txtFrom.Text),Convert.ToInt64(txtTo.Text));
                //    MessageBox.Show(val);
                //    writer.WriteLine(val + "------>" + txtFrom.Text + " - " + txtTo.Text);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                StreamWriter writer = new StreamWriter(filePath, true);
                writer.WriteLine(ex.ToString());
            }
        }

        private void CheckExchangeRate_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {

                SyncService syncService = new SyncService();
                var val = syncService.TakeExchangRate();
                {
                    writer.WriteLine(val);
                }
            }

            
        }
    }
}
