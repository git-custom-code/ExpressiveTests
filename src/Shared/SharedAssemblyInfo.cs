using System.Reflection;

[assembly: AssemblyProduct("Test.BehaviorDrivenDevelopment")]

[assembly: AssemblyCompany("CustomCode")]
[assembly: AssemblyCopyright("Copyright © 2018")]
[assembly: AssemblyTrademark("Behavior driven development implementation for c#.")]

#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif