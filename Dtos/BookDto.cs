namespace BookStore.Api.Dtos;

public record BookDto(
    int Id,
    string Title,
    string Author,
    decimal Price,
    DateOnly PublishedDate
);
