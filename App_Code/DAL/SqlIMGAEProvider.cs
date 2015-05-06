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

public class SqlIMGAEProvider:DataAccessObject
{
	public SqlIMGAEProvider()
    {
    }


    public bool DeleteIMGAE(int iMGAEID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteIMGAE", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IMGAEID", SqlDbType.Int).Value = iMGAEID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<IMGAE> GetAllIMGAEs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllIMGAEs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetIMGAEsFromReader(reader);
        }
    }
    public List<IMGAE> GetIMGAEsFromReader(IDataReader reader)
    {
        List<IMGAE> iMGAEs = new List<IMGAE>();

        while (reader.Read())
        {
            iMGAEs.Add(GetIMGAEFromReader(reader));
        }
        return iMGAEs;
    }

    public IMGAE GetIMGAEFromReader(IDataReader reader)
    {
        try
        {
            IMGAE iMGAE = new IMGAE
                (
                    (int)reader["IMGAEID"],
                    reader["IMG"].ToString()
                );
             return iMGAE;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public IMGAE GetIMGAEByID(int iMGAEID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetIMGAEByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@IMGAEID", SqlDbType.Int).Value = iMGAEID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetIMGAEFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertIMGAE(IMGAE iMGAE)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertIMGAE", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IMGAEID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@IMG", SqlDbType.Image).Value = iMGAE.IMG;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@IMGAEID"].Value;
        }
    }

    public bool UpdateIMGAE(IMGAE iMGAE)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateIMGAE", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IMGAEID", SqlDbType.Int).Value = iMGAE.IMGAEID;
            cmd.Parameters.Add("@IMG", SqlDbType.Image).Value = iMGAE.IMG;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
