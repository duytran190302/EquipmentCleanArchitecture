using EquipmentManagement.Application.Contract.Persis;
using EquipmentManagement.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.UnitTests.Mocks
{
	public class MockLocationRepository
	{
		public static Mock<ILocationRepository> GetMockLocationRepository()
		{
			var locations = new List<Location>
			{
				new Location
				{
					LocationId= "a",
					Note= "1"
				},
				new Location
				{
					LocationId= "b",
					Note= "2"
				},
				new Location
				{
					LocationId= "c",
					Note= "3"
				}
			};

			var mockRepo = new Mock<ILocationRepository>();

			//mockRepo.Setup(r => r.GetAllAsync(null)).ReturnsAsync(locations);
			//mockRepo.Setup(r => r.GetAsync(null)).ReturnsAsync(locations.FirstOrDefault());

			//mockRepo.Setup(r => r.CreateAsync(It.IsAny<Location>()))
			//	.Returns((Location location) =>
			//	{
			//		locations.Add(location);
			//		return Task.CompletedTask;
			//	});



			return mockRepo;
		}
	}
}
