namespace ASP.NET.Core
{
    public class Model
    {
        public override string ToString() => $"{UserId}\n{Id}\n{Title}\n{Body}\n";
        public uint UserId { get; set; }
        public uint Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
    }
}


