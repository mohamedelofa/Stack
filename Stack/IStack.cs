using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
	internal interface IStack<T>
	{
		T GetByIndex(int idx);
	}
}
