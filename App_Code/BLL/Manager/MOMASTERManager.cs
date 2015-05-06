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

public class MOMASTERManager
{
	public MOMASTERManager()
	{
	}

    public static List<MOMASTER> GetAllMOMASTERs()
    {
        List<MOMASTER> mOMASTERs = new List<MOMASTER>();
        SqlMOMASTERProvider sqlMOMASTERProvider = new SqlMOMASTERProvider();
        mOMASTERs = sqlMOMASTERProvider.GetAllMOMASTERs();
        return mOMASTERs;
    }


    public static MOMASTER GetMOMASTERByID(int id)
    {
        MOMASTER mOMASTER = new MOMASTER();
        SqlMOMASTERProvider sqlMOMASTERProvider = new SqlMOMASTERProvider();
        mOMASTER = sqlMOMASTERProvider.GetMOMASTERByID(id);
        return mOMASTER;
    }


    public static int InsertMOMASTER(MOMASTER mOMASTER)
    {
        SqlMOMASTERProvider sqlMOMASTERProvider = new SqlMOMASTERProvider();
        return sqlMOMASTERProvider.InsertMOMASTER(mOMASTER);
    }


    public static bool UpdateMOMASTER(MOMASTER mOMASTER)
    {
        SqlMOMASTERProvider sqlMOMASTERProvider = new SqlMOMASTERProvider();
        return sqlMOMASTERProvider.UpdateMOMASTER(mOMASTER);
    }

    public static bool DeleteMOMASTER(int mOMASTERID)
    {
        SqlMOMASTERProvider sqlMOMASTERProvider = new SqlMOMASTERProvider();
        return sqlMOMASTERProvider.DeleteMOMASTER(mOMASTERID);
    }
}
