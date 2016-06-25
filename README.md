#SkeletonMvc :skull:
A skeleton project for general MVC projects.

[Documentation](http://mcnultyyy.github.io/SkeletonMvc "SkeletonMvc Documentation")

[![Build status](https://ci.appveyor.com/api/projects/status/95cde753hdyvnkvu?svg=true)](https://ci.appveyor.com/project/william/skeletonmvc)

---

###DAL (Data Access Layer)
Contains the DAO, entity mappings, repositories, context as well as the database migrations.

###BLL (Business Logic Layer)
Contains the entity services.

###Web (Presentation Layer)
A standard MVC web project.

---

###Dependency Injection
Uses Unity for dependency injection, should be relatively easy to change to Ninject, StructureMap etc...

###Documentation
Contains the SandCastle documentation project.

###Extension
A collection of extension methods used through the application.

---

####QuickStart
```
Enable-Migrations -ContextProjectName DAL
```
