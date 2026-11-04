namespace User.Application.DTOs;

public class TeamDTO
{
    public required EmployeeDTO Manager { get; set; }
    public required IReadOnlyCollection<EmployeeDTO> Associates { get; set; }
}