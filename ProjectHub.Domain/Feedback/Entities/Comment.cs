using ProjectHub.Domain.Common.Contracts;
using ProjectHub.Domain.Common.Models;
using ProjectHub.Domain.Feedback.Enums;

namespace ProjectHub.Domain.Feedback.Entities;

public sealed class Comment : BaseEntity
{
    public Guid Id { get; set; } = new();

    public string Title { get; set; }

    public string Body { get; set; }

    public CommentStatus Status { get; set; } = CommentStatus.Open;

    public Visibility Accessibility { get; set; } = Visibility.Public;

    public IEnumerable<Comment> Comments { get; set; } = new List<Comment>(); // NOTE: Find out if I should have nested comments

    public Guid ApiUserId { get; set; } // OPTIMIZE: Created By an ApiUser

    public IEntityId TaskId { get; set; } // TODO: Create so it can be either Bug or Feature
}
