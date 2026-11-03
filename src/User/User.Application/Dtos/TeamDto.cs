namespace User.Application.Dtos;

using Domain.Entities;

public class TeamDto
{
    public User Manager { get; set; }
    public ICollection<User> Employees { get; set; }
}