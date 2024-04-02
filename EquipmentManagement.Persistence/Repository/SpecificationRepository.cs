﻿using EquipmentManagement.Application.Contract.Persis;
using EquipmentManagement.Domain;
using EquipmentManagement.Persistence.DatabaseContext;
using EquipmentManagement.Persistence.Repository.Generic;

namespace EquipmentManagement.Persistence.Repository
{
	public class SpecificationRepository: RepositoryBase<Specification,int>,ISpecificationRepository
	{
		private readonly ManageEquipmentDbContext _manageEquipmentDbContext;
		public SpecificationRepository(ManageEquipmentDbContext manageEquipmentDbContext) : base(manageEquipmentDbContext)
		{
			_manageEquipmentDbContext = manageEquipmentDbContext;
		}
	}


}
