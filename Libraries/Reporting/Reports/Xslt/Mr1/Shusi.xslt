<?xml version="1.0" encoding="UTF-8"?>

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:c="http://www.niso.org/schemas/counter" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
                >
  <xsl:output method="xml" version="1.0" encoding="UTF-8" indent="yes" />

  <xsl:variable name="Title" select="'Media Report 1'" />
  <xsl:variable name="Name" select="'MR1'" />
  <xsl:variable name="Version" select="'3.0'" />

  <xsl:key name="groups" match="/ReportData/Item/ItemPerformance" use="PeriodStart" />

  <xsl:template match="/">
    <c:Reports xsi:schemaLocation="http://www.niso.org/schemas/counter http://www.niso.org/schemas/sushi/counter4_0.xsd">
      <xsl:apply-templates select="ReportData/Item/ItemPerformance[generate-id() = generate-id(key('groups', PeriodStart)[1])]"/>
    </c:Reports>
  </xsl:template>

  <xsl:template match="ItemPerformance">

    <c:Report>
      <xsl:attribute name="ID">
        <xsl:value-of select="//ReportData/Header/CustomerName" />_<xsl:value-of select="Month" />__<xsl:value-of select="Year" />
      </xsl:attribute>
      <xsl:attribute name="Title">
        <xsl:value-of select="$Title" />
      </xsl:attribute>
      <xsl:attribute name="Name">
        <xsl:value-of select="$Name" />
      </xsl:attribute>
      <xsl:attribute name="Version">
        <xsl:value-of select="$Version" />
      </xsl:attribute>
      <xsl:attribute name="Created">
        <xsl:value-of select="//ReportData/Header/CreatedDateTime" />
      </xsl:attribute>

      <c:Vendor>
        <c:Name>
          <xsl:value-of select="//ReportData/Header/VendorName" />
        </c:Name>
        <c:ID>
          <xsl:value-of select="//ReportData/Header/VendorID" />
        </c:ID>
        <c:Contact>
          <c:Contact>
            <xsl:value-of select="//ReportData/Header/VendorContactName" />
          </c:Contact>
          <c:E-mail>
            <xsl:value-of select="//ReportData/Header/VendorContactEmail" />
          </c:E-mail>
        </c:Contact>
      </c:Vendor>
      <c:Customer>
        <c:Name>
          <xsl:value-of select="//ReportData/Header/CustomerName" />
        </c:Name>
        <c:ID>
          <xsl:value-of select="//ReportData/Header/CustomerId" />
        </c:ID>
        <!--<c:Contact>
          <c:Contact>
            <xsl:value-of select="//ReportData/Header/CustomerContactName" />
          </c:Contact>
          <c:E-mail>
            <xsl:value-of select="//ReportData/Header/CustomerContactEmail" />
          </c:E-mail>
        </c:Contact>-->
        <xsl:for-each select="key('groups', PeriodStart)">
          <c:ReportItems>
           <c:ItemPlatform>
              <xsl:value-of select="../Platform" />
            </c:ItemPlatform>
            <xsl:if test="../Publisher">
              <c:ItemPublisher>
                <xsl:value-of select="../Publisher" />
              </c:ItemPublisher>
            </xsl:if>
            <c:ItemName>
              <xsl:value-of select="../Name" />
            </c:ItemName>
            <c:ItemDataType>
              <xsl:value-of select="../DataType" />
            </c:ItemDataType>
            <c:ItemPerformance>
              <c:Period>
                <c:Begin>
                  <xsl:value-of select="substring(PeriodStart,1,10)" />
                </c:Begin>
                <c:End>
                  <xsl:value-of select="substring(PeriodEnd,1,10)" />
                </c:End>
              </c:Period>
              <c:Category>
                <xsl:value-of select="Category" />
              </c:Category>
              <c:Instance>
                <c:MetricType>multimedia</c:MetricType>
                <c:Count>
                  <xsl:value-of select="Multimedia" />
                </c:Count>
              </c:Instance>
            </c:ItemPerformance>
          </c:ReportItems>
        </xsl:for-each>
      </c:Customer>
    </c:Report>
  </xsl:template>
</xsl:stylesheet>