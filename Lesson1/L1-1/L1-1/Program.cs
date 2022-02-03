using L1_1.Client;
using L1_1.DataObject;
using L1_1.Print;

// Создание клиента
Client<ContentDTO> client = new Client<ContentDTO>();

// Вызов функции для асинхронного получения постов
var posts = client.GetContentByAnyIdAsync(@"https://jsonplaceholder.typicode.com/posts/", 4, 13);

// Печать полученных постов в файл
Printer printer = new Printer();
posts.ForEach(t => printer.PrintToFile(@"C:\Users\Данил Шабанов\Desktop\Programming\GeekBrains\results.txt", t));
