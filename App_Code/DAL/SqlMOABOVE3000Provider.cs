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

public class SqlMOABOVE3000Provider:DataAccessObject
{
	public SqlMOABOVE3000Provider()
    {
    }


    public bool DeleteMOABOVE3000(int mOABOVE3000ID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteMOABOVE3000", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MOABOVE3000ID", SqlDbType.Int).Value = mOABOVE3000ID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<MOABOVE3000> GetAllMOABOVE3000s()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllMOABOVE3000s", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetMOABOVE3000sFromReader(reader);
        }
    }
    public List<MOABOVE3000> GetMOABOVE3000sFromReader(IDataReader reader)
    {
        List<MOABOVE3000> mOABOVE3000s = new List<MOABOVE3000>();

        while (reader.Read())
        {
            mOABOVE3000s.Add(GetMOABOVE3000FromReader(reader));
        }
        return mOABOVE3000s;
    }

    public MOABOVE3000 GetMOABOVE3000FromReader(IDataReader reader)
    {
        try
        {
            MOABOVE3000 mOABOVE3000 = new MOABOVE3000
                (
                    (int)reader["MOABOVE3000ID"],
                    (DateTime)reader["DT"],
                    reader["CUST_ID"].ToString(),
                    reader["STARTNO"].ToString(),
                    reader["ENDNO"].ToString(),
                    (int)reader["AMOUNT"],
                    (int)reader["EMP_ID"],
                    (int)reader["STATION_ID"],
                    (int)reader["SHIFT_ID"]
                );
             return mOABOVE3000;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public MOABOVE3000 GetMOABOVE3000ByID(int mOABOVE3000ID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetMOABOVE3000ByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MOABOVE3000ID", SqlDbType.Int).Value = mOABOVE3000ID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetMOABOVE3000FromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertMOABOVE3000(MOABOVE3000 mOABOVE3000)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertMOABOVE3000", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MOABOVE3000ID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@DT", SqlDbType.DateTime).Value = mOABOVE3000.DT;
            cmd.Parameters.Add("@CUST_ID", SqlDbType.VarChar).Value = mOABOVE3000.CUST_ID;
            cmd.Parameters.Add("@STARTNO", SqlDbType.VarChar).Value = mOABOVE3000.STARTNO;
            cmd.Parameters.Add("@ENDNO", SqlDbType.VarChar).Value = mOABOVE3000.ENDNO;
            cmd.Parameters.Add("@AMOUNT", SqlDbType.Int).Value = mOABOVE3000.AMOUNT;
            cmd.Parameters.Add("@EMP_ID", SqlDbType.Int).Value = mOABOVE3000.EMP_ID;
            cmd.Parameters.Add("@STATION_ID", SqlDbType.Int).Value = mOABOVE3000.STATION_ID;
            cmd.Parameters.Add("@SHIFT_ID", SqlDbType.Int).Value = mOABOVE3000.SHIFT_ID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@MOABOVE3000ID"].Value;
        }
    }

    public bool UpdateMOABOVE3000(MOABOVE3000 mOABOVE3000)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateMOABOVE3000", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MOABOVE3000ID", SqlDbType.Int).Value = mOABOVE3000.MOABOVE3000ID;
            cmd.Parameters.Add("@DT", SqlDbType.DateTime).Value = mOABOVE3000.DT;
            cmd.Parameters.Add("@CUST_ID", SqlDbType.VarChar).Value = mOABOVE3000.CUST_ID;
            cmd.Parameters.Add("@STARTNO", SqlDbType.VarChar).Value = mOABOVE3000.STARTNO;
            cmd.Parameters.Add("@ENDNO", SqlDbType.VarChar).Value = mOABOVE3000.ENDNO;
            cmd.Parameters.Add("@AMOUNT", SqlDbType.Int).Value = mOABOVE3000.AMOUNT;
            cmd.Parameters.Add("@EMP_ID", SqlDbType.Int).Value = mOABOVE3000.EMP_ID;
            cmd.Parameters.Add("@STATION_ID", SqlDbType.Int).Value = mOABOVE3000.STATION_ID;
            cmd.Parameters.Add("@SHIFT_ID", SqlDbType.Int).Value = mOABOVE3000.SHIFT_ID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
