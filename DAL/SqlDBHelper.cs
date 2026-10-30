using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public sealed class SqlDBHelper
{
    public static readonly SqlDBHelper sqlDBHelper = new SqlDBHelper();
    public string msg;

    public const string CONNECTION_STRING = "Data Source=103.12.1.74,61236;Initial Catalog=ravERPDB;User ID=TantrashAdmin;Password=Vbxgsj34@hdrH";

    internal DataTable ExecuteSelectCommand(string CommandName, CommandType cmdType)
    {
        DataTable table = null;
        using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
        {
            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.CommandType = cmdType;
                cmd.CommandText = CommandName;

                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        table = new DataTable();
                        da.Fill(table);
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                }
            }
        }

        return table;
    }
    internal DataTable ExecuteParameterizedSelectCommand(string CommandName, CommandType cmdType, SqlParameter[] param)
    {
        DataTable table = new DataTable();

        using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
        {
            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.CommandType = cmdType;
                cmd.CommandText = CommandName;
                cmd.Parameters.AddRange(param);
                cmd.CommandTimeout = 30000;

                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(table);
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                }
            }
        }

        return table;
    }
    internal DataSet ExecuteParameterizedSelectCommand_UsingdataSet(string CommandName, CommandType cmdType, SqlParameter[] param)
    {
        DataSet ds = new DataSet();

        using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
        {
            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.CommandType = cmdType;
                cmd.CommandText = CommandName;
                cmd.Parameters.AddRange(param);
                cmd.CommandTimeout = 30000;

                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                }
            }
        }

        return ds;
    }

    // This function will be used to execute CRUD(CRUD) operation of parameterized commands
    internal string ExecuteNonQuery(string CommandName, CommandType cmdType, SqlParameter[] param)
    {
        string result = "";
        SqlTransaction trans;
        using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();

            }
            trans = con.BeginTransaction();
            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.Transaction = trans;
                cmd.CommandType = cmdType;
                cmd.CommandText = CommandName;
                param[param.Length - 1].Direction = ParameterDirection.Output;
                param[param.Length - 1].Size = 0x100;
                cmd.Parameters.AddRange(param);

                try
                {
                    cmd.ExecuteNonQuery();
                    result = cmd.Parameters["@result"].Value.ToString();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    msg = ex.Message;
                }
                finally
                {
                    trans.Dispose();
                    con.Close();
                }
            }
        }

        return result;
    }
    internal int ExecuteNonQueryReturnInt_UsingTimeOut(string CommandName, CommandType cmdType, SqlParameter[] param)
    {
        int result = 0;
        SqlTransaction trans;
        using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();

            }
            trans = con.BeginTransaction();
            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.Transaction = trans;
                cmd.CommandType = cmdType;
                cmd.CommandTimeout = 60;
                cmd.CommandText = CommandName;
                param[param.Length - 1].Direction = ParameterDirection.Output;
                param[param.Length - 1].Size = 0x100;
                cmd.Parameters.AddRange(param);

                try
                {
                    cmd.ExecuteNonQuery();
                    result = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    msg = ex.Message;
                }
                finally
                {
                    trans.Dispose();
                    con.Close();
                }
            }
        }

        return result;
    }
}