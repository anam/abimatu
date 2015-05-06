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

public class SqlACTIVATIONProvider:DataAccessObject
{
	public SqlACTIVATIONProvider()
    {
    }


    public bool DeleteACTIVATION(int aCTIVATIONID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteACTIVATION", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ACTIVATIONID", SqlDbType.Int).Value = aCTIVATIONID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<ACTIVATION> GetAllACTIVATIONs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllACTIVATIONs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetACTIVATIONsFromReader(reader);
        }
    }
    public List<ACTIVATION> GetACTIVATIONsFromReader(IDataReader reader)
    {
        List<ACTIVATION> aCTIVATIONs = new List<ACTIVATION>();

        while (reader.Read())
        {
            aCTIVATIONs.Add(GetACTIVATIONFromReader(reader));
        }
        return aCTIVATIONs;
    }

    public ACTIVATION GetACTIVATIONFromReader(IDataReader reader)
    {
        try
        {
            ACTIVATION aCTIVATION = new ACTIVATION
                (
                    (int)reader["ACTIVATIONID"],
                    (int)reader["CUST_ID"],
                    reader["CARRIERTYPE"].ToString(),
                    reader["ACTIVATIONTYPE"].ToString(),
                    reader["ACCOUNTNO"].ToString(),
                    reader["ORDERNO"].ToString(),
                    reader["DEALERCODE"].ToString(),
                    (DateTime)reader["ACTIVATIONDATE"],
                    reader["MOBILENO"].ToString(),
                    reader["SIMM"].ToString(),
                    reader["IMEI"].ToString(),
                    reader["RATEPLAN"].ToString(),
                    (int)reader["COMMAMOUNT"],
                    (int)reader["SPIFF"],
                    (int)reader["REBATE"],
                    (char)reader["ISACTIVE"],
                    (int)reader["CREATEDBY"],
                    (DateTime)reader["CREATEDON"],
                    (int)reader["UPDATEDBY"],
                    (DateTime)reader["UPDATEDON"]
                );
             return aCTIVATION;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public ACTIVATION GetACTIVATIONByID(int aCTIVATIONID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetACTIVATIONByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ACTIVATIONID", SqlDbType.Int).Value = aCTIVATIONID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetACTIVATIONFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertACTIVATION(ACTIVATION aCTIVATION)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertACTIVATION", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ACTIVATIONID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@CUST_ID", SqlDbType.Int).Value = aCTIVATION.CUST_ID;
            cmd.Parameters.Add("@CARRIERTYPE", SqlDbType.VarChar).Value = aCTIVATION.CARRIERTYPE;
            cmd.Parameters.Add("@ACTIVATIONTYPE", SqlDbType.VarChar).Value = aCTIVATION.ACTIVATIONTYPE;
            cmd.Parameters.Add("@ACCOUNTNO", SqlDbType.VarChar).Value = aCTIVATION.ACCOUNTNO;
            cmd.Parameters.Add("@ORDERNO", SqlDbType.VarChar).Value = aCTIVATION.ORDERNO;
            cmd.Parameters.Add("@DEALERCODE", SqlDbType.VarChar).Value = aCTIVATION.DEALERCODE;
            cmd.Parameters.Add("@ACTIVATIONDATE", SqlDbType.DateTime).Value = aCTIVATION.ACTIVATIONDATE;
            cmd.Parameters.Add("@MOBILENO", SqlDbType.VarChar).Value = aCTIVATION.MOBILENO;
            cmd.Parameters.Add("@SIMM", SqlDbType.VarChar).Value = aCTIVATION.SIMM;
            cmd.Parameters.Add("@IMEI", SqlDbType.VarChar).Value = aCTIVATION.IMEI;
            cmd.Parameters.Add("@RATEPLAN", SqlDbType.VarChar).Value = aCTIVATION.RATEPLAN;
            cmd.Parameters.Add("@COMMAMOUNT", SqlDbType.Int).Value = aCTIVATION.COMMAMOUNT;
            cmd.Parameters.Add("@SPIFF", SqlDbType.Int).Value = aCTIVATION.SPIFF;
            cmd.Parameters.Add("@REBATE", SqlDbType.Int).Value = aCTIVATION.REBATE;
            cmd.Parameters.Add("@ISACTIVE", SqlDbType.Char).Value = aCTIVATION.ISACTIVE;
            cmd.Parameters.Add("@CREATEDBY", SqlDbType.Int).Value = aCTIVATION.CREATEDBY;
            cmd.Parameters.Add("@CREATEDON", SqlDbType.DateTime).Value = aCTIVATION.CREATEDON;
            cmd.Parameters.Add("@UPDATEDBY", SqlDbType.Int).Value = aCTIVATION.UPDATEDBY;
            cmd.Parameters.Add("@UPDATEDON", SqlDbType.DateTime).Value = aCTIVATION.UPDATEDON;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ACTIVATIONID"].Value;
        }
    }

    public bool UpdateACTIVATION(ACTIVATION aCTIVATION)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateACTIVATION", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ACTIVATIONID", SqlDbType.Int).Value = aCTIVATION.ACTIVATIONID;
            cmd.Parameters.Add("@CUST_ID", SqlDbType.Int).Value = aCTIVATION.CUST_ID;
            cmd.Parameters.Add("@CARRIERTYPE", SqlDbType.VarChar).Value = aCTIVATION.CARRIERTYPE;
            cmd.Parameters.Add("@ACTIVATIONTYPE", SqlDbType.VarChar).Value = aCTIVATION.ACTIVATIONTYPE;
            cmd.Parameters.Add("@ACCOUNTNO", SqlDbType.VarChar).Value = aCTIVATION.ACCOUNTNO;
            cmd.Parameters.Add("@ORDERNO", SqlDbType.VarChar).Value = aCTIVATION.ORDERNO;
            cmd.Parameters.Add("@DEALERCODE", SqlDbType.VarChar).Value = aCTIVATION.DEALERCODE;
            cmd.Parameters.Add("@ACTIVATIONDATE", SqlDbType.DateTime).Value = aCTIVATION.ACTIVATIONDATE;
            cmd.Parameters.Add("@MOBILENO", SqlDbType.VarChar).Value = aCTIVATION.MOBILENO;
            cmd.Parameters.Add("@SIMM", SqlDbType.VarChar).Value = aCTIVATION.SIMM;
            cmd.Parameters.Add("@IMEI", SqlDbType.VarChar).Value = aCTIVATION.IMEI;
            cmd.Parameters.Add("@RATEPLAN", SqlDbType.VarChar).Value = aCTIVATION.RATEPLAN;
            cmd.Parameters.Add("@COMMAMOUNT", SqlDbType.Int).Value = aCTIVATION.COMMAMOUNT;
            cmd.Parameters.Add("@SPIFF", SqlDbType.Int).Value = aCTIVATION.SPIFF;
            cmd.Parameters.Add("@REBATE", SqlDbType.Int).Value = aCTIVATION.REBATE;
            cmd.Parameters.Add("@ISACTIVE", SqlDbType.Char).Value = aCTIVATION.ISACTIVE;
            cmd.Parameters.Add("@CREATEDBY", SqlDbType.Int).Value = aCTIVATION.CREATEDBY;
            cmd.Parameters.Add("@CREATEDON", SqlDbType.DateTime).Value = aCTIVATION.CREATEDON;
            cmd.Parameters.Add("@UPDATEDBY", SqlDbType.Int).Value = aCTIVATION.UPDATEDBY;
            cmd.Parameters.Add("@UPDATEDON", SqlDbType.DateTime).Value = aCTIVATION.UPDATEDON;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
