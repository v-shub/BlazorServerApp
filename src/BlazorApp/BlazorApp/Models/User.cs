using System;
using System.Collections.Generic;

namespace BlazorApp.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime BirthdayDate { get; set; }

    public int ChildrenCount { get; set; }

    public string? ExtraInfo { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? DeletedById { get; set; }

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
