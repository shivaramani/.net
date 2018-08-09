## ASP.NET
server side technology that helps in creation, deployment and execution of web applications and services
web apps are built using web forms, built in web form controls
makes use of rich set of class libraries, ADO.NET etc., for easier development and execution

## Some of the advantages of ASP.NET
1) separation of code from html
2) support for compiled languages
3) services provided by .net framework
4) graphical development environment
5) state management - sesion and application state management
6) update files while server is running
7) xml based configuration files

## Common files
common file types are ASPX and user controls with ASCX. The code behind ends with .ASPX.CS (for a C# compilation)
global asax contains global logic of the application and resides in teh root directory of the application
web.config - configuration file
Web services ends with .ASMX

## ASP.NET Execution Process (ASP.NET Page Life Cycle)
asp.net page goes through a life cycle . this include initialization, instantiating controls, restoring and maintaining state, running event handler code and rendering.

## Whate are the major built in objects of asp.net
Application ,Request ,Response ,Server ,Session ,Context ,Trace 

## General page life cycle - Page request, Start, Initialization, Load, Postback, Rendering, Unload
Life Cycle events - 

Preinit - raised after start stage before initialization. checks IsPostBack. creates/recreates dynamic controls, master pages/themes etc.,
Init - after the controls are initialized. generally used to read or initialize control properties
InitComplete - at the end of init stage.tracking of viewstate changes are turned on. generally used to make changes to view state that may want to persist after next postback
PreLoad - raised after page load with view. processes the postback data
Load - page objects calls OnLoad and recursively calls the same for each chile control unti; the page and controls are loaded
Control Events - textchanged and other events for specific controls
LoadComplete - 
PreRender - page object is created. al contrls are availale at this stage. page raises prerender for page object and recursively raises for each control
PreRenderComplete - raised after each databound control where databind is set
SaveStateComplete - raised after view state and control state for the page and all controls
Render - NOT an event. but more of a processing stage for Page and each control where markup is sent to the browser
Unload - controls are rendered at this point. no further changes can be made to the response stream


## IIS - Page Request Handling
TODO
reference - 
IIS 6 and below - https://msdn.microsoft.com/en-us/library/ms524901(v=vs.90).aspx
IIS 7 - https://msdn.microsoft.com/en-us/library/bb470252.aspx


## Validations in ASP.NET
Client Side Validation
Server Side Validation
Server side validators - RequiredFieldValidator, CompareValidator, RangeValidator, RegularExpressionValidator, CustomFieldvalidator, ValidationSumary
ex:
<asp:TextBox ID="txtrepass" runat="server" Width="180px" TextMode="Password"></asp:TextBox>   

<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtrepass" 
	ErrorMessage="ReEnter Password" ForeColor="Fuchsia"></asp:RequiredFieldValidator> 
	
<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtpass" ControlToValidate="txtrepass" 
	ErrorMessage="Password must me same" ForeColor="Fuchsia"></asp:CompareValidator> 

	
## Different State management techniques
Client Side - View State, Control State, 
			  Hidden fields (ex: Request.Form["HiddenField"];), 
			  cookies (temporary or persistent cookies), 
				Response.Cookies["username"].value = "shiva";
				Response.Cookies["username"].Expires = DateTime.Now.AddDays(2);
				string user = Request.Cookies["username"].Value;
			  query strings
Server Side - Application State (ex: ) - 
				Application ["MyVariable"] = "Hello";
				stringval = (string) Application["MyVariable"];
    		  Session State
			    Session["MyVariable"]="HELLO";
				String val = (string)Session["MyVariable"];
     		  

## What is a View State
ViewState - method to preserve the value of the page and controls between round trips. turned on by default
features:
	retains value of control after postback
	stores value of pages and control properties defined in the page
	no server resources. can be compressed/encoded etc.,
disadvantages:
	security risk, performance, device limitation (ex: size on mobile devices), scope limited to the same page


## Caching in ASP.NET
Page Caching - ex: <%@ OutputCache Duration = 5 VaryByParam = "*" VaryByCustom = "Browser" %>   or <%@ OutputCache Duration = 5 VaryByParam = "ID" VaryByCustom = "Browser" %>  
Fragment Caching 
Data Caching - Cache["username"] = "shiva";  or 
		Cache.Insert("image file", strName,  new CacheDependency(Sever.MapPath("myimage.img") , DateTime.Now.Addminutes(5), TimeSpan.Zero); 


## Ajax in ASP.NET
Asynchronous JavaScript and XML - Ajax is a combination of client side technologies that provides asynchronous communication between the user interface and the web server so that partial page rendering occurs instead of complete page post back.
common Ajax extensions used are
1) ScriptManager, 2) UpdatePanel, 3) Timer 4) UpdateProgress 5)ScriptManagerProxy 6) Pointer

## What are web services in ASP.NET
web servcices uses xml to exchange information/objects over internet
XML - describes data
SOAP - provies communication between services and applications
WSDL - offers uninform method of describing web services
UDDI - search discovery & web services registry

## What is globalization & localization

