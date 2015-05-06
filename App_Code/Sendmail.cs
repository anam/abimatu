using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net.Mail;
using System.Net;

/// <summary>
/// Summary description for Sendmail
/// </summary>
public class Sendmail
{
	public Sendmail()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static bool sendEmail(String fromAddr, String senderName, String toAddr, String ccAddr, String subject, String body, String _userName, String _password)
    {

        SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

        client.EnableSsl = true;

        client.Credentials = new NetworkCredential(_userName, _password);

        MailAddress from = new MailAddress(fromAddr, senderName);

        MailAddress to = new MailAddress(toAddr);

        MailMessage message = new MailMessage(from, to);

        if (ccAddr.Trim() != "")
        {

            string[] strArray = ccAddr.Trim().Split(new char[] { ';' });

            for (int i = 0; i < strArray.Length; i++)
            {

                message.CC.Add(strArray[i].Trim());

            }

        }

        message.Subject = subject;

        message.IsBodyHtml = true;

        message.Body = body;

        try
        {

            client.Send(message);

            return true;

        }

        catch (Exception ex)
        {

            return false;

        }

    }
}
