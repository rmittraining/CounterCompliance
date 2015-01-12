<?xml version="1.0"?>

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:csv="csv:csv">
  <xsl:output method="text" encoding="utf-8" />

  <!--Keys for Group by Months and publisher-->
  <xsl:key name="publisherKey" match="//Item/Publisher" use="text()" />

  <!--Variable Declaration-->
  <xsl:strip-space elements="*" />
  <xsl:variable name="delimiter" select="','" />
  <xsl:variable name="platform" select="'Informit'" />
  <xsl:variable name="quote" select="'&quot;'" />
  <xsl:variable name="countDistinctPublisher" select="0" />

  <!--CSV,TSV Column Declaration-->
  <csv:columns>
    <column>Journal</column>
    <column>Publisher</column>
    <column>Platform</column>
    <column>Journal DOI</column>
    <column>Property Identifier</column>
    <column>Print ISSN</column>
    <column>Online ISSN</column>
    <column>Articles in Press</column>
  </csv:columns>

  <!-- Start with root node -->
  <xsl:template match="/">

    <!-- Output the header information -->
    <xsl:text>Journal Report 5 (R4)</xsl:text>
    <xsl:value-of select="$delimiter" />
    <xsl:text>Number of Successful Full-text Article Requests by Month and Journal</xsl:text>
    <xsl:text>&#xa;</xsl:text>

    <xsl:value-of select="/ReportData/Header/CustomerName" />
    <xsl:text>&#xa;</xsl:text>

    <xsl:text></xsl:text>
    <xsl:text>&#xa;</xsl:text>

    <xsl:text>Period covered by Report</xsl:text>
    <xsl:text>&#xa;</xsl:text>

    <xsl:value-of select="substring-before(/ReportData/Header/StartDate,'T')" />
    <xsl:text> to </xsl:text>
    <xsl:value-of select="substring-before(/ReportData/Header/EndDate,'T')" />
    <xsl:text>&#xa;</xsl:text>

    <xsl:text>Date Run:</xsl:text>
    <xsl:text>&#xa;</xsl:text>

    <xsl:value-of select="substring-before(/ReportData/Header/CreatedDateTime,'T')" />
    <xsl:text>&#xa;</xsl:text>

    <!-- Main table headers row with computed months -->
    <xsl:for-each select="document('')/*/csv:columns/*">
      <xsl:value-of select="$quote" />
      <xsl:value-of select="." />
      <xsl:value-of select="$quote" />
      <xsl:value-of select="$delimiter" />
    </xsl:for-each>

    <!-- Computed Years from YearlySummary  -->
    <!-- assumptions: - yearly summary will be always sorted with PbYrFrom in sql query  -->
    <!-- assumptions: - if pubYearFrom has value in it then pbYrTo must also have value. it is also taken care in sql query.  -->
    <xsl:for-each select="//ReportData/YearlySummary">
      <xsl:choose>
        <xsl:when test="PubYrFrom!=''">
          <xsl:text>YOP </xsl:text>
          <xsl:value-of select="PubYrFrom" />
        </xsl:when>
        <xsl:when test="not(PubYrFrom) and PubYrTo!=''">
          <xsl:text>YOP Pre-</xsl:text>
          <xsl:value-of select="PubYrTo+1" />
        </xsl:when>
        <xsl:when test="not(PubYrFrom) and not(PubYrTo)">
          <xsl:text>YOP Unknown </xsl:text>
        </xsl:when>
      </xsl:choose>
      <xsl:if test="position() != last()">
      <xsl:value-of select="$delimiter" />
      </xsl:if>
      </xsl:for-each>
    <xsl:text>&#xa;</xsl:text>



    <!--Main table total for all journals Row-->
    <xsl:text>Total for all journals</xsl:text>
    <xsl:value-of select="$delimiter" />

    <!--Cell B9 contains the name of the publisher/vendor, provided all the journals listed in column A are from
        the same publisher/vendor. If not, this cell is left blank.-->
    <xsl:for-each select="//Item/Publisher [generate-id() = generate-id(key('publisherKey', text())[1])]">
      <xsl:if test="last() = 1">
        <xsl:value-of select="$quote" />
        <xsl:value-of select="text()" />
        <xsl:value-of select="$quote" />
      </xsl:if>
    </xsl:for-each>
    <xsl:value-of select="$delimiter" />


    <xsl:value-of select="$platform" />
    <xsl:value-of select="$delimiter" />

    <!--Journal DOI, Proprietary identifier, Print ISSN, Online ISSN, Articles in Press must be blank in total row-->
    <xsl:value-of select="$delimiter" />
    <xsl:value-of select="$delimiter" />
    <xsl:value-of select="$delimiter" />
    <xsl:value-of select="$delimiter" />
    <xsl:value-of select="$delimiter" />

    <!--Yearly column total-->
    <xsl:for-each select="//ReportData/YearlySummary">
        <xsl:value-of select="Count" />
        <xsl:if test="position() != last()">
          <xsl:value-of select="$delimiter" />
        </xsl:if>
    </xsl:for-each>
    <xsl:text>&#xa;</xsl:text>


    <!-- individula journal info and full text download count -->
    <xsl:for-each select="ReportData/Item">
      <xsl:value-of select="$quote" />
      <xsl:value-of select="Name" />
      <xsl:value-of select="$quote" />
      <xsl:value-of select="$delimiter" />

      <xsl:value-of select="$quote" />
      <xsl:value-of select="Publisher" />
      <xsl:value-of select="$quote" />
      <xsl:value-of select="$delimiter" />

      <xsl:value-of select="$quote" />
      <xsl:value-of select="$platform" />
      <xsl:value-of select="$quote" />
      <xsl:value-of select="$delimiter" />

      <xsl:value-of select="$delimiter" />
      <xsl:value-of select="$delimiter" />

      <xsl:value-of select="$quote" />
      <xsl:value-of select="Print_ISSN" />
      <xsl:value-of select="$quote" />
      <xsl:value-of select="$delimiter" />

      <xsl:value-of select="$quote" />
      <xsl:value-of select="Online_ISSN" />
      <xsl:value-of select="$quote" />
      <xsl:value-of select="$delimiter" />

      <xsl:value-of select="$quote" />
      <xsl:value-of select="ArticlesInPress" />
      <xsl:value-of select="$quote" />
      <xsl:value-of select="$delimiter" />

      <!-- Full Text download for individual journal based on publication year  -->
      <!-- Note : -  it loops over yearlysummary and then tries to match "Publication Year TO" with current node.  
                    Because it is assume that if journal have PubYrTo then it must have PubYearFrom. therefor when journal dont have PubYrTo then it must be YOP Unknown otherwise it is 0.
      -->
      <xsl:variable name="ItemNode" select="." />
      
      <xsl:for-each select="//YearlySummary">
        <xsl:variable name="PubYrFrom" select="PubYrFrom" />
        <xsl:variable name="PubYrTo" select="PubYrTo" />
        <xsl:choose>
          <xsl:when test="$ItemNode/ItemPerformance[PubYrTo = $PubYrTo]">
              <xsl:value-of select="$ItemNode/ItemPerformance[PubYrTo/text() = $PubYrTo]/Count" />
          </xsl:when>
          <xsl:when test="$ItemNode/ItemPerformance[not (PubYrTo) and not ($PubYrTo)]">
            <xsl:value-of select="$ItemNode/ItemPerformance[not (PubYrTo) and not ($PubYrTo)]/Count" />
          </xsl:when>
          <xsl:otherwise>0</xsl:otherwise>
        </xsl:choose>
          <xsl:if test="position() != last()">
            <xsl:value-of select="$delimiter" />
          </xsl:if>
      </xsl:for-each>
      <xsl:text>&#xa;</xsl:text>
    </xsl:for-each>
  </xsl:template>

</xsl:stylesheet>