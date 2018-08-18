## WebApi
- WebApi is a framework that helps you to build & develop HTTP Services. Using ASP.NET WebApi we can build non SOAP based services like plain XML or JSON outputs. Helps to build RESTful serices on .NET framework.

## Advantages of Using ASP.NET Web API?
- HTTP way using standard HTTP verbs like GET, POST, PUT, DELETE, etc. for all CRUD operations
- Complete support for routing
- Response generated in JSON or XML format using MediaTypeFormatter
- Ability to be hosted in IIS as well as self-host outside of IIS
- Supports Model binding and Validation
- Support for OData
- light weight architecture that can support broad range of clients, browsers & mobile.

## Features
- Routing
- External Authentication
- CORS. ex: "using System.Web.Http.Cors". As part of "Register(HttpConfiguratin config), we can set the following
    config.EnableCors(); & config.EnableCors(new EnableCorsAttribute("*","*","*));    
- WebAPI Odata
- IHttpActionResult

## MVC vs WebAPI

- WebAPI is to generate HTTP services that reach more clients by generating data in raw format. WebApi cannot return view.

- ASP.NET MVC framework is used to develop web applications that generates Views as well as data. ASP.NET MVC facilitates in rendering HTML easy

## WCF vs WebAPI

- WCF is SOAP based and WCF is still a good choice for following scenarios:
    - when to use transport other than HTTP, e.g. TCP, UDP or Named Pipes
    - Message Queuing scenario using MSMQ
    - One-way communication or Duplex communication
   
## Main return types of WebApi

- Void
- HttpResponseMessage - converts message to http response
- IHttpActionResult - internallly ExecutesAsync to create HttpResponseMessage

## Explain WebApi Routing

- In ASP.NET Web API, a controller is a class that handles HTTP requests. The public methods of the controller are called action methods or simply actions. When the Web API framework receives a request, it routes the request to an action.

- Routing has three main phases:
    - Matching the URI to a route template.
    - Selecting a controller.
    - Selecting an action.

- framework uses routing table to decide the actions. ex: /api/contacts or /api/contacts/1

    // ContactsController (Inside Controller folder)
    // can override the action name by using the ActionName attribute.
    public class ContactsController : ApiController
    {
        [HttpGet]
        public Contact contacts(id) {}

        [HttpGet]
        [ActionName("Thumbnail")]
        public HttpResponseMessage GetThumbnailImage(int id);

        [HttpPost]
        [ActionName("Thumbnail")]
        public void AddThumbnailImage(int id);

        // Not an action method. to prevent a method from getting invoked as action
        [NonAction]  
        public string GetPrivateData() { ... }
    }

    // In WebApiConfig.cs (inside App_Start directory)
    routes.MapHttpRoute(
        name: "API Default",
        routeTemplate: "api/{controller}/{id}",
        defaults: new {id = RouteParameter.Optional } // can provide defaults 
    );

    or

    routes.MapHttpRoute(
        name: "API Default",
        routeTemplate: "api/{controller}/{category}/{id}",
        defaults: new { category: "all", id = RouteParameter.Optional } // can provide defaults 
    );
## Route Dictionary

 - framework finds a match for a URI, it creates a dictionary that contains the value for each placeholder. 
 - The keys are the placeholder names, not including the curly braces. The values are taken from the URI path or from the defaults. 
 - The dictionary is stored in the IHttpRouteData object.

    Ex: For the URI path "api/contacts", the route dictionary will contain:

        controller: "contacts"
        category: "all"

    For "api/contacts/work/1", however, the route dictionary will contain:

        controller: "contacts"
        category: "work"
        id: "1"

## Controller (Controller Selection)

- Controller selection is handled by the IHttpControllerSelector.SelectController method.
- This method takes an HttpRequestMessage instance and returns an HttpControllerDescriptor
- DefaultHttpControllerSelector does the default implementation. This looks for route dictionary for the key "Controller"
- IHttpControllerTypeResolver returns all public classes that 
    (a) implement IHttpController
    (b) are not abstract and 
    (c) have a name that ends in "Controller".

  ex: if the route dictionary contains the key-value pair "controller" = "contacts", then the controller type is "ContactsController". If there is no matching type, or multiple matches, the framework returns an error to the client.


## Actions (Action Selection)

- After selecting the controller, the framework selects the action by calling the IHttpActionSelector.SelectAction method
- This method takes an HttpControllerContext and returns an HttpActionDescriptor.
- ApiControllerActionSelector does the default implementation.  To select an action, framework looks for
    - HTTP method of the request
    - "{action}" placeholder in the route template - if present
    - parameters of the action in the controller.

## HTTP Methods

- we can pecify the HTTP method with an attribute: AcceptVerbs, HttpDelete, HttpGet, HttpHead, HttpOptions, HttpPatch, HttpPost, or HttpPut.

- Otherwise, if the name of the controller method starts with "Get", "Post", "Put", "Delete", "Head", "Options", or "Patch", then by convention the action supports that HTTP method.

- If none of the above, the method supports POST.

Ex: ContactsController

    public class ContactsController : ApiController
    {
        public IEnumerable<Contact> GetAll() {}
        public Contact GetById(int id, double version = 1.0) {}
        [HttpGet]
        public void FindContactsByName(string name) {}
        public void Post(Contact value) {}
        public void Put(int id, Contact value) {}
    }

## Exception Filters

- Exception filters gets executed when there are unhandled exceptions
- Exception filters implement IExceptionFilter interface
- can be registered to an action or globally

  ex: to register exception filter from action using the code
    [NotImplExceptionFilter] 
    public TestCustomer GetMyTestCustomer(int custid)
    {
        //code goes here
    
    }

  ex: GlobalConfiguration.Configuration.Filters.Add(new MyContactStore.NotImplExceptionFilterAttribute());


## what is REST and RESTFUL?

- REST represents REpresentational  State Transfer; it is entirely a new aspect of writing a web app.

- RESTFUL: It is term written by applying REST architectural concepts is called RESTful services. It focuses on system resources and how the state of the resource should be transported over HTTP protocol.

## How do you handle errors in WebApis?

- HttpError, Exception Filters, HttpResponseException, and Registering Exception Filters.


## What is DelegatingHandler?

- DelegatingHandler is used in the Web API to represent Message Handlers before routing.

## How do you respond with a custom http response code (ex to return 404 error)

string message = string.Format(“TestContact id = {0} not found”, contactid);
return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);

## How can we make sure that Web API returns JSON data only?

- We can force webapi to return only json in WebApiConfig.cs 
    Config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));



## New Features comes with ASP.NET Web API 2.0?

The latest features of ASP.NET Web API framework v2.0 are as follows:

- Attribute Routing
- Cross-Origin Resource Sharing
- External Authentication
- Open Web Interface NET
- HttpActionResult
- Web API OData














## Other points about WebApi
- Introduced as part of .NET 4.0 and above.
- WebApi supports HTTP protocol.
- uses JSON.NET for JSON serialization.
- 500 - Internal Server error code.
- Disadvantage/limitation - cannot return "Other retun types" ex: 404 error directly
- Http Verbs or Attribute programming plays an important role. It is easy to restrict access to an ASP.NET Web API method to be called using a particular HTTP method.
- NOTE "ApiController" from "System.Http.Web" in case of .NET 4.x version
       "Controller" from "System.Http.Mvc" in case of .NET Core. This is the common namespace for Web app, MVC and WebApi in .NET Core



## References

https://www.asp.net/web-api


