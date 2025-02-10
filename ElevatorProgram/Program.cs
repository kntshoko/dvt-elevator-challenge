using System;
using System.Net;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using ElevatorProgram.Constants;
using ElevatorProgram.Interfaces;
using ElevatorProgram.Models;
using ElevatorProgram.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;








public class Elevator
{

    
    

    public static void Main(String[] args)
    {

        IHost _host = Host.CreateDefaultBuilder().ConfigureServices(
            services =>
            {
                services.AddSingleton<IElevatorMovement, ElevatorMovement>()
               .AddSingleton<IOptions, Options>()
               .AddSingleton<IInputValidators, InputValidators>()
               .AddSingleton<ISimulator, Simulator>()
               .BuildServiceProvider();
            }
            
            ).Build();

    
               

        var elevatorService = _host.Services.GetRequiredService<IElevatorMovement>();
        var optionsService = _host.Services.GetRequiredService<IOptions>();
        var inputValidatorService = _host.Services.GetRequiredService<IInputValidators>();

        var simulator = _host.Services.GetRequiredService<ISimulator>();

        simulator.StartSimulation();



    }
}