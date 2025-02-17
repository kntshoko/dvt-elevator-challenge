using ElevatorProgram.Constants;
using ElevatorProgram.Interfaces;
using ElevatorProgram.Models;
using ElevatorProgram.Services;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ElevatorSimulation.Tests;

public class UnitTest1
{
    private ServiceProvider serviceProvider;
    private IElevatorMovement elevatorService;
    private IOptions optionsService;
    private IInputValidators inputValidatorService;

    public UnitTest1() {


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




         elevatorService = _host.Services.GetRequiredService<IElevatorMovement>();
        optionsService = _host.Services.GetRequiredService<IOptions>();
         inputValidatorService = _host.Services.GetRequiredService<IInputValidators>();

        
    }
    [Fact]
    public void ChecksIfNumberIsNotString()
    {
      
        InputResultModel result = inputValidatorService.InputValidation("3",10,InputType.elevator);

        result.valid.Should().BeTrue();
    }

    [Fact]
    public void ChecksIfNumberIsValid()
    {

        InputResultModel result = inputValidatorService.InputValidation("3", 10, InputType.elevator);

        result.valid.Should().BeTrue();
    }
}