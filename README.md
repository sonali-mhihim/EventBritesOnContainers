**PROJECT TITLE:**  Catalog  Microservice

**PROJECT DESCRIPTION:**
Catalog microservice is one of the microservices within Eventbrite website that displays all the events  to the users based on type of events and host of events. It also allows users to query events by the catalogHostId and catalogTypeId. This project uses the following patterns and Features:

Domain:
We have created 3 Classes: CatalogEvent, CatalogEventType, CatalogHost which we named as Domain in microservices.

Entity Framework core:
We have installed entity framework core software through nugget package that automates the conversion of  C# classes into tables within the database.

Data:
We have created two special class called Catalog Context and Catalog Seed class.
1 Within Catalog Context class, we have provided instructions to the Entity framework to what tables we have to create and how we have to create.
2 Within Catalog Seed Class, we have written two methods:
  * Update Migration Method  is used to updates the database schema based on the last migration snapshot.
  * Seed method is used to populate our predefined data within the database. It is implemented through program.cs class.
	
Dependency Injection:
1 We have used dependency injection to coupled our application loosely and injected our dependency through constructor.
2 We have injected dependency for our database location in Catalog Context class through constructor by passing a parameter "options".
3 We have also injected dependency for  Catalog context database and Picture URL in Catalog Controller through constructor by passing parameters "context" for catalog Db and "config" for picture URL.

Migration:
We have installed  Add Migration feature through package manager console library  that uses command line tool  to convert C# code into SQL through  C# PowerShell scripting language.

WWWRoot Folder:
We have Created special folder called "wwwroot" to store our events images. Because we don't want our images to be compiled along with our code.

Controllers:
We have created two controllers:
	1. Pic controller to send pics to the client through file.
	2. Within Catalog controller, we have created four APIs:
		a. First one  to send the list of all the events to the clients by page index and page size.
		b. Second one is to  send  the list of events by CatalogType.
		c. Third one is to send the list of events by CatalogHost.
		d. Fourth one is to filter events by CatalogTypeId and CatalogHostId.
		
ViewModels:
We have created a generic class called paginated events view Model that aggregated information from various table and send information to the client as a single information. 

STARTUP:
Within this file we have pulled all the dependency for our microservices.

Appsettings.Json:
This file is used to place  things  that are meant to change in future. It includes configuration string for SQL server, and External base Url for pictures.

**KEY FEATURES:**
	• Users can get event's images by Id.
	
	• Users can query events by page index and page size.
	
	• Users can query events by catalog host.
	
	• Users can query events by catalog type.
	
	• Users can query events by CatalogTypeId.
	
	• Users can query events by CatalogHostId.
	

**SCREENSHOTS:**

![Event pic](https://github.com/sonali-mhihim/EventBritesOnContainers/blob/master/EventCatalogAPI/Docs/Screenshots/Eventpic.png)

![Catalog events Pic](https://github.com/sonali-mhihim/EventBritesOnContainers/blob/master/EventCatalogAPI/Docs/Screenshots/Catalogeventspic.png)


**SUPPORTED PLATFORMS:** IIS Express and Postman

**REQUIREMENTS TO RUN THE DEMO**

•  Visual studio 2019

•  IIS Express

•  Postman
  
**YOUTUBE LINK:**

https://youtu.be/zTovwg-P2Ys


 





