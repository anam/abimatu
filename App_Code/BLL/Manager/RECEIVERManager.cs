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

public class RECEIVERManager
{
	public RECEIVERManager()
	{
	}

    public static List<RECEIVER> GetAllRECEIVERs()
    {
        List<RECEIVER> rECEIVERs = new List<RECEIVER>();
        SqlRECEIVERProvider sqlRECEIVERProvider = new SqlRECEIVERProvider();
        rECEIVERs = sqlRECEIVERProvider.GetAllRECEIVERs();
        return rECEIVERs;
    }


    public static List<RECEIVER> GetAllRECEIVERsForSearchByID(int rECEIVERID)
    {
        List<RECEIVER> rECEIVERs = new List<RECEIVER>();
        SqlRECEIVERProvider sqlRECEIVERProvider = new SqlRECEIVERProvider();
        rECEIVERs = sqlRECEIVERProvider.GetAllRECEIVERsForSearchByID(rECEIVERID);
        return rECEIVERs;
    }

    public static List<RECEIVER> GetAllRECEIVERByAgentID(int agentID, int customerID)
    {
        List<RECEIVER> rECEIVERs = new List<RECEIVER>();
        SqlRECEIVERProvider sqlRECEIVERProvider = new SqlRECEIVERProvider();
        rECEIVERs = sqlRECEIVERProvider.GetAllRECEIVERByAgentID(agentID, customerID);
        return rECEIVERs;
    }

    public static List<RECEIVER> GetAllRECEIVERsForSearchByIDNew(int rECEIVERID)
    {
        List<RECEIVER> rECEIVERs = new List<RECEIVER>();
        SqlRECEIVERProvider sqlRECEIVERProvider = new SqlRECEIVERProvider();
        rECEIVERs = sqlRECEIVERProvider.GetAllRECEIVERsForSearchByIDNew(rECEIVERID);
        return rECEIVERs;
    }
    public static List<RECEIVER> GetAllRECEIVERsForSearch(int cUSTID , int rECEIVERID, string rECEIVERFNAME, string rECEIVERADDRESS1,string rECEIVERCITY,string rECEIVERSTATE,string rECEIVERZIP,string rECEIVERPHONE)
    {
        List<RECEIVER> rECEIVERs = new List<RECEIVER>();
        SqlRECEIVERProvider sqlRECEIVERProvider = new SqlRECEIVERProvider();
        rECEIVERs = sqlRECEIVERProvider.GetAllRECEIVERsForSearch(cUSTID, rECEIVERID, rECEIVERFNAME, rECEIVERADDRESS1, rECEIVERCITY, rECEIVERSTATE, rECEIVERZIP, rECEIVERPHONE);
        return rECEIVERs;
    }

    public static List<RECEIVER> GetAllRECEIVERsFoodForSearch(int cUSTID, int rECEIVERID, string rECEIVERFNAME, string rECEIVERADDRESS1, string rECEIVERCITY, string rECEIVERSTATE, string rECEIVERZIP, string rECEIVERPHONE)
    {
        List<RECEIVER> rECEIVERs = new List<RECEIVER>();
        SqlRECEIVERProvider sqlRECEIVERProvider = new SqlRECEIVERProvider();
        rECEIVERs = sqlRECEIVERProvider.GetAllRECEIVERsFoodForSearch(cUSTID, rECEIVERID, rECEIVERFNAME, rECEIVERADDRESS1, rECEIVERCITY, rECEIVERSTATE, rECEIVERZIP, rECEIVERPHONE);
        return rECEIVERs;
    }

    public static RECEIVER GetRECEIVERByID(int id)
    {
        RECEIVER rECEIVER = new RECEIVER();
        SqlRECEIVERProvider sqlRECEIVERProvider = new SqlRECEIVERProvider();
        rECEIVER = sqlRECEIVERProvider.GetRECEIVERByID(id);
        return rECEIVER;
    }


    public static int InsertRECEIVER(RECEIVER rECEIVER)
    {
        SqlRECEIVERProvider sqlRECEIVERProvider = new SqlRECEIVERProvider();
        return sqlRECEIVERProvider.InsertRECEIVER(rECEIVER);
    }


    public static bool UpdateRECEIVER(RECEIVER rECEIVER)
    {
        SqlRECEIVERProvider sqlRECEIVERProvider = new SqlRECEIVERProvider();
        return sqlRECEIVERProvider.UpdateRECEIVER(rECEIVER);
    }

    public static bool DeleteRECEIVER(int rECEIVERID)
    {
        SqlRECEIVERProvider sqlRECEIVERProvider = new SqlRECEIVERProvider();
        return sqlRECEIVERProvider.DeleteRECEIVER(rECEIVERID);
    }
}
