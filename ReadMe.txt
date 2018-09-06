Wieland Dominik	04.07.2018 V1.0
================================
Erstellung der WebApplication und verbindung mit einer OracleXE Datenbank
Datenbank liefert Cursur damit die WebApplication schnell auf die Datenbank zugreifen kann.
Layout die Alle Seite betreffen gehören in den Views Ordner unter Shared
Einzelne Websiten werden im View Ordner als eigene Ordernen mit eigenen .cshtml

Erstellung der WebApplication mit ASP.Net Core MVC
https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-2.1&tabs=aspnetcore2x

ASP.NET MVC mit Datenbankverbindung aufbauen:
http://www.mukeshkumar.net/articles/aspnetcore/asp-net-core-web-api-with-oracle-database-and-dapper

ConnectionString für das Setup bei Worldline! Einfach Kopieren und Einfügen
string con = "Data Source=(DESCRIPTION =(ADDRESS_LIST =(ADDRESS = (PROTOCOL = TCP)(Host = ECREP.org.oebb.at)(Port = 1521)))(CONNECT_DATA =(SID = ECREP)(SERVER = DEDICATED)));User Id=ws;Password=cisoe2016;";



