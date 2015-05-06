using System;
using System.Collections.Generic;
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

public class WUABOVE3000Manager
{
	public WUABOVE3000Manager()
	{
	}

    public static List<WUABOVE3000> GetAllWUABOVE3000s()
    {
        List<WUABOVE3000> wUABOVE3000s = new List<WUABOVE3000>();
        SqlWUABOVE3000Provider sqlWUABOVE3000Provider = new SqlWUABOVE3000Provider();
        wUABOVE3000s = sqlWUABOVE3000Provider.GetAllWUABOVE3000s();
        return wUABOVE3000s;
    }


    public static WUABOVE3000 GetWUABOVE3000ByID(int id)
    {
        WUABOVE3000 wUABOVE3000 = new WUABOVE3000();
        SqlWUABOVE3000Provider sqlWUABOVE3000Provider = new SqlWUABOVE3000Provider();
        wUABOVE3000 = sqlWUABOVE3000Provider.GetWUABOVE3000ByID(id);
        return wUABOVE3000;
    }


    public static int InsertWUABOVE3000(WUABOVE3000 wUABOVE3000)
    {
        SqlWUABOVE3000Provider sqlWUABOVE3000Provider = new SqlWUABOVE3000Provider();
        return sqlWUABOVE3000Provider.InsertWUABOVE3000(wUABOVE3000);
    }


    public static bool UpdateWUABOVE3000(WUABOVE3000 wUABOVE3000)
    {
        SqlWUABOVE3000Provider sqlWUABOVE3000Provider = new SqlWUABOVE3000Provider();
        return sqlWUABOVE3000Provider.UpdateWUABOVE3000(wUABOVE3000);
    }

    public static bool DeleteWUABOVE3000(int wUABOVE3000ID)
    {
        SqlWUABOVE3000Provider sqlWUABOVE3000Provider = new SqlWUABOVE3000Provider();
        return sqlWUABOVE3000Provider.DeleteWUABOVE3000(wUABOVE3000ID);
    }
}
