using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;
using System.Configuration;
using System.Data;

public partial class SuspiciousActivityPage : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Session.RemoveAll(); Response.Redirect("LogInPage.aspx");
            }
            else
            {
                reLoadSession();
                
                if (Request.QueryString["cUSTOMERID"] != null)
                {
                        showCUSTOMERData();

                }
            }
            
        }
    }

    private void reLoadSession()
    {
        if (Session["userType"] == null || Session["aGENT"] != null || Session["lOCATION"] != null)
        {
            USERINFO userInfo = new USERINFO();
            userInfo = USERINFOManager.GetUSERINFOByUserNameType("Agent", User.Identity.Name);//"Agent" is dami in database i have not use the

            if (userInfo != null)
            {
                Session["userType"] = userInfo.Type.ToString();
                Session["userInfoID"] = userInfo.USERINFOID.ToString();
                Session["userName"] = userInfo.UserName.ToString();

                //if (userInfo.Agent_LocationID.ToString() == ddlAgent.SelectedItem.Value.ToString())
                if (userInfo.Type == "Agent")
                {
                    Session["aGENT"] = AGENTManager.GetAGENTByID(userInfo.Agent_LocationID);
                    Session["role"] = "Agent";
                }
                else if (userInfo.Type == "Location")
                {
                    Session["lOCATION"] = LOCATIONGROUPManager.GetLOCATIONGROUPByID(userInfo.Agent_LocationID);
                    Session["role"] = "Location";
                }

            }
        }
    }

    private void showCUSTOMERData()
    {
        CUSTOMER cUSTOMER = new CUSTOMER();
        cUSTOMER = CUSTOMERManager.GetCUSTOMERByID(Int32.Parse(Request.QueryString["cUSTOMERID"]));
        if (cUSTOMER != null)
        {
            txtCUSTFNAME.Text = cUSTOMER.CUSTFNAME;
            txtCUSTMNAME.Text = cUSTOMER.CUSTMNAME;
            txtCUSTLNAME.Text = cUSTOMER.CUSTLNAME;
            txtCUSTADDRESS1.Text = cUSTOMER.CUSTADDRESS1;
            txtCUSTCITY.Text = cUSTOMER.CUSTCITY;
            txtCUSTSTATE.Text = cUSTOMER.CUSTSTATE;
            txtCUSTZIP.Text = cUSTOMER.CUSTZIP;
            txtCUSTHPHONE.Text = cUSTOMER.CUSTHPHONE;
            txtCUSTSSN.Text = cUSTOMER.CUSTSSN;
            txtCUSTDOB.Text = cUSTOMER.CUSTDOB.ToShortDateString();
        }

    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        BindReport();
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {

    }

    public void BindReport()
    {
        try
        {
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "dsSAR_dtSAR";
            rds.Value = ConvertListToDataTable();

            ReportDataSource rds1 = new ReportDataSource();
            rds1.Name = "dsSusActivity_dtSus";
            rds1.Value = SuspiciousActivityInfo();



            ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/rptSAR.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();


            ReportParameter[] reportParameterCollection = new ReportParameter[99];

            #region Part 3 and 4

            reportParameterCollection[0] = new ReportParameter();
            reportParameterCollection[0].Name = "LegalNameOfBusiness";
            reportParameterCollection[0].Values.Add("ABIMATU ENTERPRISE");

            reportParameterCollection[1] = new ReportParameter();
            reportParameterCollection[1].Name = "DoingBusiness";
            reportParameterCollection[1].Values.Add("");

            reportParameterCollection[2] = new ReportParameter();
            reportParameterCollection[2].Name = "PermanentAddress";
            reportParameterCollection[2].Values.Add("5010 SUNNYSIDE AVE");

            reportParameterCollection[3] = new ReportParameter();
            reportParameterCollection[3].Name = "City";
            reportParameterCollection[3].Values.Add("BELTSVILLE");

            reportParameterCollection[4] = new ReportParameter();
            reportParameterCollection[4].Name = "State";
            reportParameterCollection[4].Values.Add("MD");

            reportParameterCollection[5] = new ReportParameter();
            reportParameterCollection[5].Name = "Zip";
            reportParameterCollection[5].Values.Add("20705");

            reportParameterCollection[6] = new ReportParameter();
            reportParameterCollection[6].Name = "SSN";
            reportParameterCollection[6].Values.Add("");

            reportParameterCollection[7] = new ReportParameter();
            reportParameterCollection[7].Name = "Telephone";
            reportParameterCollection[7].Values.Add("3014747188");

            reportParameterCollection[8] = new ReportParameter();
            reportParameterCollection[8].Name = "Country";
            reportParameterCollection[8].Values.Add("");

            reportParameterCollection[9] = new ReportParameter();
            reportParameterCollection[9].Name = "InternalFileNumber";
            reportParameterCollection[9].Values.Add("");


            reportParameterCollection[9] = new ReportParameter();
            reportParameterCollection[9].Name = "InternalFileNumber";
            reportParameterCollection[9].Values.Add("");


            reportParameterCollection[89] = new ReportParameter();
            reportParameterCollection[89].Name = "TypeOfBusinessLocation";
            reportParameterCollection[89].Values.Add(rblTypeBusiness.SelectedItem.Value.ToString());
            #endregion

            #region 5
            reportParameterCollection[10] = new ReportParameter();
            reportParameterCollection[10].Name = "DesignatedContact";
            reportParameterCollection[10].Values.Add(txtDesignatedContactOfficer.Text);

            reportParameterCollection[11] = new ReportParameter();
            reportParameterCollection[11].Name = "DesignatedPhone";
            reportParameterCollection[11].Values.Add(txtPHONE.Text);

            reportParameterCollection[12] = new ReportParameter();
            reportParameterCollection[12].Name = "DesignatedDate";
            reportParameterCollection[12].Values.Add(txtdate.Text);

            reportParameterCollection[13] = new ReportParameter();
            reportParameterCollection[13].Name = "DesignatedAgency";
            reportParameterCollection[13].Values.Add(txtAgency.Text);
            #endregion

            #region Part 1

            string chkAmendingValue = "No";
            string chkRecurringValue = "No";
            string chkMultipleValue = "No";


            if (chkAmending.Checked == true)
            {
                chkAmendingValue = "Yes";
                    
            }

            if (chkRecurring.Checked == true)
            {
                chkRecurringValue = "Yes";

            }

            if (chkMultiple.Checked == true)
            {
                chkMultipleValue = "Yes";
            }

            reportParameterCollection[14] = new ReportParameter();
            reportParameterCollection[14].Name = "ChkAmending";
            reportParameterCollection[14].Values.Add(chkAmendingValue);

            reportParameterCollection[15] = new ReportParameter();
            reportParameterCollection[15].Name = "ChkRecurring";
            reportParameterCollection[15].Values.Add(chkRecurringValue);

            reportParameterCollection[16] = new ReportParameter();
            reportParameterCollection[16].Name = "ChkMultiple";
            reportParameterCollection[16].Values.Add(chkMultipleValue);

            reportParameterCollection[17] = new ReportParameter();
            reportParameterCollection[17].Name = "ChkSubjectType";
            reportParameterCollection[17].Values.Add(rblSubjectType.SelectedItem.Value.ToString());

            //reportParameterCollection[17] = new ReportParameter();
            //reportParameterCollection[17].Name = "ChkSubjectType";
            //reportParameterCollection[17].Values.Add("askdya8sd");

            #endregion

            #region Part 2

            string chkvalue1 = "No";
            string chkvalue2 = "No";
            string chkvalue3 = "No";
            string chkvalue4 = "No";
            string chkvalue5 = "No";
            string chkvalue6 = "No";
            string chkvalue7 = "No";
            string chkvalue8 = "No";
            string chkvalue9 = "No";
            string chkvalue10 = "No";


            if (cblSuspiciousActivity.Items[0].Selected)
            {
                chkvalue1 = "Yes";
            }
            if (cblSuspiciousActivity.Items[1].Selected)
            {
                chkvalue2 = "Yes";
            }
            if (cblSuspiciousActivity.Items[2].Selected)
            {
                chkvalue3 = "Yes";
            }
            if (cblSuspiciousActivity.Items[3].Selected)
            {
                chkvalue4 = "Yes";
            }
            if (cblSuspiciousActivity.Items[4].Selected)
            {
                chkvalue5 = "Yes";
            }
            if (cblSuspiciousActivity.Items[5].Selected)
            {
                chkvalue6 = "Yes";
            }

            if (cblSuspiciousActivity.Items[6].Selected)
            {
                chkvalue7 = "Yes";
            }
            if (cblSuspiciousActivity.Items[7].Selected)
            {
                chkvalue8 = "Yes";
            }
            if (cblSuspiciousActivity.Items[8].Selected)
            {
                chkvalue9 = "Yes";
            }
            if (cblSuspiciousActivity.Items[9].Selected)
            {
                chkvalue10 = "Yes";
            }



                reportParameterCollection[18] = new ReportParameter();
                reportParameterCollection[18].Name = "Chk3000";
                reportParameterCollection[18].Values.Add(chkvalue1);

                reportParameterCollection[19] = new ReportParameter();
                reportParameterCollection[19].Name = "Chk10000";
                reportParameterCollection[19].Values.Add(chkvalue2);

                reportParameterCollection[20] = new ReportParameter();
                reportParameterCollection[20].Name = "CHkLess3000";
                reportParameterCollection[20].Values.Add(chkvalue3);

                reportParameterCollection[21] = new ReportParameter();
                reportParameterCollection[21].Name = "CHkFHChanges";
                reportParameterCollection[21].Values.Add(chkvalue4);

                reportParameterCollection[22] = new ReportParameter();
                reportParameterCollection[22].Name = "CHkSusActivity5";
                reportParameterCollection[22].Values.Add(chkvalue5);

                reportParameterCollection[23] = new ReportParameter();
                reportParameterCollection[23].Name = "CHkSusActivity6";
                reportParameterCollection[23].Values.Add(chkvalue6);

                reportParameterCollection[24] = new ReportParameter();
                reportParameterCollection[24].Name = "CHkSusActivity7";
                reportParameterCollection[24].Values.Add(chkvalue7);


                reportParameterCollection[25] = new ReportParameter();
                reportParameterCollection[25].Name = "CHkSusActivity8";
                reportParameterCollection[25].Values.Add(chkvalue8);


                reportParameterCollection[26] = new ReportParameter();
                reportParameterCollection[26].Name = "CHkSusActivity9";
                reportParameterCollection[26].Values.Add(chkvalue9);


                reportParameterCollection[27] = new ReportParameter();
                reportParameterCollection[27].Name = "CHkSusActivity10";
                reportParameterCollection[27].Values.Add(chkvalue10);


                string chkMoneyLaunderingValue = "No";
                string chkStructuring = "No";
                string chkTerroristFinancing = "No";

                if (cblSusCategory.Items[0].Selected)
                {
                    chkMoneyLaunderingValue = "Yes";
                }
                if (cblSusCategory.Items[1].Selected)
                {
                    chkStructuring = "Yes";
                }
                if (cblSusCategory.Items[2].Selected)
                {
                    chkTerroristFinancing = "Yes";
                }
                //if (cblSusCategory.Items[0].Selected)
                //{
                //    chkMoneyLaunderingValue = "Yes";
                //}
                reportParameterCollection[90] = new ReportParameter();
                reportParameterCollection[90].Name = "chkMoneyLaundering";
                reportParameterCollection[90].Values.Add(chkMoneyLaunderingValue);

                reportParameterCollection[91] = new ReportParameter();
                reportParameterCollection[91].Name = "chkStructuring";
                reportParameterCollection[91].Values.Add(chkStructuring);

                reportParameterCollection[92] = new ReportParameter();
                reportParameterCollection[92].Name = "chkTerroristFinancing";
                reportParameterCollection[92].Values.Add(chkTerroristFinancing);

                reportParameterCollection[93] = new ReportParameter();
                reportParameterCollection[93].Name = "OtherValue";
                reportParameterCollection[93].Values.Add(txtSusActivityOther.Text);


                string chkMoneyOrderValue = "No";
                string chkTravelerCheckValue = "No";
                string chkMoneyTransferValue = "No";
                string chkCurrencyExchangeValue = "No";

                if (cblFinancialService.Items[0].Selected)
                {
                    chkMoneyOrderValue = "Yes";
                }
                if (cblFinancialService.Items[0].Selected)
                {
                    chkTravelerCheckValue = "Yes";
                }
                if (cblFinancialService.Items[0].Selected)
                {
                    chkMoneyTransferValue = "Yes";
                }
                if (cblFinancialService.Items[0].Selected)
                {
                    chkCurrencyExchangeValue = "Yes";
                }

                reportParameterCollection[94] = new ReportParameter();
                reportParameterCollection[94].Name = "chkMoneyOrder";
                reportParameterCollection[94].Values.Add(chkMoneyOrderValue);
                reportParameterCollection[95] = new ReportParameter();
                reportParameterCollection[95].Name = "chkTravelerCheck";
                reportParameterCollection[95].Values.Add(chkTravelerCheckValue);
                reportParameterCollection[96] = new ReportParameter();
                reportParameterCollection[96].Name = "chkMoneyTransfer";
                reportParameterCollection[96].Values.Add(chkMoneyTransferValue);
                reportParameterCollection[97] = new ReportParameter();
                reportParameterCollection[97].Name = "chkCurrencyExchange";
                reportParameterCollection[97].Values.Add(chkCurrencyExchangeValue);
                reportParameterCollection[98] = new ReportParameter();
                reportParameterCollection[98].Name = "OtherFinancialService";
                reportParameterCollection[98].Values.Add(txtOtherFinancialService.Text);




            #endregion

                #region PArt 2 Continued


                string ChkP1Value = "No";
                string ChkP2Value = "No";
                string ChkP3Value = "No";
                string ChkP4Value = "No";
                string ChkP5Value = "No";
                string ChkP6Value = "No";
                string ChkP7Value = "No";
                string ChkP8Value = "No";
                string ChkP9Value = "No";



                string ChkR1Value = "No";
                string ChkR2Value = "No";
                string ChkR3Value = "No";
                string ChkR4Value = "No";
                string ChkR5Value = "No";
                string ChkR6Value = "No";
                string ChkR7Value = "No";
                string ChkR8Value = "No";
                string ChkR9Value = "No";



                if (ChkP1.Checked == true)
                {
                     ChkP1Value = "Yes";
                }


                if (ChkP2.Checked == true)
                {
                    ChkP2Value = "Yes";
                }


                if (ChkP3.Checked == true)
                {
                    ChkP3Value = "Yes";
                }


                if (ChkP4.Checked == true)
                {
                    ChkP4Value = "Yes";
                }


                if (ChkP5.Checked == true)
                {
                    ChkP5Value = "Yes";
                }

                if (ChkP6.Checked == true)
                {
                    ChkP6Value = "Yes";
                }

                if (ChkP7.Checked == true)
                {
                    ChkP7Value = "Yes";
                }

                if (ChkP8.Checked == true)
                {
                    ChkP8Value = "Yes";
                }

                if (ChkP9.Checked == true)
                {
                    ChkP9Value = "Yes";
                }

                if (ChkR1.Checked == true)
                {
                    ChkR1Value = "Yes";
                }

                if (ChkR2.Checked == true)
                {
                    ChkR2Value = "Yes";
                }

                if (ChkR3.Checked == true)
                {
                    ChkR3Value = "Yes";
                }

                if (ChkR4.Checked == true)
                {
                    ChkR4Value = "Yes";
                }

                if (ChkR5.Checked == true)
                {
                    ChkR5Value = "Yes";
                }

                if (ChkR6.Checked == true)
                {
                    ChkR6Value = "Yes";
                }

                if (ChkR7.Checked == true)
                {
                    ChkR7Value = "Yes";
                }

                if (ChkR8.Checked == true)
                {
                    ChkR8Value = "Yes";
                }

                if (ChkR9.Checked == true)
                {
                    ChkR9Value = "Yes";
                }

                        reportParameterCollection[28] = new ReportParameter();
                        reportParameterCollection[28].Name = "P1";
                        reportParameterCollection[28].Values.Add(ChkP1Value);

                        reportParameterCollection[29] = new ReportParameter();
                        reportParameterCollection[29].Name = "P2";
                        reportParameterCollection[29].Values.Add(ChkP2Value);

                        reportParameterCollection[30] = new ReportParameter();
                        reportParameterCollection[30].Name = "P3";
                        reportParameterCollection[30].Values.Add(ChkP3Value);


            /**********************Not Used*************************/
                        reportParameterCollection[31] = new ReportParameter();
                        reportParameterCollection[31].Name = "P4";
                        reportParameterCollection[31].Values.Add(ChkP4Value);


                        reportParameterCollection[32] = new ReportParameter();
                        reportParameterCollection[32].Name = "P4";
                        reportParameterCollection[32].Values.Add(ChkP4Value);

                        reportParameterCollection[33] = new ReportParameter();
                        reportParameterCollection[33].Name = "P4";
                        reportParameterCollection[33].Values.Add(ChkP4Value);



            /**********************End Not USed**********************************/


                        reportParameterCollection[34] = new ReportParameter();
                        reportParameterCollection[34].Name = "P5";
                        reportParameterCollection[34].Values.Add(ChkP5Value);


                        reportParameterCollection[35] = new ReportParameter();
                        reportParameterCollection[35].Name = "P6";
                        reportParameterCollection[35].Values.Add(ChkP6Value);


                        reportParameterCollection[36] = new ReportParameter();
                        reportParameterCollection[36].Name = "P7";
                        reportParameterCollection[36].Values.Add(ChkP7Value);


                        reportParameterCollection[37] = new ReportParameter();
                        reportParameterCollection[37].Name = "P8";
                        reportParameterCollection[37].Values.Add(ChkP8Value);


                        reportParameterCollection[38] = new ReportParameter();
                        reportParameterCollection[38].Name = "P9";
                        reportParameterCollection[38].Values.Add(ChkP9Value);



                        reportParameterCollection[39] = new ReportParameter();
                        reportParameterCollection[39].Name = "R1";
                        reportParameterCollection[39].Values.Add(ChkR1Value);

                        reportParameterCollection[40] = new ReportParameter();
                        reportParameterCollection[40].Name = "R2";
                        reportParameterCollection[40].Values.Add(ChkR2Value);

                        reportParameterCollection[41] = new ReportParameter();
                        reportParameterCollection[41].Name = "R3";
                        reportParameterCollection[41].Values.Add(ChkR3Value);

                        reportParameterCollection[42] = new ReportParameter();
                        reportParameterCollection[42].Name = "R4";
                        reportParameterCollection[42].Values.Add(ChkR4Value);


                        reportParameterCollection[43] = new ReportParameter();
                        reportParameterCollection[43].Name = "R5";
                        reportParameterCollection[43].Values.Add(ChkR5Value);


                        reportParameterCollection[44] = new ReportParameter();
                        reportParameterCollection[44].Name = "R6";
                        reportParameterCollection[44].Values.Add(ChkR6Value);


                        reportParameterCollection[45] = new ReportParameter();
                        reportParameterCollection[45].Name = "R7";
                        reportParameterCollection[45].Values.Add(ChkR7Value);


                        reportParameterCollection[46] = new ReportParameter();
                        reportParameterCollection[46].Name = "R8";
                        reportParameterCollection[46].Values.Add(ChkR8Value);


                        reportParameterCollection[47] = new ReportParameter();
                        reportParameterCollection[47].Name = "R9";
                        reportParameterCollection[47].Values.Add(ChkR9Value);






                        reportParameterCollection[48] = new ReportParameter();
                        reportParameterCollection[48].Name = "Issuers1";
                        reportParameterCollection[48].Values.Add(txtIssuer1.Text);
                                    reportParameterCollection[49] = new ReportParameter();
                        reportParameterCollection[49].Name = "Issuers2";
                        reportParameterCollection[49].Values.Add(txtIssuer2.Text);
                                    reportParameterCollection[50] = new ReportParameter();
                        reportParameterCollection[50].Name = "Issuers3";
                        reportParameterCollection[50].Values.Add(txtIssuer3.Text);
                                    reportParameterCollection[51] = new ReportParameter();
                        reportParameterCollection[51].Name = "Issuers4";
                        reportParameterCollection[51].Values.Add(txtIssuer4.Text);
                                    reportParameterCollection[52] = new ReportParameter();
                        reportParameterCollection[52].Name = "Issuers5";
                        reportParameterCollection[52].Values.Add(txtIssuer5.Text);
                                    reportParameterCollection[53] = new ReportParameter();
                        reportParameterCollection[53].Name = "Issuers6";
                        reportParameterCollection[53].Values.Add(txtIssuer6.Text);
                                    reportParameterCollection[54] = new ReportParameter();
                        reportParameterCollection[54].Name = "Issuers7";
                        reportParameterCollection[54].Values.Add(txtIssuer7.Text);
                        reportParameterCollection[55] = new ReportParameter();
                        reportParameterCollection[55].Name = "Issuers8";
                        reportParameterCollection[55].Values.Add(txtIssuer8.Text);
                                    reportParameterCollection[56] = new ReportParameter();
                        reportParameterCollection[56].Name = "Issuers9";
                        reportParameterCollection[56].Values.Add(txtIssuer9.Text);


                        reportParameterCollection[57] = new ReportParameter();
                        reportParameterCollection[57].Name = "Instruments1";
                        reportParameterCollection[57].Values.Add(txtInstruments1.Text);

                                    reportParameterCollection[58] = new ReportParameter();
                        reportParameterCollection[58].Name = "Instruments2";
                        reportParameterCollection[58].Values.Add(txtInstruments2.Text);

                                    reportParameterCollection[59] = new ReportParameter();
                        reportParameterCollection[59].Name = "Instruments3";
                        reportParameterCollection[59].Values.Add(txtInstruments3.Text);

                                    reportParameterCollection[60] = new ReportParameter();
                        reportParameterCollection[60].Name = "Instruments4";
                        reportParameterCollection[60].Values.Add(txtInstruments4.Text);

                                    reportParameterCollection[61] = new ReportParameter();
                        reportParameterCollection[61].Name = "Instruments5";
                        reportParameterCollection[61].Values.Add(txtInstruments5.Text);

                                    reportParameterCollection[62] = new ReportParameter();
                        reportParameterCollection[62].Name = "Instruments6";
                        reportParameterCollection[62].Values.Add(txtInstruments6.Text);

                                    reportParameterCollection[63] = new ReportParameter();
                        reportParameterCollection[63].Name = "Instruments7";
                        reportParameterCollection[63].Values.Add(txtInstruments7.Text);

                                    reportParameterCollection[64] = new ReportParameter();
                        reportParameterCollection[64].Name = "Instruments8";
                        reportParameterCollection[64].Values.Add(txtInstruments8.Text);

                                    reportParameterCollection[65] = new ReportParameter();
                        reportParameterCollection[65].Name = "Instruments9";
                        reportParameterCollection[65].Values.Add(txtInstruments9.Text);




                        reportParameterCollection[66] = new ReportParameter();
                        reportParameterCollection[66].Name = "Amount1";
                        reportParameterCollection[66].Values.Add(txtAmount1.Text);

            
                        reportParameterCollection[67] = new ReportParameter();
                        reportParameterCollection[67].Name = "Amount2";
                        reportParameterCollection[67].Values.Add(txtAmount2.Text);

            
                        reportParameterCollection[68] = new ReportParameter();
                        reportParameterCollection[68].Name = "Amount3";
                        reportParameterCollection[68].Values.Add(txtAmount3.Text);

            
                        reportParameterCollection[69] = new ReportParameter();
                        reportParameterCollection[69].Name = "Amount4";
                        reportParameterCollection[69].Values.Add(txtAmount4.Text);

            
                        reportParameterCollection[70] = new ReportParameter();
                        reportParameterCollection[70].Name = "Amount5";
                        reportParameterCollection[70].Values.Add(txtAmount5.Text);

            
                        reportParameterCollection[71] = new ReportParameter();
                        reportParameterCollection[71].Name = "Amount6";
                        reportParameterCollection[71].Values.Add(txtAmount6.Text);

            
                        reportParameterCollection[72] = new ReportParameter();
                        reportParameterCollection[72].Name = "Amount7";
                        reportParameterCollection[72].Values.Add(txtAmount7.Text);

            
                        reportParameterCollection[73] = new ReportParameter();
                        reportParameterCollection[73].Name = "Amount8";
                        reportParameterCollection[73].Values.Add(txtAmount8.Text);


            
                        reportParameterCollection[74] = new ReportParameter();
                        reportParameterCollection[74].Name = "Amount9";
                        reportParameterCollection[74].Values.Add(txtAmount9.Text);





            //}

                #endregion


                        #region Section 21

                        string chkcurrencyValue1 = "No";
                        string chkcurrencyValue2 = "No";

                        if (Chkbulk1.Checked == true)
                        {
                            chkcurrencyValue1 = "Yes";
                        }
                        if (Chkbulk2.Checked == true)
                        {
                            chkcurrencyValue2 = "Yes";
                        }


                        reportParameterCollection[75] = new ReportParameter();
                        reportParameterCollection[75].Name = "currency1";
                        reportParameterCollection[75].Values.Add(chkcurrencyValue1);

                        reportParameterCollection[76] = new ReportParameter();
                        reportParameterCollection[76].Name = "currency2";
                        reportParameterCollection[76].Values.Add(chkcurrencyValue2);

                        reportParameterCollection[77] = new ReportParameter();
                        reportParameterCollection[77].Name = "TenderedCurrency1";
                        reportParameterCollection[77].Values.Add(txtCurrency1.Text);

                        reportParameterCollection[78] = new ReportParameter();
                        reportParameterCollection[78].Name = "TenderedCurrency2";
                        reportParameterCollection[78].Values.Add(txtCurrency2.Text);

            

                                        reportParameterCollection[79] = new ReportParameter();
                                        reportParameterCollection[79].Name = "Country1";
                        reportParameterCollection[79].Values.Add(txtCountry1.Text);


                        reportParameterCollection[86] = new ReportParameter();
                        reportParameterCollection[86].Name = "Country2";
                        reportParameterCollection[86].Values.Add(txtCountry2.Text);


                        reportParameterCollection[80] = new ReportParameter();
                        reportParameterCollection[80].Name = "Receivedcurrency1";
                        reportParameterCollection[80].Values.Add(txtReceivedCurrency1.Text);

                        reportParameterCollection[81] = new ReportParameter();
                        reportParameterCollection[81].Name = "Receivedcurrency2";
                        reportParameterCollection[81].Values.Add(txtReceivedCurrency2.Text);
            
                                        reportParameterCollection[82] = new ReportParameter();
                                        reportParameterCollection[82].Name = "ReceivedCountry1";
                        reportParameterCollection[82].Values.Add(txtReceivedCountry1.Text);

                        reportParameterCollection[83] = new ReportParameter();
                        reportParameterCollection[83].Name = "ReceivedCountry2";
                        reportParameterCollection[83].Values.Add(txtReceivedCountry2.Text);

                                    reportParameterCollection[84] = new ReportParameter();
                                    reportParameterCollection[84].Name = "ReceivedAmount1";
                        reportParameterCollection[84].Values.Add(txtReceivedAmount1.Text);
                        reportParameterCollection[85] = new ReportParameter();
                        reportParameterCollection[85].Name = "ReceivedAmount2";
                        reportParameterCollection[85].Values.Add(txtReceivedAmount2.Text);
                        #endregion



                        #region Part-2
                        string chkUnAmountValue = "No";
                        if (chkUnAmount.Checked == true)
                        {
                            chkUnAmountValue = "Yes";
                        }


                        reportParameterCollection[86] = new ReportParameter();
                        reportParameterCollection[86].Name = "SusActDateRange";
                        reportParameterCollection[86].Values.Add(txtFromDate.Text + " To " + txtToDate.Text);
                        reportParameterCollection[87] = new ReportParameter();
                        reportParameterCollection[87].Name = "TotalAmount";
                        reportParameterCollection[87].Values.Add(txtTotalAmount.Text);
                        reportParameterCollection[88] = new ReportParameter();
                        reportParameterCollection[88].Name = "chkAmount";
                        reportParameterCollection[88].Values.Add(chkUnAmountValue);

                        #endregion


                        ReportViewer1.LocalReport.SetParameters(reportParameterCollection);
            ReportViewer1.LocalReport.Refresh();

            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.DataSources.Add(rds1);

            //Export to PDF
            string mimeType;
            string encoding;
            string fileNameExtension;
            string[] streams;
            Microsoft.Reporting.WebForms.Warning[] warnings;

            byte[] pdfContent = ReportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);

            //Return PDF
            this.Response.Clear();
            this.Response.ContentType = "application/pdf";
            this.Response.AddHeader("Content-disposition", "attachment; filename=SARReport.pdf");
            this.Response.BinaryWrite(pdfContent);
            this.Response.End();
        }

        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }

    public DataTable ConvertListToDataTable()
    {
       CUSTOMER cUSTOMER = new CUSTOMER();
        cUSTOMER = CUSTOMERManager.GetCUSTOMERByID(Int32.Parse(Request.QueryString["cUSTOMERID"]));
        if (cUSTOMER != null)
        {
        dt = new DataTable();

        dt.Columns.Add(new DataColumn("CUSTLNAME", typeof(String)));
        dt.Columns.Add(new DataColumn("CUSTFNAME", typeof(String)));
        dt.Columns.Add(new DataColumn("CUSTMNAME", typeof(String)));
        dt.Columns.Add(new DataColumn("CUSTADDRESS1", typeof(String)));
        dt.Columns.Add(new DataColumn("CUSTCITY", typeof(String)));
        dt.Columns.Add(new DataColumn("CUSTSTATE", typeof(String)));
        dt.Columns.Add(new DataColumn("CUSTZIP", typeof(String)));
        dt.Columns.Add(new DataColumn("CUSTIDNUMBER", typeof(String)));
        dt.Columns.Add(new DataColumn("CUSTSSN", typeof(String)));
        dt.Columns.Add(new DataColumn("CUSTDOB", typeof(String)));
        dt.Columns.Add(new DataColumn("CUSTHPHONE", typeof(String)));

        DataRow dr = dt.NewRow();

        for (int i = 0; i <= 5; i++)
        {
            dr = dt.NewRow();
            dr[0] = cUSTOMER.CUSTLNAME.ToString();
            dr[1] = cUSTOMER.CUSTFNAME.ToString();
            dr[2] = cUSTOMER.CUSTMNAME.ToString() ;
            dr[3] =cUSTOMER.CUSTADDRESS1.ToString() ;
            dr[4] =cUSTOMER.CUSTCITY ;
            dr[5] =cUSTOMER.CUSTSTATE ;
            dr[6] =cUSTOMER.CUSTZIP ;
            dr[7] =cUSTOMER.CUSTIDNUMBER ;
            dr[8] =cUSTOMER.CUSTSSN ;
            dr[9] =cUSTOMER.CUSTDOB.ToShortDateString() ;
            dr[10] =cUSTOMER.CUSTHPHONE ;
            

            dt.Rows.Add(dr);
            dr = dt.NewRow();
        }

        }
        return dt;

    }



    public DataTable SuspiciousActivityInfo()
    {

            dt = new DataTable();

            dt.Columns.Add(new DataColumn("Instrument", typeof(String)));
            dt.Columns.Add(new DataColumn("P", typeof(String)));
            dt.Columns.Add(new DataColumn("R", typeof(String)));
            dt.Columns.Add(new DataColumn("Issuers", typeof(String)));
            dt.Columns.Add(new DataColumn("TotalInstruments", typeof(String)));
            dt.Columns.Add(new DataColumn("TotalAmount", typeof(String)));
            DataRow dr = dt.NewRow();

            for (int i = 0; i <9; i++)
            {
                dr = dt.NewRow();
                dr[0] = "Instrument";
                dr[1] = "P";
                dr[2] = "R";
                dr[3] = "Issuers";
                dr[4] = "TotalInstruments";
                dr[5] = "TotalAmount";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
            }


        return dt;

    }

}