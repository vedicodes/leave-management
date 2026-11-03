using User.Application.Dtos;

namespace User.Application.Contracts;

public interface ITeam
{
    TeamDto GetTeamById(Guid id);
}