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

public class GLOBALPAYMENTManager
{
	public GLOBALPAYMENTManager()
	{
	}

    public static List<GLOBALPAYMENT> GetAllGLOBALPAYMENTs()
    {
        List<GLOBALPAYMENT> gLOBALPAYMENTs = new List<GLOBALPAYMENT>();
        SqlGLOBALPAYMENTProvider sqlGLOBALPAYMENTProvider = new SqlGLOBALPAYMENTProvider();
        gLOBALPAYMENTs = sqlGLOBALPAYMENTProvider.GetAllGLOBALPAYMENTs();
        return gLOBALPAYMENTs;
    }


    public static GLOBALPAYMENT GetGLOBALPAYMENTByID(int id)
    {
        GLOBALPAYMENT gLOBALPAYMENT = new GLOBALPAYMENT();
        SqlGLOBALPAYMENTProvider sqlGLOBALPAYMENTProvider = new SqlGLOBALPAYMENTProvider();
        gLOBALPAYMENT = sqlGLOBALPAYMENTProvider.GetGLOBALPAYMENTByID(id);
        return gLOBALPAYMENT;
    }


    public static int InsertGLOBALPAYMENT(GLOBALPAYMENT gLOBALPAYMENT)
    {
        SqlGLOBALPAYMENTProvider sqlGLOBALPAYMENTProvider = new SqlGLOBALPAYMENTProvider();
        return sqlGLOBALPAYMENTProvider.InsertGLOBALPAYMENT(gLOBALPAYMENT);
    }


    public static bool UpdateGLOBALPAYMENT(GLOBALPAYMENT gLOBALPAYMENT)
    {
        SqlGLOBALPAYMENTProvider sqlGLOBALPAYMENTProvider = new SqlGLOBALPAYMENTProvider();
        return sqlGLOBALPAYMENTProvider.UpdateGLOBALPAYMENT(gLOBALPAYMENT);
    }

    public static bool DeleteGLOBALPAYMENT(int gLOBALPAYMENTID)
    {
        SqlGLOBALPAYMENTProvider sqlGLOBALPAYMENTProvider = new SqlGLOBALPAYMENTProvider();
        return sqlGLOBALPAYMENTProvider.DeleteGLOBALPAYMENT(gLOBALPAYMENTID);
    }
}
