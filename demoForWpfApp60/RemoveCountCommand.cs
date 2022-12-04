using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoForWpfApp60
{
    internal class RemoveCountCommand: IRequest<int>
    {
        public int Count { get; private set; }

        public RemoveCountCommand(int count) { this.Count = count; }
    }
}
