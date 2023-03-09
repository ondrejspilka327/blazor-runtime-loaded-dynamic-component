# blazor-runtime-loaded-dynamic-component
Demo of pluggable (truly runtime loaded) Blazor dynamic component.

# Motivation
I am somehow fascinated when I experience well built plugin architecture software in real life.

On the other hand, it is nothing unusual nowadays, examples are ranging from IDEs and editors (VSCode is the shining example),
thorugh o(O)ffice suites, CRMs, ERPs, SCADA systems, up to BI tools like PowerBI, and you would find hundreds of others.

And frankly I was always admiring architects and developers who were able to not only implement such a systems, but also to keep safety and quality in place for many years.
Plugin architectures are no exception to any technology, however with .NET it was always a bit of struggle especially on web side of things.
I believe it is because of fact that most .NET web technologies up to date were not coherent in terms on backed and frontend code.
The closest to ideal is React/Angular frontend + .NET backend, but it still has some drawbacks.

First of all, even if using TypeScript with React,
generally it generates package which is loosely coupled with its backend counterpart. Not talking about NPM package hell, which we all have experienced for sure.
Non coherent packaging can be sorted out using other packaging techniques or completely omitting backend part.
Which is definitely valid strategy, even though I'm not fan of serverless web apps.

Above summary is to some extent opiniated judgement, hope you can agree achieving robust plugin architecture with .NET for web apps is not that easy.

This has changed quite recently. Article https://learn.microsoft.com/en-us/aspnet/core/blazor/components/dynamiccomponent?view=aspnetcore-7.0 
is dated to Jan 2023. It describes programmatic way how to embed Blazor components dynamically. Definitely great feature.
All you need is to specify type of component as a parameter of <DynamicComponent> component and optionally dynamic component parameters.

This feature is cool, but itself it doesn't allow one to build truly open plugin architecture, since types has to be resolvable during compile time.
Safe, but less flexible.

But you never know, it is sometimes worth of try undocummented things. Loading control/component dynamically with Blazor I tried some 2 years ago with no luck.
So I tried again, being stubborn like an old dog.
Simple thing it is to load type in runtime from assembly file using mighty reflection.

And it had worked from the very first moment!
Clearly, I was missing that <DynamicComponent> enabler.
Was I surprised? Honestly, not too much, after first five seconds of excitement I told to myself "well, it is logical it works".
My compliments folks.

Conclusion? Blazor server app and Blazor class libraries are allowing to build comprehensive and consistent plugin architecture software.
Moreover, they add few nice benefits:
- modern type-safe, compiled fast language of choice, mine is C# 7, .NET Core
- coherent packaged DLLs containing UI as well as backend, simple packaging
- easy to implement type safety mechanisms like interface defined components
- easy to implement security mechanisms like signing etc.
- super simple debugging
- easily extensible by unified logging, exception handling etc...
- cool profiling options

So I prepared very simple demo for curious readers.


# What's inside
- DynamicComponentDemo - Blazor server app demonstrating runtime injected dynamic component 
- DynamicComponent - component to be loaded from assembly on disk and embedded using <DynamicComponent> Blazor 

# Requirements

- .NET 7
- VS2022

# Building

Open solution in VS2022 and build.

# Use cases

## Prove it doesn't work if assembly is not in target folder

To prove the app doesn't work if dynamic component assembly is not present in target folder, just press F5 or run main app DynamicComponentDemo.
First exception caused by missing file is swallawed, so the app will fail when trying to render component.

## Prove it works
Follow these steps:
- build both projects
- copy DynamicComponent\* into target directory of demo app (DynamicComponentDemo\bin\Debug\net7.0)
- run demo app, you shall see dynamic component renderred

# Disclaimer
Please be aware the code is provided as is, as long as the use case is yet not officially documented, use it on your own responsibility.
I will do my best to confirm this is officially supported as soon as possible.
