using BookStore.Api.Dtos;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var books = new List<BookDto>
{
    new BookDto(1, "Nuts And Bolts", "Asad Iqbal", 29, DateOnly.Parse("2024-10-10", CultureInfo.InvariantCulture)),
    new BookDto(2, "C# in Depth", "Jon Skeet", 39, DateOnly.Parse("2023-05-15", CultureInfo.InvariantCulture)),
    new BookDto(3, "Effective Java", "Joshua Bloch", 49, DateOnly.Parse("2022-08-20", CultureInfo.InvariantCulture))
};

app.MapGet("/", () => "Hello World!");
app.MapGet("/books", () => books);
app.MapGet("/books/{id}", (int id) =>
{
    var book = books.Find(b => b.Id == id);
    return book is not null ? Results.Ok(book) : Results.NotFound();
});

app.Run();
