using System.ComponentModel.DataAnnotations;

namespace ProjectHub.Application.DTOs.SpaceDtos;

public record CreateSpaceDtoRequest(
    string Name,
    string Description
);
