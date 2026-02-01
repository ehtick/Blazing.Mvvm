namespace Blazing.Mvvm.Sample.Shared.Models;

public record User
{
    public required string Id { get; init; }
    public required string Name { get; init; }
    public required string Email { get; init; }
}
