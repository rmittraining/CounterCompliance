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
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using RMIT.Counter.Libraries.Sushi.Core;

#endregion

namespace RMIT.Counter.Test.Unit.Libraries.Sushi.Core
{
    /// <summary>
    /// Unit Tests the SushiComponent
    /// </summary>
    [TestFixture]
    public class SushiComponentTest
    {
        #region Setup/Teardown

        [SetUp]
        public void SetUp()
        {
            _reportRepository = Substitute.For<IUsageReportRepository>();
            _authorizationAuthority = Substitute.For<IAuthorizationAuthority>();
            _sushiComponent = new SushiComponent(_reportRepository, _authorizationAuthority);
        }

        [TearDown]
        public void TearDown()
        {
        }

        #endregion

        #region Fields
        private SushiComponent _sushiComponent;
        private IUsageReportRepository _reportRepository;
        private IAuthorizationAuthority _authorizationAuthority;
        private List<Report> _expected; 
        #endregion

        /// <summary>
        /// Checks if the SushiComponent can produce Report.
        /// </summary>
        [Test]
        public void HappyPath()
        {
            //Arrange
            var request = new ReportRequest
                          {
                              ReportDefinition = new ReportDefinition
                                                 {
                                                     Release = "4",
                                                     Filters = new ReportDefinitionFilters
                                                               {
                                                                   UsageDateRange = new Range
                                                                                    {
                                                                                        Begin =
                                                                                            new DateTime(2014, 12, 25),
                                                                                        End = new DateTime(2015, 1, 1)
                                                                                    }
                                                               }
                                                 }
                          };
            _authorizationAuthority.IsRequestorAuthorized(request.Requestor, request.CustomerReference).Returns(true);
            _expected = new List<Report>();
            _reportRepository.GetUsageReports(request).Returns(_expected);

            //Act
            var actual = _sushiComponent.GetSushiReports(request);

            //Assert
            _authorizationAuthority.Received().IsRequestorAuthorized(request.Requestor, request.CustomerReference);
            Assert.IsNotNull(actual);
            Assert.AreEqual(_expected, actual);
        }

        #region Alternate Conditions

        /// <summary>
        /// Checks if the release is invalid.
        /// </summary>
        [Test]
        [ExpectedException(typeof(SushiCustomException), ExpectedMessage = "Request specifies an unsupported release value. Only release 4 is supported at this time.")]
        public void InValidRelease()
        {
            //Arrange
            var request = new ReportRequest();

            //Act
            _sushiComponent.GetSushiReports(request);

            //Assert
        }

        /// <summary>
        /// Checks if the Date range is invalid.
        /// </summary>
        [Test]
        [ExpectedException(typeof(SushiCustomException), ExpectedMessage = "Invalid date range, as end date is less than begin date")]
        public void InValidDateRange()
        {
            //Arrange
            var request = new ReportRequest
                          {
                              ReportDefinition = new ReportDefinition
                                                 {
                                                     Release = "4",
                                                     Filters = new ReportDefinitionFilters
                                                               {
                                                                   UsageDateRange = new Range
                                                                                    {
                                                                                        Begin = new DateTime(2015, 12, 25),
                                                                                        End = new DateTime(2015, 1, 1)
                                                                                    }
                                                               }
                                                 }
                          };

            //Act
            _sushiComponent.GetSushiReports(request);

            //Assert
        }
        /// <summary>
        /// Checks if the user is invalid.
        /// </summary>
        [Test]
        [ExpectedException(typeof(SushiCustomException), ExpectedMessage = "Requestor not authorised to access service")]
        public void InValidUser()
        {
            //Arrange
            var request = new ReportRequest
            {
                ReportDefinition = new ReportDefinition
                {
                    Release = "4",
                    Filters = new ReportDefinitionFilters
                    {
                        UsageDateRange = new Range
                        {
                            Begin = new DateTime(2014, 12, 25),
                            End = new DateTime(2015, 1, 1)
                        }
                    }
                }
            };
            _authorizationAuthority.IsRequestorAuthorized(request.Requestor, request.CustomerReference).Returns(false);

            //Act
            _sushiComponent.GetSushiReports(request);

            //Assert
        } 
        #endregion
    }
}