Localization - "process of translating resources for a specific culture"
Globalization -  "process of designing applications that can adapt to different cultures

System.Globalization
System.Resources
System.Text

## What is App Domain in ASP.NET
Application Domain (AppDomain) is a Lightweight process which is both a container and boundary.
.NET runtime uses an AppDomain as a container for code and data, just like the operating system uses a process as a container for code and data. 
As the operating system uses a process to isolate misbehaving code, the .NET runtime uses an AppDomain to isolate code inside a secure boundary.

## What is master page in ASP.NET
pages - extensions with .master. acts as a template for other content pages. ContentPlaceHolder provides a place holder for contents inside it to be customizable

## What is tracing in .NET
to see execution path/issues during runtime of the app. by default disabled
can be page level or application level
<%@ Page Trace="true" Language="C#" 
<trace enabled="true"/> - application level trace can be seen at http://localhost/myapp/trace.axd

other attrbutes are enabled, pageoutput, requestlimit, localonly, mostrecent

## What are the Data controls available in asp.net?
controls having datasource property are called data controls
ex: Repeater Control,DataGrid Control,DataList Control,,GridView Control,DetailsView,FormView,DropDownList,ListBox,RadioButtonList,CheckBoxList,BulletList etc.

There are three types of binding: 
Declarative Binding , Static Binding , Programmatically Binding

Data binding uses a special syntax:
<%# %>

## What are the major events in global.aspx?
Application_Init,Application_Disposed,Application_Error,Application_Start,Application_End,Application_BeginReques

## What is the authentication and authorization in ASP.NET
 Authentication means to identify the user
 Authorization means does the user have access to a particular resource
 
 ## Types of authentication
 Windows - local windows users and groups
	 <authentication mode="Windows">  
	   <forms name=" AuthenticationDemo" loginUrl="logon.aspx" protection="All" path="/"timeout="30" />  
	</authentication>  
 Forms - cookie based authentication
	 <authentication mode="Forms">  
	   <forms name=" AuthenticationDemo" loginUrl="logon.aspx" protection="All" path="/"timeout="30" />  
	</authentication> 
 Passport - based on windows passport. token sent after validated from the passport is sent for further redirection/execution
 Anonymous
 
 ## Authorization
	 <authorization>
		<allow roles="mydomain\Administrator"/>
		<deny users="*"/>
	</authorization>

## What are the HTML Server controls in ASP.NET
html controls with "runat=server"	ex: <asp:textbox id = Textbox1 runat ="server" />

## Describe Login Controls in ASP.NET
The Login control uses the Membership service to authenticate the user in your membership system. 
The default Membership service from your configuration file will be used automatically, 
however you can also set the Membership provider that you would like used as a property on the control.
	ex: <asp:Login ID="Login1" runat="server" BackColor="#FFE0C0" BorderColor="Red" ></asp:Login>  

	
## What are repeater control in ASP.NET?
Repeater Control is for displaying a repeated list of items bound to the control.
Repeater Control has the following types of template fields:
Item Template, AlternatingItem Template, Header Template, Footer Template, Separator Template
	
## What are the different types of Session management (modes) in ASP.NET
session management technique stores data on the server. Can be set based on Machine Configuration file or Application Configuration file.

InProc - default session mode. stored in application worker process (aspnet_wp.exe) in the app domain. 
		 memory handled by asp.net worker thread. not suitable for webfarms and webgardens
StateServer - out-proc. maintained by aspnet_sate.exe. session variables are stored in asp.net state service
         ex: <sessionState mode="StateServer" stateConnectionString="tcpip=localhost:42424"> 
SQLServer  - stores in MS sql
         ex: <sessionState mode="SQLServer" sqlConnectionString="Server=mydomain\SQLEXPRESS;Integrated Security=true">
Custom - customizable
         ex: <sessionState mode="Custom" customProvider="mySessionProvider">   
			  <providers>   
				 <add name="mySessionProvider" type="CustomDataType" />   
			  </providers>   
			</sessionState>


Difference between session and caching
session - peruser
caching - common/applicaion level shared by all users

## What is the difference between Server.Transfer and Response.redirect?

Response.Redirect method redirects a request to a new URL and specifies the new URL 
Server.Transfer method for the current request, terminates execution of the current page and starts execution of a new page using the specified URL path of the page

Response.Redirect should be used when:
	we want to redirect the request to some plain HTML pages on our server or to some other web server
	we don't care about causing additional roundtrips to the server on each request
	we do not need to preserve Query String and Form Variables from the original request
	we want our users to be able to see the new redirected URL where he is redirected in his browser (and be able to bookmark it if its necessary)
Server.Transfer should be used when:
	we want to transfer current page request to another .aspx page on the same server 
	we want to preserve server resources and avoid the unnecessary roundtrips to the server
	we want to preserve Query String and Form Variables (optionally)
	we don't need to show the real URL where we redirected the request in the users Web Browser
 
## What is page directives in ASP.NET?

These are page commands used by the compiler when the page is compiled

