using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace Com.Winfotian.SyncTool
{
    class SQLHelper
    {
        internal static SqlConnection CreateNewConnection(string ConnStr)
        {
            try
            {
                return new SqlConnection(ConnStr);
            }
            catch
            {
                return null;
            }
        }

        internal static DataSet QuerySet(string SQL, string ConnStr)
        {
            string message;
            return QuerySet(SQL, ConnStr, out message);
        }

        internal static DataSet QuerySet(string SQL, string ConnStr, out string Message)
        {
            using (SqlConnection connection = SQLHelper.CreateNewConnection(ConnStr))
            {
                connection.Open();
                var result = new StringBuilder();
                connection.InfoMessage += (s, e) =>
                {
                    result.AppendLine(e.Message);
                };
                var command = new SqlCommand(SQL, connection);
                command.StatementCompleted += (s, e) =>
                {
                    result.AppendLine(string.Format("{0} row(s) affected.", e.RecordCount));
                };
                var adapter = new SqlDataAdapter(command);
                var data = new DataSet();
                //adapter.FillSchema(data, SchemaType.Mapped);
                adapter.Fill(data);
                connection.Close();
                Message = result.ToString();
                return data;
            }
        }

        internal static DataSet QuerySet(string SQL, string ConnStr, SqlParameter[] pars)
        {
            try
            {
                using (SqlConnection connection = SQLHelper.CreateNewConnection(ConnStr))
                {
                    connection.Open();
                    var command = new SqlCommand(SQL, connection);
                    if (pars.Length > 0)
                    {
                        command.Parameters.AddRange(pars);
                    }
                    var adapter = new SqlDataAdapter(command);
                    var data = new DataSet();
                    adapter.Fill(data);
                    command.Parameters.Clear();
                    connection.Close();
                    return data;
                }
            }
            catch 
            {
                return null;
                 
            }
        }

        internal static DataTable Query(string SQL, string ConnStr)
        {
            DataSet data = QuerySet(SQL, ConnStr);
            if (data != null && data.Tables.Count > 0)
                return data.Tables[0];
            else
                return null;
        }

        internal static int ExecuteNonQuery(string SQL, string ConnStr)
        {
            using (SqlConnection connection = SQLHelper.CreateNewConnection(ConnStr))
            {
                var result = new StringBuilder();
                connection.InfoMessage += (s, e) =>
                {
                    result.AppendLine(e.Message);
                };
                var command = new SqlCommand(SQL, connection);
                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        internal static object ExecuteScalar(string SQL, string ConnStr)
        {
            object result;
            using (SqlConnection connection = SQLHelper.CreateNewConnection(ConnStr))
            {
                var command = new SqlCommand(SQL, connection);
                connection.Open();
                result = command.ExecuteScalar();
                connection.Close();
            }
            return result;
        }

        internal static bool InsertBatch(string ConnStr, DataTable dt, string TableName)
        {
            using (SqlConnection connection = SQLHelper.CreateNewConnection(ConnStr))
            {
                bool IsOk = true;
                connection.Open();
                SqlBulkCopy bulkCopy = new SqlBulkCopy(connection);
                bulkCopy.DestinationTableName = TableName;
                bulkCopy.BatchSize = dt.Rows.Count;
                try
                {
                    if (dt != null && dt.Rows.Count != 0)
                        bulkCopy.WriteToServer(dt);
                }
                catch
                {
                    IsOk = false;
                }
                finally
                {
                    if (bulkCopy != null)
                        bulkCopy.Close();
                }
                return IsOk;
            }
        }
    }
}
