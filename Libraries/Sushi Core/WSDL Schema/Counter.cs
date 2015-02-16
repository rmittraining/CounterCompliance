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
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

#endregion

namespace RMIT.Counter.Libraries.Sushi.Core
{
    [GeneratedCode("System.Xml", "4.0.30319.18408")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.niso.org/schemas/counter")]
    [XmlRoot(Namespace = "http://www.niso.org/schemas/counter", IsNullable = false)]
    public class Reports
    {
        [XmlElement("Report", Order = 0)]
        public List<Report> Report { get; set; }

        private static XmlSerializer _serializer = new XmlSerializer(typeof (Reports));

        #region Serialize/Deserialize

        /// <summary>
        ///     Serializes current Reports object into an XML document
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            StreamReader streamReader = null;
            MemoryStream memoryStream = null;
            try
            {
                memoryStream = new MemoryStream();
                _serializer.Serialize(memoryStream, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        ///     Deserializes workflow markup into an Reports object
        /// </summary>
        /// <param name="xml">string workflow markup to deserialize</param>
        /// <param name="obj">Output Reports object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string xml, out Reports obj, out System.Exception exception)
        {
            exception = null;
            obj = default(Reports);
            try
            {
                obj = Deserialize(xml);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string xml, out Reports obj)
        {
            System.Exception exception;
            return Deserialize(xml, out obj, out exception);
        }

        public static Reports Deserialize(string xml)
        {
            StringReader stringReader = null;
            try
            {
                stringReader = new StringReader(xml);
                return ((Reports) (_serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        /// <summary>
        ///     Serializes current Reports object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            StreamWriter streamWriter = null;
            try
            {
                var xmlString = Serialize();
                var xmlFile = new FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        ///     Deserializes xml markup from file into an Reports object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output Reports object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out Reports obj, out System.Exception exception)
        {
            exception = null;
            obj = default(Reports);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out Reports obj)
        {
            System.Exception exception;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static Reports LoadFromFile(string fileName)
        {
            FileStream file = null;
            StreamReader sr = null;
            try
            {
                file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(file);
                var xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }

        #endregion
    }

    [GeneratedCode("System.Xml", "4.0.30319.18408")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.niso.org/schemas/counter")]
    [XmlRoot(Namespace = "http://www.niso.org/schemas/counter", IsNullable = true)]
    public class Report
    {
        [XmlElement(Order = 0)]
        public Vendor Vendor { get; set; }

        [XmlElement("Customer", Order = 1)]
        public List<ReportCustomer> Customer { get; set; }

        [XmlAttribute]
        public DateTime Created { get; set; }

        [XmlIgnore]
        public bool CreatedSpecified { get; set; }

        [XmlAttribute]
        public string ID { get; set; }

        [XmlAttribute]
        public string Version { get; set; }

        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public string Title { get; set; }

        private static XmlSerializer _serializer = new XmlSerializer(typeof (Report));

        #region Serialize/Deserialize

        /// <summary>
        ///     Serializes current Report object into an XML document
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            StreamReader streamReader = null;
            MemoryStream memoryStream = null;
            try
            {
                memoryStream = new MemoryStream();
                _serializer.Serialize(memoryStream, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        ///     Deserializes workflow markup into an Report object
        /// </summary>
        /// <param name="xml">string workflow markup to deserialize</param>
        /// <param name="obj">Output Report object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string xml, out Report obj, out System.Exception exception)
        {
            exception = null;
            obj = default(Report);
            try
            {
                obj = Deserialize(xml);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string xml, out Report obj)
        {
            System.Exception exception;
            return Deserialize(xml, out obj, out exception);
        }

        public static Report Deserialize(string xml)
        {
            StringReader stringReader = null;
            try
            {
                stringReader = new StringReader(xml);
                return ((Report) (_serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        /// <summary>
        ///     Serializes current Report object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            StreamWriter streamWriter = null;
            try
            {
                var xmlString = Serialize();
                var xmlFile = new FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        ///     Deserializes xml markup from file into an Report object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output Report object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out Report obj, out System.Exception exception)
        {
            exception = null;
            obj = default(Report);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out Report obj)
        {
            System.Exception exception;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static Report LoadFromFile(string fileName)
        {
            FileStream file = null;
            StreamReader sr = null;
            try
            {
                file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(file);
                var xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }

        #endregion
    }

    [GeneratedCode("System.Xml", "4.0.30319.18408")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.niso.org/schemas/counter")]
    [XmlRoot(Namespace = "http://www.niso.org/schemas/counter", IsNullable = true)]
    public class Vendor : Organization
    {
        private static XmlSerializer _serializer = new XmlSerializer(typeof (Vendor));

        #region Serialize/Deserialize

        /// <summary>
        ///     Serializes current Vendor object into an XML document
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            StreamReader streamReader = null;
            MemoryStream memoryStream = null;
            try
            {
                memoryStream = new MemoryStream();
                _serializer.Serialize(memoryStream, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        ///     Deserializes workflow markup into an Vendor object
        /// </summary>
        /// <param name="xml">string workflow markup to deserialize</param>
        /// <param name="obj">Output Vendor object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string xml, out Vendor obj, out System.Exception exception)
        {
            exception = null;
            obj = default(Vendor);
            try
            {
                obj = Deserialize(xml);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string xml, out Vendor obj)
        {
            System.Exception exception;
            return Deserialize(xml, out obj, out exception);
        }

        public static Vendor Deserialize(string xml)
        {
            StringReader stringReader = null;
            try
            {
                stringReader = new StringReader(xml);
                return ((Vendor) (_serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        /// <summary>
        ///     Serializes current Vendor object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            StreamWriter streamWriter = null;
            try
            {
                var xmlString = Serialize();
                var xmlFile = new FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        ///     Deserializes xml markup from file into an Vendor object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output Vendor object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out Vendor obj, out System.Exception exception)
        {
            exception = null;
            obj = default(Vendor);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out Vendor obj)
        {
            System.Exception exception;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static Vendor LoadFromFile(string fileName)
        {
            FileStream file = null;
            StreamReader sr = null;
            try
            {
                file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(file);
                var xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }

        #endregion
    }

    [XmlInclude(typeof (Vendor))]
    [XmlInclude(typeof (Customer))]
    [GeneratedCode("System.Xml", "4.0.30319.18408")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.niso.org/schemas/counter")]
    [XmlRoot(Namespace = "http://www.niso.org/schemas/counter", IsNullable = true)]
    public class Organization
    {
        [XmlElement(Order = 0)]
        public string Name { get; set; }

        [XmlElement(Order = 1)]
        public string ID { get; set; }

        [XmlElement("Contact", Order = 2)]
        public List<Contact> Contact { get; set; }

        [XmlElement(DataType = "anyURI", Order = 3)]
        public string WebSiteUrl { get; set; }

        [XmlElement(DataType = "anyURI", Order = 4)]
        public string LogoUrl { get; set; }

        private static XmlSerializer _serializer = new XmlSerializer(typeof (Organization));

        #region Serialize/Deserialize

        /// <summary>
        ///     Serializes current Organization object into an XML document
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            StreamReader streamReader = null;
            MemoryStream memoryStream = null;
            try
            {
                memoryStream = new MemoryStream();
                _serializer.Serialize(memoryStream, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        ///     Deserializes workflow markup into an Organization object
        /// </summary>
        /// <param name="xml">string workflow markup to deserialize</param>
        /// <param name="obj">Output Organization object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string xml, out Organization obj, out System.Exception exception)
        {
            exception = null;
            obj = default(Organization);
            try
            {
                obj = Deserialize(xml);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string xml, out Organization obj)
        {
            System.Exception exception;
            return Deserialize(xml, out obj, out exception);
        }

        public static Organization Deserialize(string xml)
        {
            StringReader stringReader = null;
            try
            {
                stringReader = new StringReader(xml);
                return ((Organization) (_serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        /// <summary>
        ///     Serializes current Organization object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            StreamWriter streamWriter = null;
            try
            {
                var xmlString = Serialize();
                var xmlFile = new FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        ///     Deserializes xml markup from file into an Organization object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output Organization object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out Organization obj, out System.Exception exception)
        {
            exception = null;
            obj = default(Organization);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out Organization obj)
        {
            System.Exception exception;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static Organization LoadFromFile(string fileName)
        {
            FileStream file = null;
            StreamReader sr = null;
            try
            {
                file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(file);
                var xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }

        #endregion
    }

    [GeneratedCode("System.Xml", "4.0.30319.18408")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.niso.org/schemas/counter")]
    [XmlRoot(Namespace = "http://www.niso.org/schemas/counter", IsNullable = true)]
    public class Contact
    {
        [XmlElement("Contact", Order = 0)]
        public string Contact1 { get; set; }

        [XmlElement("E-mail", Order = 1)]
        public string Email { get; set; }

        private static XmlSerializer _serializer = new XmlSerializer(typeof (Contact));

        #region Serialize/Deserialize

        /// <summary>
        ///     Serializes current Contact object into an XML document
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            StreamReader streamReader = null;
            MemoryStream memoryStream = null;
            try
            {
                memoryStream = new MemoryStream();
                _serializer.Serialize(memoryStream, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        ///     Deserializes workflow markup into an Contact object
        /// </summary>
        /// <param name="xml">string workflow markup to deserialize</param>
        /// <param name="obj">Output Contact object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string xml, out Contact obj, out System.Exception exception)
        {
            exception = null;
            obj = default(Contact);
            try
            {
                obj = Deserialize(xml);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string xml, out Contact obj)
        {
            System.Exception exception;
            return Deserialize(xml, out obj, out exception);
        }

        public static Contact Deserialize(string xml)
        {
            StringReader stringReader = null;
            try
            {
                stringReader = new StringReader(xml);
                return ((Contact) (_serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        /// <summary>
        ///     Serializes current Contact object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            StreamWriter streamWriter = null;
            try
            {
                var xmlString = Serialize();
                var xmlFile = new FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        ///     Deserializes xml markup from file into an Contact object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output Contact object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out Contact obj, out System.Exception exception)
        {
            exception = null;
            obj = default(Contact);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out Contact obj)
        {
            System.Exception exception;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static Contact LoadFromFile(string fileName)
        {
            FileStream file = null;
            StreamReader sr = null;
            try
            {
                file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(file);
                var xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }

        #endregion
    }

    [GeneratedCode("System.Xml", "4.0.30319.18408")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.niso.org/schemas/counter")]
    [XmlRoot(Namespace = "http://www.niso.org/schemas/counter", IsNullable = true)]
    public class PerformanceCounter
    {
        [XmlElement(Order = 0)]
        public MetricType MetricType { get; set; }

        [XmlElement(DataType = "nonNegativeInteger", Order = 1)]
        public string Count { get; set; }

        private static XmlSerializer _serializer = new XmlSerializer(typeof (PerformanceCounter));

        #region Serialize/Deserialize

        /// <summary>
        ///     Serializes current PerformanceCounter object into an XML document
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            StreamReader streamReader = null;
            MemoryStream memoryStream = null;
            try
            {
                memoryStream = new MemoryStream();
                _serializer.Serialize(memoryStream, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        ///     Deserializes workflow markup into an PerformanceCounter object
        /// </summary>
        /// <param name="xml">string workflow markup to deserialize</param>
        /// <param name="obj">Output PerformanceCounter object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string xml, out PerformanceCounter obj, out System.Exception exception)
        {
            exception = null;
            obj = default(PerformanceCounter);
            try
            {
                obj = Deserialize(xml);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string xml, out PerformanceCounter obj)
        {
            System.Exception exception;
            return Deserialize(xml, out obj, out exception);
        }

        public static PerformanceCounter Deserialize(string xml)
        {
            StringReader stringReader = null;
            try
            {
                stringReader = new StringReader(xml);
                return ((PerformanceCounter) (_serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        /// <summary>
        ///     Serializes current PerformanceCounter object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            StreamWriter streamWriter = null;
            try
            {
                var xmlString = Serialize();
                var xmlFile = new FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        ///     Deserializes xml markup from file into an PerformanceCounter object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output PerformanceCounter object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out PerformanceCounter obj, out System.Exception exception)
        {
            exception = null;
            obj = default(PerformanceCounter);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out PerformanceCounter obj)
        {
            System.Exception exception;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static PerformanceCounter LoadFromFile(string fileName)
        {
            FileStream file = null;
            StreamReader sr = null;
            try
            {
                file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(file);
                var xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }

        #endregion
    }

    [GeneratedCode("System.Xml", "4.0.30319.18408")]
    [Serializable]
    [XmlType(Namespace = "http://www.niso.org/schemas/counter")]
    [XmlRoot(Namespace = "http://www.niso.org/schemas/counter", IsNullable = false)]
    public enum MetricType
    {
        /// <remarks />
        ft_ps,

        /// <remarks />
        ft_ps_mobile,

        /// <remarks />
        ft_pdf,

        /// <remarks />
        ft_pdf_mobile,

        /// <remarks />
        ft_html,

        /// <remarks />
        ft_html_mobile,

        /// <remarks />
        ft_epub,

        /// <remarks />
        ft_total,

        /// <remarks />
        sectioned_html,

        /// <remarks />
        toc,

        /// <remarks />
        @abstract,

        /// <remarks />
        reference,

        /// <remarks />
        data_set,

        /// <remarks />
        audio,

        /// <remarks />
        video,

        /// <remarks />
        image,

        /// <remarks />
        podcast,

        /// <remarks />
        multimedia,

        /// <remarks />
        record_view,

        /// <remarks />
        result_click,

        /// <remarks />
        search_reg,

        /// <remarks />
        search_fed,

        /// <remarks />
        turnaway,

        /// <remarks />
        no_license,

        /// <remarks />
        other,
    }

    [GeneratedCode("System.Xml", "4.0.30319.18408")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.niso.org/schemas/counter")]
    [XmlRoot(Namespace = "http://www.niso.org/schemas/counter", IsNullable = true)]
    public class DateRange
    {
        [XmlElement(DataType = "date", Order = 0)]
        public DateTime Begin { get; set; }

        [XmlElement(DataType = "date", Order = 1)]
        public DateTime End { get; set; }

        private static XmlSerializer _serializer = new XmlSerializer(typeof (DateRange));

        #region Serialize/Deserialize

        /// <summary>
        ///     Serializes current DateRange object into an XML document
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            StreamReader streamReader = null;
            MemoryStream memoryStream = null;
            try
            {
                memoryStream = new MemoryStream();
                _serializer.Serialize(memoryStream, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        ///     Deserializes workflow markup into an DateRange object
        /// </summary>
        /// <param name="xml">string workflow markup to deserialize</param>
        /// <param name="obj">Output DateRange object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string xml, out DateRange obj, out System.Exception exception)
        {
            exception = null;
            obj = default(DateRange);
            try
            {
                obj = Deserialize(xml);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string xml, out DateRange obj)
        {
            System.Exception exception;
            return Deserialize(xml, out obj, out exception);
        }

        public static DateRange Deserialize(string xml)
        {
            StringReader stringReader = null;
            try
            {
                stringReader = new StringReader(xml);
                return ((DateRange) (_serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        /// <summary>
        ///     Serializes current DateRange object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            StreamWriter streamWriter = null;
            try
            {
                var xmlString = Serialize();
                var xmlFile = new FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        ///     Deserializes xml markup from file into an DateRange object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output DateRange object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out DateRange obj, out System.Exception exception)
        {
            exception = null;
            obj = default(DateRange);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out DateRange obj)
        {
            System.Exception exception;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static DateRange LoadFromFile(string fileName)
        {
            FileStream file = null;
            StreamReader sr = null;
            try
            {
                file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(file);
                var xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }

        #endregion
    }

    [GeneratedCode("System.Xml", "4.0.30319.18408")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.niso.org/schemas/counter")]
    [XmlRoot(Namespace = "http://www.niso.org/schemas/counter", IsNullable = true)]
    public class Metric
    {
        [XmlElement(Order = 0)]
        public DateRange Period { get; set; }

        [XmlElement(Order = 1)]
        public Category Category { get; set; }

        [XmlElement("Instance", Order = 2)]
        public List<PerformanceCounter> Instance { get; set; }

        [XmlAttribute(DataType = "gYear")]
        public string PubYr { get; set; }

        [XmlAttribute(DataType = "gYear")]
        public string PubYrFrom { get; set; }

        [XmlAttribute(DataType = "gYear")]
        public string PubYrTo { get; set; }

        private static XmlSerializer _serializer = new XmlSerializer(typeof (Metric));

        #region Serialize/Deserialize

        /// <summary>
        ///     Serializes current Metric object into an XML document
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            StreamReader streamReader = null;
            MemoryStream memoryStream = null;
            try
            {
                memoryStream = new MemoryStream();
                _serializer.Serialize(memoryStream, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        ///     Deserializes workflow markup into an Metric object
        /// </summary>
        /// <param name="xml">string workflow markup to deserialize</param>
        /// <param name="obj">Output Metric object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string xml, out Metric obj, out System.Exception exception)
        {
            exception = null;
            obj = default(Metric);
            try
            {
                obj = Deserialize(xml);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string xml, out Metric obj)
        {
            System.Exception exception;
            return Deserialize(xml, out obj, out exception);
        }

        public static Metric Deserialize(string xml)
        {
            StringReader stringReader = null;
            try
            {
                stringReader = new StringReader(xml);
                return ((Metric) (_serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        /// <summary>
        ///     Serializes current Metric object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            StreamWriter streamWriter = null;
            try
            {
                var xmlString = Serialize();
                var xmlFile = new FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        ///     Deserializes xml markup from file into an Metric object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output Metric object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out Metric obj, out System.Exception exception)
        {
            exception = null;
            obj = default(Metric);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out Metric obj)
        {
            System.Exception exception;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static Metric LoadFromFile(string fileName)
        {
            FileStream file = null;
            StreamReader sr = null;
            try
            {
                file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(file);
                var xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }

        #endregion
    }

    [GeneratedCode("System.Xml", "4.0.30319.18408")]
    [Serializable]
    [XmlType(Namespace = "http://www.niso.org/schemas/counter")]
    [XmlRoot(Namespace = "http://www.niso.org/schemas/counter", IsNullable = false)]
    public enum Category
    {
        /// <remarks />
        Requests,

        /// <remarks />
        Searches,

        /// <remarks />
        Access_denied,
    }

    [GeneratedCode("System.Xml", "4.0.30319.18408")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.niso.org/schemas/counter")]
    [XmlRoot(Namespace = "http://www.niso.org/schemas/counter", IsNullable = true)]
    public class ReportItem
    {
        [XmlElement("ItemIdentifier", Order = 0)]
        public List<Identifier> ItemIdentifier { get; set; }

        [XmlElement(Order = 1)]
        public string ItemPlatform { get; set; }

        [XmlElement(Order = 2)]
        public string ItemPublisher { get; set; }

        [XmlElement(Order = 3)]
        public string ItemName { get; set; }

        [XmlElement(Order = 4)]
        public DataType ItemDataType { get; set; }

        [XmlElement("ItemPerformance", Order = 5)]
        public List<Metric> ItemPerformance { get; set; }

        private static XmlSerializer _serializer = new XmlSerializer(typeof (ReportItem));

        #region Serialize/Deserialize

        /// <summary>
        ///     Serializes current ReportItem object into an XML document
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            StreamReader streamReader = null;
            MemoryStream memoryStream = null;
            try
            {
                memoryStream = new MemoryStream();
                _serializer.Serialize(memoryStream, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        ///     Deserializes workflow markup into an ReportItem object
        /// </summary>
        /// <param name="xml">string workflow markup to deserialize</param>
        /// <param name="obj">Output ReportItem object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string xml, out ReportItem obj, out System.Exception exception)
        {
            exception = null;
            obj = default(ReportItem);
            try
            {
                obj = Deserialize(xml);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string xml, out ReportItem obj)
        {
            System.Exception exception;
            return Deserialize(xml, out obj, out exception);
        }

        public static ReportItem Deserialize(string xml)
        {
            StringReader stringReader = null;
            try
            {
                stringReader = new StringReader(xml);
                return ((ReportItem) (_serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        /// <summary>
        ///     Serializes current ReportItem object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            StreamWriter streamWriter = null;
            try
            {
                var xmlString = Serialize();
                var xmlFile = new FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        ///     Deserializes xml markup from file into an ReportItem object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output ReportItem object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out ReportItem obj, out System.Exception exception)
        {
            exception = null;
            obj = default(ReportItem);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out ReportItem obj)
        {
            System.Exception exception;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static ReportItem LoadFromFile(string fileName)
        {
            FileStream file = null;
            StreamReader sr = null;
            try
            {
                file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(file);
                var xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }

        #endregion
    }

    [GeneratedCode("System.Xml", "4.0.30319.18408")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.niso.org/schemas/counter")]
    [XmlRoot(Namespace = "http://www.niso.org/schemas/counter", IsNullable = true)]
    public class Identifier
    {
        [XmlElement(Order = 0)]
        public IdentifierType Type { get; set; }

        [XmlElement(Order = 1)]
        public string Value { get; set; }

        private static XmlSerializer _serializer = new XmlSerializer(typeof (Identifier));

        #region Serialize/Deserialize

        /// <summary>
        ///     Serializes current Identifier object into an XML document
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            StreamReader streamReader = null;
            MemoryStream memoryStream = null;
            try
            {
                memoryStream = new MemoryStream();
                _serializer.Serialize(memoryStream, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        ///     Deserializes workflow markup into an Identifier object
        /// </summary>
        /// <param name="xml">string workflow markup to deserialize</param>
        /// <param name="obj">Output Identifier object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string xml, out Identifier obj, out System.Exception exception)
        {
            exception = null;
            obj = default(Identifier);
            try
            {
                obj = Deserialize(xml);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string xml, out Identifier obj)
        {
            System.Exception exception;
            return Deserialize(xml, out obj, out exception);
        }

        public static Identifier Deserialize(string xml)
        {
            StringReader stringReader = null;
            try
            {
                stringReader = new StringReader(xml);
                return ((Identifier) (_serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        /// <summary>
        ///     Serializes current Identifier object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            StreamWriter streamWriter = null;
            try
            {
                var xmlString = Serialize();
                var xmlFile = new FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        ///     Deserializes xml markup from file into an Identifier object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output Identifier object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out Identifier obj, out System.Exception exception)
        {
            exception = null;
            obj = default(Identifier);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out Identifier obj)
        {
            System.Exception exception;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static Identifier LoadFromFile(string fileName)
        {
            FileStream file = null;
            StreamReader sr = null;
            try
            {
                file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(file);
                var xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }

        #endregion
    }

    [GeneratedCode("System.Xml", "4.0.30319.18408")]
    [Serializable]
    [XmlType(Namespace = "http://www.niso.org/schemas/counter")]
    [XmlRoot(Namespace = "http://www.niso.org/schemas/counter", IsNullable = false)]
    public enum IdentifierType
    {
        /// <remarks />
        Online_ISSN,

        /// <remarks />
        Print_ISSN,

        /// <remarks />
        EISSN,

        /// <remarks />
        ISSN,

        /// <remarks />
        ISBN,

        /// <remarks />
        Online_ISBN,

        /// <remarks />
        Print_ISBN,

        /// <remarks />
        DOI,

        /// <remarks />
        Proprietary,
    }

    [GeneratedCode("System.Xml", "4.0.30319.18408")]
    [Serializable]
    [XmlType(Namespace = "http://www.niso.org/schemas/counter")]
    [XmlRoot(Namespace = "http://www.niso.org/schemas/counter", IsNullable = false)]
    public enum DataType
    {
        /// <remarks />
        Journal,

        /// <remarks />
        Database,

        /// <remarks />
        Platform,

        /// <remarks />
        Book,

        /// <remarks />
        Collection,

        /// <remarks />
        Multimedia,
    }

    [GeneratedCode("System.Xml", "4.0.30319.18408")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.niso.org/schemas/counter")]
    [XmlRoot(Namespace = "http://www.niso.org/schemas/counter", IsNullable = true)]
    public class Consortium
    {
        [XmlElement(Order = 0)]
        public string Code { get; set; }

        [XmlElement(Order = 1)]
        public string WellKnownName { get; set; }

        private static XmlSerializer _serializer = new XmlSerializer(typeof (Consortium));

        #region Serialize/Deserialize

        /// <summary>
        ///     Serializes current Consortium object into an XML document
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            StreamReader streamReader = null;
            MemoryStream memoryStream = null;
            try
            {
                memoryStream = new MemoryStream();
                _serializer.Serialize(memoryStream, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        ///     Deserializes workflow markup into an Consortium object
        /// </summary>
        /// <param name="xml">string workflow markup to deserialize</param>
        /// <param name="obj">Output Consortium object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string xml, out Consortium obj, out System.Exception exception)
        {
            exception = null;
            obj = default(Consortium);
            try
            {
                obj = Deserialize(xml);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string xml, out Consortium obj)
        {
            System.Exception exception;
            return Deserialize(xml, out obj, out exception);
        }

        public static Consortium Deserialize(string xml)
        {
            StringReader stringReader = null;
            try
            {
                stringReader = new StringReader(xml);
                return ((Consortium) (_serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        /// <summary>
        ///     Serializes current Consortium object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            StreamWriter streamWriter = null;
            try
            {
                var xmlString = Serialize();
                var xmlFile = new FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        ///     Deserializes xml markup from file into an Consortium object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output Consortium object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out Consortium obj, out System.Exception exception)
        {
            exception = null;
            obj = default(Consortium);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out Consortium obj)
        {
            System.Exception exception;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static Consortium LoadFromFile(string fileName)
        {
            FileStream file = null;
            StreamReader sr = null;
            try
            {
                file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(file);
                var xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }

        #endregion
    }

    [GeneratedCode("System.Xml", "4.0.30319.18408")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.niso.org/schemas/counter")]
    [XmlRoot(Namespace = "http://www.niso.org/schemas/counter", IsNullable = true)]
    public class Customer : Organization
    {
        [XmlElement(Order = 0)]
        public Consortium Consortium { get; set; }

        [XmlElement("InstitutionalIdentifier", Order = 1)]
        public List<Identifier> InstitutionalIdentifier { get; set; }

        private static XmlSerializer _serializer = new XmlSerializer(typeof (Customer));

        #region Serialize/Deserialize

        /// <summary>
        ///     Serializes current Customer object into an XML document
        /// </summary>
        /// <returns>string XML value</returns>
        public override string Serialize()
        {
            StreamReader streamReader = null;
            MemoryStream memoryStream = null;
            try
            {
                memoryStream = new MemoryStream();
                _serializer.Serialize(memoryStream, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        ///     Deserializes workflow markup into an Customer object
        /// </summary>
        /// <param name="xml">string workflow markup to deserialize</param>
        /// <param name="obj">Output Customer object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string xml, out Customer obj, out System.Exception exception)
        {
            exception = null;
            obj = default(Customer);
            try
            {
                obj = Deserialize(xml);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string xml, out Customer obj)
        {
            System.Exception exception;
            return Deserialize(xml, out obj, out exception);
        }

        public static Customer Deserialize(string xml)
        {
            StringReader stringReader = null;
            try
            {
                stringReader = new StringReader(xml);
                return ((Customer) (_serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        /// <summary>
        ///     Serializes current Customer object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public override bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public override void SaveToFile(string fileName)
        {
            StreamWriter streamWriter = null;
            try
            {
                var xmlString = Serialize();
                var xmlFile = new FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        ///     Deserializes xml markup from file into an Customer object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output Customer object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out Customer obj, out System.Exception exception)
        {
            exception = null;
            obj = default(Customer);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out Customer obj)
        {
            System.Exception exception;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static Customer LoadFromFile(string fileName)
        {
            FileStream file = null;
            StreamReader sr = null;
            try
            {
                file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(file);
                var xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }

        #endregion
    }

    [GeneratedCode("System.Xml", "4.0.30319.18408")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.niso.org/schemas/counter")]
    public class ReportCustomer : Customer
    {
        [XmlElement("ReportItems", Order = 0)]
        public List<ReportItem> ReportItems { get; set; }

        private static XmlSerializer _serializer = new XmlSerializer(typeof (ReportCustomer));

        #region Serialize/Deserialize

        /// <summary>
        ///     Serializes current ReportCustomer object into an XML document
        /// </summary>
        /// <returns>string XML value</returns>
        public override string Serialize()
        {
            StreamReader streamReader = null;
            MemoryStream memoryStream = null;
            try
            {
                memoryStream = new MemoryStream();
                _serializer.Serialize(memoryStream, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        ///     Deserializes workflow markup into an ReportCustomer object
        /// </summary>
        /// <param name="xml">string workflow markup to deserialize</param>
        /// <param name="obj">Output ReportCustomer object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string xml, out ReportCustomer obj, out System.Exception exception)
        {
            exception = null;
            obj = default(ReportCustomer);
            try
            {
                obj = Deserialize(xml);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string xml, out ReportCustomer obj)
        {
            System.Exception exception;
            return Deserialize(xml, out obj, out exception);
        }

        public static ReportCustomer Deserialize(string xml)
        {
            StringReader stringReader = null;
            try
            {
                stringReader = new StringReader(xml);
                return ((ReportCustomer) (_serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        /// <summary>
        ///     Serializes current ReportCustomer object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public override bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public override void SaveToFile(string fileName)
        {
            StreamWriter streamWriter = null;
            try
            {
                var xmlString = Serialize();
                var xmlFile = new FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        ///     Deserializes xml markup from file into an ReportCustomer object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output ReportCustomer object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out ReportCustomer obj, out System.Exception exception)
        {
            exception = null;
            obj = default(ReportCustomer);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out ReportCustomer obj)
        {
            System.Exception exception;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static ReportCustomer LoadFromFile(string fileName)
        {
            FileStream file = null;
            StreamReader sr = null;
            try
            {
                file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(file);
                var xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }

        #endregion
    }

    [GeneratedCode("System.Xml", "4.0.30319.18408")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.niso.org/schemas/counter")]
    [XmlRoot(Namespace = "http://www.niso.org/schemas/counter", IsNullable = true)]
    public class IPAddress
    {
        [XmlAttribute]
        public IPAddressType type { get; set; }

        [XmlText]
        public string Value { get; set; }

        private static XmlSerializer _serializer = new XmlSerializer(typeof (IPAddress));

        #region Serialize/Deserialize

        /// <summary>
        ///     Serializes current IPAddress object into an XML document
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            StreamReader streamReader = null;
            MemoryStream memoryStream = null;
            try
            {
                memoryStream = new MemoryStream();
                _serializer.Serialize(memoryStream, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        ///     Deserializes workflow markup into an IPAddress object
        /// </summary>
        /// <param name="xml">string workflow markup to deserialize</param>
        /// <param name="obj">Output IPAddress object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string xml, out IPAddress obj, out System.Exception exception)
        {
            exception = null;
            obj = default(IPAddress);
            try
            {
                obj = Deserialize(xml);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string xml, out IPAddress obj)
        {
            System.Exception exception;
            return Deserialize(xml, out obj, out exception);
        }

        public static IPAddress Deserialize(string xml)
        {
            StringReader stringReader = null;
            try
            {
                stringReader = new StringReader(xml);
                return ((IPAddress) (_serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        /// <summary>
        ///     Serializes current IPAddress object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            StreamWriter streamWriter = null;
            try
            {
                var xmlString = Serialize();
                var xmlFile = new FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        ///     Deserializes xml markup from file into an IPAddress object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output IPAddress object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out IPAddress obj, out System.Exception exception)
        {
            exception = null;
            obj = default(IPAddress);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out IPAddress obj)
        {
            System.Exception exception;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static IPAddress LoadFromFile(string fileName)
        {
            FileStream file = null;
            StreamReader sr = null;
            try
            {
                file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(file);
                var xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }

        #endregion
    }

    [GeneratedCode("System.Xml", "4.0.30319.18408")]
    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.niso.org/schemas/counter")]
    public enum IPAddressType
    {
        /// <remarks />
        single,

        /// <remarks />
        range,

        /// <remarks />
        wildcard,

        /// <remarks />
        subnet,

        /// <remarks />
        cidr,
    }
}