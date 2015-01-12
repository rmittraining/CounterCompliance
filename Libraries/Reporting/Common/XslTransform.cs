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
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Xsl;
using RMIT.Counter.Libraries.Reporting.Interfaces;

#endregion

namespace RMIT.Counter.Libraries.Reporting.Common
{
    public class XslTransform : ITransform
    {
        private readonly string _folder;

        public XslTransform(string folder)
        {
            _folder = folder;
        }

        public string Transform(IReportData data, ReportFormat formatter)
        {
            var xsl = GetXslt(data, formatter);
            var xml = data.GetDataset().GetXml();

            using (var sr = new StringReader(xml))
            {
                using (var reader = XmlReader.Create(sr))
                {
                    using (var writer = new Utf8StringWriter())
                    {
                        xsl.Transform(reader, null, writer);
                        return writer.ToString();
                    }
                }
            }
        }

        private XslCompiledTransform GetXslt(IReportData data, ReportFormat formatter)
        {
            var fileName = Path.Combine(_folder, data.GetType().Name,
                Enum.GetName(typeof (ReportFormat), formatter) + ".xslt");

            var xsl = new XslCompiledTransform();
            var settings = new XsltSettings(true, true);
            xsl.Load(fileName, settings, new XmlUrlResolver());
            return xsl;
        }

        private sealed class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding
            {
                get { return Encoding.UTF8; }
            }
        }
    }
}