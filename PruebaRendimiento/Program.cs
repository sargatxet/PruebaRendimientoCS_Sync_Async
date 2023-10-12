using System.Diagnostics;

int Calculate(int parameter, int veces)
{
    int result = parameter;
    for (int i = 0; i < veces; i++)
    {
        result += i * parameter;
        result -= i / parameter;
        result *= parameter + i;
        result /= parameter - (i == parameter ? i + 1 : i);
    }
    return result;
}
async Task<int> CalculateAsync(int parameter, int veces)
{
    int result = parameter;
    for (int i = 0; i < veces; i++)
    {
        result += i * parameter;
        result -= i / parameter;
        result *= parameter + i;
        result /= parameter - (i == parameter ? i + 1 : i);
    }
    return await Task.FromResult(result);
}

Stopwatch stopwatch = new Stopwatch();

stopwatch.Start();
Random random = new Random();
int veces = 50000;
for (int i = 0; i < veces; i++)
{
    int parameter = random.Next(1, 100);
    int result = Calculate(parameter, veces);
    Console.WriteLine($"Result {i + 1}: {result}");
}
stopwatch.Stop();
long sincrono = stopwatch.ElapsedMilliseconds;


// Llamada asíncrona
stopwatch.Start();
random = new Random();
for (int i = 0; i < veces; i++)
{
    int parameter = random.Next(1, 100);
    Task<int> resultTask = CalculateAsync(parameter, veces);
    Console.WriteLine($"Result {i + 1}: {await resultTask}");
}
stopwatch.Stop();
long asincrono = stopwatch.ElapsedMilliseconds;

Console.WriteLine($"Time elapsed: {sincrono} ms");
Console.WriteLine($"Time elapsed Async: {asincrono} ms");