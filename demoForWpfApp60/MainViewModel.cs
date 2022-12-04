using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace demoForWpfApp60
{
    internal class MainViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        public MainViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        //private int _count;
        //public int Count
        //{
        //    get => _count;
        //    set => SetProperty(ref _count, value);
        //}

        public int Count { get; set; }

        public ICommand AddCountCommand => new RelayCommand(AddCount);

        public void AddCount()
        {
            Count++;
        }

        public IAsyncRelayCommand RemoveCountCommand => new AsyncRelayCommand(RemoveCount);

        public async Task RemoveCount()
        {
            Count = await _mediator.Send(new RemoveCountCommand(Count));
        }
    }
}
