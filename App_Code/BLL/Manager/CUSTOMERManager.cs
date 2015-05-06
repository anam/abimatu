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

public class CUSTOMERManager
{
	public CUSTOMERManager()
	{
	}

    public static List<CUSTOMER> GetAllCUSTOMERs()
    {
        List<CUSTOMER> cUSTOMERs = new List<CUSTOMER>();
        SqlCUSTOMERProvider sqlCUSTOMERProvider = new SqlCUSTOMERProvider();
        cUSTOMERs = sqlCUSTOMERProvider.GetAllCUSTOMERs();
        return cUSTOMERs;
    }

    public static List<CUSTOMER> GetAllCUSTOMERsForSearch(int customerID, string phoneNumber, string drivingLicense, string ssn, string customerFName, string customerMName, string customerLName)
    {
        List<CUSTOMER> cUSTOMERs = new List<CUSTOMER>();
        SqlCUSTOMERProvider sqlCUSTOMERProvider = new SqlCUSTOMERProvider();
        cUSTOMERs = sqlCUSTOMERProvider.GetAllCUSTOMERsForSearch(customerID, phoneNumber, drivingLicense, ssn, customerFName, customerMName, customerLName);
        return cUSTOMERs;
    }


    public static List<CUSTOMER> GetAllCUSTOMERsByCUSTIDNUMBER_CUSTDOB(string cUSTIDNUMBER, DateTime cUSTDOB)
    {
        List<CUSTOMER> cUSTOMERs = new List<CUSTOMER>();
        SqlCUSTOMERProvider sqlCUSTOMERProvider = new SqlCUSTOMERProvider();
        cUSTOMERs = sqlCUSTOMERProvider.GetAllCUSTOMERsForSearch( cUSTIDNUMBER,  cUSTDOB);
        return cUSTOMERs;
    }

    public static List<CUSTOMER> GetAllCUSTOMERsForSearchByName( string customerFName)
    {
        List<CUSTOMER> cUSTOMERs = new List<CUSTOMER>();
        SqlCUSTOMERProvider sqlCUSTOMERProvider = new SqlCUSTOMERProvider();
        cUSTOMERs = sqlCUSTOMERProvider.GetAllCUSTOMERsForSearchByName(customerFName);
        return cUSTOMERs;
    }

    public static List<CUSTOMER> GetAllCUSTOMERsForSearchByID(int customerID)
    {
        List<CUSTOMER> cUSTOMERs = new List<CUSTOMER>();
        SqlCUSTOMERProvider sqlCUSTOMERProvider = new SqlCUSTOMERProvider();
        cUSTOMERs = sqlCUSTOMERProvider.GetAllCUSTOMERsForSearchByID(customerID);
        return cUSTOMERs;
    }

    public static CUSTOMER GetCUSTOMERByID(int id)
    {
        CUSTOMER cUSTOMER = new CUSTOMER();
        SqlCUSTOMERProvider sqlCUSTOMERProvider = new SqlCUSTOMERProvider();
        cUSTOMER = sqlCUSTOMERProvider.GetCUSTOMERByID(id);
        return cUSTOMER;
    }


    public static int InsertCUSTOMER(CUSTOMER cUSTOMER)
    {
        SqlCUSTOMERProvider sqlCUSTOMERProvider = new SqlCUSTOMERProvider();
        return sqlCUSTOMERProvider.InsertCUSTOMER(cUSTOMER);
    }


    public static bool UpdateCUSTOMER(CUSTOMER cUSTOMER)
    {
        SqlCUSTOMERProvider sqlCUSTOMERProvider = new SqlCUSTOMERProvider();
        return sqlCUSTOMERProvider.UpdateCUSTOMER(cUSTOMER);
    }

    public static bool DeleteCUSTOMER(int cUSTOMERID)
    {
        SqlCUSTOMERProvider sqlCUSTOMERProvider = new SqlCUSTOMERProvider();
        return sqlCUSTOMERProvider.DeleteCUSTOMER(cUSTOMERID);
    }

    public static bool UpdateSUS_CUSTOMER(string ids, string date)
    {
        SqlCUSTOMERProvider sqlCUSTOMERProvider = new SqlCUSTOMERProvider();
        return sqlCUSTOMERProvider.UpdateSUS_CUSTOMER(ids,date);
    }
}
