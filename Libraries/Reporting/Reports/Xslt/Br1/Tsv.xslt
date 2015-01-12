<?xml version="1.0"?>

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:csv="csv:csv">
  <xsl:output method="text" encoding="utf-8" />

  <!--Keys for Group by Months and publisher-->
  <xsl:key name="periodStartByNameKey" match="//PeriodStart" use="text()" />
  <xsl:key name="publisherKey" match="//Item/Publisher" use="text()" />

  <!--Variable Declaration-->
  <xsl:variable name="months" select="'  JanFebMarAprMayJunJulAugSepOctNovDec'" />
  <xsl:strip-space elements="*" />
  <xsl:variable name="delimiter" select="'&#009;'" />
  <xsl:variable name="platform" select="'Informit'" />
  <xsl:variable name="quote" select="'&quot;'" />
  <xsl:variable name="countDistinctPublisher" select="0" />

  <!--CSV,TSV Column Declaration-->
  <csv:columns>
    <column></column>
    <column>Publisher</column>
    <column>Platform</column>
    <column>Book DOI</column>
    <column>Property Identifier</column>
    <column>ISBN</column>
    <column>ISSN</column>
    <column>Reporting Period Total</column>
  </csv:columns>

  <!-- Start with root node -->
  <xsl:template match="/">

    <!-- Output the header information -->
    <xsl:text>Book Report 1 (R4)</xsl:text>
    <xsl:value-of select="$delimiter" />
    <xsl:text>Number of Successful Title Requests by Month and Title</xsl:text>
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

    <!-- Computed months -->
    <xsl:for-each select="//ItemPerformanceMonthlySummary">
      <xsl:value-of select="$quote" />
      <xsl:value-of select="substring($months, Month * 3, 3)" />-<xsl:value-of select="Year" />
        <xsl:value-of select="$quote" />
      <xsl:if test="position() != last()">
        <xsl:value-of select="$delimiter" />
      </xsl:if>
    </xsl:for-each>
    <xsl:text>&#xa;</xsl:text>

    <!--Main table total for all journals Row-->
    <xsl:text>Total for all titles</xsl:text>
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

    <!--Book DOI, Properietary identifier, isbn,issn must be blank in total row-->
    <xsl:value-of select="$delimiter" />
    <xsl:value-of select="$delimiter" />
    <xsl:value-of select="$delimiter" />
    <xsl:value-of select="$delimiter" />


    <xsl:value-of select="sum(//ft_total)" />
    <xsl:value-of select="$delimiter" />
    
    <!--monthly column total-->
    <xsl:for-each select="//ItemPerformanceMonthlySummary">
      <xsl:value-of select="Month_Total" />
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
      <xsl:value-of select="ISBN" />
      <xsl:value-of select="$quote" />
      <xsl:value-of select="$delimiter" />

      <xsl:value-of select="$quote" />
      <xsl:value-of select="ISSN" />
      <xsl:value-of select="$quote" />
      <xsl:value-of select="$delimiter" />

      <xsl:value-of select="sum(.//ft_total)" />
      <xsl:value-of select="$delimiter" />


      <!--fulltext count based on month for individual journal-->
      <xsl:variable name="ItemNode" select="." />

      <xsl:for-each select="//ItemPerformanceMonthlySummary">
        <xsl:variable name="Summary" select="." />
          <xsl:variable name="TotalOfMonth" select="$ItemNode/ItemPerformance[Year=$Summary/Year and Month=$Summary/Month]/ft_total" />
        <xsl:if test="$TotalOfMonth !=''">
          <xsl:value-of select="$TotalOfMonth" />
        </xsl:if>
        <xsl:if test="not($TotalOfMonth)">
          <xsl:text>0</xsl:text>
        </xsl:if>
        <xsl:if test="position() != last()">
          <xsl:value-of select="$delimiter" />
        </xsl:if>
      </xsl:for-each>
      <xsl:text>&#xa;</xsl:text>
    </xsl:for-each>
  </xsl:template>

</xsl:stylesheet>