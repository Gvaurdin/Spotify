Console.WriteLine("Приложение начало работу");
using (var client = new HttpClient())
{
    var result = await client.GetAsync("https://localhost:7077/Groups");
    string responseBody = await result.Content.ReadAsStringAsync();
    Console.WriteLine(responseBody);
    
    result = await client.GetAsync($"https://localhost:7077/Groups?id={1}");
    responseBody = await result.Content.ReadAsStringAsync();
    Console.WriteLine(responseBody);
    var date = new DateOnly(1986, 12, 12);

    //======================================================================================================================
    /* Добавление группы */
    //var values = new Dictionary<string, string>
    //{
    //    {"title","Marlin Manson" },
    //    {"urlImage","..." },
    //    {"foundationDate", "1986-12-12" }
    //};
    //var formUrlEncodedContentnew = new FormUrlEncodedContent(values);
    //result = await client.PostAsync("https://localhost:7077/Groups", formUrlEncodedContentnew);
    //responseBody = await result.Content.ReadAsStringAsync();
    //Console.WriteLine(responseBody);

    //======================================================================================================================
    /* Удаление группы */
    //result = await client.DeleteAsync($"https://localhost:7077/Groups/3");
    //responseBody = await result.Content.ReadAsStringAsync();
    //Console.WriteLine(responseBody);

    //======================================================================================================================
    /* Обновление группы */
    var values = new Dictionary<string, string>
    {
        {"title","Михаил Круг" },
        {"urlImage","..." },
        {"foundationDate", "1990-12-12" }
    };
    var formUrlEncodedContentnew = new FormUrlEncodedContent(values);
    result = await client.PutAsync("https://localhost:7077/Groups/4", formUrlEncodedContentnew);
}

Console.WriteLine("Приложение завершило работу");
Console.ReadKey();