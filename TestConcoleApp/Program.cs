Console.WriteLine("Приложение начало работу");
using (var client = new HttpClient())
{
    using var result = await client.GetAsync("https://localhost:7077/Groups");
    string responseBody = await result.Content.ReadAsStringAsync();
    Console.WriteLine(responseBody);
}

Console.WriteLine("Приложение завершило работу");