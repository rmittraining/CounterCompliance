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

Copyright (c) 2009, EBSCO Industries, Inc.
All rights reserved.
Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
•Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
•Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer 
 in the documentation and/or other materials provided with the distribution.
•Neither the name of EBSCO Industries, Inc. nor the names of its contributors may be used to endorse or promote products derived 
 from this software without specific prior written permission.
THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
 * FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, 
 * INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS 
 * OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN 
 * CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, 
 * EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/
#region

using System;
using System.Linq;
using System.ServiceModel;
using System.Threading;
using System.Windows.Forms;
using RMIT.Counter.Libraries.Sushi.Core;
using Exception = System.Exception;

#endregion

namespace Sushi.Client
{
    internal partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try
            {
                using (var proxy = new SushiServiceProxy())
                {
                    _serviceUri.Text = proxy.Endpoint.Address.Uri.AbsoluteUri;
                }
            }
            catch (Exception ex)
            {
                _serviceUri.Text = "Could not retrieve default Uri:" + ex.Message;
            }
        }

        private void OnInvokeService(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                Invoke(new Action(() => UpdateFormStatus(true, null, null)));
                //UpdateFormStatus(true, null, null);

                try
                {
                    //create a new instance of a proxy to the WCF service
                    //This reads WCF <system.serviceModel> <client> data from the app.config
                    using (var proxy = new SushiServiceProxy())
                    {
                        //overriding the defaul endpoint with a value from the user
                        //_serviceUri is a TextBox in this case
                        proxy.Endpoint.Address = new EndpointAddress(_serviceUri.Text);

                        //make the call building the request object on the fly
                        var report = proxy.GetReport(new GetReportRequest
                        {
                            //all of these values are being set from UI objects
                            ReportRequest = new ReportRequest
                            {
                                Created = DateTime.Now,
                                CreatedSpecified = true,
                                CustomerReference = new CustomerReference
                                {
                                    ID = _customerId.Text,
                                    Name = _customerName.Text
                                },
                                ID = Guid.NewGuid().ToString(),
                                ReportDefinition = new ReportDefinition
                                {
                                    Filters = new ReportDefinitionFilters
                                    {
                                        UsageDateRange = new Range
                                        {
                                            Begin = _dateRangeBegin.Value,
                                            End = _dateRangeEnd.Value
                                        }
                                    },
                                    Name = _reportName.Text,
                                    Release = _reportRelease.Text
                                },
                                Requestor = new Requestor
                                {
                                    Email = _requestorEmail.Text,
                                    ID = _requestorId.Text,
                                    Name = _requestorName.Text
                                }
                            }
                        });

                        Invoke(new Action(() => UpdateResponseTree(report)));
                        //UpdateResponseTree(report);

                        Invoke(
                            new Action(
                                () =>
                                    UpdateFormStatus(false, true,
                                        report.ReportResponse.Exception != null
                                            ? report.ReportResponse.Exception.Length
                                            : 0)));
                        //UpdateFormStatus(false, true, report.Exception != null ? report.Exception.Length : 0);
                    }
                }
                catch (Exception ex)
                {
                    var exceptionReport = new GetReportResponse
                    {
                        ReportResponse = new CounterReportResponse
                        {
                            Exception = ExceptionHelper.ToSushiExceptions(ex).ToArray()
                        }
                    };

                    Invoke(new Action(() => UpdateResponseTree(exceptionReport)));
                    //UpdateResponseTree(exceptionReport);

                    Invoke(
                        new Action(() => UpdateFormStatus(false, false, exceptionReport.ReportResponse.Exception.Length)));
                    //UpdateFormStatus(false, false, exceptionReport.Exception.Length);
                }
            }).Start();
        }

        private void UpdateFormStatus(bool callingService, bool? lastResponseSuccessful, int? lastErrorCount)
        {
            if (callingService)
            {
                _status.Text = "Calling Service...";
                return;
            }

            _status.Text = string.Format("Idle; Last request {0} with {1} error{2}.",
                lastResponseSuccessful ?? true ? "succeeded" : "failed", lastErrorCount ?? 0,
                lastErrorCount != 1 ? "s" : string.Empty);
        }

        private void UpdateResponseTree(GetReportResponse response)
        {
            _response.Nodes.Clear();
            _responseDetails.Text = string.Empty;
            if (!ShowAsTree.Checked)
            {
                _responseDetails.Text = response.SerializeToXElement().ToString();
                return;
            }

            var node = new XTreeNode("Sushi Response",
                new XTreeNode("Report",
                    response.ReportResponse.Report.SerializeToXElement().ToTreeNode()),
                new XTreeNode("Exceptions",
                    (from exception in response.ReportResponse.Exception ?? new RMIT.Counter.Libraries.Sushi.Core.Exception[] { }
                        select exception.SerializeToXElement().ToTreeNode()).ToArray()));

            _response.Nodes.Add(node);

            _response.ExpandAll();
        }

        private void OnResponseSelectionChanged(object sender, TreeViewEventArgs e)
        {
            _responseDetails.Text = _response.SelectedNode.Text;
        }

        private void _requestorName_TextChanged(object sender, EventArgs e)
        {
        }
    }
}