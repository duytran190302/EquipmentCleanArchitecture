﻿
using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Domain;
namespace EquipmentManagement.Application.Contract.Persis
{
	public interface IProjectRepository : IRepositoryBaseAsync<Project,string>
	{
	}
}
