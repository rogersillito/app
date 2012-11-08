#Project Conventions

1. Leverage convention over configuration as much as possible.
  * Have a convention for configuration

##Test Naming Convention

All tests for a component will be under the spec project in a file name [Component]Specs.cs. The file will contain an outer class named [Component]Specs. All tests will be contained as nested classes of the containing class.

##For components that we write, null is not an allowable return value of value returning methods.

##1 Command per unique request
##1 Logical view per view model

##Stub Convention
  * All stubs must live in a stubs namespace under the namespace of where their contract lives.
  * Must be named using the convention Stub[Name].cs
