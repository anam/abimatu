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

public class SPR_COMMISSIONManager
{
	public SPR_COMMISSIONManager()
	{
	}

    public static List<SPR_COMMISSION> GetAllSPR_COMMISSIONs()
    {
        List<SPR_COMMISSION> sPR_COMMISSIONs = new List<SPR_COMMISSION>();
        SqlSPR_COMMISSIONProvider sqlSPR_COMMISSIONProvider = new SqlSPR_COMMISSIONProvider();
        sPR_COMMISSIONs = sqlSPR_COMMISSIONProvider.GetAllSPR_COMMISSIONs();
        return sPR_COMMISSIONs;
    }


    public static SPR_COMMISSION GetSPR_COMMISSIONByID(int id)
    {
        SPR_COMMISSION sPR_COMMISSION = new SPR_COMMISSION();
        SqlSPR_COMMISSIONProvider sqlSPR_COMMISSIONProvider = new SqlSPR_COMMISSIONProvider();
        sPR_COMMISSION = sqlSPR_COMMISSIONProvider.GetSPR_COMMISSIONByID(id);
        return sPR_COMMISSION;
    }


    public static int InsertSPR_COMMISSION(SPR_COMMISSION sPR_COMMISSION)
    {
        SqlSPR_COMMISSIONProvider sqlSPR_COMMISSIONProvider = new SqlSPR_COMMISSIONProvider();
        return sqlSPR_COMMISSIONProvider.InsertSPR_COMMISSION(sPR_COMMISSION);
    }


    public static bool UpdateSPR_COMMISSION(SPR_COMMISSION sPR_COMMISSION)
    {
        SqlSPR_COMMISSIONProvider sqlSPR_COMMISSIONProvider = new SqlSPR_COMMISSIONProvider();
        return sqlSPR_COMMISSIONProvider.UpdateSPR_COMMISSION(sPR_COMMISSION);
    }

    public static bool DeleteSPR_COMMISSION(int sPR_COMMISSIONID)
    {
        SqlSPR_COMMISSIONProvider sqlSPR_COMMISSIONProvider = new SqlSPR_COMMISSIONProvider();
        return sqlSPR_COMMISSIONProvider.DeleteSPR_COMMISSION(sPR_COMMISSIONID);
    }
}
