The following files were created to show you the basic operation of Fluent Infrastructure

/Context
	-DbContextLocal.cs
/Controllers
	-ForumController.cs
/Mapper
	-ForumMap.cs
/Models
	-Forum.cs
/Views
	/Forum
		-AddReturn.cshtml
		-New.cshtml
	/Shared
		-Index.cshtml
		
These files can be deleted without prejudice to your system once you have understood how to operate the Fluent Infrastructure

**** If you do not have the Global.asax file in the project root ***

1. Open Solution Explorer.
2. Right-click on the project.
3. Add New Item.
4. VB or C#
5. Web.
6. General.
7. Global Application Class.
8. Add the initialization call in your Global.asax:

protected void Application_Start(object sender, EventArgs e)
{
    AreaRegistration.RegisterAllAreas();
    RouteConfig.RegisterRoutes(RouteTable.Routes);
}

See more in: https://github.com/dn32/Fluent.Infrastructure/wiki