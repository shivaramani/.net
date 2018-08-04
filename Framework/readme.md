Concepts
.NET Framework, CLR, CTS, CLS
Managed Code, MSIL, JIT, PE, App Domain
Assembly, Strong Name, GAC, Garbage collector
Ildasm, ResGen

.NET Framework
.net framework is a framework developed by microsoft to develop applications, install and run the application. These are set of technologies that form an integral part of .net platform that provide user experiences, seamless and secure communication and ability to model a range of business processes.

.net framework has two main components CLR (common language runtime) & .NET framework class library (collection of reusable classes and exposes features of runtime)

What is CLR?
The .NET Framework provides a runtime environment called the Common Language Runtime or CLR. The CLR can be compared to the Java Virtual Machine or JVM in Java. CLR handles the execution of code and provides useful services for the implementation of the program. In addition to executing code, CLR provides services such as memory management, thread management, security management, code verification, compilation, and other system services. It enforces rules that in turn provide a robust and secure execution environment for .NET applications.


What is CTS?
Common Type System (CTS) describes the datatypes that can be used by managed code. CTS defines how these types are declared, used and managed in the runtime. It facilitates cross-language integration, type safety, and high performance code execution. The rules defined in CTS can be used to define your own classes and values.


What is CLS?
Common Language Specification (CLS) defines the rules and standards to which languages must adhere to in order to be compatible with other .NET languages. This enables C# developers to inherit from classes defined in VB.NET or other .NET compatible languages.


What is managed code?
The .NET Framework provides a run-time environment called the Common Language Runtime, which manages the execution of code and provides services that make the development process easier. Compilers and tools expose the runtime's functionality and enable you to write code that benefits from this managed execution environment. The code that runs within the common language runtime is called managed code.


What is MSIL?
When the code is compiled, the compiler translates your code into Microsoft intermediate language (MSIL). The common language runtime includes a JIT compiler for converting this MSIL then to native code.
MSIL contains metadata that is the key to cross language interoperability. Since this metadata is standardized across all .NET languages, a program written in one language can understand the metadata and execute code, written in a different language. MSIL includes instructions for loading, storing, initializing, and calling methods on objects, as well as instructions for arithmetic and logical operations, control flow, direct memory access, exception handling, and other operations.


What is JIT?
JIT is a compiler that converts MSIL to native code. The native code consists of hardware specific instructions that can be executed by the CPU.
Rather than converting the entire MSIL (in a portable executable[PE]file) to native code, the JIT converts the MSIL as it is needed during execution. This converted native code is stored so that it is accessible for subsequent calls.


What is portable executable (PE)?
PE is the file format defining the structure that all executable files (EXE) and Dynamic Link Libraries (DLL) must use to allow them to be loaded and executed by Windows. PE is derived from the Microsoft Common Object File Format (COFF). The EXE and DLL files created using the .NET Framework obey the PE/COFF formats and also add additional header and data sections to the files that are only used by the CLR.


What is an application domain?
Application domain is the boundary within which an application runs. A process can contain multiple application domains. Application domains provide an isolated environment to applications that is similar to the isolation provided by processes. An application running inside one application domain cannot directly access the code running inside another application domain. To access the code running in another application domain, an application needs to use a proxy.


How does an AppDomain get created? 
AppDomains are usually created by hosts. Examples of hosts are the Windows Shell, ASP.NET and IE. When you run a .NET application from the command-line, the host is the Shell. The Shell creates a new AppDomain for every application. AppDomains can also be explicitly created by .NET applications.


What is an assembly?
An assembly is a collection of one or more .exe or dll’s. An assembly is the fundamental unit for application development and deployment in the .NET Framework. An assembly contains a collection of types and resources that are built to work together and form a logical unit of functionality. An assembly provides the CLR with the information it needs to be aware of type implementations.


What are the contents of assembly?
A static assembly can consist of four elements:
·         Assembly manifest - Contains the assembly metadata. An assembly manifest contains the information about the identity and version of the assembly. It also contains the information required to resolve references to types and resources.
·         Type metadata - Binary information that describes a program.
·         Microsoft intermediate language (MSIL) code.
·         A set of resources.


What are the different types of assembly?
Assemblies can also be private or shared. A private assembly is installed in the installation directory of an application and is accessible to that application only. On the other hand, a shared assembly is shared by multiple applications. A shared assembly has a strong name and is installed in the GAC.
We also have satellite assemblies that are often used to deploy language-specific resources for an application.


What is a dynamic assembly?
A dynamic assembly is created dynamically at run time when an application requires the types within these assemblies.


What is a strong name?
You need to assign a strong name to an assembly to place it in the GAC and make it globally accessible. A strong name consists of a name that consists of an assembly's identity (text name, version number, and culture information), a public key and a digital signature generated over the assembly.  The .NET Framework provides a tool called the Strong Name Tool (Sn.exe), which allows verification and key pair and signature generation.


What is GAC? What are the steps to create an assembly and add it to the GAC?
The global assembly cache (GAC) is a machine-wide code cache that stores assemblies specifically designated to be shared by several applications on the computer. You should share assemblies by installing them into the global assembly cache only when you need to.
Steps
- Create a strong name using sn.exe tool eg: sn -k mykey.snk
- in AssemblyInfo.cs, add the strong name eg: [assembly: AssemblyKeyFile("mykey.snk")]
- recompile project, and then install it to GAC in two ways :
·         drag & drop it to assembly folder (C:\WINDOWS\assembly OR C:\WINNT\assembly) (shfusion.dll tool)
·         gacutil -i abc.dll


What is the caspol.exe tool used for?
The caspol tool grants and modifies permissions to code groups at the user policy, machine policy, and enterprise policy levels.


What is a garbage collector?
A garbage collector performs periodic checks on the managed heap to identify objects that are no longer required by the program and removes them from memory.
What are generations and how are they used by the garbage collector?
Generations are the division of objects on the managed heap used by the garbage collector. This mechanism allows the garbage collector to perform highly optimized garbage collection. The unreachable objects are placed in generation 0, the reachable objects are placed in generation 1, and the objects that survive the collection process are promoted to higher generations.


What is Ilasm.exe used for?
Ilasm.exe is a tool that generates PE files from MSIL code. You can run the resulting executable to determine whether the MSIL code performs as expected.


What is the ResGen.exe tool used for?
ResGen.exe is a tool that is used to convert resource files in the form of .txt or .resx files to common language runtime binary .resources files that can be compiled into satellite assemblies.



references 
- http://www.dotnetcurry.com/ShowArticle.aspx?ID=64
- https://www.c-sharpcorner.com/UploadFile/8ef97c/interview-question-on-net-framework-or-clr/

