using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace demoForWpfApp50
{
    internal class MainViewModel : ObservableObject
    {
        private int _count;
        public int Count
        {
            get => _count;
            set => SetProperty(ref _count, value);
        }

        public ICommand AddCountCommand => new RelayCommand(AddCount);

        public void AddCount()
        {
            Count++;
        }

        public IAsyncRelayCommand RemoveCountCommand => new AsyncRelayCommand(RemoveCount);

        public async Task RemoveCount()
        {
            await Task.Run(() =>
            {
                Count--;
            });
        }
    }
}
