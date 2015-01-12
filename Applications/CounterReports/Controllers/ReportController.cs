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
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using CounterReports.Models;
using RMIT.Counter.Libraries.Reporting;
using RMIT.Counter.Libraries.Reporting.Common;

#endregion

namespace CounterReports.Controllers
{
    [RoutePrefix("api/report")]
    public class ReportController : ApiController
    {
        #region Search

        [HttpPost]
        public HttpResponseMessage Post(Report reportFormData)
        {
            string errorMessage = null;

            try
            {
                if (!ModelState.IsValid)
                {
                    errorMessage = string.Join("; ", ModelState.Values
                        .SelectMany(x => x.Errors)
                        .Select(x => x.ErrorMessage));
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }

                var startDate = GetFormatedDate(reportFormData.Report_Start_Date_DFY,
                    reportFormData.Report_Start_Date_DFM, reportFormData.Report_Start_Date_DFD);
                var endDate = GetFormatedDate(reportFormData.Report_End_Date_DFY, reportFormData.Report_End_Date_DFM,
                    reportFormData.Report_End_Date_DFD);

                if (startDate > endDate)
                    throw new Exception("Invalid date range, as end date is less than begin date");

                var report = ReportGenerator.GetReportData(reportFormData.Report_Template, reportFormData.Users,
                    startDate, endDate);

                if (report == null)
                    throw new Exception("Report Not Supported");

                var generator = new ReportGenerator();
                var output = generator.OnDemand(GetReportFormat(reportFormData.Report_Format), report);

                output = output.Replace(@"#informitreport:report_desc#", reportFormData.Report_Desc);
                output = output.Replace(@"#infomitreport:report_name#", reportFormData.Report_Name);
                output = output.Replace(@"#infomitreport:root#", string.Empty);

                return PrepareHttpResponseMessage(reportFormData, output);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error Message : - " + e.Message);
            }
            finally
            {
                RecordReportUsageLog(reportFormData, errorMessage);
            }
        }

        private static void RecordReportUsageLog(Report reportFormData, string errorMessage)
        {
            var startDate = GetFormatedDate(reportFormData.Report_Start_Date_DFY, reportFormData.Report_Start_Date_DFM,
                reportFormData.Report_Start_Date_DFD);
            var endDate = GetFormatedDate(reportFormData.Report_End_Date_DFY, reportFormData.Report_End_Date_DFM,
                reportFormData.Report_End_Date_DFD);
            var reportForamt = reportFormData.Report_Format;

            if (reportForamt != null && reportForamt.Trim() == "On-Screen")
                reportForamt = "Html";

            ReportUsageLogWriter.Flush(reportFormData.Users,
                reportFormData.Report_Template, reportForamt,
                startDate, endDate, DateTime.Now, null, null, errorMessage);
        }

        private static DateTime GetFormatedDate(string dateDfy, string dateDfm, string dateDfd)
        {
            try
            {
                return DateTime.Parse(dateDfy + "-" + dateDfm +
                                      "-" + dateDfd);
            }
            catch (Exception)
            {
                throw new Exception("Invalid DateTime");
            }
        }


        private static HttpResponseMessage PrepareHttpResponseMessage(Report reportFormData, string output)
        {
            var format = GetReportFormat(reportFormData.Report_Format);
            var mediaType = GetReportMediaType(reportFormData.Report_Format);

            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(output, Encoding.UTF8, mediaType)
            };

            if (format != ReportFormat.Html)
            {
                AttachmentHeaderToHttpResponseMessage(reportFormData.Report_Name, result, format);
            }

            return result;
        }

        private static void AttachmentHeaderToHttpResponseMessage(string reportName, HttpResponseMessage result,
            ReportFormat format)
        {
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName =
                    reportName + "_" + DateTime.Now.ToString("yyyyMMddTHHmmss") + "." + format
            };
        }

        private static ReportFormat GetReportFormat(string reportFormat)
        {
            switch (reportFormat.ToLower())
            {
                case "csv":
                    return ReportFormat.Csv;
                case "tsv":
                    return ReportFormat.Tsv;
            }

            return ReportFormat.Html;
        }

        private static string GetReportMediaType(string reportFormat)
        {
            switch (reportFormat.ToLower())
            {
                case "comma-delimited-headings":
                    return "text/csv";
            }

            return "text/html";
        }

        #endregion
    }
}