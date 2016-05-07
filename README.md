#SkeletonMvc
A skeleton project for general MVC projects.

[![Build Status](https://travis-ci.org/McNultyyy/SkeletonMvc.svg?branch=master)](https://travis-ci.org/McNultyyy/SkeletonMvc)
[![Build status](https://ci.appveyor.com/api/projects/status/95cde753hdyvnkvu?svg=true)](https://ci.appveyor.com/project/william/skeletonmvc)

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