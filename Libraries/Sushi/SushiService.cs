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
using RMIT.Counter.Libraries.Reporting.Common;
using RMIT.Counter.Libraries.Sushi.Core;
using Exception = System.Exception;

#endregion

namespace RMIT.Counter.Libraries.Sushi.Implementation
{
    /// <summary>
    ///     Provides a concrete implementation of the <see cref="ISushiService" /> interface.
    /// </summary>
    public class SushiService : ISushiService
    {
        #region ISushiCounterService Members

        /// <summary>
        ///     Retrieves a Counter report response that corresponds with the provided request.
        /// </summary>
        /// <param name="request">The report request.</param>
        /// <returns>A Counter report response.</returns>
        public GetReportResponse GetReport(GetReportRequest request)
        {
            var response = new GetReportResponse
            {
                ReportResponse = new CounterReportResponse
                {
                    Created = DateTime.Now,
                    CreatedSpecified = true,
                    CustomerReference = request.ReportRequest.CustomerReference,
                    ID = request.ReportRequest.ID,
                    ReportDefinition = request.ReportRequest.ReportDefinition,
                    Requestor = request.ReportRequest.Requestor,
                }
            };

            string errorMessage = null;
            int? errorStatusCode = null;

            try
            {
                var businessLogic = new SushiComponent(new OnDemandRepository(), new AuthorizationAuthority());
                response.ReportResponse.Report = businessLogic.GetSushiReports(request.ReportRequest);

                if (IsPartialDate(request))
                {
                    response.ReportResponse.Exception =
                        ExceptionHelper.ToSushiExceptions(new SushiCustomException("Partial Data Returned", 3040),
                            ExceptionSeverity.Warning);
                }
            }
            catch (Exception ex)
            {
                response.ReportResponse.Exception = ExceptionHelper.ToSushiExceptions(ex);
                errorMessage = response.ReportResponse.Exception[0].Message;
                errorStatusCode = response.ReportResponse.Exception[0].Number;
            }
            finally
            {
                RecordReportUsageLog(request, errorMessage, errorStatusCode);
            }


            return response;
        }

        /// <summary>
        /// Determines whether the request date range falls within the dates where we lost data.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        private static bool IsPartialDate(GetReportRequest request)
        {
            var partialDates = Config.SushiPartialDates;

            return
                partialDates.Count(
                    pdate =>
                        request.ReportRequest.ReportDefinition.Filters.UsageDateRange.Begin <= pdate.Value &&
                        pdate.Key <= request.ReportRequest.ReportDefinition.Filters.UsageDateRange.End) > 0;
        }


        private static void RecordReportUsageLog(GetReportRequest request, string errorMessage, int? errorStatusCode)
        {
            ReportUsageLogWriter.Flush(request.ReportRequest.CustomerReference.Name,
                request.ReportRequest.ReportDefinition.Name, "Sushi",
                request.ReportRequest.ReportDefinition.Filters.UsageDateRange.Begin,
                request.ReportRequest.ReportDefinition.Filters.UsageDateRange.End, request.ReportRequest.Created,
                request.ReportRequest.CustomerReference.ID, errorStatusCode, errorMessage);
        }

        #endregion
    }
}