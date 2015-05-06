using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using System.IO;
using System.Collections;
using System.Net;
using iTextSharp;

public partial class FoodTransmit : System.Web.UI.Page
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
            }

            if (Session["ssReferenceCode"] != null)
            {
                List<string> ssReferenceCodeFINAL = new List<string>();
                ssReferenceCodeFINAL = (List<string>)Session["ssReferenceCode"];

                string stReferenceCode = string.Empty;
                for (int i = 0; i < ssReferenceCodeFINAL.Count; i++)
                {
                    lblReferenceCODE.Text = stReferenceCode.ToString() + "<br/>" + ssReferenceCodeFINAL[i].ToString();
                    stReferenceCode = lblReferenceCODE.Text;

                }
            }
            else
            {
                Response.Redirect("SearchSenderPage.aspx");
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
    protected void btnBack_Click(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Session.Remove("ssReferenceCode");

        Response.Redirect("Default.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {

    }

    protected void btnReceipt_Click(object sender, EventArgs e)
    {

        ExportToPDF();
        if (Session["ssReferenceCode"] != null)
        {
            //List<string> ssReferenceCodeFINAL = new List<string>();
            //ssReferenceCodeFINAL = (List<string>)Session["ssReferenceCode"];

            //string stReferenceCode = string.Empty;
            //for (int i = 0; i < ssReferenceCodeFINAL.Count; i++)
            //{
            //    lblReferenceCODE.Text = stReferenceCode.ToString() + "<br/>" + ssReferenceCodeFINAL[i].ToString();
            //    stReferenceCode = lblReferenceCODE.Text;

            //}

            ExportToPDF();
        }
        else
        {
            Response.Redirect("SearchSenderPage.aspx");
        }
    }


    #region Added By Maruf (Export PDF)
    private void ExportToPDF()
    {



        Document document = new Document(PageSize.A4, 0, 0, 0, 0);
        System.IO.MemoryStream msReport = new System.IO.MemoryStream();

        try
        {
            // creation of the different writers
            PdfWriter writer = PdfWriter.GetInstance(document, msReport);

            // we add some meta information to the document
            document.AddAuthor("Maruf");
            document.AddSubject("Report");

            document.Open();

            iTextSharp.text.Table datatable = new iTextSharp.text.Table(9);

            datatable.Padding = 2;
            datatable.Spacing = 0;

            float[] headerwidths = { 10, 9, 9, 9, 9, 9, 9, 9, 9 };
            datatable.Widths = headerwidths;



            //iTextSharp.text.Table datatable1 = new iTextSharp.text.Table(7);

            //datatable1.Padding = 2;
            //datatable1.Spacing = 0;

            float[] headerwidths1 = { 16, 14, 14, 14, 14, 14, 14 };
            //datatable1.Widths = headerwidths1;


            // the first cell spans 7 columns
            Cell cell = new Cell(new Phrase("Receipt", FontFactory.GetFont(FontFactory.HELVETICA, 16, Font.BOLD)));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.Leading = 30;
            cell.Colspan = 9;
            cell.Border = Rectangle.NO_BORDER;
            cell.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.Gray);
            datatable.AddCell(cell);

            List<string> ssReferenceCodeFINAL = new List<string>();
            ssReferenceCodeFINAL = (List<string>)Session["ssReferenceCode"];

            string stReferenceCode = string.Empty;

            datatable.DefaultHorizontalAlignment = Element.ALIGN_LEFT;
            TRANS tRANS = new TRANS();
            tRANS = TRANSManager.GetTRANSByRefCode(ssReferenceCodeFINAL[0].ToString());

            if (tRANS != null)
            {

                AGENT agent = new AGENT();

                agent = AGENTManager.GetAGENTByID(tRANS.AGENTID);
                if (agent != null)
                {
                    Cell cell1 = new Cell(new Phrase("Agent No/Location : " + agent.AGENTNAME.ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD)));
                    cell1.HorizontalAlignment = Element.ALIGN_LEFT;
                    //cell1.Leading = 30;
                    cell1.Colspan = 9;
                    cell1.Border = Rectangle.BOX;
                    cell1.BorderWidth = 1;
                    cell1.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.WhiteSmoke);
                    datatable.AddCell(cell1);
                }




                Cell cellSender = new Cell(new Phrase("Sender Information  ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD)));
                cellSender.HorizontalAlignment = Element.ALIGN_LEFT;
                cellSender.Colspan = 9;
                cellSender.Border = Rectangle.NO_BORDER;
                cellSender.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.WhiteSmoke);
                datatable.AddCell(cellSender);


                datatable.DefaultCellBorderWidth = 1;
                datatable.DefaultHorizontalAlignment = 1;
                datatable.DefaultRowspan = 9;
                //datatable.Widths = headerwidths;
                //datatable.ta
                datatable.AddCell(new Phrase("First Name", FontFactory.GetFont(FontFactory.HELVETICA, 9, Font.BOLD)));
                datatable.AddCell(new Phrase("Last Name", FontFactory.GetFont(FontFactory.HELVETICA, 9, Font.BOLD)));
                datatable.AddCell(new Phrase("Middle Name", FontFactory.GetFont(FontFactory.HELVETICA, 9, Font.BOLD)));
                datatable.AddCell(new Phrase("Address", FontFactory.GetFont(FontFactory.HELVETICA, 9, Font.BOLD)));
                datatable.AddCell(new Phrase("City", FontFactory.GetFont(FontFactory.HELVETICA, 9, Font.BOLD)));
                datatable.AddCell(new Phrase("State", FontFactory.GetFont(FontFactory.HELVETICA, 9, Font.BOLD)));
                datatable.AddCell(new Phrase("Zip", FontFactory.GetFont(FontFactory.HELVETICA, 9, Font.BOLD)));
                datatable.AddCell(new Phrase("", FontFactory.GetFont(FontFactory.HELVETICA, 9, Font.BOLD)));
                datatable.AddCell(new Phrase("", FontFactory.GetFont(FontFactory.HELVETICA, 9, Font.BOLD)));
                //datatable.AddCell(new Phrase("", FontFactory.GetFont(FontFactory.HELVETICA, 9, Font.BOLD)));
                //datatable.AddCell(new Phrase("", FontFactory.GetFont(FontFactory.HELVETICA, 9, Font.BOLD)));




                datatable.Alignment = Element.ALIGN_CENTER;


                CUSTOMER cUSTOMER = new CUSTOMER();

                cUSTOMER = CUSTOMERManager.GetCUSTOMERByID(int.Parse(tRANS.CUSTID.ToString()));

                if (cUSTOMER != null)
                {
                    datatable.AddCell(cUSTOMER.CUSTFNAME);
                    datatable.AddCell(cUSTOMER.CUSTMNAME);
                    datatable.AddCell(cUSTOMER.CUSTLNAME);
                    datatable.AddCell(cUSTOMER.CUSTADDRESS1);
                    datatable.AddCell(cUSTOMER.CUSTCITY);
                    datatable.AddCell(cUSTOMER.CUSTSTATE);

                    datatable.AddCell(cUSTOMER.CUSTZIP);
                }
                datatable.AddCell("");
                datatable.AddCell("");
                //datatable.AddCell("");
                //datatable.AddCell("");
            }

            //document.Add(datatable1);

            //document.Close();
            Cell cellLocation = new Cell(new Phrase("Location Information  ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD)));
            cellLocation.HorizontalAlignment = Element.ALIGN_LEFT;
            cellLocation.Colspan = 9;
            cellLocation.Border = Rectangle.NO_BORDER;
            cellLocation.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.WhiteSmoke);
            datatable.AddCell(cellLocation);


            datatable.DefaultCellBorderWidth = 1;
            datatable.DefaultHorizontalAlignment = 1;
            datatable.DefaultRowspan = 9;

            datatable.AddCell(new Phrase("Branch", FontFactory.GetFont(FontFactory.HELVETICA, 9, Font.BOLD)));
            datatable.AddCell(new Phrase("City", FontFactory.GetFont(FontFactory.HELVETICA, 9, Font.BOLD)));
            datatable.AddCell(new Phrase("Country", FontFactory.GetFont(FontFactory.HELVETICA, 9, Font.BOLD)));
            datatable.AddCell(new Phrase("", FontFactory.GetFont(FontFactory.HELVETICA, 9, Font.BOLD)));
            datatable.AddCell(new Phrase("", FontFactory.GetFont(FontFactory.HELVETICA, 9, Font.BOLD)));
            datatable.AddCell(new Phrase("", FontFactory.GetFont(FontFactory.HELVETICA, 9, Font.BOLD)));
            datatable.AddCell(new Phrase("", FontFactory.GetFont(FontFactory.HELVETICA, 9, Font.BOLD)));
            datatable.AddCell(new Phrase("", FontFactory.GetFont(FontFactory.HELVETICA, 9, Font.BOLD)));
            datatable.AddCell(new Phrase("", FontFactory.GetFont(FontFactory.HELVETICA, 9, Font.BOLD)));



            for (int i = 0; i < ssReferenceCodeFINAL.Count; i++)
            {
                datatable.DefaultHorizontalAlignment = Element.ALIGN_LEFT;
                TRANS tRANS1 = new TRANS();
                tRANS1 = TRANSManager.GetTRANSByRefCode(ssReferenceCodeFINAL[i].ToString());

                if (tRANS1 != null)
                {
                    datatable.Alignment = Element.ALIGN_CENTER;


                    LOCATION lOCATION = new LOCATION();

                    lOCATION = LOCATIONManager.GetLOCATIONByID(int.Parse(tRANS1.LOCATIONID.ToString()));

                    if (lOCATION != null)
                    {
                        datatable.AddCell(lOCATION.BRANCH);
                        datatable.AddCell(lOCATION.CITY);
                        datatable.AddCell(lOCATION.COUNTRY);
                        datatable.AddCell("");
                        datatable.AddCell("");
                        datatable.AddCell("");
                        datatable.AddCell("");
                        datatable.AddCell("");
                        datatable.AddCell("");
                    }
                }


            }


            Cell cellReceiver = new Cell(new Phrase("Receiver Information  ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD)));
            cellReceiver.HorizontalAlignment = Element.ALIGN_LEFT;
            cellReceiver.Colspan = 9;
            cellReceiver.Border = Rectangle.NO_BORDER;
            cellReceiver.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.WhiteSmoke);
            datatable.AddCell(cellReceiver);


            datatable.DefaultCellBorderWidth = 1;
            datatable.DefaultHorizontalAlignment = 1;
            datatable.DefaultRowspan = 9;

            datatable.AddCell(new Phrase("First Name", FontFactory.GetFont(FontFactory.HELVETICA, 9, Font.BOLD)));
            datatable.AddCell(new Phrase("Last Name", FontFactory.GetFont(FontFactory.HELVETICA, 9, Font.BOLD)));
            datatable.AddCell(new Phrase("Middle Name", FontFactory.GetFont(FontFactory.HELVETICA, 9, Font.BOLD)));
            datatable.AddCell(new Phrase("Address", FontFactory.GetFont(FontFactory.HELVETICA, 9, Font.BOLD)));
            //datatable.AddCell(new Phrase("City", FontFactory.GetFont(FontFactory.HELVETICA, 9, Font.BOLD)));
            //datatable.AddCell(new Phrase("State", FontFactory.GetFont(FontFactory.HELVETICA, 9, Font.BOLD)));
            datatable.AddCell(new Phrase("Reference Code", FontFactory.GetFont(FontFactory.HELVETICA, 9, Font.BOLD)));
            datatable.AddCell(new Phrase("Charges", FontFactory.GetFont(FontFactory.HELVETICA, 9, Font.BOLD)));
            datatable.AddCell(new Phrase("Other Charges", FontFactory.GetFont(FontFactory.HELVETICA, 9, Font.BOLD)));
            datatable.AddCell(new Phrase("Amount Trans", FontFactory.GetFont(FontFactory.HELVETICA, 9, Font.BOLD)));
            datatable.AddCell(new Phrase("Total Amount", FontFactory.GetFont(FontFactory.HELVETICA, 9, Font.BOLD)));


            decimal smCharges = 0;
            decimal smOtherCharges = 0;
            decimal smAmountTrans = 0;
            decimal smTotalAmount = 0;




            for (int i = 0; i < ssReferenceCodeFINAL.Count; i++)
            {
                datatable.DefaultHorizontalAlignment = Element.ALIGN_LEFT;
                TRANS tRANS1 = new TRANS();
                tRANS1 = TRANSManager.GetTRANSByRefCode(ssReferenceCodeFINAL[i].ToString());

                if (tRANS1 != null)
                {
                    datatable.Alignment = Element.ALIGN_CENTER;


                    RECEIVER rECEIVER = new RECEIVER();

                    rECEIVER = RECEIVERManager.GetRECEIVERByID(int.Parse(tRANS1.RECEIVERID.ToString()));

                    if (rECEIVER != null)
                    {
                        datatable.AddCell(rECEIVER.RECEIVERFNAME);
                        datatable.AddCell(rECEIVER.RECEIVERMNAME);
                        datatable.AddCell(rECEIVER.RECEIVERLNAME);
                        datatable.AddCell(rECEIVER.RECEIVERADDRESS1);
                        //datatable.AddCell(rECEIVER.RECEIVERCITY);
                        //datatable.AddCell(rECEIVER.RECEIVERSTATE);

                        datatable.AddCell(ssReferenceCodeFINAL[i].ToString());
                    }
                    datatable.AddCell(tRANS1.TRANSFEES.ToString());
                    datatable.AddCell(tRANS1.TRANSOTHERFEES.ToString());
                    datatable.AddCell(tRANS1.TRANSAMOUNT.ToString());
                    datatable.AddCell(tRANS1.TRANSTOTALAMOUNT.ToString());

                    smCharges = smCharges + decimal.Parse(tRANS1.TRANSFEES.ToString());
                    smOtherCharges = smOtherCharges + decimal.Parse(tRANS1.TRANSOTHERFEES.ToString());
                    smAmountTrans = smAmountTrans + decimal.Parse(tRANS1.TRANSAMOUNT.ToString());
                    smTotalAmount = smTotalAmount + decimal.Parse(tRANS1.TRANSTOTALAMOUNT.ToString());

                }


            }
























            //datatable.AddCell("");
            //datatable.AddCell("");
            datatable.AddCell("");
            datatable.AddCell("");
            datatable.AddCell("");
            datatable.AddCell("");

            datatable.AddCell(new Phrase("Total : ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD)));
            datatable.AddCell(new Phrase(smCharges.ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD)));
            datatable.AddCell(new Phrase(smOtherCharges.ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD)));
            datatable.AddCell(new Phrase(smAmountTrans.ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD)));
            datatable.AddCell(new Phrase(smTotalAmount.ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD)));




            Cell cellConditionTitle = new Cell(new Phrase("CONDITIONS GOVERNING THE TRANSFER OF FUNDS", FontFactory.GetFont(FontFactory.HELVETICA, 14, Font.BOLD)));
            cellConditionTitle.HorizontalAlignment = Element.ALIGN_CENTER;
            cellConditionTitle.Colspan = 9;

            cellConditionTitle.Border = Rectangle.NO_BORDER;
            cellConditionTitle.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.WhiteSmoke);
            datatable.AddCell(cellConditionTitle);





            string ConditionDesc = string.Empty;

            ConditionDesc = "Customer(s) (“You”) authorize ABIMATU ENTERPRISE (“Us/We”) to make thewire transfer described on this form.CURRENCYEXCHANGE:In addition to the transfer fee, ABIMATU ENTERPRISE also makes money when it changesyour dollars into foreign currency. Payments willgenerally be in local currency. In addition to the transfer feesapplicable to this transaction, a currency exchange rate will beapplied. United States currency is converted to foreign currency at anexchange rate set by ABIMATU ENTERPRISE. Any difference between the rate given to Customers and the rate receivedby ABIMATU ENTERPRISE will be kept by ABIMATU ENTERPRISE(and its Agents in some cases) in addition to the transfer fees.We may transfer funds through an Intermediary Bank or funds transfersystem tha is different from that shown in your instructions. If we receive your payment order after our processing ending hour, or ona weekend or holiday, we may process it on the next funds-transferbusiness day. A delay may also occur if an Intermediary Bank or theBeneficiary Bank is not accepting payment orders (e.g. due to a localholiday).You agree to hold ABIMATU ENTERPRISE  harmlessfrom any loss that occurs if your instructions are incomplete,ambiguous, or incorrect. We are not required to seek clarification fromanyone regarding ambiguous instructions. If we cannot complete atransfer .g. because of an ambiguity), we will notify you orally or inwriting at the end of the next business day.    We will not be liable for the consequential, special, or exemplarydamages or losses of any kind. We will not be liable for any failure toact or delay due to: circumstances beyond our control; fire, flood, ornatural disasters; communication failures; labor disputes; anyinaccuracy or ambiguity in your instructions; the action or inaction ofothers; or any applicable government or funds-transfer system rule,policy, or regulations.REFUNDOF PRINCIPAL AMOUNTand cancellation of the money transfer will be made upon written requestof the Sender if payment to the Receiver has not yet been made at thetime the request is processed by ABIMATU ENTERPRISE . REFUNDS OFTRANSFER FEES will be made upon written request of the Sender if themoney transfer is not available to the Receiver within the timespecified by ABIMATU ENTERPRISE  forthe selected service, subject to the hours of operation that the Serviceis offered at the Agent location selected by the Receiver for paymentand other special conditions. Refund will be made within 45 days ofreceipt of a valid written request from the Sender.LIMITATION OF LIABILITY: IN NO EVENT SHALL ABIMATU ENTERPRISE  BELIABLE FOR DAMAGES FOR DELAY, NON DELIVERY, NON PAYMENT OR UNDERPAYMENTOF ANY MONEY TRANSFER, OR ANY SUPPLEMENTAL MESSAGE WHETHER CAUSED BYNEGLIGENCE ON THE PART OF ITS EMPLOYEES, SUPPLIERS OR AGENTS OROTHERWISE BEYOND THE SUM OF $500 (in addition to refunding the principalamount of the money transfer and the transfer fees), IN NO EVENT WILLABIMATU ENTERPRISE  BE LIABLE FORANY INDIRECT, SPECIAL, INCIDENTAL, CONSEQUENTIAL EXEMPLENARY OR PUNITIVEDAMGES, OR THE LIKE. THESE CONDITIONS CANNOT BE CHANGED OR SUPPLEMENTEDORALLY.ABIMATU ENTERPRISE  reserved theright to limit the principal amount of a money transfer, or to reject aproposed money transfer, in its sole discretion. ABIMATU ENTERPRISE assumes no obligation fordamages resulting from nonpayment of the money transfer or any failureto complete any applicable Service transaction by reason of such lack ofauthorization. ABIMATU ENTERPRISE  reservesthe right to refuse to provide the Service to you at anytime for anyreason deemed necessary to protect ABIMATU ENTERPRISE ’s interests.";


            Cell cellConditionDesc = new Cell(new Phrase(ConditionDesc, FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.NORMAL)));
            cellConditionDesc.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            cellConditionDesc.Colspan = 9;
            cellConditionDesc.Border = Rectangle.NO_BORDER;
            cellConditionDesc.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.White);
            datatable.AddCell(cellConditionDesc);




            Cell cellAgentSignature = new Cell(new Phrase("AGENT SIGNATURE", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL)));
            cellAgentSignature.HorizontalAlignment = Element.ALIGN_LEFT;
            cellAgentSignature.Leading = 100;
            cellAgentSignature.Colspan = 5;
            cellAgentSignature.Border = Rectangle.NO_BORDER;
            cellAgentSignature.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.White);
            datatable.AddCell(cellAgentSignature);



            Cell cellCustomerSignature = new Cell(new Phrase("CUSTOMER SIGNATURE", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL)));
            cellCustomerSignature.HorizontalAlignment = Element.ALIGN_RIGHT;
            cellCustomerSignature.Leading = 100;
            cellCustomerSignature.Colspan = 4;
            cellCustomerSignature.Border = Rectangle.NO_BORDER;
            cellCustomerSignature.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.White);
            datatable.AddCell(cellCustomerSignature);



            document.Add(datatable);

        }
        catch (Exception e)
        {
            //Console.Error.WriteLine(e.Message);
        }

        document.Close();

        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Receipt.pdf");
        Response.ContentType = "application/pdf";
        Response.BinaryWrite(msReport.ToArray());
        Response.End();
    }

    #endregion
}