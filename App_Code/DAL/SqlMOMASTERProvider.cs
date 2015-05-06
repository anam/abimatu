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

public class SqlMOMASTERProvider:DataAccessObject
{
	public SqlMOMASTERProvider()
    {
    }


    public bool DeleteMOMASTER(int mOMASTERID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteMOMASTER", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MOMASTERID", SqlDbType.Int).Value = mOMASTERID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<MOMASTER> GetAllMOMASTERs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllMOMASTERs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetMOMASTERsFromReader(reader);
        }
    }
    public List<MOMASTER> GetMOMASTERsFromReader(IDataReader reader)
    {
        List<MOMASTER> mOMASTERs = new List<MOMASTER>();

        while (reader.Read())
        {
            mOMASTERs.Add(GetMOMASTERFromReader(reader));
        }
        return mOMASTERs;
    }

    public MOMASTER GetMOMASTERFromReader(IDataReader reader)
    {
        try
        {
            MOMASTER mOMASTER = new MOMASTER
                (
                    (int)reader["MOMASTERID"],
                    (int)reader["AGENTID"],
                    (int)reader["STARTMO"],
                    (int)reader["ENDMO"],
                    (int)reader["CURRMO"]
                );
             return mOMASTER;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public MOMASTER GetMOMASTERByID(int mOMASTERID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetMOMASTERByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MOMASTERID", SqlDbType.Int).Value = mOMASTERID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetMOMASTERFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertMOMASTER(MOMASTER mOMASTER)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertMOMASTER", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MOMASTERID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@AGENTID", SqlDbType.Int).Value = mOMASTER.AGENTID;
            cmd.Parameters.Add("@STARTMO", SqlDbType.Int).Value = mOMASTER.STARTMO;
            cmd.Parameters.Add("@ENDMO", SqlDbType.Int).Value = mOMASTER.ENDMO;
            cmd.Parameters.Add("@CURRMO", SqlDbType.Int).Value = mOMASTER.CURRMO;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@MOMASTERID"].Value;
        }
    }

    public bool UpdateMOMASTER(MOMASTER mOMASTER)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateMOMASTER", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MOMASTERID", SqlDbType.Int).Value = mOMASTER.MOMASTERID;
            cmd.Parameters.Add("@AGENTID", SqlDbType.Int).Value = mOMASTER.AGENTID;
            cmd.Parameters.Add("@STARTMO", SqlDbType.Int).Value = mOMASTER.STARTMO;
            cmd.Parameters.Add("@ENDMO", SqlDbType.Int).Value = mOMASTER.ENDMO;
            cmd.Parameters.Add("@CURRMO", SqlDbType.Int).Value = mOMASTER.CURRMO;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
