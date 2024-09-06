namespace ProjectHub.Domain.Feedback.ValueObjects;

public readonly record struct CommentId(Guid Id)
{
    public static CommentId Empty => new(Guid.Empty);
    public static CommentId NewEntityId() => new(Guid.NewGuid());
}
