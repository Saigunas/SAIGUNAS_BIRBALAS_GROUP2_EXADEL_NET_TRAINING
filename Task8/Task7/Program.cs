using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Task5.DataAccessLayer.Persistence;
using Task5.DataAccessLayer.Core.Domain;
using Task7.DataAccessLayer.Persistence;
using Autofac;
using Task7;
using Task7.DataAccessLayer.Persistence.Services;
using Task7.DataAccessLayer.Persistence.StudentServices;

public partial class Program
{
    public static void Main(string[] args)
    {
        var container = ContainerConfigure();

        using(var scope = container.BeginLifetimeScope())
        {
            var app = scope.Resolve<IApplication>();
            app.Run();
        }
    }

    public static IContainer ContainerConfigure()
    {
        var builder = new ContainerBuilder();

        builder.RegisterType<Application>().As<IApplication>();
        builder.RegisterType<GetStudentsInfoService>().As<IGetStudentsInfoService>();
        builder.RegisterType<GetLastNameService>().As<IGetLastNameService>();
        builder.RegisterType<GetFullInfoService>().As<IGetFullInfoService>();
        builder.RegisterType<ConsoleMenuService>().As<IConsoleMenuService>();


        return builder.Build();
    }
}