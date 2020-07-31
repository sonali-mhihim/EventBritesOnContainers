**PROJECT TITLE:** MVC Client for Eventbrite and Token Service

**PROJECT DESCRIPTION** 

**Build MVC client for Eventbrite.** User-interface (view) was added to complete the design pattern with data (model) and application logic (controllers) developed on the previous 
assignment. Views included show events (image, date, time and place) and pagination. Controllers included on MVC client are Account Controller, Catalog Controller and 
Home Controller. 

**TokenService Microservice.** In this phase, we included authentication service as a security token service using Token Service Microservice and Redis cache. A database is 
created to storage user names and passwords and we seed it with the user me@myemail.com.

**Integrate with the client.**  UI allows the user see all the events on database and filter by Host and type of event as well as pagination. It is possible login as the use 
me@myemail.com and create new users.

As previous phase, images as logo of project and images for banner are stored on wwwroot folder on Mvc. For authentication we add account controller, home Controller and manage 
controller as well as new model to manage errors on UI (ErrorViewModel).

Docker-compose file includes new container to run Token Service and we are using the same sqlserver container as CatalogEvent for demonstration purposes although it's possible 
create a different one.

**KEY FEATURES:**
*	UI allows users to see all events and filter by host or/and type of event.
*	Users can authenticate using login.
*	Users can create new accounts to login.

**SCREENSHOTS:**

 ![Event main](https://github.com/sonali-mhihim/EventBritesOnContainers/blob/master/EventCatalogAPI/Docs/Screenshots/asg3b-1.png)
 ![Event filter](https://github.com/sonali-mhihim/EventBritesOnContainers/blob/master/EventCatalogAPI/Docs/Screenshots/asg3b-2.gif)
 ![Event login](https://github.com/sonali-mhihim/EventBritesOnContainers/blob/master/EventCatalogAPI/Docs/Screenshots/asg3b-3.gif)


**REQUIREMENTS TO RUN THE DEMO**
*	Visual studio 2019
*	Docker 
*	Postman

**YOUTUBE LINK:**
https://youtu.be/s4yVa9cmVDQ
