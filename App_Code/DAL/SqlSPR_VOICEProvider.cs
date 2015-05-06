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

public class SqlSPR_VOICEProvider:DataAccessObject
{
	public SqlSPR_VOICEProvider()
    {
    }


    public bool DeleteSPR_VOICE(int sPR_VOICEID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteSPR_VOICE", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SPR_VOICEID", SqlDbType.Int).Value = sPR_VOICEID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<SPR_VOICE> GetAllSPR_VOICEs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllSPR_VOICEs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetSPR_VOICEsFromReader(reader);
        }
    }
    public List<SPR_VOICE> GetSPR_VOICEsFromReader(IDataReader reader)
    {
        List<SPR_VOICE> sPR_VOICEs = new List<SPR_VOICE>();

        while (reader.Read())
        {
            sPR_VOICEs.Add(GetSPR_VOICEFromReader(reader));
        }
        return sPR_VOICEs;
    }

    public SPR_VOICE GetSPR_VOICEFromReader(IDataReader reader)
    {
        try
        {
            SPR_VOICE sPR_VOICE = new SPR_VOICE
                (
                    (int)reader["SPR_VOICEID"],
                    reader["STYPE"].ToString(),
                    reader["MRC"].ToString(),
                    (int)reader["VCOMM"]
                );
             return sPR_VOICE;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public SPR_VOICE GetSPR_VOICEByID(int sPR_VOICEID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetSPR_VOICEByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SPR_VOICEID", SqlDbType.Int).Value = sPR_VOICEID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetSPR_VOICEFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertSPR_VOICE(SPR_VOICE sPR_VOICE)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertSPR_VOICE", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SPR_VOICEID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@STYPE", SqlDbType.VarChar).Value = sPR_VOICE.STYPE;
            cmd.Parameters.Add("@MRC", SqlDbType.VarChar).Value = sPR_VOICE.MRC;
            cmd.Parameters.Add("@VCOMM", SqlDbType.Int).Value = sPR_VOICE.VCOMM;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@SPR_VOICEID"].Value;
        }
    }

    public bool UpdateSPR_VOICE(SPR_VOICE sPR_VOICE)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateSPR_VOICE", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SPR_VOICEID", SqlDbType.Int).Value = sPR_VOICE.SPR_VOICEID;
            cmd.Parameters.Add("@STYPE", SqlDbType.VarChar).Value = sPR_VOICE.STYPE;
            cmd.Parameters.Add("@MRC", SqlDbType.VarChar).Value = sPR_VOICE.MRC;
            cmd.Parameters.Add("@VCOMM", SqlDbType.Int).Value = sPR_VOICE.VCOMM;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
