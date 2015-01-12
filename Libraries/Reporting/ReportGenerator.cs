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
using System.Diagnostics;
using RMIT.Counter.Libraries.Library.Common;
using RMIT.Counter.Libraries.Library.Models;
using RMIT.Counter.Libraries.Reporting.Common;
using RMIT.Counter.Libraries.Reporting.Interfaces;

#endregion

namespace RMIT.Counter.Libraries.Reporting
{
    public class ReportGenerator
    {
        public string OnDemand(ReportFormat format, IReportData report)
        {
            Trace.TraceInformation("Generating {0} report for {1} form {2:yyyy-MM-dd} to {3:yyyy-MM-dd}",
                report.GetType().Name,
                report.User.Username, report.Start, report.End);
            var formatter = new XslTransform(Config.CounterXsltFolder);
            var result = formatter.Transform(report, format);
            Trace.TraceInformation("Generated");
            return result;
        }

        public static IReportData GetReportData(string typeName, string username, DateTime start, DateTime end)
        {
            typeName = typeName.ToLower().ToProperCase();

            const string classNamespace = "RMIT.Counter.Libraries.Reporting.Reports";

            var type = Type.GetType(string.Format("{0}.{1}", classNamespace, typeName));
            if (type != null)
            {
                return (IReportData) Activator.CreateInstance(type, new Users {Username = username}, start, end);
            }
            return null;
        }
    }
}