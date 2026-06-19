namespace Common.Reaction
{
    public class EventReaction
    {
        public required Type EventType { get; init; }
        public required Reaction Handler { get; init; }
    }
}