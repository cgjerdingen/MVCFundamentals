# MVCFundamentals
MVCFundamentals

This application is an ASP.NET MVC 5.2 Application, running on .NET 4.5
It's a Code First, Entity Framework 6.0 backed app.
It's UI is a combo of whatever ASP.NET MVC and Visual Studio T4 template HTML spew and some added bootstrap.

Mountain Biking / Hiking / Etc Trails Rating System
It is intended to be a sample site for collecting Trail information and allowing Trails to be rated and reviewed.

It is pretty simple, but hold many of the building blocks and concepts for larger more complex applications.

Endable-Migrations is on for the DB Context RateMyTrails
   * Use Update-Database to create/recreate the database if needed. There is only a little seed data at present.


## Future plans:
While my original intent was to teach my kids coding using this app, so they could see the progression and code along with each commit, I planned on just leaving as is when our time ran out. 

However as I look at other technologies with them, I may return to this project, branch it and use it to explore other technologies to demonstate, enhancement to and existing code base. Two obvious projects would be to completely remove the template generated HTML with better, more standards based, HTML5 coding; and to replace the backend with a webapi service and convert the frontend to angularjs, emberjs, and/or knockoutjs.

## Dependencies
* .NET 4.5.2
* ASP.NET MVC 5.2
* Entity Framework 6.0
* Bootstrap 3.0
* jQuery 1.10.2
* jQuery-UI 1.11.4
* SQL Server (localdb or express or sql server) or some EF 6.0 compatible db
