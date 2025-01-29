using FrontendMock;
using FrontendMock.Model;
using Serilog;

Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("logs/MachineApi.log", rollingInterval: RollingInterval.Day)
            .CreateLogger();

Random rand = new Random();

List<Machine> machines = new List<Machine>
{
    new Machine{Id = "Alfa", Name = "sprite", State = EState.On},
    new Machine{Id = "Beta", Name = "coca", State = EState.On},
    new Machine{Id = "Gamma", Name = "cola", State = EState.On},
    new Machine{Id = "Omega", Name = "caffeine", State = EState.On},
    new Machine{Id = "Live", Name = "sleep", State = EState.On},
    new Machine{Id = "Fire", Name = "deathline", State = EState.On},
    new Machine{Id = "Optimus", Name = "operator", State = EState.On},
    new Machine{Id = "Prime", Name = "incrementator", State = EState.On},
};

foreach (var mahine in machines)
{
    Log.Information(MoqBehaviour.AppendAgregate(mahine.Id, mahine.Name, (int)mahine.State).Result);
}

while (true)
{
    int index = rand.Next(machines.Count);

    Machine machine = machines[index];

    int state = (int)(machine.State == EState.On ? EState.Off : EState.On);

    machine.State = (EState)state;

    Log.Information(MoqBehaviour.ChangeAgregateStateByName(machine.Name, state).Result);

    Thread.Sleep(rand.Next(500, 2500));
}