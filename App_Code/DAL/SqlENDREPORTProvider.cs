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

public class SqlENDREPORTProvider:DataAccessObject
{
	public SqlENDREPORTProvider()
    {
    }


    public bool DeleteENDREPORT(int eNDREPORTID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteENDREPORT", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ENDREPORTID", SqlDbType.Int).Value = eNDREPORTID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<ENDREPORT> GetAllENDREPORTs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllENDREPORTs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetENDREPORTsFromReader(reader);
        }
    }
    public List<ENDREPORT> GetENDREPORTsFromReader(IDataReader reader)
    {
        List<ENDREPORT> eNDREPORTs = new List<ENDREPORT>();

        while (reader.Read())
        {
            eNDREPORTs.Add(GetENDREPORTFromReader(reader));
        }
        return eNDREPORTs;
    }

    public ENDREPORT GetENDREPORTFromReader(IDataReader reader)
    {
        try
        {
            ENDREPORT eNDREPORT = new ENDREPORT
                (
                    (int)reader["ENDREPORTID"],
                    (DateTime)reader["DT"],
                    (int)reader["BEGININGBALANCE"],
                    (int)reader["CASHFROM1"],
                    reader["CASHFROM1REMARKS"].ToString(),
                    (int)reader["CASHFROM2"],
                    reader["CASHFROM2REMARKS"].ToString(),
                    (int)reader["CASHFROM3"],
                    reader["CASHFROM3REMARKS"].ToString(),
                    (int)reader["CASHFROM4"],
                    reader["CASHFROM4REMARKS"].ToString(),
                    (int)reader["CASHFROM5"],
                    reader["CASHFROM5REMARKS"].ToString(),
                    (int)reader["CASHFROM6"],
                    reader["CASHFROM6REMARKS"].ToString(),
                    (int)reader["CASHFROM7"],
                    reader["CASHFROM7REMARKS"].ToString(),
                    (int)reader["CASHFROM8"],
                    reader["CASHFROM8REMARKS"].ToString(),
                    (int)reader["CASHFROM9"],
                    reader["CASHFROM9REMARKS"].ToString(),
                    (int)reader["CASHFROM10"],
                    reader["CASHFROM10REMARKS"].ToString(),
                    (int)reader["CASHFROM11"],
                    reader["CASHFROM11REMARKS"].ToString(),
                    (int)reader["CASHFROM12"],
                    reader["CASHFROM12REMARKS"].ToString(),
                    (int)reader["WU"],
                    (int)reader["WUCOUNT"],
                    (int)reader["CONVPAY"],
                    (int)reader["CONVPAYCOUNT"],
                    (int)reader["MO"],
                    (int)reader["MOCOMM"],
                    (int)reader["MOCOUNT"],
                    (int)reader["FEDILITY"],
                    (int)reader["FEDILITYCOMM"],
                    (int)reader["FEDILITYCOUNT"],
                    (int)reader["GLOBALEXPRESS"],
                    (int)reader["GLOBALEXPRESSCOMM"],
                    (int)reader["GLOBALEXPRESSCOUNT"],
                    (int)reader["CHECKFREEPAY"],
                    (int)reader["CHECKFREEPAYCOMM"],
                    (int)reader["CHECKFREEPAYCOUNT"],
                    (int)reader["PRECASH"],
                    (int)reader["PRECASHCOMM"],
                    (int)reader["PRECASHCOUNT"],
                    (int)reader["PHONECARD"],
                    (int)reader["IDCARD"],
                    (int)reader["IDCARDCOUNT"],
                    (int)reader["CHECKCOMM"],
                    (int)reader["CHECKCOUNT"],
                    (int)reader["TOTALCASHIN"],
                    (int)reader["CASHDEPOSIT1"],
                    (int)reader["CASHDEPOSIT2"],
                    (int)reader["CASHDEPOSIT3"],
                    (int)reader["CASHDEPOSIT4"],
                    (int)reader["CASHDEPOSIT5"],
                    (int)reader["CHECKDEPOSIT1"],
                    (int)reader["CHECKDEPOSIT2"],
                    (int)reader["CHECKDEPOSIT3"],
                    (int)reader["CHECKDEPOSIT4"],
                    (int)reader["CHECKDEPOSIT5"],
                    (int)reader["CHECKDEPOSIT6"],
                    (int)reader["CHECKDEPOSIT7"],
                    (int)reader["CHECKDEPOSIT8"],
                    (int)reader["CHECKDEPOSIT9"],
                    (int)reader["CHECKDEPOSIT10"],
                    (int)reader["CHECKDEPOSIT11"],
                    (int)reader["CHECKDEPOSIT12"],
                    (int)reader["CASHTRANSFER1"],
                    reader["CASHTRANSFER1REMARKS"].ToString(),
                    (int)reader["CASHTRANSFER2"],
                    reader["CASHTRANSFER2REMARKS"].ToString(),
                    (int)reader["CASHTRANSFER3"],
                    reader["CASHTRANSFER3REMARKS"].ToString(),
                    (int)reader["CASHTRANSFER4"],
                    reader["CASHTRANSFER4REMARKS"].ToString(),
                    (int)reader["CASHTRANSFER5"],
                    reader["CASHTRANSFER5REMARKS"].ToString(),
                    (int)reader["CASHTRANSFER6"],
                    reader["CASHTRANSFER6REMARKS"].ToString(),
                    (int)reader["CASHTRANSFER7"],
                    reader["CASHTRANSFER7REMARKS"].ToString(),
                    (int)reader["CASHTRANSFER8"],
                    reader["CASHTRANSFER8REMARKS"].ToString(),
                    (int)reader["FEDILITYDEPOSIT"],
                    (int)reader["CHECKFREEPAYDEPOSIT"],
                    (int)reader["CONVPAYDEPOSIT"],
                    (int)reader["WUPAYOUT"],
                    (int)reader["CREDITCARD"],
                    (int)reader["EXPENSES"],
                    (int)reader["TOTALCASHOUT"],
                    (int)reader["TOTALBALANCE"],
                    (int)reader["ACTUALBALACE"],
                    (int)reader["SHORTOVER"]
                );
             return eNDREPORT;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public ENDREPORT GetENDREPORTByID(int eNDREPORTID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetENDREPORTByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ENDREPORTID", SqlDbType.Int).Value = eNDREPORTID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetENDREPORTFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertENDREPORT(ENDREPORT eNDREPORT)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertENDREPORT", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ENDREPORTID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@DT", SqlDbType.DateTime).Value = eNDREPORT.DT;
            cmd.Parameters.Add("@BEGININGBALANCE", SqlDbType.Int).Value = eNDREPORT.BEGININGBALANCE;
            cmd.Parameters.Add("@CASHFROM1", SqlDbType.Int).Value = eNDREPORT.CASHFROM1;
            cmd.Parameters.Add("@CASHFROM1REMARKS", SqlDbType.VarChar).Value = eNDREPORT.CASHFROM1REMARKS;
            cmd.Parameters.Add("@CASHFROM2", SqlDbType.Int).Value = eNDREPORT.CASHFROM2;
            cmd.Parameters.Add("@CASHFROM2REMARKS", SqlDbType.VarChar).Value = eNDREPORT.CASHFROM2REMARKS;
            cmd.Parameters.Add("@CASHFROM3", SqlDbType.Int).Value = eNDREPORT.CASHFROM3;
            cmd.Parameters.Add("@CASHFROM3REMARKS", SqlDbType.VarChar).Value = eNDREPORT.CASHFROM3REMARKS;
            cmd.Parameters.Add("@CASHFROM4", SqlDbType.Int).Value = eNDREPORT.CASHFROM4;
            cmd.Parameters.Add("@CASHFROM4REMARKS", SqlDbType.VarChar).Value = eNDREPORT.CASHFROM4REMARKS;
            cmd.Parameters.Add("@CASHFROM5", SqlDbType.Int).Value = eNDREPORT.CASHFROM5;
            cmd.Parameters.Add("@CASHFROM5REMARKS", SqlDbType.VarChar).Value = eNDREPORT.CASHFROM5REMARKS;
            cmd.Parameters.Add("@CASHFROM6", SqlDbType.Int).Value = eNDREPORT.CASHFROM6;
            cmd.Parameters.Add("@CASHFROM6REMARKS", SqlDbType.VarChar).Value = eNDREPORT.CASHFROM6REMARKS;
            cmd.Parameters.Add("@CASHFROM7", SqlDbType.Int).Value = eNDREPORT.CASHFROM7;
            cmd.Parameters.Add("@CASHFROM7REMARKS", SqlDbType.VarChar).Value = eNDREPORT.CASHFROM7REMARKS;
            cmd.Parameters.Add("@CASHFROM8", SqlDbType.Int).Value = eNDREPORT.CASHFROM8;
            cmd.Parameters.Add("@CASHFROM8REMARKS", SqlDbType.VarChar).Value = eNDREPORT.CASHFROM8REMARKS;
            cmd.Parameters.Add("@CASHFROM9", SqlDbType.Int).Value = eNDREPORT.CASHFROM9;
            cmd.Parameters.Add("@CASHFROM9REMARKS", SqlDbType.VarChar).Value = eNDREPORT.CASHFROM9REMARKS;
            cmd.Parameters.Add("@CASHFROM10", SqlDbType.Int).Value = eNDREPORT.CASHFROM10;
            cmd.Parameters.Add("@CASHFROM10REMARKS", SqlDbType.VarChar).Value = eNDREPORT.CASHFROM10REMARKS;
            cmd.Parameters.Add("@CASHFROM11", SqlDbType.Int).Value = eNDREPORT.CASHFROM11;
            cmd.Parameters.Add("@CASHFROM11REMARKS", SqlDbType.VarChar).Value = eNDREPORT.CASHFROM11REMARKS;
            cmd.Parameters.Add("@CASHFROM12", SqlDbType.Int).Value = eNDREPORT.CASHFROM12;
            cmd.Parameters.Add("@CASHFROM12REMARKS", SqlDbType.VarChar).Value = eNDREPORT.CASHFROM12REMARKS;
            cmd.Parameters.Add("@WU", SqlDbType.Int).Value = eNDREPORT.WU;
            cmd.Parameters.Add("@WUCOUNT", SqlDbType.Int).Value = eNDREPORT.WUCOUNT;
            cmd.Parameters.Add("@CONVPAY", SqlDbType.Int).Value = eNDREPORT.CONVPAY;
            cmd.Parameters.Add("@CONVPAYCOUNT", SqlDbType.Int).Value = eNDREPORT.CONVPAYCOUNT;
            cmd.Parameters.Add("@MO", SqlDbType.Int).Value = eNDREPORT.MO;
            cmd.Parameters.Add("@MOCOMM", SqlDbType.Int).Value = eNDREPORT.MOCOMM;
            cmd.Parameters.Add("@MOCOUNT", SqlDbType.Int).Value = eNDREPORT.MOCOUNT;
            cmd.Parameters.Add("@FEDILITY", SqlDbType.Int).Value = eNDREPORT.FEDILITY;
            cmd.Parameters.Add("@FEDILITYCOMM", SqlDbType.Int).Value = eNDREPORT.FEDILITYCOMM;
            cmd.Parameters.Add("@FEDILITYCOUNT", SqlDbType.Int).Value = eNDREPORT.FEDILITYCOUNT;
            cmd.Parameters.Add("@GLOBALEXPRESS", SqlDbType.Int).Value = eNDREPORT.GLOBALEXPRESS;
            cmd.Parameters.Add("@GLOBALEXPRESSCOMM", SqlDbType.Int).Value = eNDREPORT.GLOBALEXPRESSCOMM;
            cmd.Parameters.Add("@GLOBALEXPRESSCOUNT", SqlDbType.Int).Value = eNDREPORT.GLOBALEXPRESSCOUNT;
            cmd.Parameters.Add("@CHECKFREEPAY", SqlDbType.Int).Value = eNDREPORT.CHECKFREEPAY;
            cmd.Parameters.Add("@CHECKFREEPAYCOMM", SqlDbType.Int).Value = eNDREPORT.CHECKFREEPAYCOMM;
            cmd.Parameters.Add("@CHECKFREEPAYCOUNT", SqlDbType.Int).Value = eNDREPORT.CHECKFREEPAYCOUNT;
            cmd.Parameters.Add("@PRECASH", SqlDbType.Int).Value = eNDREPORT.PRECASH;
            cmd.Parameters.Add("@PRECASHCOMM", SqlDbType.Int).Value = eNDREPORT.PRECASHCOMM;
            cmd.Parameters.Add("@PRECASHCOUNT", SqlDbType.Int).Value = eNDREPORT.PRECASHCOUNT;
            cmd.Parameters.Add("@PHONECARD", SqlDbType.Int).Value = eNDREPORT.PHONECARD;
            cmd.Parameters.Add("@IDCARD", SqlDbType.Int).Value = eNDREPORT.IDCARD;
            cmd.Parameters.Add("@IDCARDCOUNT", SqlDbType.Int).Value = eNDREPORT.IDCARDCOUNT;
            cmd.Parameters.Add("@CHECKCOMM", SqlDbType.Int).Value = eNDREPORT.CHECKCOMM;
            cmd.Parameters.Add("@CHECKCOUNT", SqlDbType.Int).Value = eNDREPORT.CHECKCOUNT;
            cmd.Parameters.Add("@TOTALCASHIN", SqlDbType.Int).Value = eNDREPORT.TOTALCASHIN;
            cmd.Parameters.Add("@CASHDEPOSIT1", SqlDbType.Int).Value = eNDREPORT.CASHDEPOSIT1;
            cmd.Parameters.Add("@CASHDEPOSIT2", SqlDbType.Int).Value = eNDREPORT.CASHDEPOSIT2;
            cmd.Parameters.Add("@CASHDEPOSIT3", SqlDbType.Int).Value = eNDREPORT.CASHDEPOSIT3;
            cmd.Parameters.Add("@CASHDEPOSIT4", SqlDbType.Int).Value = eNDREPORT.CASHDEPOSIT4;
            cmd.Parameters.Add("@CASHDEPOSIT5", SqlDbType.Int).Value = eNDREPORT.CASHDEPOSIT5;
            cmd.Parameters.Add("@CHECKDEPOSIT1", SqlDbType.Int).Value = eNDREPORT.CHECKDEPOSIT1;
            cmd.Parameters.Add("@CHECKDEPOSIT2", SqlDbType.Int).Value = eNDREPORT.CHECKDEPOSIT2;
            cmd.Parameters.Add("@CHECKDEPOSIT3", SqlDbType.Int).Value = eNDREPORT.CHECKDEPOSIT3;
            cmd.Parameters.Add("@CHECKDEPOSIT4", SqlDbType.Int).Value = eNDREPORT.CHECKDEPOSIT4;
            cmd.Parameters.Add("@CHECKDEPOSIT5", SqlDbType.Int).Value = eNDREPORT.CHECKDEPOSIT5;
            cmd.Parameters.Add("@CHECKDEPOSIT6", SqlDbType.Int).Value = eNDREPORT.CHECKDEPOSIT6;
            cmd.Parameters.Add("@CHECKDEPOSIT7", SqlDbType.Int).Value = eNDREPORT.CHECKDEPOSIT7;
            cmd.Parameters.Add("@CHECKDEPOSIT8", SqlDbType.Int).Value = eNDREPORT.CHECKDEPOSIT8;
            cmd.Parameters.Add("@CHECKDEPOSIT9", SqlDbType.Int).Value = eNDREPORT.CHECKDEPOSIT9;
            cmd.Parameters.Add("@CHECKDEPOSIT10", SqlDbType.Int).Value = eNDREPORT.CHECKDEPOSIT10;
            cmd.Parameters.Add("@CHECKDEPOSIT11", SqlDbType.Int).Value = eNDREPORT.CHECKDEPOSIT11;
            cmd.Parameters.Add("@CHECKDEPOSIT12", SqlDbType.Int).Value = eNDREPORT.CHECKDEPOSIT12;
            cmd.Parameters.Add("@CASHTRANSFER1", SqlDbType.Int).Value = eNDREPORT.CASHTRANSFER1;
            cmd.Parameters.Add("@CASHTRANSFER1REMARKS", SqlDbType.VarChar).Value = eNDREPORT.CASHTRANSFER1REMARKS;
            cmd.Parameters.Add("@CASHTRANSFER2", SqlDbType.Int).Value = eNDREPORT.CASHTRANSFER2;
            cmd.Parameters.Add("@CASHTRANSFER2REMARKS", SqlDbType.VarChar).Value = eNDREPORT.CASHTRANSFER2REMARKS;
            cmd.Parameters.Add("@CASHTRANSFER3", SqlDbType.Int).Value = eNDREPORT.CASHTRANSFER3;
            cmd.Parameters.Add("@CASHTRANSFER3REMARKS", SqlDbType.VarChar).Value = eNDREPORT.CASHTRANSFER3REMARKS;
            cmd.Parameters.Add("@CASHTRANSFER4", SqlDbType.Int).Value = eNDREPORT.CASHTRANSFER4;
            cmd.Parameters.Add("@CASHTRANSFER4REMARKS", SqlDbType.VarChar).Value = eNDREPORT.CASHTRANSFER4REMARKS;
            cmd.Parameters.Add("@CASHTRANSFER5", SqlDbType.Int).Value = eNDREPORT.CASHTRANSFER5;
            cmd.Parameters.Add("@CASHTRANSFER5REMARKS", SqlDbType.VarChar).Value = eNDREPORT.CASHTRANSFER5REMARKS;
            cmd.Parameters.Add("@CASHTRANSFER6", SqlDbType.Int).Value = eNDREPORT.CASHTRANSFER6;
            cmd.Parameters.Add("@CASHTRANSFER6REMARKS", SqlDbType.VarChar).Value = eNDREPORT.CASHTRANSFER6REMARKS;
            cmd.Parameters.Add("@CASHTRANSFER7", SqlDbType.Int).Value = eNDREPORT.CASHTRANSFER7;
            cmd.Parameters.Add("@CASHTRANSFER7REMARKS", SqlDbType.VarChar).Value = eNDREPORT.CASHTRANSFER7REMARKS;
            cmd.Parameters.Add("@CASHTRANSFER8", SqlDbType.Int).Value = eNDREPORT.CASHTRANSFER8;
            cmd.Parameters.Add("@CASHTRANSFER8REMARKS", SqlDbType.VarChar).Value = eNDREPORT.CASHTRANSFER8REMARKS;
            cmd.Parameters.Add("@FEDILITYDEPOSIT", SqlDbType.Int).Value = eNDREPORT.FEDILITYDEPOSIT;
            cmd.Parameters.Add("@CHECKFREEPAYDEPOSIT", SqlDbType.Int).Value = eNDREPORT.CHECKFREEPAYDEPOSIT;
            cmd.Parameters.Add("@CONVPAYDEPOSIT", SqlDbType.Int).Value = eNDREPORT.CONVPAYDEPOSIT;
            cmd.Parameters.Add("@WUPAYOUT", SqlDbType.Int).Value = eNDREPORT.WUPAYOUT;
            cmd.Parameters.Add("@CREDITCARD", SqlDbType.Int).Value = eNDREPORT.CREDITCARD;
            cmd.Parameters.Add("@EXPENSES", SqlDbType.Int).Value = eNDREPORT.EXPENSES;
            cmd.Parameters.Add("@TOTALCASHOUT", SqlDbType.Int).Value = eNDREPORT.TOTALCASHOUT;
            cmd.Parameters.Add("@TOTALBALANCE", SqlDbType.Int).Value = eNDREPORT.TOTALBALANCE;
            cmd.Parameters.Add("@ACTUALBALACE", SqlDbType.Int).Value = eNDREPORT.ACTUALBALACE;
            cmd.Parameters.Add("@SHORTOVER", SqlDbType.Int).Value = eNDREPORT.SHORTOVER;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ENDREPORTID"].Value;
        }
    }

    public bool UpdateENDREPORT(ENDREPORT eNDREPORT)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateENDREPORT", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ENDREPORTID", SqlDbType.Int).Value = eNDREPORT.ENDREPORTID;
            cmd.Parameters.Add("@DT", SqlDbType.DateTime).Value = eNDREPORT.DT;
            cmd.Parameters.Add("@BEGININGBALANCE", SqlDbType.Int).Value = eNDREPORT.BEGININGBALANCE;
            cmd.Parameters.Add("@CASHFROM1", SqlDbType.Int).Value = eNDREPORT.CASHFROM1;
            cmd.Parameters.Add("@CASHFROM1REMARKS", SqlDbType.VarChar).Value = eNDREPORT.CASHFROM1REMARKS;
            cmd.Parameters.Add("@CASHFROM2", SqlDbType.Int).Value = eNDREPORT.CASHFROM2;
            cmd.Parameters.Add("@CASHFROM2REMARKS", SqlDbType.VarChar).Value = eNDREPORT.CASHFROM2REMARKS;
            cmd.Parameters.Add("@CASHFROM3", SqlDbType.Int).Value = eNDREPORT.CASHFROM3;
            cmd.Parameters.Add("@CASHFROM3REMARKS", SqlDbType.VarChar).Value = eNDREPORT.CASHFROM3REMARKS;
            cmd.Parameters.Add("@CASHFROM4", SqlDbType.Int).Value = eNDREPORT.CASHFROM4;
            cmd.Parameters.Add("@CASHFROM4REMARKS", SqlDbType.VarChar).Value = eNDREPORT.CASHFROM4REMARKS;
            cmd.Parameters.Add("@CASHFROM5", SqlDbType.Int).Value = eNDREPORT.CASHFROM5;
            cmd.Parameters.Add("@CASHFROM5REMARKS", SqlDbType.VarChar).Value = eNDREPORT.CASHFROM5REMARKS;
            cmd.Parameters.Add("@CASHFROM6", SqlDbType.Int).Value = eNDREPORT.CASHFROM6;
            cmd.Parameters.Add("@CASHFROM6REMARKS", SqlDbType.VarChar).Value = eNDREPORT.CASHFROM6REMARKS;
            cmd.Parameters.Add("@CASHFROM7", SqlDbType.Int).Value = eNDREPORT.CASHFROM7;
            cmd.Parameters.Add("@CASHFROM7REMARKS", SqlDbType.VarChar).Value = eNDREPORT.CASHFROM7REMARKS;
            cmd.Parameters.Add("@CASHFROM8", SqlDbType.Int).Value = eNDREPORT.CASHFROM8;
            cmd.Parameters.Add("@CASHFROM8REMARKS", SqlDbType.VarChar).Value = eNDREPORT.CASHFROM8REMARKS;
            cmd.Parameters.Add("@CASHFROM9", SqlDbType.Int).Value = eNDREPORT.CASHFROM9;
            cmd.Parameters.Add("@CASHFROM9REMARKS", SqlDbType.VarChar).Value = eNDREPORT.CASHFROM9REMARKS;
            cmd.Parameters.Add("@CASHFROM10", SqlDbType.Int).Value = eNDREPORT.CASHFROM10;
            cmd.Parameters.Add("@CASHFROM10REMARKS", SqlDbType.VarChar).Value = eNDREPORT.CASHFROM10REMARKS;
            cmd.Parameters.Add("@CASHFROM11", SqlDbType.Int).Value = eNDREPORT.CASHFROM11;
            cmd.Parameters.Add("@CASHFROM11REMARKS", SqlDbType.VarChar).Value = eNDREPORT.CASHFROM11REMARKS;
            cmd.Parameters.Add("@CASHFROM12", SqlDbType.Int).Value = eNDREPORT.CASHFROM12;
            cmd.Parameters.Add("@CASHFROM12REMARKS", SqlDbType.VarChar).Value = eNDREPORT.CASHFROM12REMARKS;
            cmd.Parameters.Add("@WU", SqlDbType.Int).Value = eNDREPORT.WU;
            cmd.Parameters.Add("@WUCOUNT", SqlDbType.Int).Value = eNDREPORT.WUCOUNT;
            cmd.Parameters.Add("@CONVPAY", SqlDbType.Int).Value = eNDREPORT.CONVPAY;
            cmd.Parameters.Add("@CONVPAYCOUNT", SqlDbType.Int).Value = eNDREPORT.CONVPAYCOUNT;
            cmd.Parameters.Add("@MO", SqlDbType.Int).Value = eNDREPORT.MO;
            cmd.Parameters.Add("@MOCOMM", SqlDbType.Int).Value = eNDREPORT.MOCOMM;
            cmd.Parameters.Add("@MOCOUNT", SqlDbType.Int).Value = eNDREPORT.MOCOUNT;
            cmd.Parameters.Add("@FEDILITY", SqlDbType.Int).Value = eNDREPORT.FEDILITY;
            cmd.Parameters.Add("@FEDILITYCOMM", SqlDbType.Int).Value = eNDREPORT.FEDILITYCOMM;
            cmd.Parameters.Add("@FEDILITYCOUNT", SqlDbType.Int).Value = eNDREPORT.FEDILITYCOUNT;
            cmd.Parameters.Add("@GLOBALEXPRESS", SqlDbType.Int).Value = eNDREPORT.GLOBALEXPRESS;
            cmd.Parameters.Add("@GLOBALEXPRESSCOMM", SqlDbType.Int).Value = eNDREPORT.GLOBALEXPRESSCOMM;
            cmd.Parameters.Add("@GLOBALEXPRESSCOUNT", SqlDbType.Int).Value = eNDREPORT.GLOBALEXPRESSCOUNT;
            cmd.Parameters.Add("@CHECKFREEPAY", SqlDbType.Int).Value = eNDREPORT.CHECKFREEPAY;
            cmd.Parameters.Add("@CHECKFREEPAYCOMM", SqlDbType.Int).Value = eNDREPORT.CHECKFREEPAYCOMM;
            cmd.Parameters.Add("@CHECKFREEPAYCOUNT", SqlDbType.Int).Value = eNDREPORT.CHECKFREEPAYCOUNT;
            cmd.Parameters.Add("@PRECASH", SqlDbType.Int).Value = eNDREPORT.PRECASH;
            cmd.Parameters.Add("@PRECASHCOMM", SqlDbType.Int).Value = eNDREPORT.PRECASHCOMM;
            cmd.Parameters.Add("@PRECASHCOUNT", SqlDbType.Int).Value = eNDREPORT.PRECASHCOUNT;
            cmd.Parameters.Add("@PHONECARD", SqlDbType.Int).Value = eNDREPORT.PHONECARD;
            cmd.Parameters.Add("@IDCARD", SqlDbType.Int).Value = eNDREPORT.IDCARD;
            cmd.Parameters.Add("@IDCARDCOUNT", SqlDbType.Int).Value = eNDREPORT.IDCARDCOUNT;
            cmd.Parameters.Add("@CHECKCOMM", SqlDbType.Int).Value = eNDREPORT.CHECKCOMM;
            cmd.Parameters.Add("@CHECKCOUNT", SqlDbType.Int).Value = eNDREPORT.CHECKCOUNT;
            cmd.Parameters.Add("@TOTALCASHIN", SqlDbType.Int).Value = eNDREPORT.TOTALCASHIN;
            cmd.Parameters.Add("@CASHDEPOSIT1", SqlDbType.Int).Value = eNDREPORT.CASHDEPOSIT1;
            cmd.Parameters.Add("@CASHDEPOSIT2", SqlDbType.Int).Value = eNDREPORT.CASHDEPOSIT2;
            cmd.Parameters.Add("@CASHDEPOSIT3", SqlDbType.Int).Value = eNDREPORT.CASHDEPOSIT3;
            cmd.Parameters.Add("@CASHDEPOSIT4", SqlDbType.Int).Value = eNDREPORT.CASHDEPOSIT4;
            cmd.Parameters.Add("@CASHDEPOSIT5", SqlDbType.Int).Value = eNDREPORT.CASHDEPOSIT5;
            cmd.Parameters.Add("@CHECKDEPOSIT1", SqlDbType.Int).Value = eNDREPORT.CHECKDEPOSIT1;
            cmd.Parameters.Add("@CHECKDEPOSIT2", SqlDbType.Int).Value = eNDREPORT.CHECKDEPOSIT2;
            cmd.Parameters.Add("@CHECKDEPOSIT3", SqlDbType.Int).Value = eNDREPORT.CHECKDEPOSIT3;
            cmd.Parameters.Add("@CHECKDEPOSIT4", SqlDbType.Int).Value = eNDREPORT.CHECKDEPOSIT4;
            cmd.Parameters.Add("@CHECKDEPOSIT5", SqlDbType.Int).Value = eNDREPORT.CHECKDEPOSIT5;
            cmd.Parameters.Add("@CHECKDEPOSIT6", SqlDbType.Int).Value = eNDREPORT.CHECKDEPOSIT6;
            cmd.Parameters.Add("@CHECKDEPOSIT7", SqlDbType.Int).Value = eNDREPORT.CHECKDEPOSIT7;
            cmd.Parameters.Add("@CHECKDEPOSIT8", SqlDbType.Int).Value = eNDREPORT.CHECKDEPOSIT8;
            cmd.Parameters.Add("@CHECKDEPOSIT9", SqlDbType.Int).Value = eNDREPORT.CHECKDEPOSIT9;
            cmd.Parameters.Add("@CHECKDEPOSIT10", SqlDbType.Int).Value = eNDREPORT.CHECKDEPOSIT10;
            cmd.Parameters.Add("@CHECKDEPOSIT11", SqlDbType.Int).Value = eNDREPORT.CHECKDEPOSIT11;
            cmd.Parameters.Add("@CHECKDEPOSIT12", SqlDbType.Int).Value = eNDREPORT.CHECKDEPOSIT12;
            cmd.Parameters.Add("@CASHTRANSFER1", SqlDbType.Int).Value = eNDREPORT.CASHTRANSFER1;
            cmd.Parameters.Add("@CASHTRANSFER1REMARKS", SqlDbType.VarChar).Value = eNDREPORT.CASHTRANSFER1REMARKS;
            cmd.Parameters.Add("@CASHTRANSFER2", SqlDbType.Int).Value = eNDREPORT.CASHTRANSFER2;
            cmd.Parameters.Add("@CASHTRANSFER2REMARKS", SqlDbType.VarChar).Value = eNDREPORT.CASHTRANSFER2REMARKS;
            cmd.Parameters.Add("@CASHTRANSFER3", SqlDbType.Int).Value = eNDREPORT.CASHTRANSFER3;
            cmd.Parameters.Add("@CASHTRANSFER3REMARKS", SqlDbType.VarChar).Value = eNDREPORT.CASHTRANSFER3REMARKS;
            cmd.Parameters.Add("@CASHTRANSFER4", SqlDbType.Int).Value = eNDREPORT.CASHTRANSFER4;
            cmd.Parameters.Add("@CASHTRANSFER4REMARKS", SqlDbType.VarChar).Value = eNDREPORT.CASHTRANSFER4REMARKS;
            cmd.Parameters.Add("@CASHTRANSFER5", SqlDbType.Int).Value = eNDREPORT.CASHTRANSFER5;
            cmd.Parameters.Add("@CASHTRANSFER5REMARKS", SqlDbType.VarChar).Value = eNDREPORT.CASHTRANSFER5REMARKS;
            cmd.Parameters.Add("@CASHTRANSFER6", SqlDbType.Int).Value = eNDREPORT.CASHTRANSFER6;
            cmd.Parameters.Add("@CASHTRANSFER6REMARKS", SqlDbType.VarChar).Value = eNDREPORT.CASHTRANSFER6REMARKS;
            cmd.Parameters.Add("@CASHTRANSFER7", SqlDbType.Int).Value = eNDREPORT.CASHTRANSFER7;
            cmd.Parameters.Add("@CASHTRANSFER7REMARKS", SqlDbType.VarChar).Value = eNDREPORT.CASHTRANSFER7REMARKS;
            cmd.Parameters.Add("@CASHTRANSFER8", SqlDbType.Int).Value = eNDREPORT.CASHTRANSFER8;
            cmd.Parameters.Add("@CASHTRANSFER8REMARKS", SqlDbType.VarChar).Value = eNDREPORT.CASHTRANSFER8REMARKS;
            cmd.Parameters.Add("@FEDILITYDEPOSIT", SqlDbType.Int).Value = eNDREPORT.FEDILITYDEPOSIT;
            cmd.Parameters.Add("@CHECKFREEPAYDEPOSIT", SqlDbType.Int).Value = eNDREPORT.CHECKFREEPAYDEPOSIT;
            cmd.Parameters.Add("@CONVPAYDEPOSIT", SqlDbType.Int).Value = eNDREPORT.CONVPAYDEPOSIT;
            cmd.Parameters.Add("@WUPAYOUT", SqlDbType.Int).Value = eNDREPORT.WUPAYOUT;
            cmd.Parameters.Add("@CREDITCARD", SqlDbType.Int).Value = eNDREPORT.CREDITCARD;
            cmd.Parameters.Add("@EXPENSES", SqlDbType.Int).Value = eNDREPORT.EXPENSES;
            cmd.Parameters.Add("@TOTALCASHOUT", SqlDbType.Int).Value = eNDREPORT.TOTALCASHOUT;
            cmd.Parameters.Add("@TOTALBALANCE", SqlDbType.Int).Value = eNDREPORT.TOTALBALANCE;
            cmd.Parameters.Add("@ACTUALBALACE", SqlDbType.Int).Value = eNDREPORT.ACTUALBALACE;
            cmd.Parameters.Add("@SHORTOVER", SqlDbType.Int).Value = eNDREPORT.SHORTOVER;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
