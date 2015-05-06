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

public class SqlREPORTProvider:DataAccessObject
{
	public SqlREPORTProvider()
    {
    }


    public bool DeleteREPORT(int rEPORTID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteREPORT", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@REPORTID", SqlDbType.Int).Value = rEPORTID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<REPORT> GetAllREPORTs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllREPORTs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetREPORTsFromReader(reader);
        }
    }
    public List<REPORT> GetREPORTsFromReader(IDataReader reader)
    {
        List<REPORT> rEPORTs = new List<REPORT>();

        while (reader.Read())
        {
            rEPORTs.Add(GetREPORTFromReader(reader));
        }
        return rEPORTs;
    }

    public REPORT GetREPORTFromReader(IDataReader reader)
    {
        try
        {
            REPORT rEPORT = new REPORT
                (
                    (int)reader["REPORTID"],
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
                    (int)reader["SHORTOVER"],
                    (int)reader["EMP_ID"],
                    (int)reader["STATION_ID"],
                    (int)reader["SHIFT_ID"],
                    (DateTime)reader["SHIFTOPEN"],
                    (DateTime)reader["SHIFTCLOSE"]
                );
             return rEPORT;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public REPORT GetREPORTByID(int rEPORTID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetREPORTByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@REPORTID", SqlDbType.Int).Value = rEPORTID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetREPORTFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertREPORT(REPORT rEPORT)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertREPORT", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@REPORTID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@DT", SqlDbType.DateTime).Value = rEPORT.DT;
            cmd.Parameters.Add("@BEGININGBALANCE", SqlDbType.Int).Value = rEPORT.BEGININGBALANCE;
            cmd.Parameters.Add("@CASHFROM1", SqlDbType.Int).Value = rEPORT.CASHFROM1;
            cmd.Parameters.Add("@CASHFROM1REMARKS", SqlDbType.VarChar).Value = rEPORT.CASHFROM1REMARKS;
            cmd.Parameters.Add("@CASHFROM2", SqlDbType.Int).Value = rEPORT.CASHFROM2;
            cmd.Parameters.Add("@CASHFROM2REMARKS", SqlDbType.VarChar).Value = rEPORT.CASHFROM2REMARKS;
            cmd.Parameters.Add("@CASHFROM3", SqlDbType.Int).Value = rEPORT.CASHFROM3;
            cmd.Parameters.Add("@CASHFROM3REMARKS", SqlDbType.VarChar).Value = rEPORT.CASHFROM3REMARKS;
            cmd.Parameters.Add("@CASHFROM4", SqlDbType.Int).Value = rEPORT.CASHFROM4;
            cmd.Parameters.Add("@CASHFROM4REMARKS", SqlDbType.VarChar).Value = rEPORT.CASHFROM4REMARKS;
            cmd.Parameters.Add("@CASHFROM5", SqlDbType.Int).Value = rEPORT.CASHFROM5;
            cmd.Parameters.Add("@CASHFROM5REMARKS", SqlDbType.VarChar).Value = rEPORT.CASHFROM5REMARKS;
            cmd.Parameters.Add("@CASHFROM6", SqlDbType.Int).Value = rEPORT.CASHFROM6;
            cmd.Parameters.Add("@CASHFROM6REMARKS", SqlDbType.VarChar).Value = rEPORT.CASHFROM6REMARKS;
            cmd.Parameters.Add("@CASHFROM7", SqlDbType.Int).Value = rEPORT.CASHFROM7;
            cmd.Parameters.Add("@CASHFROM7REMARKS", SqlDbType.VarChar).Value = rEPORT.CASHFROM7REMARKS;
            cmd.Parameters.Add("@CASHFROM8", SqlDbType.Int).Value = rEPORT.CASHFROM8;
            cmd.Parameters.Add("@CASHFROM8REMARKS", SqlDbType.VarChar).Value = rEPORT.CASHFROM8REMARKS;
            cmd.Parameters.Add("@CASHFROM9", SqlDbType.Int).Value = rEPORT.CASHFROM9;
            cmd.Parameters.Add("@CASHFROM9REMARKS", SqlDbType.VarChar).Value = rEPORT.CASHFROM9REMARKS;
            cmd.Parameters.Add("@CASHFROM10", SqlDbType.Int).Value = rEPORT.CASHFROM10;
            cmd.Parameters.Add("@CASHFROM10REMARKS", SqlDbType.VarChar).Value = rEPORT.CASHFROM10REMARKS;
            cmd.Parameters.Add("@CASHFROM11", SqlDbType.Int).Value = rEPORT.CASHFROM11;
            cmd.Parameters.Add("@CASHFROM11REMARKS", SqlDbType.VarChar).Value = rEPORT.CASHFROM11REMARKS;
            cmd.Parameters.Add("@CASHFROM12", SqlDbType.Int).Value = rEPORT.CASHFROM12;
            cmd.Parameters.Add("@CASHFROM12REMARKS", SqlDbType.VarChar).Value = rEPORT.CASHFROM12REMARKS;
            cmd.Parameters.Add("@WU", SqlDbType.Int).Value = rEPORT.WU;
            cmd.Parameters.Add("@WUCOUNT", SqlDbType.Int).Value = rEPORT.WUCOUNT;
            cmd.Parameters.Add("@CONVPAY", SqlDbType.Int).Value = rEPORT.CONVPAY;
            cmd.Parameters.Add("@CONVPAYCOUNT", SqlDbType.Int).Value = rEPORT.CONVPAYCOUNT;
            cmd.Parameters.Add("@MO", SqlDbType.Int).Value = rEPORT.MO;
            cmd.Parameters.Add("@MOCOMM", SqlDbType.Int).Value = rEPORT.MOCOMM;
            cmd.Parameters.Add("@MOCOUNT", SqlDbType.Int).Value = rEPORT.MOCOUNT;
            cmd.Parameters.Add("@FEDILITY", SqlDbType.Int).Value = rEPORT.FEDILITY;
            cmd.Parameters.Add("@FEDILITYCOMM", SqlDbType.Int).Value = rEPORT.FEDILITYCOMM;
            cmd.Parameters.Add("@FEDILITYCOUNT", SqlDbType.Int).Value = rEPORT.FEDILITYCOUNT;
            cmd.Parameters.Add("@GLOBALEXPRESS", SqlDbType.Int).Value = rEPORT.GLOBALEXPRESS;
            cmd.Parameters.Add("@GLOBALEXPRESSCOMM", SqlDbType.Int).Value = rEPORT.GLOBALEXPRESSCOMM;
            cmd.Parameters.Add("@GLOBALEXPRESSCOUNT", SqlDbType.Int).Value = rEPORT.GLOBALEXPRESSCOUNT;
            cmd.Parameters.Add("@CHECKFREEPAY", SqlDbType.Int).Value = rEPORT.CHECKFREEPAY;
            cmd.Parameters.Add("@CHECKFREEPAYCOMM", SqlDbType.Int).Value = rEPORT.CHECKFREEPAYCOMM;
            cmd.Parameters.Add("@CHECKFREEPAYCOUNT", SqlDbType.Int).Value = rEPORT.CHECKFREEPAYCOUNT;
            cmd.Parameters.Add("@PRECASH", SqlDbType.Int).Value = rEPORT.PRECASH;
            cmd.Parameters.Add("@PRECASHCOMM", SqlDbType.Int).Value = rEPORT.PRECASHCOMM;
            cmd.Parameters.Add("@PRECASHCOUNT", SqlDbType.Int).Value = rEPORT.PRECASHCOUNT;
            cmd.Parameters.Add("@PHONECARD", SqlDbType.Int).Value = rEPORT.PHONECARD;
            cmd.Parameters.Add("@IDCARD", SqlDbType.Int).Value = rEPORT.IDCARD;
            cmd.Parameters.Add("@IDCARDCOUNT", SqlDbType.Int).Value = rEPORT.IDCARDCOUNT;
            cmd.Parameters.Add("@CHECKCOMM", SqlDbType.Int).Value = rEPORT.CHECKCOMM;
            cmd.Parameters.Add("@CHECKCOUNT", SqlDbType.Int).Value = rEPORT.CHECKCOUNT;
            cmd.Parameters.Add("@TOTALCASHIN", SqlDbType.Int).Value = rEPORT.TOTALCASHIN;
            cmd.Parameters.Add("@CASHDEPOSIT1", SqlDbType.Int).Value = rEPORT.CASHDEPOSIT1;
            cmd.Parameters.Add("@CASHDEPOSIT2", SqlDbType.Int).Value = rEPORT.CASHDEPOSIT2;
            cmd.Parameters.Add("@CASHDEPOSIT3", SqlDbType.Int).Value = rEPORT.CASHDEPOSIT3;
            cmd.Parameters.Add("@CASHDEPOSIT4", SqlDbType.Int).Value = rEPORT.CASHDEPOSIT4;
            cmd.Parameters.Add("@CASHDEPOSIT5", SqlDbType.Int).Value = rEPORT.CASHDEPOSIT5;
            cmd.Parameters.Add("@CHECKDEPOSIT1", SqlDbType.Int).Value = rEPORT.CHECKDEPOSIT1;
            cmd.Parameters.Add("@CHECKDEPOSIT2", SqlDbType.Int).Value = rEPORT.CHECKDEPOSIT2;
            cmd.Parameters.Add("@CHECKDEPOSIT3", SqlDbType.Int).Value = rEPORT.CHECKDEPOSIT3;
            cmd.Parameters.Add("@CHECKDEPOSIT4", SqlDbType.Int).Value = rEPORT.CHECKDEPOSIT4;
            cmd.Parameters.Add("@CHECKDEPOSIT5", SqlDbType.Int).Value = rEPORT.CHECKDEPOSIT5;
            cmd.Parameters.Add("@CHECKDEPOSIT6", SqlDbType.Int).Value = rEPORT.CHECKDEPOSIT6;
            cmd.Parameters.Add("@CHECKDEPOSIT7", SqlDbType.Int).Value = rEPORT.CHECKDEPOSIT7;
            cmd.Parameters.Add("@CHECKDEPOSIT8", SqlDbType.Int).Value = rEPORT.CHECKDEPOSIT8;
            cmd.Parameters.Add("@CHECKDEPOSIT9", SqlDbType.Int).Value = rEPORT.CHECKDEPOSIT9;
            cmd.Parameters.Add("@CHECKDEPOSIT10", SqlDbType.Int).Value = rEPORT.CHECKDEPOSIT10;
            cmd.Parameters.Add("@CHECKDEPOSIT11", SqlDbType.Int).Value = rEPORT.CHECKDEPOSIT11;
            cmd.Parameters.Add("@CHECKDEPOSIT12", SqlDbType.Int).Value = rEPORT.CHECKDEPOSIT12;
            cmd.Parameters.Add("@CASHTRANSFER1", SqlDbType.Int).Value = rEPORT.CASHTRANSFER1;
            cmd.Parameters.Add("@CASHTRANSFER1REMARKS", SqlDbType.VarChar).Value = rEPORT.CASHTRANSFER1REMARKS;
            cmd.Parameters.Add("@CASHTRANSFER2", SqlDbType.Int).Value = rEPORT.CASHTRANSFER2;
            cmd.Parameters.Add("@CASHTRANSFER2REMARKS", SqlDbType.VarChar).Value = rEPORT.CASHTRANSFER2REMARKS;
            cmd.Parameters.Add("@CASHTRANSFER3", SqlDbType.Int).Value = rEPORT.CASHTRANSFER3;
            cmd.Parameters.Add("@CASHTRANSFER3REMARKS", SqlDbType.VarChar).Value = rEPORT.CASHTRANSFER3REMARKS;
            cmd.Parameters.Add("@CASHTRANSFER4", SqlDbType.Int).Value = rEPORT.CASHTRANSFER4;
            cmd.Parameters.Add("@CASHTRANSFER4REMARKS", SqlDbType.VarChar).Value = rEPORT.CASHTRANSFER4REMARKS;
            cmd.Parameters.Add("@CASHTRANSFER5", SqlDbType.Int).Value = rEPORT.CASHTRANSFER5;
            cmd.Parameters.Add("@CASHTRANSFER5REMARKS", SqlDbType.VarChar).Value = rEPORT.CASHTRANSFER5REMARKS;
            cmd.Parameters.Add("@CASHTRANSFER6", SqlDbType.Int).Value = rEPORT.CASHTRANSFER6;
            cmd.Parameters.Add("@CASHTRANSFER6REMARKS", SqlDbType.VarChar).Value = rEPORT.CASHTRANSFER6REMARKS;
            cmd.Parameters.Add("@CASHTRANSFER7", SqlDbType.Int).Value = rEPORT.CASHTRANSFER7;
            cmd.Parameters.Add("@CASHTRANSFER7REMARKS", SqlDbType.VarChar).Value = rEPORT.CASHTRANSFER7REMARKS;
            cmd.Parameters.Add("@CASHTRANSFER8", SqlDbType.Int).Value = rEPORT.CASHTRANSFER8;
            cmd.Parameters.Add("@CASHTRANSFER8REMARKS", SqlDbType.VarChar).Value = rEPORT.CASHTRANSFER8REMARKS;
            cmd.Parameters.Add("@FEDILITYDEPOSIT", SqlDbType.Int).Value = rEPORT.FEDILITYDEPOSIT;
            cmd.Parameters.Add("@CHECKFREEPAYDEPOSIT", SqlDbType.Int).Value = rEPORT.CHECKFREEPAYDEPOSIT;
            cmd.Parameters.Add("@CONVPAYDEPOSIT", SqlDbType.Int).Value = rEPORT.CONVPAYDEPOSIT;
            cmd.Parameters.Add("@WUPAYOUT", SqlDbType.Int).Value = rEPORT.WUPAYOUT;
            cmd.Parameters.Add("@CREDITCARD", SqlDbType.Int).Value = rEPORT.CREDITCARD;
            cmd.Parameters.Add("@EXPENSES", SqlDbType.Int).Value = rEPORT.EXPENSES;
            cmd.Parameters.Add("@TOTALCASHOUT", SqlDbType.Int).Value = rEPORT.TOTALCASHOUT;
            cmd.Parameters.Add("@TOTALBALANCE", SqlDbType.Int).Value = rEPORT.TOTALBALANCE;
            cmd.Parameters.Add("@ACTUALBALACE", SqlDbType.Int).Value = rEPORT.ACTUALBALACE;
            cmd.Parameters.Add("@SHORTOVER", SqlDbType.Int).Value = rEPORT.SHORTOVER;
            cmd.Parameters.Add("@EMP_ID", SqlDbType.Int).Value = rEPORT.EMP_ID;
            cmd.Parameters.Add("@STATION_ID", SqlDbType.Int).Value = rEPORT.STATION_ID;
            cmd.Parameters.Add("@SHIFT_ID", SqlDbType.Int).Value = rEPORT.SHIFT_ID;
            cmd.Parameters.Add("@SHIFTOPEN", SqlDbType.DateTime).Value = rEPORT.SHIFTOPEN;
            cmd.Parameters.Add("@SHIFTCLOSE", SqlDbType.DateTime).Value = rEPORT.SHIFTCLOSE;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@REPORTID"].Value;
        }
    }

    public bool UpdateREPORT(REPORT rEPORT)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateREPORT", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@REPORTID", SqlDbType.Int).Value = rEPORT.REPORTID;
            cmd.Parameters.Add("@DT", SqlDbType.DateTime).Value = rEPORT.DT;
            cmd.Parameters.Add("@BEGININGBALANCE", SqlDbType.Int).Value = rEPORT.BEGININGBALANCE;
            cmd.Parameters.Add("@CASHFROM1", SqlDbType.Int).Value = rEPORT.CASHFROM1;
            cmd.Parameters.Add("@CASHFROM1REMARKS", SqlDbType.VarChar).Value = rEPORT.CASHFROM1REMARKS;
            cmd.Parameters.Add("@CASHFROM2", SqlDbType.Int).Value = rEPORT.CASHFROM2;
            cmd.Parameters.Add("@CASHFROM2REMARKS", SqlDbType.VarChar).Value = rEPORT.CASHFROM2REMARKS;
            cmd.Parameters.Add("@CASHFROM3", SqlDbType.Int).Value = rEPORT.CASHFROM3;
            cmd.Parameters.Add("@CASHFROM3REMARKS", SqlDbType.VarChar).Value = rEPORT.CASHFROM3REMARKS;
            cmd.Parameters.Add("@CASHFROM4", SqlDbType.Int).Value = rEPORT.CASHFROM4;
            cmd.Parameters.Add("@CASHFROM4REMARKS", SqlDbType.VarChar).Value = rEPORT.CASHFROM4REMARKS;
            cmd.Parameters.Add("@CASHFROM5", SqlDbType.Int).Value = rEPORT.CASHFROM5;
            cmd.Parameters.Add("@CASHFROM5REMARKS", SqlDbType.VarChar).Value = rEPORT.CASHFROM5REMARKS;
            cmd.Parameters.Add("@CASHFROM6", SqlDbType.Int).Value = rEPORT.CASHFROM6;
            cmd.Parameters.Add("@CASHFROM6REMARKS", SqlDbType.VarChar).Value = rEPORT.CASHFROM6REMARKS;
            cmd.Parameters.Add("@CASHFROM7", SqlDbType.Int).Value = rEPORT.CASHFROM7;
            cmd.Parameters.Add("@CASHFROM7REMARKS", SqlDbType.VarChar).Value = rEPORT.CASHFROM7REMARKS;
            cmd.Parameters.Add("@CASHFROM8", SqlDbType.Int).Value = rEPORT.CASHFROM8;
            cmd.Parameters.Add("@CASHFROM8REMARKS", SqlDbType.VarChar).Value = rEPORT.CASHFROM8REMARKS;
            cmd.Parameters.Add("@CASHFROM9", SqlDbType.Int).Value = rEPORT.CASHFROM9;
            cmd.Parameters.Add("@CASHFROM9REMARKS", SqlDbType.VarChar).Value = rEPORT.CASHFROM9REMARKS;
            cmd.Parameters.Add("@CASHFROM10", SqlDbType.Int).Value = rEPORT.CASHFROM10;
            cmd.Parameters.Add("@CASHFROM10REMARKS", SqlDbType.VarChar).Value = rEPORT.CASHFROM10REMARKS;
            cmd.Parameters.Add("@CASHFROM11", SqlDbType.Int).Value = rEPORT.CASHFROM11;
            cmd.Parameters.Add("@CASHFROM11REMARKS", SqlDbType.VarChar).Value = rEPORT.CASHFROM11REMARKS;
            cmd.Parameters.Add("@CASHFROM12", SqlDbType.Int).Value = rEPORT.CASHFROM12;
            cmd.Parameters.Add("@CASHFROM12REMARKS", SqlDbType.VarChar).Value = rEPORT.CASHFROM12REMARKS;
            cmd.Parameters.Add("@WU", SqlDbType.Int).Value = rEPORT.WU;
            cmd.Parameters.Add("@WUCOUNT", SqlDbType.Int).Value = rEPORT.WUCOUNT;
            cmd.Parameters.Add("@CONVPAY", SqlDbType.Int).Value = rEPORT.CONVPAY;
            cmd.Parameters.Add("@CONVPAYCOUNT", SqlDbType.Int).Value = rEPORT.CONVPAYCOUNT;
            cmd.Parameters.Add("@MO", SqlDbType.Int).Value = rEPORT.MO;
            cmd.Parameters.Add("@MOCOMM", SqlDbType.Int).Value = rEPORT.MOCOMM;
            cmd.Parameters.Add("@MOCOUNT", SqlDbType.Int).Value = rEPORT.MOCOUNT;
            cmd.Parameters.Add("@FEDILITY", SqlDbType.Int).Value = rEPORT.FEDILITY;
            cmd.Parameters.Add("@FEDILITYCOMM", SqlDbType.Int).Value = rEPORT.FEDILITYCOMM;
            cmd.Parameters.Add("@FEDILITYCOUNT", SqlDbType.Int).Value = rEPORT.FEDILITYCOUNT;
            cmd.Parameters.Add("@GLOBALEXPRESS", SqlDbType.Int).Value = rEPORT.GLOBALEXPRESS;
            cmd.Parameters.Add("@GLOBALEXPRESSCOMM", SqlDbType.Int).Value = rEPORT.GLOBALEXPRESSCOMM;
            cmd.Parameters.Add("@GLOBALEXPRESSCOUNT", SqlDbType.Int).Value = rEPORT.GLOBALEXPRESSCOUNT;
            cmd.Parameters.Add("@CHECKFREEPAY", SqlDbType.Int).Value = rEPORT.CHECKFREEPAY;
            cmd.Parameters.Add("@CHECKFREEPAYCOMM", SqlDbType.Int).Value = rEPORT.CHECKFREEPAYCOMM;
            cmd.Parameters.Add("@CHECKFREEPAYCOUNT", SqlDbType.Int).Value = rEPORT.CHECKFREEPAYCOUNT;
            cmd.Parameters.Add("@PRECASH", SqlDbType.Int).Value = rEPORT.PRECASH;
            cmd.Parameters.Add("@PRECASHCOMM", SqlDbType.Int).Value = rEPORT.PRECASHCOMM;
            cmd.Parameters.Add("@PRECASHCOUNT", SqlDbType.Int).Value = rEPORT.PRECASHCOUNT;
            cmd.Parameters.Add("@PHONECARD", SqlDbType.Int).Value = rEPORT.PHONECARD;
            cmd.Parameters.Add("@IDCARD", SqlDbType.Int).Value = rEPORT.IDCARD;
            cmd.Parameters.Add("@IDCARDCOUNT", SqlDbType.Int).Value = rEPORT.IDCARDCOUNT;
            cmd.Parameters.Add("@CHECKCOMM", SqlDbType.Int).Value = rEPORT.CHECKCOMM;
            cmd.Parameters.Add("@CHECKCOUNT", SqlDbType.Int).Value = rEPORT.CHECKCOUNT;
            cmd.Parameters.Add("@TOTALCASHIN", SqlDbType.Int).Value = rEPORT.TOTALCASHIN;
            cmd.Parameters.Add("@CASHDEPOSIT1", SqlDbType.Int).Value = rEPORT.CASHDEPOSIT1;
            cmd.Parameters.Add("@CASHDEPOSIT2", SqlDbType.Int).Value = rEPORT.CASHDEPOSIT2;
            cmd.Parameters.Add("@CASHDEPOSIT3", SqlDbType.Int).Value = rEPORT.CASHDEPOSIT3;
            cmd.Parameters.Add("@CASHDEPOSIT4", SqlDbType.Int).Value = rEPORT.CASHDEPOSIT4;
            cmd.Parameters.Add("@CASHDEPOSIT5", SqlDbType.Int).Value = rEPORT.CASHDEPOSIT5;
            cmd.Parameters.Add("@CHECKDEPOSIT1", SqlDbType.Int).Value = rEPORT.CHECKDEPOSIT1;
            cmd.Parameters.Add("@CHECKDEPOSIT2", SqlDbType.Int).Value = rEPORT.CHECKDEPOSIT2;
            cmd.Parameters.Add("@CHECKDEPOSIT3", SqlDbType.Int).Value = rEPORT.CHECKDEPOSIT3;
            cmd.Parameters.Add("@CHECKDEPOSIT4", SqlDbType.Int).Value = rEPORT.CHECKDEPOSIT4;
            cmd.Parameters.Add("@CHECKDEPOSIT5", SqlDbType.Int).Value = rEPORT.CHECKDEPOSIT5;
            cmd.Parameters.Add("@CHECKDEPOSIT6", SqlDbType.Int).Value = rEPORT.CHECKDEPOSIT6;
            cmd.Parameters.Add("@CHECKDEPOSIT7", SqlDbType.Int).Value = rEPORT.CHECKDEPOSIT7;
            cmd.Parameters.Add("@CHECKDEPOSIT8", SqlDbType.Int).Value = rEPORT.CHECKDEPOSIT8;
            cmd.Parameters.Add("@CHECKDEPOSIT9", SqlDbType.Int).Value = rEPORT.CHECKDEPOSIT9;
            cmd.Parameters.Add("@CHECKDEPOSIT10", SqlDbType.Int).Value = rEPORT.CHECKDEPOSIT10;
            cmd.Parameters.Add("@CHECKDEPOSIT11", SqlDbType.Int).Value = rEPORT.CHECKDEPOSIT11;
            cmd.Parameters.Add("@CHECKDEPOSIT12", SqlDbType.Int).Value = rEPORT.CHECKDEPOSIT12;
            cmd.Parameters.Add("@CASHTRANSFER1", SqlDbType.Int).Value = rEPORT.CASHTRANSFER1;
            cmd.Parameters.Add("@CASHTRANSFER1REMARKS", SqlDbType.VarChar).Value = rEPORT.CASHTRANSFER1REMARKS;
            cmd.Parameters.Add("@CASHTRANSFER2", SqlDbType.Int).Value = rEPORT.CASHTRANSFER2;
            cmd.Parameters.Add("@CASHTRANSFER2REMARKS", SqlDbType.VarChar).Value = rEPORT.CASHTRANSFER2REMARKS;
            cmd.Parameters.Add("@CASHTRANSFER3", SqlDbType.Int).Value = rEPORT.CASHTRANSFER3;
            cmd.Parameters.Add("@CASHTRANSFER3REMARKS", SqlDbType.VarChar).Value = rEPORT.CASHTRANSFER3REMARKS;
            cmd.Parameters.Add("@CASHTRANSFER4", SqlDbType.Int).Value = rEPORT.CASHTRANSFER4;
            cmd.Parameters.Add("@CASHTRANSFER4REMARKS", SqlDbType.VarChar).Value = rEPORT.CASHTRANSFER4REMARKS;
            cmd.Parameters.Add("@CASHTRANSFER5", SqlDbType.Int).Value = rEPORT.CASHTRANSFER5;
            cmd.Parameters.Add("@CASHTRANSFER5REMARKS", SqlDbType.VarChar).Value = rEPORT.CASHTRANSFER5REMARKS;
            cmd.Parameters.Add("@CASHTRANSFER6", SqlDbType.Int).Value = rEPORT.CASHTRANSFER6;
            cmd.Parameters.Add("@CASHTRANSFER6REMARKS", SqlDbType.VarChar).Value = rEPORT.CASHTRANSFER6REMARKS;
            cmd.Parameters.Add("@CASHTRANSFER7", SqlDbType.Int).Value = rEPORT.CASHTRANSFER7;
            cmd.Parameters.Add("@CASHTRANSFER7REMARKS", SqlDbType.VarChar).Value = rEPORT.CASHTRANSFER7REMARKS;
            cmd.Parameters.Add("@CASHTRANSFER8", SqlDbType.Int).Value = rEPORT.CASHTRANSFER8;
            cmd.Parameters.Add("@CASHTRANSFER8REMARKS", SqlDbType.VarChar).Value = rEPORT.CASHTRANSFER8REMARKS;
            cmd.Parameters.Add("@FEDILITYDEPOSIT", SqlDbType.Int).Value = rEPORT.FEDILITYDEPOSIT;
            cmd.Parameters.Add("@CHECKFREEPAYDEPOSIT", SqlDbType.Int).Value = rEPORT.CHECKFREEPAYDEPOSIT;
            cmd.Parameters.Add("@CONVPAYDEPOSIT", SqlDbType.Int).Value = rEPORT.CONVPAYDEPOSIT;
            cmd.Parameters.Add("@WUPAYOUT", SqlDbType.Int).Value = rEPORT.WUPAYOUT;
            cmd.Parameters.Add("@CREDITCARD", SqlDbType.Int).Value = rEPORT.CREDITCARD;
            cmd.Parameters.Add("@EXPENSES", SqlDbType.Int).Value = rEPORT.EXPENSES;
            cmd.Parameters.Add("@TOTALCASHOUT", SqlDbType.Int).Value = rEPORT.TOTALCASHOUT;
            cmd.Parameters.Add("@TOTALBALANCE", SqlDbType.Int).Value = rEPORT.TOTALBALANCE;
            cmd.Parameters.Add("@ACTUALBALACE", SqlDbType.Int).Value = rEPORT.ACTUALBALACE;
            cmd.Parameters.Add("@SHORTOVER", SqlDbType.Int).Value = rEPORT.SHORTOVER;
            cmd.Parameters.Add("@EMP_ID", SqlDbType.Int).Value = rEPORT.EMP_ID;
            cmd.Parameters.Add("@STATION_ID", SqlDbType.Int).Value = rEPORT.STATION_ID;
            cmd.Parameters.Add("@SHIFT_ID", SqlDbType.Int).Value = rEPORT.SHIFT_ID;
            cmd.Parameters.Add("@SHIFTOPEN", SqlDbType.DateTime).Value = rEPORT.SHIFTOPEN;
            cmd.Parameters.Add("@SHIFTCLOSE", SqlDbType.DateTime).Value = rEPORT.SHIFTCLOSE;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
