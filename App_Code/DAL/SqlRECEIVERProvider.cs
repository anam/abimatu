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

public class SqlRECEIVERProvider:DataAccessObject
{
	public SqlRECEIVERProvider()
    {
    }


    public bool DeleteRECEIVER(int rECEIVERID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteRECEIVER", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RECEIVERID", SqlDbType.Int).Value = rECEIVERID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
    
    public List<RECEIVER> GetAllRECEIVERs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllRECEIVERs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetRECEIVERsFromReader(reader);
        }
    }

    public List<RECEIVER> GetAllRECEIVERsForSearchByID(int rECEIVERID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllRECEIVERForSearchByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RECEIVERID", SqlDbType.Int).Value = rECEIVERID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetRECEIVERsFromReader(reader);
        }
    }

    public List<RECEIVER> GetAllRECEIVERByAgentID(int agentID,int customerID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllRECEIVERByAGENTID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AGENTID", SqlDbType.Int).Value = agentID;
            command.Parameters.Add("@CUSTOMERID", SqlDbType.Int).Value = customerID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetRECEIVERsFromReader(reader);
        }
    }

    public List<RECEIVER> GetAllRECEIVERsForSearchByIDNew(int rECEIVERID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllReceiver_LocationByCustID_New", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RECEIVERID", SqlDbType.Int).Value = rECEIVERID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetRECEIVERsFromReader(reader);
        }
    }
    public List<RECEIVER> GetAllRECEIVERsForSearch(int cUSTID , int rECEIVERID, string rECEIVERFNAME, string rECEIVERADDRESS1, string rECEIVERCITY, string rECEIVERSTATE, string rECEIVERZIP, string rECEIVERPHONE)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllReceiver_LocationByCustIDForSearch", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CUSTID", SqlDbType.Int).Value = cUSTID;
            command.Parameters.Add("@RECEIVERID", SqlDbType.Int).Value = rECEIVERID;
            command.Parameters.Add("@RECEIVERFNAME", SqlDbType.VarChar).Value = rECEIVERFNAME;
            command.Parameters.Add("@RECEIVERADDRESS1", SqlDbType.VarChar).Value = rECEIVERADDRESS1;
            command.Parameters.Add("@RECEIVERCITY", SqlDbType.VarChar).Value = rECEIVERCITY;
            command.Parameters.Add("@RECEIVERSTATE", SqlDbType.VarChar).Value = rECEIVERSTATE;
            command.Parameters.Add("@RECEIVERZIP", SqlDbType.VarChar).Value = rECEIVERZIP;
            command.Parameters.Add("@RECEIVERPHONE", SqlDbType.VarChar).Value = rECEIVERPHONE;

            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetRECEIVERsFromReaderForSearch(reader);
        }
    }

    public List<RECEIVER> GetAllRECEIVERsFoodForSearch(int cUSTID, int rECEIVERID, string rECEIVERFNAME, string rECEIVERADDRESS1, string rECEIVERCITY, string rECEIVERSTATE, string rECEIVERZIP, string rECEIVERPHONE)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllReceiverFood_LocationByCustIDForSearch", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CUSTID", SqlDbType.Int).Value = cUSTID;
            command.Parameters.Add("@RECEIVERID", SqlDbType.Int).Value = rECEIVERID;
            command.Parameters.Add("@RECEIVERFNAME", SqlDbType.VarChar).Value = rECEIVERFNAME;
            command.Parameters.Add("@RECEIVERADDRESS1", SqlDbType.VarChar).Value = rECEIVERADDRESS1;
            command.Parameters.Add("@RECEIVERCITY", SqlDbType.VarChar).Value = rECEIVERCITY;
            command.Parameters.Add("@RECEIVERSTATE", SqlDbType.VarChar).Value = rECEIVERSTATE;
            command.Parameters.Add("@RECEIVERZIP", SqlDbType.VarChar).Value = rECEIVERZIP;
            command.Parameters.Add("@RECEIVERPHONE", SqlDbType.VarChar).Value = rECEIVERPHONE;

            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetRECEIVERsFromReaderForSearch(reader);
        }
    }
    public List<RECEIVER> GetRECEIVERsFromReader(IDataReader reader)
    {
        List<RECEIVER> rECEIVERs = new List<RECEIVER>();

        while (reader.Read())
        {
            rECEIVERs.Add(GetRECEIVERFromReader(reader));
        }
        return rECEIVERs;
    }

    public RECEIVER GetRECEIVERFromReader(IDataReader reader)
    {
        try
        {
            RECEIVER rECEIVER = new RECEIVER();

            if (reader["RECEIVERID"] != DBNull.Value)
            {
                rECEIVER.RECEIVERID = int.Parse(reader["RECEIVERID"].ToString());
            }
            else
            {
                rECEIVER.RECEIVERID = 0;
            }

            if (reader["USERNAME"] != DBNull.Value)
            {
                rECEIVER.USERNAME = reader["USERNAME"].ToString();
            }
            else
            {
                rECEIVER.USERNAME = "";
            }

            if (reader["RECEIVERFNAME"] != DBNull.Value)
            {
                rECEIVER.RECEIVERFNAME = reader["RECEIVERFNAME"].ToString();
            }
            else
            {
                rECEIVER.RECEIVERFNAME = "";
            }

            if (reader["RECEIVERMNAME"] != DBNull.Value)
            {
                rECEIVER.RECEIVERMNAME = reader["RECEIVERMNAME"].ToString();
            }
            else
            {
                rECEIVER.RECEIVERMNAME = "";
            }

            if (reader["RECEIVERLNAME"] != DBNull.Value)
            {
                rECEIVER.RECEIVERLNAME = reader["RECEIVERLNAME"].ToString();
            }
            else
            {
                rECEIVER.RECEIVERLNAME = "";
            }

            if (reader["RECEIVERADDRESS1"] != DBNull.Value)
            {
                rECEIVER.RECEIVERADDRESS1 = reader["RECEIVERADDRESS1"].ToString();
            }
            else
            {
                rECEIVER.RECEIVERADDRESS1 = "";
            }

            if (reader["RECEIVERADDRESS2"] != DBNull.Value)
            {
                rECEIVER.RECEIVERADDRESS2 = reader["RECEIVERADDRESS2"].ToString();
            }
            else
            {
                rECEIVER.RECEIVERADDRESS2 = "";
            }

            if (reader["RECEIVERCITY"] != DBNull.Value)
            {
                rECEIVER.RECEIVERCITY = reader["RECEIVERCITY"].ToString();
            }
            else
            {
                rECEIVER.RECEIVERCITY = "";
            }

            if (reader["RECEIVERSTATE"] != DBNull.Value)
            {
                rECEIVER.RECEIVERSTATE = reader["RECEIVERSTATE"].ToString();
            }
            else
            {
                rECEIVER.RECEIVERSTATE = "";
            }

            if (reader["RECEIVERZIP"] != DBNull.Value)
            {
                rECEIVER.RECEIVERZIP = reader["RECEIVERZIP"].ToString();
            }
            else
            {
                rECEIVER.RECEIVERZIP = "";
            }

            if (reader["RECEIVERPHONE"] != DBNull.Value)
            {
                rECEIVER.RECEIVERPHONE = reader["RECEIVERPHONE"].ToString();
            }
            else
            {
                rECEIVER.RECEIVERPHONE = "";
            }


            if (reader["SCANURL"] != DBNull.Value)
            {
                rECEIVER.SCANURL = reader["SCANURL"].ToString();
            }
            else
            {
                rECEIVER.SCANURL = "";
            }

            if (reader["CREATEDBY"] != DBNull.Value)
            {
                rECEIVER.CREATEDBY = int.Parse(reader["CREATEDBY"].ToString());
            }
            else
            {
                rECEIVER.CREATEDBY = 0;
            }

            if (reader["CREATEDON"] != DBNull.Value)
            {
                rECEIVER.CREATEDON = DateTime.Parse(reader["CREATEDON"].ToString());
            }
            else
            {
                rECEIVER.CREATEDON = DateTime.Now;
            }

            if (reader["UPDATEDBY"] != DBNull.Value)
            {
                rECEIVER.UPDATEDBY = int.Parse(reader["UPDATEDBY"].ToString());
            }
            else
            {
                rECEIVER.UPDATEDBY = 0;
            }

            if (reader["UPDATEDON"] != DBNull.Value)
            {
                rECEIVER.UPDATEDON = DateTime.Parse(reader["UPDATEDON"].ToString());
            }
            else
            {
                rECEIVER.UPDATEDON = DateTime.Now;
            }




            return rECEIVER;
        }
        catch (Exception ex)
        {
            return null;
        }
    }




    public List<RECEIVER> GetRECEIVERsFromReaderForSearch(IDataReader reader)
    {
        List<RECEIVER> rECEIVERs = new List<RECEIVER>();

        while (reader.Read())
        {
            rECEIVERs.Add(GetRECEIVERFromReaderForSearch(reader));
        }
        return rECEIVERs;
    }

    public RECEIVER GetRECEIVERFromReaderForSearch(IDataReader reader)
    {
        try
        {
            RECEIVER rECEIVER = new RECEIVER();

            if (reader["CUSTID"] != DBNull.Value)
            {
                rECEIVER.CUSTID = int.Parse(reader["CUSTID"].ToString());
            }
            else
            {
                rECEIVER.CUSTID = 0;
            }

            if (reader["LOCATIONID"] != DBNull.Value)
            {
                rECEIVER.LOCATIONID = int.Parse(reader["LOCATIONID"].ToString());
            }
            else
            {
                rECEIVER.LOCATIONID = 0;
            }

            if (reader["AGENTID"] != DBNull.Value)
            {
                rECEIVER.AgentID = int.Parse(reader["AGENTID"].ToString());
            }
            else
            {
                rECEIVER.AgentID = 0;
            }

            if (reader["BRANCH"] != DBNull.Value)
            {
                rECEIVER.BRANCH = reader["BRANCH"].ToString();
            }
            else
            {
                rECEIVER.BRANCH = "";
            }


            if (reader["RECEIVERID"] != DBNull.Value)
            {
                rECEIVER.RECEIVERID = int.Parse(reader["RECEIVERID"].ToString());
            }
            else
            {
                rECEIVER.RECEIVERID = 0;
            }

            if (reader["USERNAME"] != DBNull.Value)
            {
                rECEIVER.USERNAME = reader["USERNAME"].ToString();
            }
            else
            {
                rECEIVER.USERNAME = "";
            }

            if (reader["RECEIVERFNAME"] != DBNull.Value)
            {
                rECEIVER.RECEIVERFNAME = reader["RECEIVERFNAME"].ToString();
            }
            else
            {
                rECEIVER.RECEIVERFNAME = "";
            }

            if (reader["RECEIVERMNAME"] != DBNull.Value)
            {
                rECEIVER.RECEIVERMNAME = reader["RECEIVERMNAME"].ToString();
            }
            else
            {
                rECEIVER.RECEIVERMNAME = "";
            }

            if (reader["RECEIVERLNAME"] != DBNull.Value)
            {
                rECEIVER.RECEIVERLNAME = reader["RECEIVERLNAME"].ToString();
            }
            else
            {
                rECEIVER.RECEIVERLNAME = "";
            }

            if (reader["RECEIVERADDRESS1"] != DBNull.Value)
            {
                rECEIVER.RECEIVERADDRESS1 = reader["RECEIVERADDRESS1"].ToString();
            }
            else
            {
                rECEIVER.RECEIVERADDRESS1 = "";
            }

            if (reader["RECEIVERADDRESS2"] != DBNull.Value)
            {
                rECEIVER.RECEIVERADDRESS2 = reader["RECEIVERADDRESS2"].ToString();
            }
            else
            {
                rECEIVER.RECEIVERADDRESS2 = "";
            }

            if (reader["RECEIVERCITY"] != DBNull.Value)
            {
                rECEIVER.RECEIVERCITY = reader["RECEIVERCITY"].ToString();
            }
            else
            {
                rECEIVER.RECEIVERCITY = "";
            }

            if (reader["RECEIVERSTATE"] != DBNull.Value)
            {
                rECEIVER.RECEIVERSTATE = reader["RECEIVERSTATE"].ToString();
            }
            else
            {
                rECEIVER.RECEIVERSTATE = "";
            }

            if (reader["RECEIVERZIP"] != DBNull.Value)
            {
                rECEIVER.RECEIVERZIP = reader["RECEIVERZIP"].ToString();
            }
            else
            {
                rECEIVER.RECEIVERZIP = "";
            }

            if (reader["RECEIVERPHONE"] != DBNull.Value)
            {
                rECEIVER.RECEIVERPHONE = reader["RECEIVERPHONE"].ToString();
            }
            else
            {
                rECEIVER.RECEIVERPHONE = "";
            }


            if (reader["SCANURL"] != DBNull.Value)
            {
                rECEIVER.SCANURL = reader["SCANURL"].ToString();
            }
            else
            {
                rECEIVER.SCANURL = "";
            }

            if (reader["CREATEDBY"] != DBNull.Value)
            {
                rECEIVER.CREATEDBY = int.Parse(reader["CREATEDBY"].ToString());
            }
            else
            {
                rECEIVER.CREATEDBY = 0;
            }

            if (reader["CREATEDON"] != DBNull.Value)
            {
                rECEIVER.CREATEDON = DateTime.Parse(reader["CREATEDON"].ToString());
            }
            else
            {
                rECEIVER.CREATEDON = DateTime.Now;
            }

            if (reader["UPDATEDBY"] != DBNull.Value)
            {
                rECEIVER.UPDATEDBY = int.Parse(reader["UPDATEDBY"].ToString());
            }
            else
            {
                rECEIVER.UPDATEDBY = 0;
            }

            if (reader["UPDATEDON"] != DBNull.Value)
            {
                rECEIVER.UPDATEDON = DateTime.Parse(reader["UPDATEDON"].ToString());
            }
            else
            {
                rECEIVER.UPDATEDON = DateTime.Now;
            }




            return rECEIVER;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public RECEIVER GetRECEIVERByID(int rECEIVERID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetRECEIVERByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RECEIVERID", SqlDbType.Int).Value = rECEIVERID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetRECEIVERFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertRECEIVER(RECEIVER rECEIVER)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertRECEIVER", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RECEIVERID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@USERNAME", SqlDbType.VarChar).Value = rECEIVER.USERNAME;
            cmd.Parameters.Add("@RECEIVERFNAME", SqlDbType.VarChar).Value = rECEIVER.RECEIVERFNAME;
            cmd.Parameters.Add("@RECEIVERMNAME", SqlDbType.VarChar).Value = rECEIVER.RECEIVERMNAME;
            cmd.Parameters.Add("@RECEIVERLNAME", SqlDbType.VarChar).Value = rECEIVER.RECEIVERLNAME;
            cmd.Parameters.Add("@RECEIVERADDRESS1", SqlDbType.VarChar).Value = rECEIVER.RECEIVERADDRESS1;
            cmd.Parameters.Add("@RECEIVERADDRESS2", SqlDbType.VarChar).Value = rECEIVER.RECEIVERADDRESS2;
            cmd.Parameters.Add("@RECEIVERCITY", SqlDbType.VarChar).Value = rECEIVER.RECEIVERCITY;
            cmd.Parameters.Add("@RECEIVERSTATE", SqlDbType.VarChar).Value = rECEIVER.RECEIVERSTATE;
            cmd.Parameters.Add("@RECEIVERZIP", SqlDbType.VarChar).Value = rECEIVER.RECEIVERZIP;
            cmd.Parameters.Add("@RECEIVERPHONE", SqlDbType.VarChar).Value = rECEIVER.RECEIVERPHONE;
            cmd.Parameters.Add("@SCANURL", SqlDbType.VarChar).Value = rECEIVER.SCANURL;
            cmd.Parameters.Add("@CREATEDBY", SqlDbType.Int).Value = rECEIVER.CREATEDBY;
            cmd.Parameters.Add("@CREATEDON", SqlDbType.DateTime).Value = rECEIVER.CREATEDON;
            cmd.Parameters.Add("@UPDATEDBY", SqlDbType.Int).Value = rECEIVER.UPDATEDBY;
            cmd.Parameters.Add("@UPDATEDON", SqlDbType.DateTime).Value = rECEIVER.UPDATEDON;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@RECEIVERID"].Value;
        }
    }

    public bool UpdateRECEIVER(RECEIVER rECEIVER)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateRECEIVER", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RECEIVERID", SqlDbType.Int).Value = rECEIVER.RECEIVERID;
            cmd.Parameters.Add("@USERNAME", SqlDbType.VarChar).Value = rECEIVER.USERNAME;
            cmd.Parameters.Add("@RECEIVERFNAME", SqlDbType.VarChar).Value = rECEIVER.RECEIVERFNAME;
            cmd.Parameters.Add("@RECEIVERMNAME", SqlDbType.VarChar).Value = rECEIVER.RECEIVERMNAME;
            cmd.Parameters.Add("@RECEIVERLNAME", SqlDbType.VarChar).Value = rECEIVER.RECEIVERLNAME;
            cmd.Parameters.Add("@RECEIVERADDRESS1", SqlDbType.VarChar).Value = rECEIVER.RECEIVERADDRESS1;
            cmd.Parameters.Add("@RECEIVERADDRESS2", SqlDbType.VarChar).Value = rECEIVER.RECEIVERADDRESS2;
            cmd.Parameters.Add("@RECEIVERCITY", SqlDbType.VarChar).Value = rECEIVER.RECEIVERCITY;
            cmd.Parameters.Add("@RECEIVERSTATE", SqlDbType.VarChar).Value = rECEIVER.RECEIVERSTATE;
            cmd.Parameters.Add("@RECEIVERZIP", SqlDbType.VarChar).Value = rECEIVER.RECEIVERZIP;
            cmd.Parameters.Add("@RECEIVERPHONE", SqlDbType.VarChar).Value = rECEIVER.RECEIVERPHONE;
            cmd.Parameters.Add("@SCANURL", SqlDbType.VarChar).Value = rECEIVER.SCANURL;
            cmd.Parameters.Add("@CREATEDBY", SqlDbType.Int).Value = rECEIVER.CREATEDBY;
            cmd.Parameters.Add("@CREATEDON", SqlDbType.DateTime).Value = rECEIVER.CREATEDON;
            cmd.Parameters.Add("@UPDATEDBY", SqlDbType.Int).Value = rECEIVER.UPDATEDBY;
            cmd.Parameters.Add("@UPDATEDON", SqlDbType.DateTime).Value = rECEIVER.UPDATEDON;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
