using System.Reactive;

using ReactiveUI;

namespace Runner
{
    public class MainViewModel : ReactiveObject
    {
        private bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set => this.RaiseAndSetIfChanged(ref isBusy,value);
        }

        public ReactiveCommand<Unit,Unit> MakeBusyCommand { get; }

        public MainViewModel()
        {
            IsBusy = false;
            MakeBusyCommand = ReactiveCommand.Create(SetToBusy);
        }

        private void SetToBusy()
        {
            IsBusy = !IsBusy;
        }
    }
}
