using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using DAL;


internal sealed class DALBase
{
    private string strCon = "";
    private string strResultSet = "";
    private System.Data.SqlClient.SqlConnection objConnection;
    private System.Data.DataSet dsResultSet;
    private System.Data.DataTable dtResultSet;
    private int result;

    public static readonly DALBase sql = new DALBase();
    public DALBase()
    {
        //this.strCon = "Data Source=192.168.0.251,1434;Initial Catalog=ravERPDB;User ID=sa;Password=hpes";
        this.strCon = "Data Source=103.12.1.74,61236;Initial Catalog=ravERPDB;User ID=TantrashAdmin;Password=Vbxgsj34@hdrH";
    }
    public void Create_Connection()
    {
        this.objConnection = null;
        try
        {
            this.objConnection = new System.Data.SqlClient.SqlConnection(this.strCon);
            if (this.objConnection.State == System.Data.ConnectionState.Closed || this.objConnection == null)
            {
                this.objConnection.Open();
            }
        }
        catch
        {
        }
    }
    public void Close_Connection()
    {
        try
        {
            if (this.objConnection.State == System.Data.ConnectionState.Open || this.objConnection != null)
            {
                this.objConnection.Close();
                this.objConnection = null;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public System.Data.DataSet ExecuteProcedure(string SPName, string[] pName, string[] pValue)
    {
        this.dsResultSet = null;
        try
        {
            this.dsResultSet = new System.Data.DataSet();
            this.Create_Connection();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = this.objConnection;
            sqlCommand.CommandText = SPName;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < pName.Length; i++)
            {
                sqlCommand.Parameters.AddWithValue(pName[i], string.IsNullOrEmpty(pValue[i]) ? null : pValue[i]);
            }
            sqlDataAdapter.SelectCommand = sqlCommand;
            sqlDataAdapter.Fill(this.dsResultSet);
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
        finally
        {
            this.Close_Connection();
        }
        return this.dsResultSet;
    }
    public System.Data.DataSet ExecuteProcedureWithoutPara(string SPName)
    {
        this.dsResultSet = null;
        try
        {
            this.dsResultSet = new System.Data.DataSet();
            this.Create_Connection();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = this.objConnection;
            sqlCommand.CommandText = SPName;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlDataAdapter.SelectCommand = sqlCommand;
            sqlDataAdapter.Fill(this.dsResultSet);
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
        finally
        {
            this.Close_Connection();
        }
        return this.dsResultSet;
    }

    public System.Data.DataTable ExecuteProcedureWithDataTable(string SPName, string[] pName, string[] pValue)
    {
        this.dtResultSet = null;
        try
        {
            this.dtResultSet = new System.Data.DataTable();
            this.Create_Connection();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = this.objConnection;
            sqlCommand.CommandText = SPName;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < pName.Length; i++)
            {
                sqlCommand.Parameters.AddWithValue(pName[i], string.IsNullOrEmpty(pValue[i]) ? null : pValue[i]);
            }
            sqlDataAdapter.SelectCommand = sqlCommand;
            sqlDataAdapter.Fill(this.dtResultSet);            
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
        finally
        {
            this.Close_Connection();
        }
        return this.dtResultSet;
    }
    public System.Data.DataTable ExecuteProcedureWithDataTableWithoutPara(string SPName)
    {
        this.dtResultSet = null;
        try
        {
            this.dtResultSet = new System.Data.DataTable();
            this.Create_Connection();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = this.objConnection;
            sqlCommand.CommandText = SPName;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlDataAdapter.SelectCommand = sqlCommand;
            sqlDataAdapter.Fill(this.dtResultSet);
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
        finally
        {
            this.Close_Connection();
        }
        return this.dtResultSet;
    }

    public Int32 ExecuteProcedureINSERT(string SPName, string[] pName, string[] pValue)
    {
        int result = 0;
        try
        {
            this.dsResultSet = new System.Data.DataSet();
            this.Create_Connection();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = this.objConnection;
            sqlCommand.CommandText = SPName;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < pName.Length; i++)
            {
                sqlCommand.Parameters.AddWithValue(pName[i], string.IsNullOrEmpty(pValue[i]) ? null : pValue[i]);
            }
            result = sqlCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw;
        }
        finally
        {
            this.Close_Connection();
        }
        return result;
    }
}
