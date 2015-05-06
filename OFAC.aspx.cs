using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml;

public partial class OFAC : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string ofacVerify = string.Empty;
                ofacservice.OFACService service;
                service = new ofacservice.OFACService();
                string token = service.Logon(1881, "abimatu", "b3t5vi113");
                string xml = service.OFACScanName(token, txtCUSTFNAME.Text + " " + txtCUSTMNAME.Text + " " + txtCUSTLNAME.Text);

                if (xml != "")
                {
                    ofacVerify = ProcessXML(xml);
                }
                Label1.Text = ofacVerify;
    }

    private string ProcessXML(string xml)
    {
        string isOfaceVerify = string.Empty;
        try
        {
            //comboBanks.Items.Clear();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            XmlNodeList nodeList = xmlDoc.SelectNodes("//OFACMatch");

            string srchFirstName = txtCUSTFNAME.Text.ToLower();
            string srchMiddleName = txtCUSTMNAME.Text.ToLower();
            string srchLastName = txtCUSTLNAME.Text.ToLower();


            int countFirstName = 0;
            int countMiddleName = 0;
            int countLastName = 0;


            for (int i = 0; i < nodeList.Count; i++)
            {

                string strOriginal = string.Empty;
                strOriginal = nodeList[i].ChildNodes[2].InnerText.ToLower();

                System.Text.RegularExpressions.Regex rexFirst = new System.Text.RegularExpressions.Regex(srchFirstName);
                countFirstName = rexFirst.Matches(strOriginal).Count;

                System.Text.RegularExpressions.Regex rexMiddle = new System.Text.RegularExpressions.Regex(srchMiddleName);
                countMiddleName = rexMiddle.Matches(strOriginal).Count;

                System.Text.RegularExpressions.Regex rexLast = new System.Text.RegularExpressions.Regex(srchLastName);
                countLastName = rexLast.Matches(strOriginal).Count;
                if (countFirstName >= 1 && countMiddleName >= 1 && countLastName >= 1)
                {
                    //lblMessage.Text = srchString + " occurs " + count + " times";

                    isOfaceVerify = "N";
                    i = nodeList.Count;
                    //lblOfacMessage.Text = "Suspecious Activity Found";
                }

                else
                {
                    isOfaceVerify = "Y";
                    //lblOfacMessage.Text = "Suspecious Activity Not Found";
                }

            }


        }
        catch (Exception)
        {
        }


        return isOfaceVerify;
    }
}