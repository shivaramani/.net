## "Windows Communication Foundation - WCF" 
Windows Communication foundation is a framework for building service oriented applications.

## WCF
Using WCF we can send async messages from one service endpoint to another. It can be hosted by IIS or by a service in an application.

general use cases
- service to process business transactions
- a chat service to communicate data in real time
- a dashboard that polls one or more services for data
- exposing a workflow as a service
- messages that needs to be sent a single character or word sent as XML or complex stream of binary data.

## Features of WCF

- Service Orientation - SOA (to send and receive data), loosely coupled relationship so that any client on any platform can connect to any service as long as the contracts are met.

- Interoperability  - apps built on same or different platforms can communicate with each other.

- Multi message patterns - one-way messaging, duplex exchange pattern (two endpoints estabilish connection and send back and forth)

- Service Metadata - using industry standards like WSDL, XML schema, WS policy.

- Data Contracts - handling through classes that represent a data entity with properties. This helps to generate metadata automatically for the clients to comply with data types


- Security - messages are encrypted. security can be implemented using SSL or WS-Secureconversation etc.,

 - Multiple Transports and Encodings - common  is SOAP using HTTP. Others include TCP, named pipes, MSMQ. Binary data can be sent using MTOM standard

- Reliable and Queued Messages - using WS-Reliable messaging and using MSMQ.

- Durable Messages - messge never gets lot. ex: durable message pattern always gets saved to DB

- Transactions - like WS-AT protocol(WS-AtomicTransaction)

- AJAX and REST support

- Extensibility


## Explain the WCF architecture


 - Contracts - data, message, service, Policy & Binding
  
    [ServiceContract]   
    public interface IService  
    {   
        [OperationContract]   
         [FaultContract(typeof(SampleFaultException))]
    DataSet GetDetails(int Employee_ID);  
    } 

    [DataContract]   
    public class Employee   
    {   
    [DataMember]   
    public int emp_id;  
    [DataMember]   
    public int emp_name;   
    } 

 - Service Runtime - Behaviors and Runtime
   - Behavior - Throttling, Error, Metadata, Instance, Message, Transaction, Dispatch, Concurrency
   - Filtering - Parameter


 - Messaging -
    Channels - Http/TCP/MSMQ/NamedPiped Channels, WS Security, WSReliable channels.
    Encoders - Binary/MTOM/text/XML
            
- Activation and Hosting - Windows activation service, EXE, windows service or COM+

## what is an endpoint
All the communication with a wcf service occurs through the endpoints of a service. Endpoints provide the configuration required for the communication and create the complete WCF service application.

Each endpoint consists of four properties:

An address that indicates where the endpoint can be found.
A binding that specifies how a client can communicate with the endpoint.
A contract that identifies the operations available.

ex:
<endpoint address="http://localhost:3901/Service1.svc" 
           binding="basicHttpBinding"  
          contract="ServiceReference.IService1" bindingConfiguration="BasicHttpBinding_IService1"   
              name="BasicHttpBinding_IService1" />  

## Explain the ABCs of endpoints

- Address - Where - Transport] ://[Domain Name]:[Port]//[Service Name]

- Binding - How - BasicHttpBinding, NetMsmqBinding, NetTcpBinding, NetPeerTcpBinding, WSHttpBinding, WSDualHttpBinding, NetNamedPipeBinding

- Contract - What


## Advantages of WCF

- Service oriented
- Location, languagem platform independent
- supports multiple operation, can maintain state, controls concurrency, can be hosted in iis, self hosting, windows services etc.,
- can be configured to work independently of SOAP and use RSS instead.

## Difference between WCF and Web services

web services vs wcf
- hosted in iis. wcf across iis, was, self hosting
- [WebService] attribute. [ServiceContract] attribbute
- [WebMethod] attribute. [OperationContract] attribute to the client
- one way response. wcf offers oneway, request/response, duplex
- System.XMl.serialization in ws. System.Runtime.Serialization for wcf
- http,tcp,custom in wf. http,tcp, named pipes, msmq, p2p, custom in wcf
- protocol - security in ws. security, reliable messaging, transactios in wcf

## Service Contract
- interface of the WCF service. defines operations of the service along with message data tyes, location, protocols etc.,

ex:
    [ServiceContract(Name="MyService", Namespace="http://tempuri.org")]  
    public interface IMyService  
    {  
    [OperationContract]  
    int AddNum(string numdesc, string assignedTo);  
    }

## Operation Contract 
- defines the method exposed to the client to exchange the information between the client and the server

public interface IService
{  
    [OperationContract]  
    string GetData(int value);  
} 

## Message Contract
- controls the structure of a message body and serialization process.

[MessageContract]  
public class AutherRequest  
{  
   [MessageHeader]  
   public string AutherId;  
} 

## Fault Contract 
- provides documented view for error accorded in the service to client. This help as to easy identity the what error has occurred, and where. 

## What is Binding in WCF. Types of binding

- Binding describes how client will communictate

Characteristics 
 - Transport - Http, TCP, MSMQ, Named pipes
 - Encoding (optional) - text, binary, message transmission optimization mechanism (MTOM)
 - Protocol (optional) - defines security , transaction, reliable messaging capability etc.,


## Binding	& their description

- BasicHttpBinding -	Basic Web service communication. No security by default.
 - WSHttpBinding - Web services with WS-* support. Supports transactions.
- WSDualHttpBinding -	Web services with duplex contract and transaction support.
- WSFederationHttpBinding - Web services with federated security. Supports transactions.
- MsmqIntegrationBinding - Communication directly with MSMQ applications. Supports transactions.
- NetMsmqBinding -Communication between WCF applications by using queuing. Supports transactions.
- NetNamedPipeBinding - Communication between WCF applications on same computer. Supports duplex contracts and transactions
- NetPeerTcpBinding -Communication between computers across peer-to-peer services. Supports duplex contracts
- NetTcpBinding -Communication between WCF applications across computers. Supports duplex contracts and transactions

