<?xml version="1.0"?>

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:tbl="tbl:tbl">
  <xsl:output method="html" encoding="utf-8" />

  <!--Keys for Group by Months and publisher-->
  <xsl:key name="periodStartByNameKey" match="//PeriodStart" use="text()" />
  <xsl:key name="publisherKey" match="//Item/Publisher" use="text()" />

  <!--Variable Declaration-->
  <xsl:variable name="months" select="'  JanFebMarAprMayJunJulAugSepOctNovDec'" />
  <xsl:variable name="platform" select="'Informit'" />
  <xsl:variable name="countDistinctPublisher" select="0" />

  <!--table Column Declaration-->
  <tbl:columns>
    <column>Collection</column>
    <column>Content Provider</column>
    <column>Platform</column>
    <column>Reporting Period Total</column>
  </tbl:columns>

  <!-- Start with root node -->
  <xsl:template match="/">
    <html>
      <head>
        <title>Media Report 1 (R4)</title>
        <link rel="stylesheet" href="#infomitreport:root#/content/website.min.css"/>
      </head>
      <body>
        <div class="container-fluid">
          <div class="page-header">
            <h1>Company - Stats</h1>
          </div>

          <div class="panel panel-info">

            <div class="panel-heading">
              <div class="panel-title col-md-3">Multimedia Report 1 (R4)</div>
              <div class="panel-title">Number of Successful Multimedia Full Content Unit Requests by Month and Collection </div>
            </div>

            <div class="panel-body">
              <p class="col-md-3 text-info">Report Name : #infomitreport:report_name#</p>
              <p class="col-md-9 text-info">
                Report Date: <xsl:value-of select="substring-before(/ReportData/Header/CreatedDateTime,'T')" />
              </p>
              <p class="col-md-3 text-info">Description: #informitreport:report_desc#</p>
              <p class="col-md-9 text-info">
                Start Date: <xsl:value-of select="substring-before(/ReportData/Header/StartDate,'T')" />
              </p>
              <p class="col-md-3 text-info">
                Username: <xsl:value-of select="/ReportData/Header/CustomerName" />
              </p>
              <p class="col-md-9 text-info">
                End Date: <xsl:value-of select="substring-before(/ReportData/Header/EndDate,'T')" />
              </p>
              <p class="col-md-3 text-info">
                Date Run: <xsl:value-of select="substring-before(/ReportData/Header/CreatedDateTime,'T')" />
              </p>
            </div>

          </div>

          <div class="panel panel-info table-responsive">
            <table class="table table-striped table-hover">
              <thead>
                <tr>
                  <!-- Main table headers row with computed months -->
                  <xsl:for-each select="document('')/*/tbl:columns/*">
                    <th>
                      <xsl:value-of select="." />
                    </th>

                  </xsl:for-each>

                  <!-- Computed months -->
                  <xsl:for-each select="//ItemPerformanceMonthlySummary">
                    <th>
                      <xsl:value-of select="substring($months, Month * 3, 3)" />-<xsl:value-of select="Year" />
                    </th>
                  </xsl:for-each>
                </tr>
                <tr>
                  <th>
                    <!--Main table total for all journals Row-->
                    <xsl:text>Total for all Collections</xsl:text>
                  </th>

                  <!--Cell B9 contains the name of the publisher/vendor, provided all the journals listed in column A are from
        the same publisher/vendor. If not, this cell is left blank.-->
                  <th>
                    <xsl:for-each select="//Item/Publisher [generate-id() = generate-id(key('publisherKey', text())[1])]">
                      <xsl:if test="last() = 1">
                        <xsl:value-of select="text()" />
                      </xsl:if>
                    </xsl:for-each>
                  </th>
                  <th>
                    <xsl:value-of select="$platform" />
                  </th>

                  <th>
                    <xsl:value-of select="sum(//Multimedia)" />
                  </th>

                  <!--monthly column total-->
                  <xsl:for-each select="//ItemPerformanceMonthlySummary">
                    <th>
                      <xsl:value-of select="Month_Total" />
                    </th>
                  </xsl:for-each>

                </tr>
              </thead>
              <tbody>
                <!-- individula journal info and full text download count -->
                <xsl:for-each select="ReportData/Item">
                  <tr>
                    <td>
                      <xsl:value-of select="Collection" />
                    </td>
                    <td>
                      <xsl:value-of select="Publisher" />
                    </td>
                    <td>
                      <xsl:value-of select="$platform" />
                    </td>
                    <td>
                      <xsl:value-of select="sum(.//Multimedia)" />
                    </td>

                    <xsl:variable name="ItemNode" select="." />

                    <!--fulltext count based on month for individual journal-->
                    <xsl:for-each select="//ItemPerformanceMonthlySummary">
                      <xsl:variable name="Summary" select="." />
                      <td>
                        <xsl:variable name="TotalOfMonth" select="$ItemNode/ItemPerformance[Year=$Summary/Year and Month=$Summary/Month]/Multimedia" />
                        <xsl:if test="$TotalOfMonth !=''">
                          <xsl:value-of select="$TotalOfMonth" />
                        </xsl:if>
                        <xsl:if test="not($TotalOfMonth)">
                          <xsl:text>0</xsl:text>
                        </xsl:if>
                      </td>
                    </xsl:for-each>
                  </tr>
                </xsl:for-each>
              </tbody>
             </table>
          </div>
        </div>
      </body>
    </html>
  </xsl:template>

</xsl:stylesheet>