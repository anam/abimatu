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

public class SqlUSERINFOProvider:DataAccessObject
{
	public SqlUSERINFOProvider()
    {
    }


    public bool DeleteUSERINFO(int uSERINFOID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteUSERINFO", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@USERINFOID", SqlDbType.Int).Value = uSERINFOID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<USERINFO> GetAllUSERINFOs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllUSERINFOs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetUSERINFOsFromReader(reader);
        }
    }

    public List<USERINFO> GetAllUSERINFOsByType(string type)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllUSERINFOsByType", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Type", SqlDbType.NVarChar).Value = type;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetUSERINFOsFromReader(reader);
        }
    }
    public List<USERINFO> GetUSERINFOsFromReader(IDataReader reader)
    {
        List<USERINFO> uSERINFOs = new List<USERINFO>();

        while (reader.Read())
        {
            uSERINFOs.Add(GetUSERINFOFromReader(reader));
        }
        return uSERINFOs;
    }

    public USERINFO GetUSERINFOFromReader(IDataReader reader)
    {
        try
        {
            USERINFO uSERINFO = new USERINFO
                (
                    (int)reader["USERINFOID"],
                    (DateTime)reader["AddedDate"],
                    reader["AddedBy"].ToString(),
                    (DateTime)reader["ModifyDate"],
                    reader["ModifyBy"].ToString(),
                    reader["Type"].ToString(),
                    reader["UserName"].ToString(),
                    (int)reader["Agent_LocationID"],
                    reader["FirstName"].ToString(),
                    reader["LastName"].ToString(),
                    reader["MiddleName"].ToString(),
                    reader["Address"].ToString(),
                    reader["City"].ToString(),
                    reader["State"].ToString(),
                    reader["Country"].ToString(),
                    reader["PostalCode"].ToString(),
                    (DateTime)reader["ExpDate"],
                    (int)reader["Status"],
                    reader["HomePhone"].ToString(),
                    reader["WorkPhone"].ToString(),
                    reader["Mobile"].ToString(),
                    reader["Comm"].ToString()
                );
             return uSERINFO;
        }
        catch(Exception ex)
        {
            return null;
        }
    }
   
    public USERINFO GetUSERINFOByID(int uSERINFOID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetUSERINFOByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@USERINFOID", SqlDbType.Int).Value = uSERINFOID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetUSERINFOFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }


    public USERINFO GetUSERINFOByUserNameType(string type , string userName)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetUSERINFOByUserNameType", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Type", SqlDbType.NVarChar).Value = type;
            command.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = userName;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetUSERINFOFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertUSERINFO(USERINFO uSERINFO)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertUSERINFO", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@USERINFOID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = uSERINFO.AddedDate;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = uSERINFO.AddedBy;
            cmd.Parameters.Add("@ModifyDate", SqlDbType.DateTime).Value = uSERINFO.ModifyDate;
            cmd.Parameters.Add("@ModifyBy", SqlDbType.NVarChar).Value = uSERINFO.ModifyBy;
            cmd.Parameters.Add("@Type", SqlDbType.NVarChar).Value = uSERINFO.Type;
            cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = uSERINFO.UserName;
            cmd.Parameters.Add("@Agent_LocationID", SqlDbType.Int).Value = uSERINFO.Agent_LocationID;
            cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = uSERINFO.FirstName;
            cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = uSERINFO.LastName;
            cmd.Parameters.Add("@MiddleName", SqlDbType.NVarChar).Value = uSERINFO.MiddleName;
            cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = uSERINFO.Address;
            cmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = uSERINFO.City;
            cmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = uSERINFO.State;
            cmd.Parameters.Add("@Country", SqlDbType.NVarChar).Value = uSERINFO.Country;
            cmd.Parameters.Add("@PostalCode", SqlDbType.NVarChar).Value = uSERINFO.PostalCode;
            cmd.Parameters.Add("@ExpDate", SqlDbType.DateTime).Value = uSERINFO.ExpDate;
            cmd.Parameters.Add("@Status", SqlDbType.Int).Value = uSERINFO.Status;
            cmd.Parameters.Add("@HomePhone", SqlDbType.NVarChar).Value = uSERINFO.HomePhone;
            cmd.Parameters.Add("@WorkPhone", SqlDbType.NVarChar).Value = uSERINFO.WorkPhone;
            cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = uSERINFO.Mobile;
            cmd.Parameters.Add("@Comm", SqlDbType.NVarChar).Value = uSERINFO.Comm;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@USERINFOID"].Value;
        }
    }

    public bool UpdateUSERINFO(USERINFO uSERINFO)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateUSERINFO", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@USERINFOID", SqlDbType.Int).Value = uSERINFO.USERINFOID;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = uSERINFO.AddedDate;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = uSERINFO.AddedBy;
            cmd.Parameters.Add("@ModifyDate", SqlDbType.DateTime).Value = uSERINFO.ModifyDate;
            cmd.Parameters.Add("@ModifyBy", SqlDbType.NVarChar).Value = uSERINFO.ModifyBy;
            cmd.Parameters.Add("@Type", SqlDbType.NVarChar).Value = uSERINFO.Type;
            cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = uSERINFO.UserName;
            cmd.Parameters.Add("@Agent_LocationID", SqlDbType.Int).Value = uSERINFO.Agent_LocationID;
            cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = uSERINFO.FirstName;
            cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = uSERINFO.LastName;
            cmd.Parameters.Add("@MiddleName", SqlDbType.NVarChar).Value = uSERINFO.MiddleName;
            cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = uSERINFO.Address;
            cmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = uSERINFO.City;
            cmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = uSERINFO.State;
            cmd.Parameters.Add("@Country", SqlDbType.NVarChar).Value = uSERINFO.Country;
            cmd.Parameters.Add("@PostalCode", SqlDbType.NVarChar).Value = uSERINFO.PostalCode;
            cmd.Parameters.Add("@ExpDate", SqlDbType.DateTime).Value = uSERINFO.ExpDate;
            cmd.Parameters.Add("@Status", SqlDbType.Int).Value = uSERINFO.Status;
            cmd.Parameters.Add("@HomePhone", SqlDbType.NVarChar).Value = uSERINFO.HomePhone;
            cmd.Parameters.Add("@WorkPhone", SqlDbType.NVarChar).Value = uSERINFO.WorkPhone;
            cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = uSERINFO.Mobile;
            cmd.Parameters.Add("@Comm", SqlDbType.NVarChar).Value = uSERINFO.Comm;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
