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

public class STOREManager
{
	public STOREManager()
	{
	}

    public static List<STORE> GetAllSTOREs()
    {
        List<STORE> sTOREs = new List<STORE>();
        SqlSTOREProvider sqlSTOREProvider = new SqlSTOREProvider();
        sTOREs = sqlSTOREProvider.GetAllSTOREs();
        return sTOREs;
    }


    public static STORE GetSTOREByID(int id)
    {
        STORE sTORE = new STORE();
        SqlSTOREProvider sqlSTOREProvider = new SqlSTOREProvider();
        sTORE = sqlSTOREProvider.GetSTOREByID(id);
        return sTORE;
    }


    public static int InsertSTORE(STORE sTORE)
    {
        SqlSTOREProvider sqlSTOREProvider = new SqlSTOREProvider();
        return sqlSTOREProvider.InsertSTORE(sTORE);
    }


    public static bool UpdateSTORE(STORE sTORE)
    {
        SqlSTOREProvider sqlSTOREProvider = new SqlSTOREProvider();
        return sqlSTOREProvider.UpdateSTORE(sTORE);
    }

    public static bool DeleteSTORE(int sTOREID)
    {
        SqlSTOREProvider sqlSTOREProvider = new SqlSTOREProvider();
        return sqlSTOREProvider.DeleteSTORE(sTOREID);
    }
}
