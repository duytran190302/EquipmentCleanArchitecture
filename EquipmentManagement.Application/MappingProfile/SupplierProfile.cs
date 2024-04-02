using AutoMapper;
using EquipmentManagement.Application.Feature.Location.Commands.CreateLocation;
using EquipmentManagement.Application.Feature.Location.Commands.UpdateLocation;
using EquipmentManagement.Application.Feature.Location.Queries.GetAllLocations;
using EquipmentManagement.Application.Feature.Supplier.Commands.CreateSupplier;
using EquipmentManagement.Application.Feature.Supplier.Commands.UpdateSupplier;
using EquipmentManagement.Application.Feature.Supplier.Queries.GetAllSupplier;
using EquipmentManagement.Domain;

namespace EquipmentManagement.Application.MappingProfile
{
	public class SupplierProfile : Profile
	{
		public SupplierProfile()
		{
			CreateMap<Supplier, SupplierDTO>().ReverseMap();
			CreateMap<CreateSupplier, Supplier>();
			CreateMap<UpdateSupplier, Supplier>();
		}
	}



}
