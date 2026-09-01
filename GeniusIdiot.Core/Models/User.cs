namespace GeniusIdiot.Core.Models;

public record User
{
    public string Name { get; init; }
    public User(string userName) => Name = string.IsNullOrWhiteSpace(userName) ? "Хитрюга" : userName;
}