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

public class SqlTRANSProvider:DataAccessObject
{
	public SqlTRANSProvider()
    {
    }


    public bool DeleteTRANS(int tRANSID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteTRANS", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TRANSID", SqlDbType.Int).Value = tRANSID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
    
    public List<TRANS> GetAllTRANSs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllTRANSs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetTRANSsFromReader(reader);
        }
    }

    public List<TRANS> GetAllTRANSsByCustomerID(int customerID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllTRANSsByCustomerID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CUSTID", SqlDbType.Int).Value = customerID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetTRANSsFromReader(reader);
        }
    }
    public List<TRANS> GetTRANSsFromReader(IDataReader reader)
    {
        List<TRANS> tRANSs = new List<TRANS>();

        while (reader.Read())
        {
            tRANSs.Add(GetTRANSFromReader(reader));
        }
        return tRANSs;
    }

    public TRANS GetTRANSFromReader(IDataReader reader)
    {
        DateTime nullDate = DateTime.Parse(ConfigurationManager.AppSettings["NULL_DATE"].ToString());
        try
        {
            TRANS tRANS = new TRANS();
                
            tRANS.TRANSID=   reader["TRANSID"] != DBNull.Value? (int)reader["TRANSID"]:0;
            tRANS.CUSTID = reader["CUSTID"] != DBNull.Value ? (int)reader["CUSTID"] : 0;
            try
            {
                tRANS.CUSTDETAIL = reader["CUSTDETAIL"] != DBNull.Value ? reader["CUSTDETAIL"].ToString() : "";
            }
            catch (Exception ex)
            {
                tRANS.CUSTDETAIL = "";               
            }

            try
            {
                tRANS.CUSTFNAME = reader["CUSTFNAME"] != DBNull.Value ? reader["CUSTFNAME"].ToString() : "";
            }
            catch (Exception ex)
            {
                tRANS.CUSTFNAME = "";
            }

            try
            {
                tRANS.USERNAME = reader["USERNAME"] != DBNull.Value ? reader["USERNAME"].ToString() : "";
            }
            catch (Exception ex)
            {
                tRANS.CUSTFNAME = "";
            }


            try
            {
                tRANS.CUSTMNAME = reader["CUSTMNAME"] != DBNull.Value ? reader["CUSTMNAME"].ToString() : "";
            }
            catch (Exception ex)
            {
                tRANS.CUSTMNAME = "";
            }


            try
            {
                tRANS.CUSTLNAME = reader["CUSTLNAME"] != DBNull.Value ? reader["CUSTLNAME"].ToString() : "";
            }
            catch (Exception ex)
            {
                tRANS.CUSTLNAME = "";
            }


            try
            {
                tRANS.RECEIVERDETAIL = reader["RECEIVERDETAIL"] != DBNull.Value ? reader["RECEIVERDETAIL"].ToString() : "";
            }
            catch (Exception ex)
            {

                tRANS.RECEIVERDETAIL = "";
            }

            try
            {
                tRANS.LOCATIONDETAIL = reader["LOCATIONDETAIL"] != DBNull.Value ? reader["LOCATIONDETAIL"].ToString() : "";
            }
            catch (Exception ex)
            {
                tRANS.LOCATIONDETAIL = "";
            }

            tRANS.RECEIVERID=   reader["RECEIVERID"] != DBNull.Value ? (int)reader["RECEIVERID"] : 0;
            tRANS.LOCATIONID=   reader["LOCATIONID"] != DBNull.Value ? (int)reader["LOCATIONID"] : 0;
            tRANS.TRANSDT = reader["TRANSDT"] != DBNull.Value ? (DateTime)reader["TRANSDT"] : nullDate;
            tRANS.TRANSAMOUNT = reader["TRANSAMOUNT"] != DBNull.Value ? (decimal)reader["TRANSAMOUNT"] : 0;
            try
            {
                tRANS.TotalAmountWitinLastTenDays = reader["totalAmountWitinLastTenDays"] != DBNull.Value ? (decimal)reader["totalAmountWitinLastTenDays"] : 0;
            }
            catch (Exception ex)
            {
                tRANS.TotalAmountWitinLastTenDays = 0;
            }
                tRANS.TRANSFEES = reader["TRANSFEES"] != DBNull.Value ? (decimal)reader["TRANSFEES"] : 0;
            tRANS.TRANSOTHERFEES = reader["TRANSOTHERFEES"] != DBNull.Value ? (decimal)reader["TRANSOTHERFEES"] : 0;
            tRANS.CAUSETRANSOTHERFEES = reader["CAUSETRANSOTHERFEES"] != DBNull.Value ? reader["CAUSETRANSOTHERFEES"].ToString() : "";
            tRANS.TRANSPROMOCODE= reader["TRANSPROMOCODE"] != DBNull.Value ? reader["TRANSPROMOCODE"].ToString() : "";
            tRANS.TRANSPROMO= reader["TRANSPROMO"] != DBNull.Value ? (int)reader["TRANSPROMO"] : 0;
            tRANS.TRANSTOTALAMOUNT = reader["TRANSTOTALAMOUNT"] != DBNull.Value ? (decimal)reader["TRANSTOTALAMOUNT"] : 0;
            tRANS.FLAG_SM_RECEIVER= reader["FLAG_SM_RECEIVER"] != DBNull.Value ? char.Parse(reader["FLAG_SM_RECEIVER"].ToString()): ' ';
            tRANS.SM_RECEIVER= reader["SM_RECEIVER"] != DBNull.Value ? reader["SM_RECEIVER"].ToString() : "";
            tRANS.FLAG_CALL_RECEIVER= reader["FLAG_CALL_RECEIVER"] != DBNull.Value ? char.Parse(reader["FLAG_CALL_RECEIVER"].ToString()) : ' ';
            tRANS.RECEIVERPHONENO= reader["RECEIVERPHONENO"] != DBNull.Value ? reader["RECEIVERPHONENO"].ToString() : "";
            tRANS.FLAG_DD= reader["FLAG_DD"] != DBNull.Value ? char.Parse(reader["FLAG_DD"].ToString()) : ' ';
            tRANS.FLAG_TESTQUESTION= reader["FLAG_TESTQUESTION"] != DBNull.Value ? char.Parse(reader["FLAG_TESTQUESTION"].ToString()) : ' ';
            tRANS.TESTQUESTION= reader["TESTQUESTION"] != DBNull.Value ? reader["TESTQUESTION"].ToString() : "";
            tRANS.TESTANSWER= reader["TESTANSWER"] != DBNull.Value ? reader["TESTANSWER"].ToString() : "";
            tRANS.FLAG_CALLSENDER= reader["FLAG_CALLSENDER"] != DBNull.Value ? char.Parse(reader["FLAG_CALLSENDER"].ToString()) : ' ';
            tRANS.FLAG_SMSSENDER= reader["FLAG_SMSSENDER"] != DBNull.Value ? char.Parse(reader["FLAG_SMSSENDER"].ToString()) : ' ';
            tRANS.FLAG_EMAILSENDER= reader["FLAG_EMAILSENDER"] != DBNull.Value ? char.Parse(reader["FLAG_EMAILSENDER"].ToString()) : ' ';
            tRANS.SENDEREMAILADDRESS= reader["SENDEREMAILADDRESS"] != DBNull.Value ? reader["SENDEREMAILADDRESS"].ToString() : "";
            tRANS.TRANSSTATUS= reader["TRANSSTATUS"] != DBNull.Value ? reader["TRANSSTATUS"].ToString() : "";
            tRANS.TRANSSTATUS = reverceDeleteAndReturn(tRANS.TRANSSTATUS);
            tRANS.TRANSRECEIVEDID= reader["TRANSRECEIVEDID"] != DBNull.Value ? reader["TRANSRECEIVEDID"].ToString() : "";
            tRANS.TRANSRECEIVEDATE= reader["TRANSRECEIVEDATE"] != DBNull.Value ? (DateTime)reader["TRANSRECEIVEDATE"] : nullDate;
            tRANS.CREATEDBY= reader["CREATEDBY"] != DBNull.Value ? (int)reader["CREATEDBY"] : 0;
            tRANS.CREATEDON= reader["CREATEDON"] != DBNull.Value ? (DateTime)reader["CREATEDON"] : nullDate;
            tRANS.UPDATEDBY= reader["UPDATEDBY"] != DBNull.Value ? (int)reader["UPDATEDBY"] : 0;
            tRANS.UPDATEDON= reader["UPDATEDON"] != DBNull.Value ? (DateTime)reader["UPDATEDON"] : nullDate;
            tRANS.AGENTID= reader["AGENTID"] != DBNull.Value ? (int)reader["AGENTID"] : 0;
            tRANS.REFCODE= reader["REFCODE"] != DBNull.Value ? reader["REFCODE"].ToString() : "";
            tRANS.IsPending = (tRANS.TRANSSTATUS == "PENDING" || tRANS.TRANSSTATUS == "PARTIALLY-PAID") ? true : false;    
             return tRANS;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    private string reverceDeleteAndReturn(string status)
    {
        if (status.ToUpper() == "VOID")
            return "RETURN";
        else if (status.ToUpper() == "RETURN")
            return "VOID";
        else return status;

    }

    public TRANS GetTRANSByID(int tRANSID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetTRANSByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@TRANSID", SqlDbType.Int).Value = tRANSID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetTRANSFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public TRANS GetTRANSByRefCode(string refCode)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetTRANSByREFCODE", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@REFCODE", SqlDbType.NVarChar).Value = refCode;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetTRANSFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }
    
    public List<TRANS> GetTRANSByAgnetID(int aGENTID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbuMatu_GetAllPaymentInfosByAgentID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AGENTID", SqlDbType.Int).Value = aGENTID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetTRANSsFromReader(reader);
        }
    }

    public List<TRANS> GetAllTRANSsByTRANSDT_CUSTOMER(int cUSTOMERID, DateTime tRANSDT)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbuMatu_GetAllTRANSsByTRANSDT_CUSTOMER", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CUSTID", SqlDbType.Int).Value = cUSTOMERID;
            command.Parameters.Add("@TRANSFROMDT", SqlDbType.DateTime).Value = tRANSDT;
            //command.Parameters.Add("@TRANSTODT", SqlDbType.DateTime).Value = tRANSDT.AddDays(1);
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetTRANSsFromReader(reader);
        }
    }

    public List<TRANS> GetTRANSByAgnetIDByDateNAmount(int aGENTID, string fromDate, string toDate, int amount)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbuMatu_GetAllPaymentInfosByAgentIDByDateNAmount", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AGENTID", SqlDbType.Int).Value = aGENTID;
            command.Parameters.Add("@FROMDATE", SqlDbType.DateTime).Value = DateTime.Parse(fromDate);
            command.Parameters.Add("@TODATE", SqlDbType.DateTime).Value = DateTime.Parse(toDate);;
            command.Parameters.Add("@AMOUNT", SqlDbType.Int).Value = amount;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetTRANSsFromReader(reader);
        }
    }

    public List<TRANS> GetAllSARFromTransBYDate(DateTime fromDate, DateTime toDate)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllSARFromTransBYDate", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = fromDate;
            command.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = toDate;
            
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetTRANSsFromReaderFORSAR(reader);
        }
    }

    public List<TRANS> GetTRANSsFromReaderFORSAR(IDataReader reader)
    {
        List<TRANS> tRANSs = new List<TRANS>();

        while (reader.Read())
        {
            tRANSs.Add(GetTRANSFromReaderFORSAR(reader));
        }
        return tRANSs;
    }

    public TRANS GetTRANSFromReaderFORSAR(IDataReader reader)
    {
        DateTime nullDate = DateTime.Parse(ConfigurationManager.AppSettings["NULL_DATE"].ToString());
        try
        {
            TRANS tRANS = new TRANS();          
            tRANS.CUSTID = reader["CUSTID"] != DBNull.Value ? (int)reader["CUSTID"] : 0;
            tRANS.TRANSDT = reader["TRANSDT"] != DBNull.Value ? (DateTime)reader["TRANSDT"] : nullDate;
            tRANS.TRANSTOTALAMOUNT = reader["TRANSTOTALAMOUNT"] != DBNull.Value ? (decimal)reader["TRANSTOTALAMOUNT"] : 0;
            
            return tRANS;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public List<TRANS> GetTRANSByAgnetIDnLocationIDByDateNAmount(int locationID,int aGENTID, string fromDate, string toDate, int amount)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbuMatu_GetAllPaymentInfosByAgentIDnLocationIDByDateNAmount", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@LOCATIONID", SqlDbType.Int).Value = locationID;
            command.Parameters.Add("@AGENTID", SqlDbType.Int).Value = aGENTID;
            command.Parameters.Add("@FROMDATE", SqlDbType.DateTime).Value = DateTime.Parse(fromDate);
            command.Parameters.Add("@TODATE", SqlDbType.DateTime).Value = DateTime.Parse(toDate);;
            command.Parameters.Add("@AMOUNT", SqlDbType.Int).Value = amount;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetTRANSsFromReader(reader);
        }
    }

    public List<TRANS> GetTRANSByAgnetIDnLocationIDByDateNAmountStatus(string status, int locationID, int aGENTID, string fromDate, string toDate, int amount)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbuMatu_GetAllPaymentInfosByAgentIDnLocationIDByDateNAmountStatus", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@LOCATIONID", SqlDbType.Int).Value = locationID;
            command.Parameters.Add("@AGENTID", SqlDbType.Int).Value = aGENTID;
            command.Parameters.Add("@FROMDATE", SqlDbType.DateTime).Value = DateTime.Parse(fromDate);
            command.Parameters.Add("@TODATE", SqlDbType.DateTime).Value = DateTime.Parse(toDate);
            command.Parameters.Add("@AMOUNT", SqlDbType.Int).Value = amount;
            command.Parameters.Add("@STATUS", SqlDbType.NVarChar).Value = status;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetTRANSsFromReader(reader);
        }
    }

    public List<TRANS> GetTRANSByAgnetIDnLocationIDByDateNAmountCustomerID(string customerIDs, string receiverIDs, int locationID, int aGENTID, string fromDate, string toDate, int amount)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbuMatu_GetAllPaymentInfosByAgentIDnLocationIDByDateNAmountByCustomerIDs", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@LOCATIONID", SqlDbType.Int).Value = locationID;
            command.Parameters.Add("@AGENTID", SqlDbType.Int).Value = aGENTID;
            command.Parameters.Add("@FROMDATE", SqlDbType.DateTime).Value = DateTime.Parse(fromDate);
            command.Parameters.Add("@TODATE", SqlDbType.DateTime).Value = DateTime.Parse(toDate);;
            command.Parameters.Add("@AMOUNT", SqlDbType.Int).Value = amount;
            command.Parameters.Add("@CUSTIDs", SqlDbType.NVarChar).Value = customerIDs;
            command.Parameters.Add("@RECEIVERIDs", SqlDbType.NVarChar).Value = receiverIDs;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetTRANSsFromReader(reader);
        }
    }



    public List<TRANS> GetTRANSByAgnetIDnLocationIDsByDateNAmount(string locationIDs, int aGENTID, string fromDate, string toDate, int amount)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbuMatu_GetAllTRANSByAgentIDnLocationIDsByDateNAmount", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@LOCATIONIDs", SqlDbType.NVarChar).Value = locationIDs;
            command.Parameters.Add("@AGENTID", SqlDbType.Int).Value = aGENTID;
            command.Parameters.Add("@FROMDATE", SqlDbType.DateTime).Value = DateTime.Parse(fromDate);
            command.Parameters.Add("@TODATE", SqlDbType.DateTime).Value = DateTime.Parse(toDate);;
            command.Parameters.Add("@AMOUNT", SqlDbType.Int).Value = amount;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetTRANSsFromReader(reader);
        }
    }


    public int InsertTRANS(TRANS tRANS)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertTRANS", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TRANSID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@CUSTID", SqlDbType.Int).Value = tRANS.CUSTID;
            cmd.Parameters.Add("@RECEIVERID", SqlDbType.Int).Value = tRANS.RECEIVERID;
            cmd.Parameters.Add("@LOCATIONID", SqlDbType.Int).Value = tRANS.LOCATIONID;
            cmd.Parameters.Add("@TRANSDT", SqlDbType.DateTime).Value = tRANS.TRANSDT;
            cmd.Parameters.Add("@TRANSAMOUNT", SqlDbType.Decimal).Value = tRANS.TRANSAMOUNT;
            cmd.Parameters.Add("@TRANSFEES", SqlDbType.Decimal).Value = tRANS.TRANSFEES;
            cmd.Parameters.Add("@TRANSOTHERFEES", SqlDbType.Decimal).Value = tRANS.TRANSOTHERFEES;
            cmd.Parameters.Add("@CAUSETRANSOTHERFEES", SqlDbType.VarChar).Value = tRANS.CAUSETRANSOTHERFEES;
            cmd.Parameters.Add("@TRANSPROMOCODE", SqlDbType.VarChar).Value = tRANS.TRANSPROMOCODE;
            cmd.Parameters.Add("@TRANSPROMO", SqlDbType.Int).Value = tRANS.TRANSPROMO;
            cmd.Parameters.Add("@TRANSTOTALAMOUNT", SqlDbType.Decimal).Value = tRANS.TRANSTOTALAMOUNT;
            cmd.Parameters.Add("@FLAG_SM_RECEIVER", SqlDbType.Char).Value = tRANS.FLAG_SM_RECEIVER;
            cmd.Parameters.Add("@SM_RECEIVER", SqlDbType.VarChar).Value = tRANS.SM_RECEIVER;
            cmd.Parameters.Add("@FLAG_CALL_RECEIVER", SqlDbType.Char).Value = tRANS.FLAG_CALL_RECEIVER;
            cmd.Parameters.Add("@RECEIVERPHONENO", SqlDbType.VarChar).Value = tRANS.RECEIVERPHONENO;
            cmd.Parameters.Add("@FLAG_DD", SqlDbType.Char).Value = tRANS.FLAG_DD;
            cmd.Parameters.Add("@FLAG_TESTQUESTION", SqlDbType.Char).Value = tRANS.FLAG_TESTQUESTION;
            cmd.Parameters.Add("@TESTQUESTION", SqlDbType.VarChar).Value = tRANS.TESTQUESTION;
            cmd.Parameters.Add("@TESTANSWER", SqlDbType.VarChar).Value = tRANS.TESTANSWER;
            cmd.Parameters.Add("@FLAG_CALLSENDER", SqlDbType.Char).Value = tRANS.FLAG_CALLSENDER;
            cmd.Parameters.Add("@FLAG_SMSSENDER", SqlDbType.Char).Value = tRANS.FLAG_SMSSENDER;
            cmd.Parameters.Add("@FLAG_EMAILSENDER", SqlDbType.Char).Value = tRANS.FLAG_EMAILSENDER;
            cmd.Parameters.Add("@SENDEREMAILADDRESS", SqlDbType.VarChar).Value = tRANS.SENDEREMAILADDRESS;
            cmd.Parameters.Add("@TRANSSTATUS", SqlDbType.VarChar).Value = tRANS.TRANSSTATUS;
            cmd.Parameters.Add("@TRANSRECEIVEDID", SqlDbType.VarChar).Value = tRANS.TRANSRECEIVEDID;
            cmd.Parameters.Add("@TRANSRECEIVEDATE", SqlDbType.DateTime).Value = tRANS.TRANSRECEIVEDATE;
            cmd.Parameters.Add("@CREATEDBY", SqlDbType.Int).Value = tRANS.CREATEDBY;
            cmd.Parameters.Add("@CREATEDON", SqlDbType.DateTime).Value = tRANS.CREATEDON;
            cmd.Parameters.Add("@UPDATEDBY", SqlDbType.Int).Value = tRANS.UPDATEDBY;
            cmd.Parameters.Add("@UPDATEDON", SqlDbType.DateTime).Value = tRANS.UPDATEDON;
            cmd.Parameters.Add("@AGENTID", SqlDbType.Int).Value = tRANS.AGENTID;
            cmd.Parameters.Add("@REFCODE", SqlDbType.VarChar).Value = tRANS.REFCODE;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@TRANSID"].Value;
        }
    }

    public bool UpdateTRANS(TRANS tRANS)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateTRANS", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TRANSID", SqlDbType.Int).Value = tRANS.TRANSID;
            cmd.Parameters.Add("@CUSTID", SqlDbType.Int).Value = tRANS.CUSTID;
            cmd.Parameters.Add("@RECEIVERID", SqlDbType.Int).Value = tRANS.RECEIVERID;
            cmd.Parameters.Add("@LOCATIONID", SqlDbType.Int).Value = tRANS.LOCATIONID;
            cmd.Parameters.Add("@TRANSDT", SqlDbType.DateTime).Value = tRANS.TRANSDT;
            cmd.Parameters.Add("@TRANSAMOUNT", SqlDbType.Decimal).Value = tRANS.TRANSAMOUNT;
            cmd.Parameters.Add("@TRANSFEES", SqlDbType.Decimal).Value = tRANS.TRANSFEES;
            cmd.Parameters.Add("@TRANSOTHERFEES", SqlDbType.Decimal).Value = tRANS.TRANSOTHERFEES;
            cmd.Parameters.Add("@CAUSETRANSOTHERFEES", SqlDbType.VarChar).Value = tRANS.CAUSETRANSOTHERFEES;
            cmd.Parameters.Add("@TRANSPROMOCODE", SqlDbType.VarChar).Value = tRANS.TRANSPROMOCODE;
            cmd.Parameters.Add("@TRANSPROMO", SqlDbType.Int).Value = tRANS.TRANSPROMO;
            cmd.Parameters.Add("@TRANSTOTALAMOUNT", SqlDbType.Decimal).Value = tRANS.TRANSTOTALAMOUNT;
            cmd.Parameters.Add("@FLAG_SM_RECEIVER", SqlDbType.Char).Value = tRANS.FLAG_SM_RECEIVER;
            cmd.Parameters.Add("@SM_RECEIVER", SqlDbType.VarChar).Value = tRANS.SM_RECEIVER;
            cmd.Parameters.Add("@FLAG_CALL_RECEIVER", SqlDbType.Char).Value = tRANS.FLAG_CALL_RECEIVER;
            cmd.Parameters.Add("@RECEIVERPHONENO", SqlDbType.VarChar).Value = tRANS.RECEIVERPHONENO;
            cmd.Parameters.Add("@FLAG_DD", SqlDbType.Char).Value = tRANS.FLAG_DD;
            cmd.Parameters.Add("@FLAG_TESTQUESTION", SqlDbType.Char).Value = tRANS.FLAG_TESTQUESTION;
            cmd.Parameters.Add("@TESTQUESTION", SqlDbType.VarChar).Value = tRANS.TESTQUESTION;
            cmd.Parameters.Add("@TESTANSWER", SqlDbType.VarChar).Value = tRANS.TESTANSWER;
            cmd.Parameters.Add("@FLAG_CALLSENDER", SqlDbType.Char).Value = tRANS.FLAG_CALLSENDER;
            cmd.Parameters.Add("@FLAG_SMSSENDER", SqlDbType.Char).Value = tRANS.FLAG_SMSSENDER;
            cmd.Parameters.Add("@FLAG_EMAILSENDER", SqlDbType.Char).Value = tRANS.FLAG_EMAILSENDER;
            cmd.Parameters.Add("@SENDEREMAILADDRESS", SqlDbType.VarChar).Value = tRANS.SENDEREMAILADDRESS;
            cmd.Parameters.Add("@TRANSSTATUS", SqlDbType.VarChar).Value = tRANS.TRANSSTATUS;
            cmd.Parameters.Add("@TRANSRECEIVEDID", SqlDbType.VarChar).Value = tRANS.TRANSRECEIVEDID;
            cmd.Parameters.Add("@TRANSRECEIVEDATE", SqlDbType.DateTime).Value = tRANS.TRANSRECEIVEDATE;
            cmd.Parameters.Add("@CREATEDBY", SqlDbType.Int).Value = tRANS.CREATEDBY;
            cmd.Parameters.Add("@CREATEDON", SqlDbType.DateTime).Value = tRANS.CREATEDON;
            cmd.Parameters.Add("@UPDATEDBY", SqlDbType.Int).Value = tRANS.UPDATEDBY;
            cmd.Parameters.Add("@UPDATEDON", SqlDbType.DateTime).Value = tRANS.UPDATEDON;
            cmd.Parameters.Add("@AGENTID", SqlDbType.Int).Value = tRANS.AGENTID;
            cmd.Parameters.Add("@REFCODE", SqlDbType.VarChar).Value = tRANS.REFCODE;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
    
    public bool UpdateTRANS_Paid(TRANS tRANS)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateTRANS_PAID", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TRANSID", SqlDbType.Int).Value = tRANS.TRANSID;
            cmd.Parameters.Add("@RECEIVERPHONENO", SqlDbType.VarChar).Value = tRANS.RECEIVERPHONENO;
            cmd.Parameters.Add("@SENDEREMAILADDRESS", SqlDbType.VarChar).Value = tRANS.SENDEREMAILADDRESS;
            cmd.Parameters.Add("@TRANSSTATUS", SqlDbType.VarChar).Value = tRANS.TRANSSTATUS;
            cmd.Parameters.Add("@TRANSRECEIVEDID", SqlDbType.VarChar).Value = tRANS.TRANSRECEIVEDID;
            cmd.Parameters.Add("@TRANSRECEIVEDATE", SqlDbType.DateTime).Value = tRANS.TRANSRECEIVEDATE;
            cmd.Parameters.Add("@UPDATEDBY", SqlDbType.Int).Value = tRANS.UPDATEDBY;
            cmd.Parameters.Add("@UPDATEDON", SqlDbType.DateTime).Value = tRANS.UPDATEDON;
            cmd.Parameters.Add("@CAUSETRANSOTHERFEES", SqlDbType.NText).Value = tRANS.CAUSETRANSOTHERFEES;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

   

    public bool UpdateTRANSByCustomerID(int previousCustomerID, int newCustomerID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateTRANSByCustomerID", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@previousCustomerID", SqlDbType.Int).Value = previousCustomerID;
            cmd.Parameters.Add("@newCustomerID", SqlDbType.Int).Value = newCustomerID;

            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
    
    public bool UpdateTRANSByReceiverID(int previousReceiverID, int newReceiverID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateTRANSByReceiverID", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@previousReceiverID", SqlDbType.Int).Value = previousReceiverID;
            cmd.Parameters.Add("@newReceiverID", SqlDbType.Int).Value = newReceiverID;

            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
    
    public bool UpdateTRANSByLocationID(int previousLocationID, int newLocationID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateTRANSByLocationID", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@previousLocationID", SqlDbType.Int).Value = previousLocationID;
            cmd.Parameters.Add("@newLocationID", SqlDbType.Int).Value = newLocationID;

            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool UpdateTRANSByAgentID(int previousAgentID, int newAgentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateTRANSByAgentID", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@previousAgentID", SqlDbType.Int).Value = previousAgentID;
            cmd.Parameters.Add("@newAgentID", SqlDbType.Int).Value = newAgentID;

            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public DataTable GetAllTransInfoByCustID(int custID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllTRANSsByCustomerIDForReport", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CUSTID", SqlDbType.Int).Value = custID;
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            connection.Close();
            return dt;
        }
    }


    public DataTable GetAllTransInfoByReferenceCodeForReport(string referenceCode)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllTRANSsByREFCODE", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@REFCODE", SqlDbType.VarChar).Value = referenceCode;
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            connection.Close();
            return dt;
        }
    }

    public DataTable GetAllTransForLocationWiseForReport(string status, string locationIDs, int agentID, string fromDate, string toDate, int amount)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllTRANSsForLocationWiseReport", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AGENTID", SqlDbType.Int).Value = agentID;
            command.Parameters.Add("@FROMDATE", SqlDbType.DateTime).Value = DateTime.Parse(fromDate);
            command.Parameters.Add("@TODATE", SqlDbType.DateTime).Value = DateTime.Parse(toDate);
            command.Parameters.Add("@AMOUNT", SqlDbType.Int).Value = amount;
            command.Parameters.Add("@LOCATIONIDs", SqlDbType.NVarChar).Value = locationIDs;
            command.Parameters.Add("@STATUS", SqlDbType.NVarChar).Value = status;

            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            connection.Close();
            return dt;
        }
    }
}
