﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace PersonalHub.Domain.Entities;

public class ApiUser : IdentityUser
{
    public PersonalInfo? Information { get; set; }

    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:dd/MM-yyyy}")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:dd/MM-yyyy}")]
    public DateTime? UpdatedAt { get; set; }
}
