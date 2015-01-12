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
using NUnit.Framework;
using RMIT.Counter.Libraries.Sushi.Core;
using RMIT.Counter.Libraries.Sushi.Implementation;

#endregion

namespace RMIT.Counter.Test.Integration.Libraries.Sushi.Implementation
{
    /// <summary>
    /// Integration Tests the SushiService
    /// </summary>
    [TestFixture]
    public class SushiServiceTest
    {
        /// <summary>
        /// Checks if the reports are running.
        /// </summary>
        [Test]
        public void HappyPath()
        {
            //Assert
            var service = new SushiService();
            var request = new GetReportRequest
                          {
                              //all of these values are being set from UI objects
                              ReportRequest = new ReportRequest
                                              {
                                                  Created = DateTime.Now,
                                                  CreatedSpecified = true,
                                                  CustomerReference = new CustomerReference
                                                                      {
                                                                          ID = "123ABC",
                                                                          Name = "guest"
                                                                      },
                                                  ID = Guid.NewGuid().ToString(),
                                                  ReportDefinition = new ReportDefinition
                                                                     {
                                                                         Filters = new ReportDefinitionFilters
                                                                                   {
                                                                                       UsageDateRange = new Range
                                                                                                        {
                                                                                                            Begin =
                                                                                                                new DateTime
                                                                                                                (2013,
                                                                                                                 12, 25),
                                                                                                            End =
                                                                                                                new DateTime
                                                                                                                (2015, 1,
                                                                                                                 3)
                                                                                                        }
                                                                                   },
                                                                         Name = "JR1",
                                                                         Release = "4"
                                                                     },
                                                  Requestor = new Requestor
                                                              {
                                                                  Email = "test@gmail.com",
                                                                  ID = "1234",
                                                                  Name = "Sample University"
                                                              }
                                              }
                          };

            //Act
            var actual = service.GetReport(request);

            //Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(14, actual.ReportResponse.Report.Count);
        }
    }
}