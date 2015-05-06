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

public class PRODUCTMASTERManager
{
	public PRODUCTMASTERManager()
	{
	}

    public static List<PRODUCTMASTER> GetAllPRODUCTMASTERs()
    {
        List<PRODUCTMASTER> pRODUCTMASTERs = new List<PRODUCTMASTER>();
        SqlPRODUCTMASTERProvider sqlPRODUCTMASTERProvider = new SqlPRODUCTMASTERProvider();
        pRODUCTMASTERs = sqlPRODUCTMASTERProvider.GetAllPRODUCTMASTERs();
        return pRODUCTMASTERs;
    }


    public static PRODUCTMASTER GetPRODUCTMASTERByID(int id)
    {
        PRODUCTMASTER pRODUCTMASTER = new PRODUCTMASTER();
        SqlPRODUCTMASTERProvider sqlPRODUCTMASTERProvider = new SqlPRODUCTMASTERProvider();
        pRODUCTMASTER = sqlPRODUCTMASTERProvider.GetPRODUCTMASTERByID(id);
        return pRODUCTMASTER;
    }


    public static int InsertPRODUCTMASTER(PRODUCTMASTER pRODUCTMASTER)
    {
        SqlPRODUCTMASTERProvider sqlPRODUCTMASTERProvider = new SqlPRODUCTMASTERProvider();
        return sqlPRODUCTMASTERProvider.InsertPRODUCTMASTER(pRODUCTMASTER);
    }


    public static bool UpdatePRODUCTMASTER(PRODUCTMASTER pRODUCTMASTER)
    {
        SqlPRODUCTMASTERProvider sqlPRODUCTMASTERProvider = new SqlPRODUCTMASTERProvider();
        return sqlPRODUCTMASTERProvider.UpdatePRODUCTMASTER(pRODUCTMASTER);
    }

    public static bool DeletePRODUCTMASTER(int pRODUCTMASTERID)
    {
        SqlPRODUCTMASTERProvider sqlPRODUCTMASTERProvider = new SqlPRODUCTMASTERProvider();
        return sqlPRODUCTMASTERProvider.DeletePRODUCTMASTER(pRODUCTMASTERID);
    }
}
