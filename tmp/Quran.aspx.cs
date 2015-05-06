using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class tmp_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            string pages = "<table>";
            for (int i = 1; i < 30; i++)
            {
                pages += "<tr><td><img src='http://readingalquran.com/images/AlQuran-15-lines/1/"+i+".jpg' /></td></tr>";
            }
            Label1.Text = pages+ "</table>";
        }
    }
}