using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TestFileUpload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Page.Form.Enctype = "multipart/form-data";

            
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            ((ASP.membermaster_master)Page.Master).RegisterPostbackTrigger(Button1);

        }
        catch
        {
        }

        if (uplFile.PostedFile != null && uplFile.PostedFile.ContentLength > 0)
        {
            //try
            //{
            //    string dirUrl = "~/Uploads/Customer";
            //    string dirPath = Server.MapPath(dirUrl);

            //    if (!Directory.Exists(dirPath))
            //    {
            //        Directory.CreateDirectory(dirPath);
            //    }

            //    string fileName = Path.GetFileName(uplFile.PostedFile.FileName);
            //    string fileUrl = dirUrl + "/" + Path.GetFileName(uplFile.PostedFile.FileName);
            //    string filePath = Server.MapPath(fileUrl);
            //    uplFile.PostedFile.SaveAs(filePath);

            //    tempCUSTOMER.SCANURL = dirUrl + "/" + fileName;
            //}
            //catch (Exception ex)
            //{
            //    lblMessage.Text = ex.Message.ToString();

            //}

            Label1.Text = "Get";
        }
        else
        {

            Label1.Text = "Not Get";
        }
    }
}