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

using NUnit.Framework;
using RMIT.Counter.Libraries.Sushi.Core;
using RMIT.Counter.Libraries.Sushi.Implementation;

#endregion

namespace RMIT.Counter.Test.Unit.Libraries.Sushi.Implementation
{
    [TestFixture]
    public class AuthorizationAuthorityTest
    {
        [TestCase("123ABC", "guest", Result = true)]
        [TestCase("123ABC", "GUEST", Result = true)]
        [TestCase("wrong", "guest", Result = false)]
        [TestCase("wrong", "GUEST", Result = false)]
        [TestCase("123ABC", "wrong", Result = false)]
        [TestCase("wrong", " guest ", Result = false)]
        public bool CombinationChecks(string id, string name)
        {
            //Arrange
            var authority = new AuthorizationAuthority();
            var customerReference = new CustomerReference {ID = id, Name = name};
            
            //Act
            return authority.IsRequestorAuthorized(null, customerReference);
        }
    }
}