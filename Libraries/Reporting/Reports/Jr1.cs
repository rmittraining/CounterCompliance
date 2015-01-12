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
using RMIT.Counter.Libraries.Library.Models;
using RMIT.Counter.Libraries.Reporting.Common;

#endregion

namespace RMIT.Counter.Libraries.Reporting.Reports
{
    public class Jr1 : ReportDataBase
    {
        public Jr1(Users user, DateTime start, DateTime end) : base(user, start, end)
        {
        }

        public override DataSet GetDataset()
        {
            var ds = base.GetDataset();

            ds.DataSetName = "ReportData";
            ds.Tables[0].TableName = "Header";
            ds.Tables[1].TableName = "Item";
            ds.Tables[2].TableName = "ItemPerformance";
            ds.Tables[3].TableName = "ItemPerformanceMonthlySummary";

            var dataPeriod = ds.Relations.Add(ds.Tables["Item"].Columns["Print_ISSN"],
                ds.Tables["ItemPerformance"].Columns["ISSN"]);
            dataPeriod.Nested = true;
            return ds;
        }

        protected override int DefaultTimeOut
        {
            get { return Config.TimeoutLarge; }
        }
    }
}