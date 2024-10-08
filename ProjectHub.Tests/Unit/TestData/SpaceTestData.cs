﻿using ProjectHub.Application.DTOs.SpaceDtos;
using ProjectHub.Domain.Workspace.Entities;
using ProjectHub.Domain.Workspace.Enums;

namespace ProjectHub.Tests.Unit.Seeder
{
    public static class SpaceTestData
    {
        public static List<Space> SeedData()
        {
            var spaces = new List<Space>()
            {
                new Space("Space 1", "Description Space 1", ProgressState.Completed),
                new Space("Space 2", "Description Space 2", ProgressState.NotStarted),
                new Space("Space 3", "Description Space 3", ProgressState.InProgress),
                new Space("Space 4", "Description Space 4", ProgressState.NotStarted),
            };

            return spaces;
        }

        public static Space CreateData(string name, string description)
        {
            var space = new Space(name, description);

            return space;
        }

        public static CreateSpaceDtoRequest CreateSpaceDto(string name, string description)
        {
            var dto = new CreateSpaceDtoRequest(name, description);

            return dto;
        }
    }
}
