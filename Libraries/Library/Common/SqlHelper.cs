/*
Copyright (c) 2014, RMIT Training
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:

* Redistributions of source code must retain the above copyright notice, this
  list of conditions and the following disclaimer.

* Redistributions in binary form must reproduce the above copyright notice,
  this list of conditions and the following disclaimer in the documentation
  and/or other materials provided with the distribution.

* Neither the name of CounterCompliance nor the names of its
  contributors may be used to endorse or promote products derived from
  this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/
#region

using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

#endregion

namespace RMIT.Counter.Libraries.Library.Common
{
    /// <summary>
    ///     Helper class for Ad-hoc database communication
    /// </summary>
    public class SqlHelper : IDisposable
    {
        //Command TimeOut Default value is 20 second
        public int CommandTimeout = 30;

        #region Properties and construtors

        /// <summary>
        ///     The connection instance
        /// </summary>
        public SqlConnection Connection { get; private set; }


        /// <summary>
        ///     Gets the transaction.
        /// </summary>
        /// <value>
        ///     The transaction.
        /// </value>
        public SqlTransaction Transaction { get; private set; }

        #endregion

        #region Object Life cycle

        /// <summary>
        ///     Initializes a new instance of the <see cref="SqlHelper" /> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public SqlHelper(string connectionString)
        {
            Connection = new SqlConnection(connectionString);
            Connection.Open();
        }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (Transaction != null)
                Transaction.Dispose();
            if (Connection == null)
                return;
            if (Connection.State == ConnectionState.Open)
                Connection.Close();
            Connection.Dispose();
            Connection = null;
        }

        #endregion

        #region Transactions

        /// <summary>
        ///     Begins the transaction.
        /// </summary>
        public void BeginTransaction()
        {
            Transaction = Connection.BeginTransaction();
        }

        /// <summary>
        ///     Rollbacks this instance.
        /// </summary>
        public void Rollback()
        {
            Transaction.Rollback();
        }

        /// <summary>
        ///     Commits this instance.
        /// </summary>
        public void Commit()
        {
            Transaction.Commit();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Executes the data set.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(string commandText, CommandType commandType = CommandType.Text,
            params SqlParameter[] parameters)
        {
            var ds = new DataSet();
            using (var adapter = new SqlDataAdapter(commandText, Connection))
            {
                adapter.SelectCommand.Transaction = Transaction;
                adapter.SelectCommand.CommandType = commandType;
                adapter.SelectCommand.Parameters.AddRange(parameters);
                adapter.SelectCommand.CommandTimeout = CommandTimeout;
                adapter.Fill(ds);
            }
            return ds;
        }


        /// <summary>
        ///     Executes the non query.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string commandText, CommandType commandType = CommandType.Text,
            params SqlParameter[] parameters)
        {
            using (var command = new SqlCommand(commandText, Connection, Transaction) {CommandType = commandType})
            {
                command.Parameters.AddRange(parameters);
                command.CommandTimeout = CommandTimeout;
                return command.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///     Executes the scalar.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public object ExecuteScalar(string commandText, CommandType commandType = CommandType.Text,
            params SqlParameter[] parameters)
        {
            using (var command = new SqlCommand(commandText, Connection, Transaction) {CommandType = commandType})
            {
                command.Parameters.AddRange(parameters);
                command.CommandTimeout = CommandTimeout;
                return command.ExecuteScalar();
            }
        }

        /// <summary>
        ///     Executes the reader.
        /// </summary>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandText">The command text.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        /// <remarks>You have to close connection yourself</remarks>
        public SqlDataReader ExecuteReader(string commandText, CommandType commandType = CommandType.Text,
            params SqlParameter[] parameters)
        {
            var command = new SqlCommand(commandText, Connection, Transaction)
            {
                CommandType = commandType,
                CommandTimeout = CommandTimeout
            };
            command.Parameters.AddRange(parameters);
            return command.ExecuteReader();
        }

        #endregion

        #region Helpers

        /// <summary>
        ///     Values the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static object Value(string value)
        {
            return string.IsNullOrEmpty(value) ? DBNull.Value : (object) value;
        }

        public static bool ToBoolean(object o, bool defaultValue = false)
        {
            return o is bool ? (bool) o : defaultValue;
        }

        /// <summary>
        ///     Bulk inserts data.
        /// </summary>
        /// <param name="bulkDataLoadTimeout">The bulk data load timeout.</param>
        /// <param name="dataTable">The data table.</param>
        /// <param name="bulkCopyOption">The bulk copy option.</param>
        /// <returns></returns>
        public bool BulkInsert(int bulkDataLoadTimeout, DataTable dataTable,
            SqlBulkCopyOptions bulkCopyOption = SqlBulkCopyOptions.Default)
        {
            var watch = Stopwatch.StartNew();
            try
            {
                //Do this in a transaction
                BeginTransaction();
                using (var s = new SqlBulkCopy(Connection, bulkCopyOption, Transaction))
                {
                    s.DestinationTableName = dataTable.TableName;
                    s.BulkCopyTimeout = bulkDataLoadTimeout;

                    foreach (var column in dataTable.Columns)
                        s.ColumnMappings.Add(column.ToString(), column.ToString());

                    s.WriteToServer(dataTable);
                }
                Commit();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
                Trace.TraceError(ex.StackTrace);
                Rollback();
                throw;
            }
            watch.Stop();
            Trace.TraceInformation("Took {0} to bulk load data of {1} records to table {2}", watch.Elapsed,
                dataTable.Rows.Count, dataTable.TableName);
            return true;
        }

        #endregion
    }
}