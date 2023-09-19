using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Models.Enums
{
	public enum SearchParams
	{
		ItemName = 1,
		Type= 2,
		Author = 4,
		Borrow= 8,
		Other = 16
	}
}