## Explain transactions in WCF
Transaction is a logical unit of work consisting of multiple activities 

Types - Atomic and Long Running

## What is one way operation?
- an operation which has no return value. fire and forget

ex:

[ServiceContract(Namespace = "http://codeandtech.com")]  
public interface IOneWayCalculator  
{  
    [OperationContract(IsOneWay = true)]  
    void SubmitAdd(double n1, double n2);  
    
}  

## Detail DataContractSerializer

When WCF transmits a message it takes a logical message object and encodes it into bytes. This gets transformed back into corresponding .net object when read. This process is called serialization.

types of serializers
- XMLSerializer - System.Xml.Serialization. Used by ASMX
- NetDataContractSerializer - implements IFormatter. analogous to .Net remoting formatters.
- DataContractSerializer - default serializer in WCF

## What is transaction propagation

- ability to propagate transaction across the boundaries of a single service.

following bindings support it - wsHttpBinding, netTcpBinding, netNamedPipeBinding, wsDualHttpBinding, wsFederationHttpBinding

ex:
<bindings>  
    <wsHttpBinding>  
        <binding name="binding1" transactionFlow="true" />   
    </wsHttpBinding>  
</bindings>  

## What is WCF Throttling

- limiting # of instances or sessions

- maxConcurrentCalls - default 16 (for wcf4 - 16 * processor count)
- maxConcurrentInstances - default - Int32.Maxvalue
- maxConcurrentSessions - default 10

## what is WCF Concurrency

- executing computations simultaneously

- single - one thread at any point
- multiple
- Reentrant - like single. one after another

// [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single]   
[ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple]   
Public class MyService : IMyService  
{  
}  


## What is REST & how to create?

- Representation State Transfer. exchanging data over a distributed environent

JSON - javascript object notation - GET, PUT, POST, DELETE

## What is Exception Handling and different ways?

- several options to handle exceptions

- Using FaultException - best option
- return UnknownExceptionAsFaults - Debugging mode
- using IErrorHandler - when cannot be handled by fault

ex: 

try{
    // code breaks with ApplicationException
}
catch(ApplicationException ex){
    throw new FaultException<ApplicationException>(
        ex, new FaultReason(ex.Message),
        new FaultCode("Sender));
    )
}

<behaviors>  
   <behavior name="MyServiceBehavior"  
       returnUnknownExceptionsAsFaults="True">  
   </behavior>  
</behaviors>  

public interface IErrorHandler  
{  
    bool HandleError(Exception error, MessageFault fault);  
    void ProvideFault(Exception error, ref MessageFault fault, ref string faultAction);  
}   

## What is Tracking in WCF?

- System.Diagnostic
- Important classes are Trace, TraceSource, TraceListener

4 steps in WCF Tracing

- Emitting Trace information from service
- setting the trace level
- configuring the listener
- enabling message logging

## What is Instance Context Mode in WCF

- deifines how long a service instance remains on the server.

- PerCall
- PerSesssion
- Singleton

ex:

// [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerCall)] 
[ServiceBehavior(InstanceContextMode=InstanceContextMode.PerSession)] 
classMyService:IMyContract  
{

}


## Describe security implementation in WCF

- wcf supports different protocols like http,tcp, msmq etc.
- following securities are provided
    - Message Security - usnig WS-Security. message is encrypted using certificate
    - Transport Security - protocol implemented security. has limited security support and bound to protocol security limitations
    - TransportWithMessageCredential - combination of both message and transport


## Streaming in WCF

- In general wcf message gets delivered as a whole on the receiving end. Receiver end is unresponsive while the message is being buffered which ideal for smaller size

- streaming addressess the above issue
- TCP/IPC and HTTP bindings support streaming
- by default disabled

ex:
<bindings>  
        <basicHttpBinding>  
            <binding name="StreamedHttp" transferMode="Streamed" /> </basicHttpBinding>  
    </bindings> 




## What is Method overloading in WCF?

- Method Overloading is a feature that allows creation of multiple methods with the same name but each method should differ from another in the context of input and output of the function. No two methods must have the same type parameters. Either they must differ in the number of parameters or in the type of the parameters.


[ServiceContract]
public interface IHelloWorld
{
    [OperationContract(Name = "ShowIntData")]
    string ShowData(int value);

    [OperationContract(Name = "ShowStringData")]
    string ShowData(string value); 
}

## What is Duplex in WCF? Explain also Message Exchange Pattern?

- Duplex is a Two-Way Communication Process. In which, a consumer send a message to the service and the service sends a notification that the request processing has been done. 

ex:
[ServiceContract(CallbackContract = typeof (DuplexServiceCallback))]  
public interface IMyService  
{  
    [OperationContract(IsOneWay = true)] //one-way message   
    void AddName(string name);  
    [OperationContract] //request-response message   
    string GetName(string name);  
}

- Message Exchange Patterns in WCF:

- The Message Exchange Pattern (MEP) provides a way of communication between client and server. 

 three types of Message Exchange Pattern:
    - Request-Response
    - One-Way
    - Duplex

## What is Proxy and how to generate for WCF services?

- Proxy is a CLR class that exposes a single CLR interface representing the service contract.

- generate using visual studio. righ click referencing and add service reference

- using "SvcUtile.exe http://localhost/myproxy/mysvc.svc /out:proxy.cs"





## References
 - https://docs.microsoft.com/en-us/dotnet/framework/wcf/whats-wcf

 - https://www.c-sharpcorner.com/UploadFile/8ef97c/wcf-interview-questions-and-answers/