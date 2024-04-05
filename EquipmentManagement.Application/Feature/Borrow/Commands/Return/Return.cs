using EquipmentManagement.Application.Feature.Borrow.Commands.UpdateBorrow;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Borrow.Commands.Return;

public class Return : IRequest<string>
{
	public string BorrowId { get; set; } = string.Empty;
	public DateTime RealReturnedDate { get; set; }
}
