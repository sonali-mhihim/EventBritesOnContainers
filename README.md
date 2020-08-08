**PROJECT TITLE:** MVC Client for Eventbrite, including Token Service, Cart Service and Order Service

**PROJECT DESCRIPTION** 

**Build MVC client for Eventbrite.** User-interface (view) was added to complete the design pattern with data (model) and application logic (controllers) developed on the previous 
assignment. Views included show events (image, date, time and place) and pagination. Controllers included on MVC client are Account Controller, Catalog Controller and 
Home Controller. 

**TokenService Microservice.** In this phase, we included authentication service as a security token service using Token Service Microservice and Redis cache. A database is 
created to storage user names and passwords and we seed it with the user me@myemail.com.

**CartApi Microservice.** The basket service allows the user to add items to cart after logging in, via the TokenService. The basket service caches the items that the user added previously, and saves it under the BuyerId. The CartApi contains the CartItem information, such as Id, ProductId, ProductName, UnitPrice, OldUnitPrice, Quantities, Picture. These CartItems are then listed in the cart and the total sum of the cart is displayed at the bottom.

**OrderApi Microservice.** The order service, so that the user can purchase the list of items in cart. The OrderService is integrated with the TokenService, which authenticates the user and authorizes the OrderService to store the user’s information such as, Name, OrderDate, BuyerId, OrderStatus, Address, Payment, OrderTotal, and list of OrderItems.

We implemented the Stripe program to process the credit card transaction and integrated the RabbitMQ to queue up the order messages to be processed.

**Integrate with the client.**  UI allows the user see all the events on database and filter by Host and type of event as well as pagination. It is possible login as the use 
me@myemail.com and create new users.

As previous phase, images as logo of project and images for banner are stored on wwwroot folder on Mvc. For authentication we add account controller, home Controller and manage 
controller as well as new model to manage errors on UI (ErrorViewModel).

Docker-compose file includes new containers to run Token Service, Cart Service and Orden Service. We are using the same sqlserver container as CatalogEvent for demonstration purposes although it's possible create a different one for each service. To process a card transaction we integrated Stripe so it is possible use real information in a furure. 

**KEY FEATURES:**
*	UI allows users to see all events and filter by host or/and type of event.
*	Users can authenticate using login.
*	Users can create new accounts to login.
* Users can create orders with all events linked to their accounts (Token service)
* Order information is storage in a Database. 
* Stripe (Stripe.com) is integrated to process credit card transaction on the checkout of an order.
* RabbitMQ is integrated to queue up the rder messages to be processed.

**SCREENSHOTS:**

 ![Event main](https://github.com/sonali-mhihim/EventBritesOnContainers/blob/master/EventCatalogAPI/Docs/Screenshots/asg3b-1.png)
 ![Event main](https://github.com/sonali-mhihim/EventBritesOnContainers/blob/master/EventCatalogAPI/Docs/Screenshots/cart.png)
 ![Event filter](https://github.com/sonali-mhihim/EventBritesOnContainers/blob/master/EventCatalogAPI/Docs/Screenshots/order1.png)
 ![Event login](https://github.com/sonali-mhihim/EventBritesOnContainers/blob/master/EventCatalogAPI/Docs/Screenshots/order2.png)
 ![Event filter](https://github.com/sonali-mhihim/EventBritesOnContainers/blob/master/EventCatalogAPI/Docs/Screenshots/order3.png)
 ![Event filter](https://github.com/sonali-mhihim/EventBritesOnContainers/blob/master/EventCatalogAPI/Docs/Screenshots/asg3b-2.gif)
 ![Event login](https://github.com/sonali-mhihim/EventBritesOnContainers/blob/master/EventCatalogAPI/Docs/Screenshots/asg3b-3.gif)

**REQUIREMENTS TO RUN THE DEMO**
*	Visual studio 2019
*	Docker 

**YOUTUBE LINK:**
https://www.youtube.com/watch?v=WduQyGoLMtY
