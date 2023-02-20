var app = WebApplication.CreateBuilder(args).Build();

app.MapGet("/api/device", () =>
{
    var devices = new List<Device>
    {
        new (Id: 1, Mac: "5F-33-CC-1F-43-82", Firmware: "2.1.6"),
        new (Id: 2, Mac: "EF-2B-C4-F5-D6-34", Firmware: "2.1.6"),
    };

    return devices;
});

app.MapPost("/api/device", () =>
{
    int number = 40;
    int fib = Fibonacci(number);
    string location = $"/api/devices/{fib}";
    return TypedResults.Created(location, location);
});

app.Run();

static int Fibonacci(int n)
{
    if (n == 1 || n == 2)
        return 1;
    if (n == 3)
        return 2;
    return Fibonacci(n - 1) + Fibonacci(n - 2);
}

record Device(int Id, string Mac, string Firmware);
