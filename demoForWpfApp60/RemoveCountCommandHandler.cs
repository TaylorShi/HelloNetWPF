using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace demoForWpfApp60
{
    internal class RemoveCountCommandHandler : IRequestHandler<RemoveCountCommand, int>
    {
        public async Task<int> Handle(RemoveCountCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(request.Count - 1);
        }
    }
}
