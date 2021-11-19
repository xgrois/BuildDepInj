# BuildDepInj
Learn Dependency Injection by Coding It. Only Singleton and Transient.
Even though this learning project follows Nick Chapsas teaching, coding it along him helps me understand the "magic" behind DI in tipical applications such as WebAPI in ASP.NET,
where the "old" startup.cs file (no longer in .NET 6 template) makes use of it intensively, e.g.:

```
services.AddSingleton<IService, ServiceX>();
```
or
```
services.AddTransient<IService, ServiceX>();
```

It also helps to improving your understanding of Reflection, Generics, Type, typeof and Activator techniques/tools. 
