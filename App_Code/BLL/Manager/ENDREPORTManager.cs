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

public class ENDREPORTManager
{
	public ENDREPORTManager()
	{
	}

    public static List<ENDREPORT> GetAllENDREPORTs()
    {
        List<ENDREPORT> eNDREPORTs = new List<ENDREPORT>();
        SqlENDREPORTProvider sqlENDREPORTProvider = new SqlENDREPORTProvider();
        eNDREPORTs = sqlENDREPORTProvider.GetAllENDREPORTs();
        return eNDREPORTs;
    }


    public static ENDREPORT GetENDREPORTByID(int id)
    {
        ENDREPORT eNDREPORT = new ENDREPORT();
        SqlENDREPORTProvider sqlENDREPORTProvider = new SqlENDREPORTProvider();
        eNDREPORT = sqlENDREPORTProvider.GetENDREPORTByID(id);
        return eNDREPORT;
    }


    public static int InsertENDREPORT(ENDREPORT eNDREPORT)
    {
        SqlENDREPORTProvider sqlENDREPORTProvider = new SqlENDREPORTProvider();
        return sqlENDREPORTProvider.InsertENDREPORT(eNDREPORT);
    }


    public static bool UpdateENDREPORT(ENDREPORT eNDREPORT)
    {
        SqlENDREPORTProvider sqlENDREPORTProvider = new SqlENDREPORTProvider();
        return sqlENDREPORTProvider.UpdateENDREPORT(eNDREPORT);
    }

    public static bool DeleteENDREPORT(int eNDREPORTID)
    {
        SqlENDREPORTProvider sqlENDREPORTProvider = new SqlENDREPORTProvider();
        return sqlENDREPORTProvider.DeleteENDREPORT(eNDREPORTID);
    }
}
