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

using System.Collections.Generic;
using RMIT.Counter.Libraries.Library.Common;

#endregion

namespace RMIT.Counter.Libraries.Sushi.Core
{
    /// <summary>
    ///     Returns report results from UsageReportRepository while checking AuthorizationAuthority for access
    /// </summary>
    public class SushiComponent
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SushiComponent" /> class.
        /// </summary>
        /// <param name="reportRepository">
        ///     The <see cref="IUsageReportRepository" /> instance to use for Counter usage data retrieval.
        /// </param>
        /// <param name="authorizationAuthority">
        ///     The <see cref="IAuthorizationAuthority" /> instance to use for requestor / customer authorization.
        /// </param>
        public SushiComponent(IUsageReportRepository reportRepository, IAuthorizationAuthority authorizationAuthority)
        {
            ReportRepository = reportRepository;
            AuthorizationAuthority = authorizationAuthority;
        }

        /// <summary>
        ///     Gets the <see cref="IUsageReportRepository" /> instance that was injected when this instance was created.
        /// </summary>
        public IUsageReportRepository ReportRepository { get; private set; }

        /// <summary>
        ///     Gets the <see cref="IAuthorizationAuthority" /> instance that was injected when this instance was created.
        /// </summary>
        public IAuthorizationAuthority AuthorizationAuthority { get; private set; }

        /// <summary>
        ///     Retrieves an instance of the <see cref="Reports" /> class containing the requested usage statistics.
        /// </summary>
        /// <param name="request">The request object from the webservice.</param>
        /// <returns>An instance of the <see cref="Reports" /> class containing the requested usage statistics.</returns>
        public List<Report> GetSushiReports(ReportRequest request)
        {
            ValidateRelease(request);
            ValidateDateRange(request);
            ValidateUser(request);
            return ReportRepository.GetUsageReports(request);
        }

        #region Validations

        /// <summary>
        ///     Validates the user credentials.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <exception cref="SushiCustomException">Requestor not authorised to access service;2000</exception>
        private void ValidateUser(ReportRequest request)
        {
            var authorized = AuthorizationAuthority.IsRequestorAuthorized(request.Requestor, request.CustomerReference);

            if (!authorized)
            {
                throw new SushiCustomException("Requestor not authorised to access service", 2000);
            }
        }

        /// <summary>
        ///     Validates the date range.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <exception cref="SushiCustomException">Requestor not authorised to access service;3020</exception>
        private static void ValidateDateRange(ReportRequest request)
        {
            var range = request.ReportDefinition.Filters.UsageDateRange;
            if (range.End < range.Begin)
            {
                throw new SushiCustomException("Invalid date range, as end date is less than begin date", 3020);
            }
        }

        /// <summary>
        ///     Validates the supported release number.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <exception cref="SushiCustomException">3010</exception>
        private static void ValidateRelease(ReportRequest request)
        {
            const string validCounterReleaseNumber = "4";
            if (
                !request.IsNull(p => p.ReportDefinition.Release) && (
                request.ReportDefinition.Release.Trim() == validCounterReleaseNumber || string.IsNullOrEmpty(request.ReportDefinition.Release))
                )
                return;

            throw new SushiCustomException(
                string.Format(
                    "Request specifies an unsupported release value. Only release {0} is supported at this time.",
                    validCounterReleaseNumber), 3010);
        }

        #endregion
    }
}