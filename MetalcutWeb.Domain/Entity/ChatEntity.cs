using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalcutWeb.Domain.Entity;

public class ChatEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public AppUser UserOne { get; set; }
    public AppUser UserTwo { get; set; }
    public string ChatName { get; set; }
    [AllowNull]
    public ICollection<MessageEntity> Messages { get; set; }
}
