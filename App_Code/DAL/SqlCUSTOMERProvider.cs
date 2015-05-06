using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public class SqlCUSTOMERProvider:DataAccessObject
{
	public SqlCUSTOMERProvider()
    {
    }


    public bool DeleteCUSTOMER(int cUSTOMERID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteCUSTOMER", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CUSTOMERID", SqlDbType.Int).Value = cUSTOMERID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
    
    public List<CUSTOMER> GetAllCUSTOMERs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllCUSTOMERs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetCUSTOMERsFromReader(reader);
        }
    }
    
    
    public List<CUSTOMER> GetAllCUSTOMERsForSearch(int customerID, string phoneNumber, string drivingLicense, string ssn, string customerFName, string customerMName, string customerLName)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllCUSTOMERForSearch", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CUSTOMERID", SqlDbType.Int).Value = customerID;
            command.Parameters.Add("@CUSTHPHONE", SqlDbType.VarChar).Value = phoneNumber;
            //command.Parameters.Add("@CUSTOMERID", SqlDbType.Int).Value = drivingLicense;
            command.Parameters.Add("@CUSTSSN", SqlDbType.VarChar).Value = ssn;
            command.Parameters.Add("@CUSTFNAME", SqlDbType.VarChar).Value = customerFName;
            command.Parameters.Add("@CUSTMNAME", SqlDbType.VarChar).Value = customerMName;
            command.Parameters.Add("@CUSTLNAME", SqlDbType.VarChar).Value = customerLName;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetCUSTOMERsFromReader(reader);
        }
    }

    public List<CUSTOMER> GetAllCUSTOMERsForSearch(string cUSTIDNUMBER, DateTime cUSTDOB)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllCUSTOMERsByCUSTIDNUMBER_CUSTDOB", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CUSTIDNUMBER", SqlDbType.VarChar).Value = cUSTIDNUMBER;
            command.Parameters.Add("@CUSTDOB", SqlDbType.DateTime).Value = cUSTDOB;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetCUSTOMERsFromReader(reader);
        }
    }


    public List<CUSTOMER> GetAllCUSTOMERsForSearchByName(string customerFName)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllCUSTOMERForSearchByName", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CUSTFNAME", SqlDbType.VarChar).Value = customerFName;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetCUSTOMERsFromReader(reader);
        }
    }

    public List<CUSTOMER> GetAllCUSTOMERsForSearchByID(int customerID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllCUSTOMERForSearchByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CUSTOMERID", SqlDbType.Int).Value = customerID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetCUSTOMERsFromReader(reader);
        }
    }
    public List<CUSTOMER> GetCUSTOMERsFromReader(IDataReader reader)
    {
        List<CUSTOMER> cUSTOMERs = new List<CUSTOMER>();

        while (reader.Read())
        {
            cUSTOMERs.Add(GetCUSTOMERFromReader(reader));
        }
        return cUSTOMERs;
    }

    public CUSTOMER GetCUSTOMERFromReader(IDataReader reader)
    {
        try
        {
            CUSTOMER cUSTOMER = new CUSTOMER();

            if ( reader["CUSTOMERID"] != DBNull.Value)
            {
                cUSTOMER.CUSTOMERID = int.Parse(reader["CUSTOMERID"].ToString());
            }
            else
            {
                cUSTOMER.CUSTOMERID = 0;
            }

            if ( reader["EMTID"] != DBNull.Value)
            {
                cUSTOMER.EMTID = reader["EMTID"].ToString();
            }
            else
            {
                cUSTOMER.EMTID = "";
            }


            if ( reader["USERNAME"] != DBNull.Value)
            {
                cUSTOMER.USERNAME = reader["USERNAME"].ToString();
            }
            else
            {
                cUSTOMER.USERNAME = "";
            }
            if ( reader["CUSTFNAME"] != DBNull.Value)
            {
                cUSTOMER.CUSTFNAME = reader["CUSTFNAME"].ToString();
            }
            else
            {
                cUSTOMER.CUSTFNAME = "";
            }
            if (reader["CUSTMNAME"] != DBNull.Value)
            {
                cUSTOMER.CUSTMNAME = reader["CUSTMNAME"].ToString();
            }
            else
            {
                cUSTOMER.CUSTMNAME = "";
            }
            if ( reader["CUSTLNAME"] != DBNull.Value)
            {
                cUSTOMER.CUSTLNAME = reader["CUSTLNAME"].ToString();
            }
            else
            {
                cUSTOMER.CUSTLNAME = "";
            }
            if ( reader["CUSTADDRESS1"] != DBNull.Value)
            {
                cUSTOMER.CUSTADDRESS1 = reader["CUSTADDRESS1"].ToString();
            }
            else
            {
                cUSTOMER.CUSTADDRESS1 = "";
            }
            if ( reader["CUSTADDRESS2"] != DBNull.Value)
            {
                cUSTOMER.CUSTADDRESS2 = reader["CUSTADDRESS2"].ToString();
            }
            else
            {
                cUSTOMER.CUSTADDRESS2 = "";
            }
            if (reader["CUSTCITY"] != DBNull.Value)
            {
                cUSTOMER.CUSTCITY = reader["CUSTCITY"].ToString();
            }
            else
            {
                cUSTOMER.CUSTCITY = "";
            }
            if ( reader["CUSTSTATE"] != DBNull.Value)
            {
                cUSTOMER.CUSTSTATE = reader["CUSTSTATE"].ToString();
            }
            else
            {
                cUSTOMER.CUSTSTATE = "";
            }
            if ( reader["CUSTZIP"] != DBNull.Value)
            {
                cUSTOMER.CUSTZIP = reader["CUSTZIP"].ToString();
            }
            else
            {
                cUSTOMER.CUSTZIP = "";
            }
            if ( reader["CUSTHPHONE"] != DBNull.Value)
            {
                cUSTOMER.CUSTHPHONE = reader["CUSTHPHONE"].ToString();
            }
            else
            {
                cUSTOMER.CUSTHPHONE = "";
            }
            if ( reader["CUSTCPHONE"] != DBNull.Value)
            {
                cUSTOMER.CUSTCPHONE = reader["CUSTCPHONE"].ToString();
            }
            else
            {
                cUSTOMER.CUSTCPHONE = "";
            }
            if ( reader["CUSTWPHONE"] != DBNull.Value)
            {
                cUSTOMER.CUSTWPHONE = reader["CUSTWPHONE"].ToString();
            }
            else
            {
                cUSTOMER.CUSTWPHONE = "";
            }
            if ( reader["CUSTSSN"] != DBNull.Value)
            {
                cUSTOMER.CUSTSSN = reader["CUSTSSN"].ToString();
            }
            else
            {
                cUSTOMER.CUSTSSN = "";
            }

            if (reader["CUSTDRIVINGLICENSE"] != DBNull.Value)
            {
                cUSTOMER.CUSTDRIVINGLICENSE = reader["CUSTDRIVINGLICENSE"].ToString();
            }

            else
            {
                cUSTOMER.CUSTDRIVINGLICENSE = "";
            }

            if ( reader["CUSTIDTYPE"] != DBNull.Value)
            {
                cUSTOMER.CUSTIDTYPE = (int)reader["CUSTIDTYPE"];
            }
            else
            {
                cUSTOMER.CUSTIDTYPE = 0;
            }
            if ( reader["CUSTIDNUMBER"] != DBNull.Value)
            {
                cUSTOMER.CUSTIDNUMBER = reader["CUSTIDNUMBER"].ToString();
            }
            else
            {
                cUSTOMER.CUSTIDNUMBER = "";
            }
            if ( reader["CUSTDOB"] != DBNull.Value)
            {
                cUSTOMER.CUSTDOB = (DateTime)reader["CUSTDOB"];
            }
            else
            {
                cUSTOMER.CUSTDOB = DateTime.Now;
            }

            if ( reader["CUSTISSUEDATE"] != DBNull.Value)
            {
                cUSTOMER.CUSTISSUEDATE = (DateTime)reader["CUSTISSUEDATE"];
            }
            else
            {
                cUSTOMER.CUSTISSUEDATE = DateTime.Now;
            }
            if ( reader["CUSTEXPIREDATE"] != DBNull.Value)
            {
                cUSTOMER.CUSTEXPIREDATE = (DateTime)reader["CUSTEXPIREDATE"];
            }
            else
            {
                cUSTOMER.CUSTEXPIREDATE = DateTime.Now;
            }
            if ( reader["ISOFACVERIFIED"] != DBNull.Value)
            {
                cUSTOMER.ISOFACVERIFIED = reader["ISOFACVERIFIED"].ToString();
            }
            else
            {
                cUSTOMER.ISOFACVERIFIED = "";
            }
            if ( reader["CUSTREMARKS"] != DBNull.Value)
            {
                cUSTOMER.CUSTREMARKS = reader["CUSTREMARKS"].ToString();
            }
            else
            {
                cUSTOMER.CUSTREMARKS = "";
            }


            if (reader["SCANURL"] != DBNull.Value)
            {
                cUSTOMER.SCANURL = reader["SCANURL"].ToString();
            }
            else
            {
                cUSTOMER.SCANURL = "";
            }

            if ( reader["CREATEDBY"] != DBNull.Value)
            {
                cUSTOMER.CREATEDBY = (int)reader["CREATEDBY"];
            }
            else
            {
                cUSTOMER.CREATEDBY = 0;
            }

            if ( reader["CREATEDON"] != DBNull.Value)
            {
                cUSTOMER.CREATEDON = (DateTime)reader["CREATEDON"];
            }
            else
            {
                cUSTOMER.CREATEDON = DateTime.Now;
            }


            if ( reader["UPDATEDBY"] != DBNull.Value)
            {
                cUSTOMER.UPDATEDBY = (int)reader["UPDATEDBY"];
            }
            else
            {
                cUSTOMER.UPDATEDBY = 0;
            }


            if ( reader["UPDATEDON"] != DBNull.Value)
            {

                cUSTOMER.UPDATEDON = (DateTime)reader["UPDATEDON"];
            }
            else
            {


                cUSTOMER.UPDATEDON = DateTime.Now;
            }


//            if (reader["CUSTOMERID"] != null || reader["CUSTOMERID"] != DBNull.Value)
//            {
//                cUSTOMER.CUSTOMERID = int.Parse(reader["CUSTOMERID"].ToString());
//            }
//            else
//            {
//                cUSTOMER.CUSTOMERID = 0;
//            }

//           if (reader["EMTID"] != null || reader["EMTID"] != DBNull.Value)
//            {
//                cUSTOMER.EMTID = reader["EMTID"].ToString();
//            }
//            else
//            {
//                cUSTOMER.EMTID = "";
//            }


//            if (reader["USERNAME"] != null || reader["USERNAME"] != DBNull.Value)
//            {
//                cUSTOMER.USERNAME = reader["USERNAME"].ToString();
//            }
//            else
//            {
//                cUSTOMER.USERNAME = "";
//            }
//            if (reader["CUSTFNAME"] != null || reader["CUSTFNAME"] != DBNull.Value)
//            {
//                cUSTOMER.CUSTFNAME = reader["CUSTFNAME"].ToString();
//            }
//            else
//            {
//                cUSTOMER.CUSTFNAME = "";
//            }
//            if (reader["CUSTMNAME"] != null || reader["CUSTMNAME"] != DBNull.Value)
//          {
//              cUSTOMER.CUSTMNAME = reader["CUSTMNAME"].ToString();
//          }
//          else
//          {
//              cUSTOMER.CUSTMNAME = "";
//          }
//       if (reader["CUSTLNAME"] != null || reader["CUSTLNAME"] != DBNull.Value)
//          {
//              cUSTOMER.CUSTLNAME = reader["CUSTLNAME"].ToString();
//          }
//          else
//          {
//              cUSTOMER.CUSTLNAME = "";
//          }
//          if (reader["CUSTADDRESS1"] != null || reader["CUSTADDRESS1"] != DBNull.Value)
//    {
//        cUSTOMER.CUSTADDRESS1 = reader["CUSTADDRESS1"].ToString();
//    }
//    else
//    {
//        cUSTOMER.CUSTADDRESS1 = "";
//    }
//        if (reader["CUSTADDRESS2"] != null || reader["CUSTADDRESS2"] != DBNull.Value)
//    {
//        cUSTOMER.CUSTADDRESS2 = reader["CUSTADDRESS2"].ToString();
//    }
//    else
//    {
//        cUSTOMER.CUSTADDRESS2 = "";
//    }
//    if (reader["CUSTCITY"] != null || reader["CUSTCITY"] != DBNull.Value)
//    {
//        cUSTOMER.CUSTCITY = reader["CUSTCITY"].ToString();
//    }
//    else
//    {
//        cUSTOMER.CUSTCITY = "";
//    }
//    if (reader["CUSTSTATE"] != null || reader["CUSTSTATE"] != DBNull.Value)
//    {
//        cUSTOMER.CUSTSTATE = reader["CUSTSTATE"].ToString();
//    }
//    else
//    {
//        cUSTOMER.CUSTSTATE = "";
//    }
//    if (reader["CUSTZIP"] != null || reader["CUSTZIP"] != DBNull.Value)
//    {
//        cUSTOMER.CUSTZIP = reader["CUSTZIP"].ToString();
//    }
//    else
//    {
//        cUSTOMER.CUSTZIP = "";
//    }
//    if (reader["CUSTHPHONE"] != null || reader["CUSTHPHONE"] != DBNull.Value)
//    {
//        cUSTOMER.CUSTHPHONE = reader["CUSTHPHONE"].ToString();
//    }
//    else
//    {
//        cUSTOMER.CUSTHPHONE = "";
//    }
//    if (reader["CUSTCPHONE"] != null || reader["CUSTCPHONE"] != DBNull.Value)
//    {
//        cUSTOMER.CUSTCPHONE = reader["CUSTCPHONE"].ToString();
//    }
//    else
//    {
//        cUSTOMER.CUSTCPHONE = "";
//    }
//    if (reader["CUSTWPHONE"] != null || reader["CUSTWPHONE"] != DBNull.Value)
//    {
//        cUSTOMER.CUSTWPHONE = reader["CUSTWPHONE"].ToString();
//    }
//    else
//    {
//        cUSTOMER.CUSTWPHONE = "";
//    }
//    if (reader["CUSTSSN"] != null || reader["CUSTSSN"] != DBNull.Value)
//    {
//        cUSTOMER.CUSTSSN = reader["CUSTSSN"].ToString();
//    }
//    else
//    {
//        cUSTOMER.CUSTSSN = "";
//    }
//    if (reader["CUSTIDTYPE"] != null || reader["CUSTIDTYPE"] != DBNull.Value)
//    {
//        cUSTOMER.CUSTIDTYPE = (int)reader["CUSTIDTYPE"];
//    }
//    else
//    {
//        cUSTOMER.CUSTIDTYPE = 0;
//    }
//    if (reader["CUSTIDNUMBER"] != null || reader["CUSTIDNUMBER"] != DBNull.Value)
//    {
//        cUSTOMER.CUSTIDNUMBER = reader["CUSTIDNUMBER"].ToString();
//    }
//    else
//    {
//        cUSTOMER.CUSTIDNUMBER = "";
//    }
//    if (reader["CUSTDOB"] != null || reader["CUSTDOB"] != DBNull.Value)
//    {
//        cUSTOMER.CUSTDOB = (DateTime)reader["CUSTDOB"];
//    }
//    else
//    {
//        cUSTOMER.CUSTDOB = DateTime.Now;
//    }

//    if (reader["CUSTISSUEDATE"] != null || reader["CUSTISSUEDATE"] != DBNull.Value)
//    {
//        cUSTOMER.CUSTISSUEDATE = (DateTime)reader["CUSTISSUEDATE"];
//    }
//    else
//    {
//        cUSTOMER.CUSTISSUEDATE = DateTime.Now;
//    }
//    if (reader["CUSTEXPIREDATE"] != null || reader["CUSTEXPIREDATE"] != DBNull.Value)
//    {
//        cUSTOMER.CUSTEXPIREDATE = (DateTime)reader["CUSTEXPIREDATE"];
//    }
//    else
//    {
//        cUSTOMER.CUSTEXPIREDATE = DateTime.Now;
//    }
//    if (reader["ISOFACVERIFIED"] != null || reader["ISOFACVERIFIED"] != DBNull.Value)
//{
//cUSTOMER.ISOFACVERIFIED = reader["ISOFACVERIFIED"].ToString();
//}
//else
//{
//cUSTOMER.ISOFACVERIFIED = "";
//}
//   if (reader["CUSTREMARKS"] != null || reader["CUSTREMARKS"] != DBNull.Value)
//{
//cUSTOMER.CUSTREMARKS = reader["CUSTREMARKS"].ToString();
//}
//else
//{
//cUSTOMER.CUSTREMARKS = "";
//}

//if (reader["CREATEDBY"] != null || reader["CREATEDBY"] != DBNull.Value)
//{
//cUSTOMER.CREATEDBY = (int)reader["CREATEDBY"];
//}
//else
//{
//cUSTOMER.CREATEDBY = 0;
//}

//if (reader["CREATEDON"] != null || reader["CREATEDON"] != DBNull.Value)
//{
//cUSTOMER.CREATEDON = (DateTime)reader["CREATEDON"];
//}
//else
//{
//cUSTOMER.CREATEDON = DateTime.Now;
//}


//if (reader["UPDATEDBY"] != null || reader["UPDATEDBY"] != DBNull.Value)
//{
//cUSTOMER.UPDATEDBY = (int)reader["UPDATEDBY"];
//}
//else
//{
//cUSTOMER.UPDATEDBY = 0;
//}


//if (reader["UPDATEDON"] != null || reader["UPDATEDON"] != DBNull.Value)
//{

//    cUSTOMER.UPDATEDON = (DateTime)reader["UPDATEDON"];
//}
//else
//{


//    cUSTOMER.UPDATEDON = DateTime.Now;
//}
            
return cUSTOMER;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public CUSTOMER GetCUSTOMERByID(int cUSTOMERID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetCUSTOMERByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CUSTOMERID", SqlDbType.Int).Value = cUSTOMERID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetCUSTOMERFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertCUSTOMER(CUSTOMER cUSTOMER)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertCUSTOMER", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CUSTOMERID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EMTID", SqlDbType.VarChar).Value = cUSTOMER.EMTID;
            cmd.Parameters.Add("@USERNAME", SqlDbType.VarChar).Value = cUSTOMER.USERNAME;
            cmd.Parameters.Add("@CUSTFNAME", SqlDbType.VarChar).Value = cUSTOMER.CUSTFNAME;
            cmd.Parameters.Add("@CUSTMNAME", SqlDbType.VarChar).Value = cUSTOMER.CUSTMNAME;
            cmd.Parameters.Add("@CUSTLNAME", SqlDbType.VarChar).Value = cUSTOMER.CUSTLNAME;
            cmd.Parameters.Add("@CUSTADDRESS1", SqlDbType.VarChar).Value = cUSTOMER.CUSTADDRESS1;
            cmd.Parameters.Add("@CUSTADDRESS2", SqlDbType.VarChar).Value = cUSTOMER.CUSTADDRESS2;
            cmd.Parameters.Add("@CUSTCITY", SqlDbType.VarChar).Value = cUSTOMER.CUSTCITY;
            cmd.Parameters.Add("@CUSTSTATE", SqlDbType.VarChar).Value = cUSTOMER.CUSTSTATE;
            cmd.Parameters.Add("@CUSTZIP", SqlDbType.VarChar).Value = cUSTOMER.CUSTZIP;
            cmd.Parameters.Add("@CUSTHPHONE", SqlDbType.VarChar).Value = cUSTOMER.CUSTHPHONE;
            cmd.Parameters.Add("@CUSTCPHONE", SqlDbType.VarChar).Value = cUSTOMER.CUSTCPHONE;
            cmd.Parameters.Add("@CUSTWPHONE", SqlDbType.VarChar).Value = cUSTOMER.CUSTWPHONE;
            cmd.Parameters.Add("@CUSTSSN", SqlDbType.VarChar).Value = cUSTOMER.CUSTSSN;
            cmd.Parameters.Add("@CUSTDRIVINGLICENSE", SqlDbType.VarChar).Value = cUSTOMER.CUSTDRIVINGLICENSE;
            cmd.Parameters.Add("@CUSTIDTYPE", SqlDbType.Int).Value = cUSTOMER.CUSTIDTYPE;
            cmd.Parameters.Add("@CUSTIDNUMBER", SqlDbType.VarChar).Value = cUSTOMER.CUSTIDNUMBER;
            cmd.Parameters.Add("@CUSTDOB", SqlDbType.DateTime).Value = cUSTOMER.CUSTDOB;
            cmd.Parameters.Add("@CUSTISSUEDATE", SqlDbType.DateTime).Value = cUSTOMER.CUSTISSUEDATE;
            cmd.Parameters.Add("@CUSTEXPIREDATE", SqlDbType.DateTime).Value = cUSTOMER.CUSTEXPIREDATE;
            cmd.Parameters.Add("@ISOFACVERIFIED", SqlDbType.VarChar).Value = cUSTOMER.ISOFACVERIFIED;
            cmd.Parameters.Add("@CUSTREMARKS", SqlDbType.VarChar).Value = cUSTOMER.CUSTREMARKS;
            cmd.Parameters.Add("@SCANURL", SqlDbType.VarChar).Value = cUSTOMER.SCANURL;
            cmd.Parameters.Add("@CREATEDBY", SqlDbType.Int).Value = cUSTOMER.CREATEDBY;
            cmd.Parameters.Add("@CREATEDON", SqlDbType.DateTime).Value = cUSTOMER.CREATEDON;
            cmd.Parameters.Add("@UPDATEDBY", SqlDbType.Int).Value = cUSTOMER.UPDATEDBY;
            cmd.Parameters.Add("@UPDATEDON", SqlDbType.DateTime).Value = cUSTOMER.UPDATEDON;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@CUSTOMERID"].Value;
        }
    }

    public bool UpdateCUSTOMER(CUSTOMER cUSTOMER)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateCUSTOMER", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CUSTOMERID", SqlDbType.Int).Value = cUSTOMER.CUSTOMERID;
            cmd.Parameters.Add("@EMTID", SqlDbType.VarChar).Value = cUSTOMER.EMTID;
            cmd.Parameters.Add("@USERNAME", SqlDbType.VarChar).Value = cUSTOMER.USERNAME;
            cmd.Parameters.Add("@CUSTFNAME", SqlDbType.VarChar).Value = cUSTOMER.CUSTFNAME;
            cmd.Parameters.Add("@CUSTMNAME", SqlDbType.VarChar).Value = cUSTOMER.CUSTMNAME;
            cmd.Parameters.Add("@CUSTLNAME", SqlDbType.VarChar).Value = cUSTOMER.CUSTLNAME;
            cmd.Parameters.Add("@CUSTADDRESS1", SqlDbType.VarChar).Value = cUSTOMER.CUSTADDRESS1;
            cmd.Parameters.Add("@CUSTADDRESS2", SqlDbType.VarChar).Value = cUSTOMER.CUSTADDRESS2;
            cmd.Parameters.Add("@CUSTCITY", SqlDbType.VarChar).Value = cUSTOMER.CUSTCITY;
            cmd.Parameters.Add("@CUSTSTATE", SqlDbType.VarChar).Value = cUSTOMER.CUSTSTATE;
            cmd.Parameters.Add("@CUSTZIP", SqlDbType.VarChar).Value = cUSTOMER.CUSTZIP;
            cmd.Parameters.Add("@CUSTHPHONE", SqlDbType.VarChar).Value = cUSTOMER.CUSTHPHONE;
            cmd.Parameters.Add("@CUSTCPHONE", SqlDbType.VarChar).Value = cUSTOMER.CUSTCPHONE;
            cmd.Parameters.Add("@CUSTWPHONE", SqlDbType.VarChar).Value = cUSTOMER.CUSTWPHONE;
            cmd.Parameters.Add("@CUSTSSN", SqlDbType.VarChar).Value = cUSTOMER.CUSTSSN;
            cmd.Parameters.Add("@CUSTDRIVINGLICENSE", SqlDbType.VarChar).Value = cUSTOMER.CUSTDRIVINGLICENSE;
            cmd.Parameters.Add("@CUSTIDTYPE", SqlDbType.Int).Value = cUSTOMER.CUSTIDTYPE;
            cmd.Parameters.Add("@CUSTIDNUMBER", SqlDbType.VarChar).Value = cUSTOMER.CUSTIDNUMBER;
            cmd.Parameters.Add("@CUSTDOB", SqlDbType.DateTime).Value = cUSTOMER.CUSTDOB;
            cmd.Parameters.Add("@CUSTISSUEDATE", SqlDbType.DateTime).Value = cUSTOMER.CUSTISSUEDATE;
            cmd.Parameters.Add("@CUSTEXPIREDATE", SqlDbType.DateTime).Value = cUSTOMER.CUSTEXPIREDATE;
            cmd.Parameters.Add("@ISOFACVERIFIED", SqlDbType.VarChar).Value = cUSTOMER.ISOFACVERIFIED;
            cmd.Parameters.Add("@CUSTREMARKS", SqlDbType.VarChar).Value = cUSTOMER.CUSTREMARKS;
            cmd.Parameters.Add("@SCANURL", SqlDbType.VarChar).Value = cUSTOMER.SCANURL;
            cmd.Parameters.Add("@CREATEDBY", SqlDbType.Int).Value = cUSTOMER.CREATEDBY;
            cmd.Parameters.Add("@CREATEDON", SqlDbType.DateTime).Value = cUSTOMER.CREATEDON;
            cmd.Parameters.Add("@UPDATEDBY", SqlDbType.Int).Value = cUSTOMER.UPDATEDBY;
            cmd.Parameters.Add("@UPDATEDON", SqlDbType.DateTime).Value = cUSTOMER.UPDATEDON;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }


    public bool UpdateSUS_CUSTOMER(string ids,string date)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateSUS_CUSTOMER", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Date", SqlDbType.VarChar).Value = date;
            cmd.Parameters.Add("@IDs", SqlDbType.VarChar).Value = ids;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
