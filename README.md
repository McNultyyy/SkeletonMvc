#SkeletonMvc
A skeleton project for general MVC projects.

---

###Code First
Currently uses EF codefirst migrations.

###Dependency Injection
Uses Unity for dependency injection, should be relatively easy to change to Ninject, StructureMap etc...

###Model
This is where the DAO entities reside. All entities contain a mapping class.

###Repository
A generic repository for the DAO entities.

###Web
A standard MVC web project.