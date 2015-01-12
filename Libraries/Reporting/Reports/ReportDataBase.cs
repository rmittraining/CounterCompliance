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
using RMIT.Counter.Libraries.Library.Models;
using RMIT.Counter.Libraries.Reporting.Common;
using RMIT.Counter.Libraries.Reporting.Interfaces;

#endregion

namespace RMIT.Counter.Libraries.Reporting.Reports
{
    public abstract class ReportDataBase : IReportData
    {
        protected ReportDataBase(Users user, DateTime start, DateTime end)
        {
            User = user;
            Start = start;
            End = end;
        }

        protected virtual int DefaultTimeOut
        {
            get { return 30; }
        }

        /// <summary>
        ///     The parameters typically used to query database and produce report.
        /// </summary>
        /// <value>
        ///     The parameters.
        /// </value>
        public virtual SqlParameter[] Parameters
        {
            get
            {
                return new[]
                       {
                           new SqlParameter("@VendorName", SqlDbType.NVarChar) {Value = Config.SushiVendorName},
                           new SqlParameter("@VendorID", SqlDbType.NVarChar) {Value = Config.SushiVendorId},
                           new SqlParameter("@VendorContactName", SqlDbType.NVarChar)
                           {
                               Value =
                                   Config
                                   .SushiVendorContactName
                           },
                           new SqlParameter("@VendorContactEmail", SqlDbType.NVarChar)
                           {
                               Value =
                                   Config
                                   .SushiVendorContactEmail
                           },
                           new SqlParameter("@Platform", SqlDbType.NVarChar) {Value = Config.SushiPlatform},
                           new SqlParameter("@User", User.Username),
                           new SqlParameter("@Start", Start),
                           new SqlParameter("@End", End)
                       };
            }
        }

        public string Query
        {
            get
            {
                return
                    @"Counter_" + GetType().Name + "_Get";
            }
        }

        #region IReportData Members

        public DateTime End { get; set; }

        public DateTime Start { get; set; }

        public Users User { get; set; }

        public virtual DataSet GetDataset()
        {
            //Below code retrive hardcoded preformatted xml data from Data Folder in solution. It is used for demonstration purpose only. 
            return SampleDataset();

            //TODO : Get Data from Database and avoid using above hardcoded xml dataset
            //using (var db = new SqlHelper(Config.ConnectionString) { CommandTimeout = DefaultTimeOut })
            //{
            //    return db.ExecuteDataSet(Query, CommandType.StoredProcedure, Parameters);
            //}
        }

        #endregion

        private DataSet SampleDataset()
        {
            const string sampleDataFolder = @"C:\Temp\RMIT.Counter\Data\";
            var myXmLfile = sampleDataFolder + GetType().Name + ".xml";
            var ds = new DataSet();
            ds.ReadXml(myXmLfile);
            return ds;
        }
    }
}