<?xml version="1.0" encoding="UTF-8"?>

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:c="http://www.niso.org/schemas/counter" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
                >
  <xsl:output method="xml" version="1.0" encoding="UTF-8" indent="yes" />

  <xsl:variable name="Title" select="'Journal Report 5'" />
  <xsl:variable name="Name" select="'JR5'" />
  <xsl:variable name="Version" select="'3.0'" />

  <xsl:template match="/">
    <c:Reports xsi:schemaLocation="http://www.niso.org/schemas/counter http://www.niso.org/schemas/sushi/counter4_0.xsd">
      <xsl:apply-templates select="/ReportData/Header"/>
    </c:Reports>
  </xsl:template>
  
  <xsl:template match="Header">
    <c:Report>
        <xsl:attribute name="ID">
          <xsl:value-of select="CustomerName" />
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
          <xsl:value-of select="CreatedDateTime" />
        </xsl:attribute>

        <c:Vendor>
          <c:Name>
            <xsl:value-of select="VendorName" />
          </c:Name>
          <c:ID>
            <xsl:value-of select="VendorID" />
          </c:ID>
          <c:Contact>
            <c:Contact>
              <xsl:value-of select="VendorContactName" />
            </c:Contact>
            <c:E-mail>
              <xsl:value-of select="VendorContactEmail" />
            </c:E-mail>
          </c:Contact>
        </c:Vendor>
        <c:Customer>
          <c:Name>
            <xsl:value-of select="CustomerName" />
          </c:Name>
          <c:ID>
            <xsl:value-of select="CustomerId" />
          </c:ID>
          <!--<c:Contact>
            <c:Contact>
              <xsl:value-of select="CustomerContactName" />
            </c:Contact>
            <c:E-mail>
              <xsl:value-of select="CustomerContactEmail" />
            </c:E-mail>
          </c:Contact>-->
          <xsl:apply-templates select="../Item"/>
        </c:Customer>
      </c:Report>
  </xsl:template>
  
  <xsl:template match="Item">

    <c:ReportItems>
      <xsl:if test="Online_ISSN">
        <c:ItemIdentifier>
          <c:Type>Online_ISSN</c:Type>
          <c:Value>
            <xsl:value-of select="Online_ISSN" />
          </c:Value>
        </c:ItemIdentifier>
      </xsl:if>
      <xsl:if test="Print_ISSN">
        <c:ItemIdentifier>
          <c:Type>Print_ISSN</c:Type>
          <c:Value>
            <xsl:value-of select="Print_ISSN" />
          </c:Value>
        </c:ItemIdentifier>
      </xsl:if>
      <c:ItemPlatform>
        <xsl:value-of select="Platform" />
      </c:ItemPlatform>
      <xsl:if test="Publisher">
        <c:ItemPublisher>
          <xsl:value-of select="Publisher" />
        </c:ItemPublisher>
      </xsl:if>
      <c:ItemName>
        <xsl:value-of select="Name" />
      </c:ItemName>
      <c:ItemDataType>
        <xsl:value-of select="DataType" />
      </c:ItemDataType>
      <xsl:apply-templates select="ItemPerformance"/>
    </c:ReportItems>
  </xsl:template>
  
  <xsl:template match="ItemPerformance">

    <c:ItemPerformance>
      <xsl:choose>
        <!-- Full Year -->
        <xsl:when test="PubYrFrom and PubYrTo">
          <xsl:attribute name="PubYr"><xsl:value-of select="PubYrTo"/></xsl:attribute>
        </xsl:when>
        <!-- Pre - year, like Pre 2000 which has a YearTo as 1999-->
        <xsl:when test="PubYrTo[not(../PubYrFrom)]">
          <xsl:attribute name="PubYrTo"><xsl:value-of select="PubYrTo+1"/></xsl:attribute>
        </xsl:when>
        <!-- UNKNOWN -->
        <xsl:otherwise>
          <xsl:attribute name="PubYr">0001</xsl:attribute>
      </xsl:otherwise>
      </xsl:choose>
      <c:Period>
        <c:Begin>
          <xsl:value-of select="substring(//ReportData/Header/Start,1,10)" />
        </c:Begin>
        <c:End>
          <xsl:value-of select="substring(//ReportData/Header/End,1,10)" />
        </c:End>
      </c:Period>
      <c:Category>
        <xsl:value-of select="//ReportData/Header/Category" />
      </c:Category>
      <c:Instance>
        <c:MetricType>ft_total</c:MetricType>
        <c:Count>
          <xsl:value-of select="Count" />
        </c:Count>
      </c:Instance>
    </c:ItemPerformance>
      
  </xsl:template>
</xsl:stylesheet>