# Counter Compliance implementation
This is RMIT Training's Open Source implementation of Counter Compliance server for Release 4.

## Includes
1. Web Service
1. Sushi implementation
1. Support for formats like CSV, TSV and HTML
1. Ability to customise to your choice using XSLT files provided
1. Ability to connect to your live data using your custom SQL Queries or any other data source.

# Getting Started

## Download and Run
1. Download project from github to “C:\Temp\”. If you choose other location then “C:\Temp\” to download and save project then web.config file of **CounterReports** and **SushiService** project must be change accordingly
```xml
<add key="Sushi.CounterXsltFolder" value="C:\Temp\RMIT.Counter\Libraries\Reporting\Reports\Xslt" />
```
1. Open solution in visual studio and compile it.
1. Make sure it compiles without any errors.

## View CSV, TSV and HTML Counter Reports
1. Click and run **CounterReports** web project (Ctrl + F5)
1. Select Report_Format to HTML
1. Select Report_Template to JR1
1. Click **Generate Report**
1. It will display the report as HTML.
    * Please note as this is sample data, we are serving same report data always.
    * User Authentication is authorized if ID is **123ABC** and customer name is **guest**.
    * We encourage you to add your data and authentication logic.
    * Therefore changing date range or username will not produce different report.
1 Change the Report_Format to CSV or TSV and also change the Report_Template to other report type and try to submit the form again and wait until download dialog pops up.
    * You can add additional formats by adding new XSLT files

## Retrieve Sushi reports with sushi client
1. Run **Sushi Service** project (Ctrl + F5)
1. Navigate to http://localhost:54676/SushiService.svc and make sure service is running
1. Now run **Sushi client** (Ctrl + F5). It would open a windows form
1. Click on **invoke service** button and it would display sushi report for JR1
1. Change the report definition name from JR1 to JR5 or MR1 or BR1 or BR2 and invoke service again.
1. Report Response window will display appropriate result.

# Project Structure
## Applications Folder
Applications folder Contains following applications
* **CounterReports** :  Asp.net 4.5 WebApi/MVC web application. It presents counter reports in html, csv and tsv format. 
* **Sushi Client** : Windows Form application that calls **Sushi Service (WCF Service)** and displays counter reports in **sushi xml** format
* **Sushi Service** : it is web applications that host the WCF Service.

## Data folder
* Contains Sample xml data to be used to produce counter reports

## Libraries folder
* **Library** :  class library contains commonly used classes 
* **Reporting** : class library contains implementation for counter reports generation
* **Sushi** : class library that contains Sushi Authentication and Sushi Service partial implementation
* **Sushi Core** : class library that contains Sushi Service complete implementation with WSDL

## Tests folder
We use NUnit for testing framework and NSubstitute for Mocking framework.
* **Unit** : contains testing code for Unit tests to test smallest possible source code
* **Integration** : contains Integration tests to test more than Units

# Add custom authentication and Authorization
**AuthorizationAuthority.cs** class inside the project **Sushi**, under **Libraries** folder is responsible for providing authorization.  Navigate to this class and add Custom Authorization. Currently, its sample data with username: “guest” and Id: “123ABC”.

# Add your Data to produce your Counter reports 
This project uses Sample data from **Data** folder to produce Counter and Sushi reports. However, it can be change by updating **ReportDataBase.cs** class GetDataset() method. **ReportDatabase.cs** class is in **Reporting** class library project under **Libraries** folder. Navigate to the GetDataset() Method and start adding different SQL Query/StoredProcedure for different reports (Jr1,Jr5 etc). SQL Query or StoredProcedure added make sure it return appropriate dataset. Dataset’s data must conform to XML Schema file (.xsd) in **Data** folder.

For e.g. jr1 sql query must return dataset same as JR1.xsd in Data folder.

### Authors and Contributors
Thanks to RMIT Training's contributing developers
* Vijay Shiyani - [@vijayshiyani](https://github.com/vijayshiyani)
* Abi Bellamkonda - [@abibell](https://github.com/abibell)
* Dominic Crowther [@vijayshiyani](https://github.com/vijayshiyani)
* Deepak Vasa - [@vijayshiyani](https://github.com/vijayshiyani)
* Yingli Cao - [@caoglish](https://github.com/caoglish)
* Kirthana Madam Raja [@kirthanaraja](https://github.com/kirthanaraja)
* Debashish Paul - [@shimanbb](https://github.com/shimanbb)
* Anshu Dutta - [@anshudutta](https://github.com/anshudutta)

### Support Contact
For support please contact http://informit.com.au/contact/default.aspx.
