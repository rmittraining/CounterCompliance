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
using System.Configuration;
using System.Linq;

#endregion

namespace RMIT.Counter.Libraries.Reporting.Common
{
    public class Config
    {
        static Config()
        {
            //Reports Database
            //ConnectionString = ConfigurationManager.ConnectionStrings["example"].ConnectionString;
            TimeoutLarge = int.Parse(ConfigurationManager.AppSettings["Reports.Timeout.Large"] ?? "0");

            //Sushi settings

            #region Sushi settings

            CounterXsltFolder = ConfigurationManager.AppSettings["Sushi.CounterXsltFolder"];
            SushiVendorName = ConfigurationManager.AppSettings["Sushi.VendorName"];
            SushiVendorId = ConfigurationManager.AppSettings["Sushi.VendorID"];
            SushiVendorContactName = ConfigurationManager.AppSettings["Sushi.VendorContactName"];
            SushiVendorContactEmail = ConfigurationManager.AppSettings["Sushi.VendorContactEmail"];
            SushiPlatform = ConfigurationManager.AppSettings["Sushi.Platform"];


            SushiSupportUrl = ConfigurationManager.AppSettings["Sushi.SupportUrl"];

            SushiPartialDates = GetPartialDates();

            #endregion
        }

        private static Dictionary<DateTime, DateTime> GetPartialDates()
        {
            var dateRanges = (ConfigurationManager.AppSettings["Sushi.PartialDates"] ?? "").Split(',');
            return
                dateRanges.Select(dateRange => dateRange.Split(new[] {" to "}, StringSplitOptions.RemoveEmptyEntries))
                    .Where(dates => dates.Length > 0)
                    .ToDictionary(dates => Convert.ToDateTime(dates[0]), dates => Convert.ToDateTime(dates[1]));
        }


        //public static readonly string ConnectionString;

        #region Sushi settings

        /// <summary>
        ///     Gets the Report database server connection string.
        /// </summary>
        /// <value>
        ///     The connection string.
        /// </value>
        /// <summary>
        ///     The counter XSLT folder
        /// </summary>
        public static string CounterXsltFolder;

        /// <summary>
        ///     The sushi vendor name
        /// </summary>
        public static readonly string SushiVendorName;

        /// <summary>
        ///     The sushi vendor identifier
        /// </summary>
        public static readonly string SushiVendorId;

        /// <summary>
        ///     The sushi vendor contact name
        /// </summary>
        public static readonly string SushiVendorContactName;

        /// <summary>
        ///     The sushi vendor contact email
        /// </summary>
        public static readonly string SushiVendorContactEmail;

        /// <summary>
        ///     The sushi platform name
        /// </summary>
        public static readonly string SushiPlatform;


        public static readonly int TimeoutLarge;

        /// <summary>
        ///     The sushi support Url
        /// </summary>
        public static string SushiSupportUrl;

        public static Dictionary<DateTime, DateTime> SushiPartialDates;

        #endregion
    }
}