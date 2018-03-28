using System.Reflection;

[assembly: AssemblyProduct("Test.BehaviorDrivenDevelopment")]

[assembly: AssemblyCompany("CustomCode")]
[assembly: AssemblyCopyright("Copyright © 2018")]
[assembly: AssemblyTrademark("C# behavior driven development")]

#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif