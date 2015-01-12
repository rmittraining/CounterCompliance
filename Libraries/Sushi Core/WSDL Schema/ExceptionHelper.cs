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
using System.Data.SqlClient;

#endregion

namespace RMIT.Counter.Libraries.Sushi.Core
{
    /// <summary>
    ///     Extends the <see cref="System.Exception" /> class with Sushi-specific functionality.
    /// </summary>
    public static class ExceptionHelper
    {
        /// <summary>
        ///     Flattens the hierarchical <see cref="System.Exception" /> instance into a collection of
        ///     <see cref="Exception" /> instances.
        /// </summary>
        /// <param name="exception">The <see cref="System.Exception" /> to convert.</param>
        /// <param name="exceptionSeverity"></param>
        /// <returns>
        ///     A <see cref="IEnumerable{T}" /> collection.
        /// </returns>
        public static Exception[] ToSushiExceptions(System.Exception exception,
            ExceptionSeverity exceptionSeverity = ExceptionSeverity.Error)
        {
            var hResult = exception.HResult;
            var msg = exception.Message;

            var ex = exception as SqlException;

            if (ex != null && ex.Number == -2)
            {
                hResult = 1010;
                msg = @"Service Busy";
                exceptionSeverity = ExceptionSeverity.Fatal;
            }

            if (ex != null && ex.Number == 2)
            {
                hResult = 1000;
                msg = @"Service Not Available";
                exceptionSeverity = ExceptionSeverity.Fatal;
            }


            return new[] {Exceptions(exception, hResult, msg, exceptionSeverity)};
        }

        private static Exception Exceptions(System.Exception exception, int num, string message,
            ExceptionSeverity exceptionSeverity)
        {
            var item = new Exception
            {
                Number = num,
                Message = message,
                HelpUrl = ConfigurationManager.AppSettings["Sushi.SupportUrl"],
                Created = DateTime.Now,
                Severity = exceptionSeverity,
                CreatedSpecified = true,
            };

            if (exception.InnerException != null)
            {
                ToSushiExceptions(exception.InnerException);
            }
            return item;
        }
    }
}