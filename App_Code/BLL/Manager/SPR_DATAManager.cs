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

public class SPR_DATAManager
{
	public SPR_DATAManager()
	{
	}

    public static List<SPR_DATA> GetAllSPR_DATAs()
    {
        List<SPR_DATA> sPR_DATAs = new List<SPR_DATA>();
        SqlSPR_DATAProvider sqlSPR_DATAProvider = new SqlSPR_DATAProvider();
        sPR_DATAs = sqlSPR_DATAProvider.GetAllSPR_DATAs();
        return sPR_DATAs;
    }


    public static SPR_DATA GetSPR_DATAByID(int id)
    {
        SPR_DATA sPR_DATA = new SPR_DATA();
        SqlSPR_DATAProvider sqlSPR_DATAProvider = new SqlSPR_DATAProvider();
        sPR_DATA = sqlSPR_DATAProvider.GetSPR_DATAByID(id);
        return sPR_DATA;
    }


    public static int InsertSPR_DATA(SPR_DATA sPR_DATA)
    {
        SqlSPR_DATAProvider sqlSPR_DATAProvider = new SqlSPR_DATAProvider();
        return sqlSPR_DATAProvider.InsertSPR_DATA(sPR_DATA);
    }


    public static bool UpdateSPR_DATA(SPR_DATA sPR_DATA)
    {
        SqlSPR_DATAProvider sqlSPR_DATAProvider = new SqlSPR_DATAProvider();
        return sqlSPR_DATAProvider.UpdateSPR_DATA(sPR_DATA);
    }

    public static bool DeleteSPR_DATA(int sPR_DATAID)
    {
        SqlSPR_DATAProvider sqlSPR_DATAProvider = new SqlSPR_DATAProvider();
        return sqlSPR_DATAProvider.DeleteSPR_DATA(sPR_DATAID);
    }
}
