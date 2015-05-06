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

public class SqlPRODUCTMASTERProvider:DataAccessObject
{
	public SqlPRODUCTMASTERProvider()
    {
    }


    public bool DeletePRODUCTMASTER(int pRODUCTMASTERID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeletePRODUCTMASTER", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PRODUCTMASTERID", SqlDbType.Int).Value = pRODUCTMASTERID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<PRODUCTMASTER> GetAllPRODUCTMASTERs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllPRODUCTMASTERs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetPRODUCTMASTERsFromReader(reader);
        }
    }
    public List<PRODUCTMASTER> GetPRODUCTMASTERsFromReader(IDataReader reader)
    {
        List<PRODUCTMASTER> pRODUCTMASTERs = new List<PRODUCTMASTER>();

        while (reader.Read())
        {
            pRODUCTMASTERs.Add(GetPRODUCTMASTERFromReader(reader));
        }
        return pRODUCTMASTERs;
    }

    public PRODUCTMASTER GetPRODUCTMASTERFromReader(IDataReader reader)
    {
        try
        {
            PRODUCTMASTER pRODUCTMASTER = new PRODUCTMASTER
                (
                    (int)reader["PRODUCTMASTERID"],
                    reader["PROD_NAME"].ToString(),
                    reader["PROD_DESC"].ToString(),
                    (int)reader["SUPPLIERID"],
                    reader["PROD_UPCCODE"].ToString(),
                    (int)reader["PROD_RETAILPRICE"],
                    (int)reader["PROD_STOCKINHAND"],
                    (int)reader["PROD_REORDERLEVEL"],
                    (DateTime)reader["CREATED_ON"],
                    reader["CREATED_BY"].ToString(),
                    (DateTime)reader["UPDATED_ON"],
                    reader["UPDATED_BY"].ToString(),
                    (char)reader["IS_TAXABLE"],
                    (int)reader["PROD_COSTPRICE"],
                    (int)reader["DEPT_ID"],
                    (int)reader["AGENTID"]
                );
             return pRODUCTMASTER;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public PRODUCTMASTER GetPRODUCTMASTERByID(int pRODUCTMASTERID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetPRODUCTMASTERByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PRODUCTMASTERID", SqlDbType.Int).Value = pRODUCTMASTERID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetPRODUCTMASTERFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertPRODUCTMASTER(PRODUCTMASTER pRODUCTMASTER)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertPRODUCTMASTER", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PRODUCTMASTERID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PROD_NAME", SqlDbType.VarChar).Value = pRODUCTMASTER.PROD_NAME;
            cmd.Parameters.Add("@PROD_DESC", SqlDbType.VarChar).Value = pRODUCTMASTER.PROD_DESC;
            cmd.Parameters.Add("@SUPPLIERID", SqlDbType.Int).Value = pRODUCTMASTER.SUPPLIERID;
            cmd.Parameters.Add("@PROD_UPCCODE", SqlDbType.VarChar).Value = pRODUCTMASTER.PROD_UPCCODE;
            cmd.Parameters.Add("@PROD_RETAILPRICE", SqlDbType.Int).Value = pRODUCTMASTER.PROD_RETAILPRICE;
            cmd.Parameters.Add("@PROD_STOCKINHAND", SqlDbType.Int).Value = pRODUCTMASTER.PROD_STOCKINHAND;
            cmd.Parameters.Add("@PROD_REORDERLEVEL", SqlDbType.Int).Value = pRODUCTMASTER.PROD_REORDERLEVEL;
            cmd.Parameters.Add("@CREATED_ON", SqlDbType.DateTime).Value = pRODUCTMASTER.CREATED_ON;
            cmd.Parameters.Add("@CREATED_BY", SqlDbType.VarChar).Value = pRODUCTMASTER.CREATED_BY;
            cmd.Parameters.Add("@UPDATED_ON", SqlDbType.DateTime).Value = pRODUCTMASTER.UPDATED_ON;
            cmd.Parameters.Add("@UPDATED_BY", SqlDbType.VarChar).Value = pRODUCTMASTER.UPDATED_BY;
            cmd.Parameters.Add("@IS_TAXABLE", SqlDbType.Char).Value = pRODUCTMASTER.IS_TAXABLE;
            cmd.Parameters.Add("@PROD_COSTPRICE", SqlDbType.Int).Value = pRODUCTMASTER.PROD_COSTPRICE;
            cmd.Parameters.Add("@DEPT_ID", SqlDbType.Int).Value = pRODUCTMASTER.DEPT_ID;
            cmd.Parameters.Add("@AGENTID", SqlDbType.Int).Value = pRODUCTMASTER.AGENTID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@PRODUCTMASTERID"].Value;
        }
    }

    public bool UpdatePRODUCTMASTER(PRODUCTMASTER pRODUCTMASTER)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdatePRODUCTMASTER", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PRODUCTMASTERID", SqlDbType.Int).Value = pRODUCTMASTER.PRODUCTMASTERID;
            cmd.Parameters.Add("@PROD_NAME", SqlDbType.VarChar).Value = pRODUCTMASTER.PROD_NAME;
            cmd.Parameters.Add("@PROD_DESC", SqlDbType.VarChar).Value = pRODUCTMASTER.PROD_DESC;
            cmd.Parameters.Add("@SUPPLIERID", SqlDbType.Int).Value = pRODUCTMASTER.SUPPLIERID;
            cmd.Parameters.Add("@PROD_UPCCODE", SqlDbType.VarChar).Value = pRODUCTMASTER.PROD_UPCCODE;
            cmd.Parameters.Add("@PROD_RETAILPRICE", SqlDbType.Int).Value = pRODUCTMASTER.PROD_RETAILPRICE;
            cmd.Parameters.Add("@PROD_STOCKINHAND", SqlDbType.Int).Value = pRODUCTMASTER.PROD_STOCKINHAND;
            cmd.Parameters.Add("@PROD_REORDERLEVEL", SqlDbType.Int).Value = pRODUCTMASTER.PROD_REORDERLEVEL;
            cmd.Parameters.Add("@CREATED_ON", SqlDbType.DateTime).Value = pRODUCTMASTER.CREATED_ON;
            cmd.Parameters.Add("@CREATED_BY", SqlDbType.VarChar).Value = pRODUCTMASTER.CREATED_BY;
            cmd.Parameters.Add("@UPDATED_ON", SqlDbType.DateTime).Value = pRODUCTMASTER.UPDATED_ON;
            cmd.Parameters.Add("@UPDATED_BY", SqlDbType.VarChar).Value = pRODUCTMASTER.UPDATED_BY;
            cmd.Parameters.Add("@IS_TAXABLE", SqlDbType.Char).Value = pRODUCTMASTER.IS_TAXABLE;
            cmd.Parameters.Add("@PROD_COSTPRICE", SqlDbType.Int).Value = pRODUCTMASTER.PROD_COSTPRICE;
            cmd.Parameters.Add("@DEPT_ID", SqlDbType.Int).Value = pRODUCTMASTER.DEPT_ID;
            cmd.Parameters.Add("@AGENTID", SqlDbType.Int).Value = pRODUCTMASTER.AGENTID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
