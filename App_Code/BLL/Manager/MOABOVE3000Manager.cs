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

public class MOABOVE3000Manager
{
	public MOABOVE3000Manager()
	{
	}

    public static List<MOABOVE3000> GetAllMOABOVE3000s()
    {
        List<MOABOVE3000> mOABOVE3000s = new List<MOABOVE3000>();
        SqlMOABOVE3000Provider sqlMOABOVE3000Provider = new SqlMOABOVE3000Provider();
        mOABOVE3000s = sqlMOABOVE3000Provider.GetAllMOABOVE3000s();
        return mOABOVE3000s;
    }


    public static MOABOVE3000 GetMOABOVE3000ByID(int id)
    {
        MOABOVE3000 mOABOVE3000 = new MOABOVE3000();
        SqlMOABOVE3000Provider sqlMOABOVE3000Provider = new SqlMOABOVE3000Provider();
        mOABOVE3000 = sqlMOABOVE3000Provider.GetMOABOVE3000ByID(id);
        return mOABOVE3000;
    }


    public static int InsertMOABOVE3000(MOABOVE3000 mOABOVE3000)
    {
        SqlMOABOVE3000Provider sqlMOABOVE3000Provider = new SqlMOABOVE3000Provider();
        return sqlMOABOVE3000Provider.InsertMOABOVE3000(mOABOVE3000);
    }


    public static bool UpdateMOABOVE3000(MOABOVE3000 mOABOVE3000)
    {
        SqlMOABOVE3000Provider sqlMOABOVE3000Provider = new SqlMOABOVE3000Provider();
        return sqlMOABOVE3000Provider.UpdateMOABOVE3000(mOABOVE3000);
    }

    public static bool DeleteMOABOVE3000(int mOABOVE3000ID)
    {
        SqlMOABOVE3000Provider sqlMOABOVE3000Provider = new SqlMOABOVE3000Provider();
        return sqlMOABOVE3000Provider.DeleteMOABOVE3000(mOABOVE3000ID);
    }
}
