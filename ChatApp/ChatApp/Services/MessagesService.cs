namespace ChatAppApi.Services;

public class MessagesService
{
    public Dictionary<string, List<Tuple<string, string>>> Messages =
        new Dictionary<string, List<Tuple<string, string>>>()
        {
            {"DotNet", new List<Tuple<string, string>>()},
            {"Blazor", new List<Tuple<string, string>>()},
            {"JavaScript", new List<Tuple<string, string>>()}
        };
}