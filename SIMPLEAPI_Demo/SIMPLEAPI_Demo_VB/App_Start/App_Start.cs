//// -----------------------------------------------------------------------
//// <copyright file="App_Start.cs" company="Fluent.Infrastructure">
////     Copyright © Fluent.Infrastructure. All rights reserved.
//// </copyright>
////-----------------------------------------------------------------------
/// See more at: https://github.com/dn32/Fluent.Infrastructure/wiki
////-----------------------------------------------------------------------

using Fluent.Infrastructure.FluentTools;
using SIMPLEAPI_Demo_VB.DataBase;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(SIMPLEAPI_Demo_VB.App_Start), "PreStart")]

namespace SIMPLEAPI_Demo_VB {
    public static class App_Start {
        public static void PreStart() {
            FluentStartup.Initialize(typeof(DbContextLocal));
        }
    }
}