@Page,@Master,@Control,@Import,@Implements,@Register,@Assembly,@MasterType,@Output Cache,@PreviousPageType,@Reference
ex: <%@Page Language="C#" AutoEventWIreup="false" CodeFile="Default.aspx.cs" Inherits="_Default"%>
ex: <%@Control Language="C#" Explicit="True" CodeFile="WebUserControl.ascx.cs" Inherits="WebUserControl" %>
ex: <%@MasterType VirtualPath="/MasterPage1.master"%>
ex: <%@ OutputCache Duration ="180" VaryByParam="None"%>

## What is HTTP Handler?
Every request into an ASP.NET application is handled by a specialized component known as an HTTP handler.
HTTP handler plays same role what ISAPI extension
ASP.NET default handlers:
	Page Handler (.aspx) - Handles Web pages.
	User Control Handler (.ascx) - Handles Web user control pages.
	Web Service Handler (.asmx) - Handles Web service pages.
	Trace Handler (trace.axd) - Handles trace functionality.
 All HTTP handlers are defined in the <httpHandlers> section of a configuration file which is nested in the <system.web> element.
	<httpHandlers>
		<add verb="*" path="trace.axd" validate="true" type="System.Web.Handlers.TraceHandler"/>
		<add verb="*" path="*.config" validate="true" type="System.Web.HttpForbiddenHandler"/>
		<add verb="*" path="*.cs" validate="true" type="System.Web.HttpForbiddenHandler"/>
		<add verb="*" path="*.aspx" validate="true" type="System.Web.UI.PageHandlerFactory"/>
	</httpHandlers>

## How to write a custom httphandler?
Two type of handler you actually can make
Synchronous handler , which implement IHttpHandler interface
Asynchronous handler, which implement IHttpAsyncHandler. 
			With asynchronous handlers additional requests can be accepted, because the handler creates a new thread 
			to process each request rather than using the worker process
extension - .ashx. ex: can write a generic httphandler.ashx to render an html text
http://localhost/mysite/SampleHandler/htmlgenerator

<httpHandlers>          
	<add verb="*" path="htmlgenerator" type="MyHttpHandler.SampleHandler,MyHttpHandler"/>
</httpHandlers>
			
## What is HTTP module?
Help in processing of page request by handing application events , similar to what global.asax does.
HTTP module plays same role what ISAPI filters does.
A request can pass through many HTTP modules but is being handled by only one HTTP handlers.
ASP.NET uses HTTP modules to enable features like caching, authentication, error pages etc.
<add> and <remove> tags can be used to add and inactive any http module from <httpmodule> section of a configuration file.

<httpModules>
	<add name="OutputCache" type="System.Web.Caching.OutputCacheModule"/>
	<add name="Session" type="System.Web.SessionState.SessionStateModule"/>
	<add name="WindowsAuthentication" type="System.Web.Security.WindowsAuthenticationModule"/>
	<add name="FormsAuthentication" type="System.Web.Security.FormsAuthenticationModule"/>
</httpModules>

HttpHandler vs HttpModule
httphandler - process that runs in response to a http request. ex user requests a file which is processed by a handler on the extension
http process - part of lifecycle of a request. security, statistics, logging, custom header
	
## What is cross-page posting in ASP.NET?
with asp.net 2.0 we can post back to different web form (other than self unlike in asp.net 1.x)


## What is the difference between ASP.NET Web API and WCF?
TODO

What is  PostBack in ASP.NET?
A postback is a request sent from a client to server from the same page user is already working with. 
ASP.NET was introduced with a mechanism to post an HTTP POST request back to the same page. 
It’s basically posting a complete page back to server (i.e. sending all of its data) on the same page. So, the whole page is refreshed.

<input type="hidden" name="__EVENTTARGET" id="__EVENTTARGET" value="" />  
<input type="hidden" name="__EVENTARGUMENT" id="__EVENTARGUMENT" value="" />


## Different types of navigation in ASP.NET
Response.Redirect,Server.Transfer,Server.Exceutem,Cross page posting

## What is the AppSetting section in the Web.Config file
The Web.config file defines the configuration for a web project. Using the AppSetting section, we can define user-defined values. 
 <appSettings>
    <add key="ConnectionString" value="server=xyz;pwd=www;database=testing" />
</appSettings> 

## How do you apply Themes to an entire application?
By specifying the theme in the web.config file.
	<configuration>
	 <system.web>
		<pages theme=Mytheme” />
	 </system.web>
	</configuration>

## What is use of the AutoEventWireup attribute in the Page directive ?
The AutoEventWireUp is a boolean attribute that allows automatic wireup of page events when this attribute is set to true on the page. 
It is set to True by default for a C# web form whereas it is set as False for VB.NET forms. 
	
## What are the components of ADO.NET? 
The components of ADO.Net are Dataset, Data Reader, Data Adaptor, Command, connection

## What is WebParts in ASP.NET?
TODO

## Enterprise Library in ASP.NET?
TODO

## What is event bubbling?
TODO

## What is smart navigation?
TODO

## What is the difference between Response.Write and Response.Output.Write?
TODO

			
## References:
https://www.c-sharpcorner.com/article/introduction-to-Asp-Net/