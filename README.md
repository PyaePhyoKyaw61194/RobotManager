# RobotManager
## Description
 - inventory system for storing robot info
 - client can add robot name and description(optional)
 - client app is window form app
 - client and server is connected via GRPC
 - can perform CRUD operations on robot data
 
## Technical Stacks
### Server
 - Written with C# GRPC project template
 - Persistance object is injected as InMemoryDatabase
 - No Database service is integrated currently
 - All operations(CRUD) are perfromed in services
 - Having one entity (Robot) and DbSet<Robot>
 
### Test
 - Wriiten in C# Xunit project template
 - Database(DBContext) is mocked by using EntityFrameworkCoreMock package
 - Unit Test Lists
  	- GetAllRobotsTest
	- GetRobotByIdTest
	- GetRobotsWithInvalidId
	- GetRobotsWithBrokenId
	- UpdateRobotTest
	- UpdateRobotWithInvalidIdTestAsync
	- UpdateRobotWithEmptyNameTestAsync
	- UpdateRobotWithDuplicateNameTestAsync
	- DeleteRobotTest
	- DeleteRobotWithInvalidIdTest
	- CreateRobotTest
	- CreateRobotWithEmptyNameTest
	- CreateRobotWithDuplicateNameTest
	
### Client
 - Written in C# window Form template
 - User can perform all CRUD operations related to the server
 - validation are checked and alert will show if error occured
 - user can change connection string to server via connection button
 - gridview will show all robots saved in server
 - You may need to install dotnet 6.0 runtime (https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
 
 

	