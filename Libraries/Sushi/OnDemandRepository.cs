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

//needed because sushi also has an exception class
using System.Collections.Generic;
using RMIT.Counter.Libraries.Reporting;
using RMIT.Counter.Libraries.Reporting.Common;
using RMIT.Counter.Libraries.Sushi.Core;

#endregion

namespace RMIT.Counter.Libraries.Sushi.Implementation
{
    public class OnDemandRepository : IUsageReportRepository
    {
        private readonly ReportGenerator _generator;
        private readonly List<Report> _list;

        public OnDemandRepository()
        {
            _generator = new ReportGenerator();
            _list = new List<Report>();
        }

        public List<Report> GetUsageReports(ReportRequest request)
        {
            var range = request.ReportDefinition.Filters.UsageDateRange;

            var start = range.Begin;
            while (start <= range.End)
            {
                //Figureout first of the month, then end of the month by adding 1month and substracting 1 day
                var firstOfMonth = start.AddDays(-start.Day + 1);
                var end = firstOfMonth.AddMonths(1).AddDays(-1);
                if (end > range.End)
                    end = range.End;
                var monthlyRange = new Range {Begin = start, End = end};
                var report = ReportGenerator.GetReportData(request.ReportDefinition.Name, request.CustomerReference.Name,
                    monthlyRange.Begin, monthlyRange.End);

                if (report == null)
                    throw new SushiCustomException("Report Not Supported", 3000);


                var output = _generator.OnDemand(ReportFormat.Shusi, report);
                _list.AddRange(Reports.Deserialize(output).Report);

                //Go to next month
                start = firstOfMonth.AddMonths(1);
            }

            if (_list.Count == 0)
                throw new SushiCustomException("No Usage Available for Requested Dates", 3030);

            return _list;
        }
    }
}