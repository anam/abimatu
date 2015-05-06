using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlUSER_MembershipProvider:DataAccessObject
{
	public SqlUSER_MembershipProvider()
    {
    }


    public DataSet  GetAllUSER_Memberships()
    {
        DataSet USER_Memberships = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllUSER_Memberships", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(USER_Memberships);
            myadapter.Dispose();
            connection.Close();

            return USER_Memberships;
        }
    }
	public DataSet GetUSER_MembershipPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetUSER_MembershipPageWise", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PageIndex", pageIndex);
                command.Parameters.AddWithValue("@PageSize",  PageSize );
                command.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
                command.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                recordCount = Convert.ToInt32(command.Parameters["@RecordCount"].Value);
                return ds;
            }
        }
    }


    public USER_Membership  GetUSER_MembershipByRowStatusID(int  rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetUSER_MembershipByRowStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RowStatusID", SqlDbType.NVarChar).Value = rowStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetUSER_MembershipFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllUSER_Membership()
    {
        DataSet USER_Memberships = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllUSER_Membership", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(USER_Memberships);
            myadapter.Dispose();
            connection.Close();

            return USER_Memberships;
        }
    }

    public DataSet   GetAllUSER_PagesWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllUSER_PagesWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<USER_Membership> GetUSER_MembershipsFromReader(IDataReader reader)
    {
        List<USER_Membership> uSER_Memberships = new List<USER_Membership>();

        while (reader.Read())
        {
            uSER_Memberships.Add(GetUSER_MembershipFromReader(reader));
        }
        return uSER_Memberships;
    }

    public USER_Membership GetUSER_MembershipFromReader(IDataReader reader)
    {
        try
        {
            USER_Membership uSER_Membership = new USER_Membership
                (

                     DataAccessObject.IsNULL<int>(reader["RoleID"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"]),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"]),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdatedDate"]),
                     DataAccessObject.IsNULL<int>(reader["RowStatusID"])
                );
             return uSER_Membership;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public USER_Membership  GetUSER_MembershipByRoleID(int  roleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetUSER_MembershipByRoleID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RoleID", SqlDbType.Int).Value = roleID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetUSER_MembershipFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet GetUSER_MembershipByID(string ID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetUSER_MembershipByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ID", SqlDbType.NVarChar).Value = ID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }


    }

    public int InsertUSER_Membership(USER_Membership uSER_Membership)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertUSER_Membership", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RoleID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = uSER_Membership.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = uSER_Membership.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = uSER_Membership.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = uSER_Membership.UpdatedDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = uSER_Membership.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@RoleID"].Value;
        }
    }

    public bool UpdateUSER_Membership(USER_Membership uSER_Membership)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateUSER_Membership", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RoleID", SqlDbType.Int).Value = uSER_Membership.RoleID;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = uSER_Membership.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = uSER_Membership.UpdatedDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = uSER_Membership.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteUSER_Membership(int roleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteUSER_Membership", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RoleID", SqlDbType.Int).Value = roleID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public bool UnlockUSER_Membership(string userID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UnlockUSER_Membership", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = userID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

