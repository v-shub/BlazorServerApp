using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BlazorApp.Models;

public partial class Post
{
    public int Id { get; set; }

    public int CreatorId { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Header { get; set; }

    public string PostContent { get; set; } = null!;

    public DateTime? DeletedAt { get; set; }

    public int? DeletedById { get; set; }

    public virtual User Creator { get; set; } = null!;
}
