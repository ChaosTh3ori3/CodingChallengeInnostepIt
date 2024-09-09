using System.ComponentModel.DataAnnotations;

namespace CodingChallengeInnostepIt.Persistence.DTOs;
public class UpdateUserDto
{
    [Required]
    public string Id { get; set; }
    [Required]
    public string ForName { get; set; }
    [Required]
    public string SureName { get; set; }
    [Required]
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
}