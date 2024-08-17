This is my application using C# to manage tasks
- C# 11
- .NET 7
- Visual Studio 2022
Model-View-ViewModel

Creating a Layered Architecture
Domain
Models representing the data and types used in the domain. Expressed in a similar language
as the business would use.
Infrastructure
Interaction with external systems such as databases, services and the file system.
UI
The definition of the UI and its components. This may be divided into multiple different
projects as well if the UI components are shared among multiple applications.