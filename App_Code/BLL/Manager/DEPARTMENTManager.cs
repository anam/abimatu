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

public class DEPARTMENTManager
{
	public DEPARTMENTManager()
	{
	}

    public static List<DEPARTMENT> GetAllDEPARTMENTs()
    {
        List<DEPARTMENT> dEPARTMENTs = new List<DEPARTMENT>();
        SqlDEPARTMENTProvider sqlDEPARTMENTProvider = new SqlDEPARTMENTProvider();
        dEPARTMENTs = sqlDEPARTMENTProvider.GetAllDEPARTMENTs();
        return dEPARTMENTs;
    }


    public static DEPARTMENT GetDEPARTMENTByID(int id)
    {
        DEPARTMENT dEPARTMENT = new DEPARTMENT();
        SqlDEPARTMENTProvider sqlDEPARTMENTProvider = new SqlDEPARTMENTProvider();
        dEPARTMENT = sqlDEPARTMENTProvider.GetDEPARTMENTByID(id);
        return dEPARTMENT;
    }


    public static int InsertDEPARTMENT(DEPARTMENT dEPARTMENT)
    {
        SqlDEPARTMENTProvider sqlDEPARTMENTProvider = new SqlDEPARTMENTProvider();
        return sqlDEPARTMENTProvider.InsertDEPARTMENT(dEPARTMENT);
    }


    public static bool UpdateDEPARTMENT(DEPARTMENT dEPARTMENT)
    {
        SqlDEPARTMENTProvider sqlDEPARTMENTProvider = new SqlDEPARTMENTProvider();
        return sqlDEPARTMENTProvider.UpdateDEPARTMENT(dEPARTMENT);
    }

    public static bool DeleteDEPARTMENT(int dEPARTMENTID)
    {
        SqlDEPARTMENTProvider sqlDEPARTMENTProvider = new SqlDEPARTMENTProvider();
        return sqlDEPARTMENTProvider.DeleteDEPARTMENT(dEPARTMENTID);
    }
}
