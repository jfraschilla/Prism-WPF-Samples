using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace CancelTask.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        private string _statusMessage;
        private double _percentComplete;
        CancellationTokenSource _tokenSource = null;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand ButtonClick { get; private set; }
        public DelegateCommand ExecuteCancelCommand { get; private set; }
        public string StatusMessage 
        {
            get { return _statusMessage; }
            private set { SetProperty(ref _statusMessage, value); } 
        }
        public double PercentComplete
        {
            get { return _percentComplete; } 
            set { SetProperty(ref _percentComplete, value); }
        }

        public MainWindowViewModel()
        {
            ButtonClick = new DelegateCommand(OnButtonClick);
            ExecuteCancelCommand = new DelegateCommand(OnCancelClick);
            StatusMessage = "Start";
        }

        private async void OnButtonClick()
        {
            _tokenSource = new CancellationTokenSource();
            var token = _tokenSource.Token;

            var progress = new Progress<int>(value =>
           {
               PercentComplete = value;
               StatusMessage = $"{value}%";
           });

            try
            {
                await Task.Run(() => LoopThoughNumbers(100, progress, token));
                StatusMessage = "Completed";
            }
            catch (OperationCanceledException)
            {
                StatusMessage = "Cancelled";
            }
            finally
            {
                // Improtant! We always want to dispose the token source
                _tokenSource.Dispose();
            }
        }

        private void LoopThoughNumbers(int count, IProgress<int> progress, CancellationToken token)
        {
            for (int x = 0; x < count; x++)
            {
                Thread.Sleep(100);
                var percentComplete = (x * 100) / count;
                progress.Report(percentComplete);

                //This cancellation method is called polling because during every 
                //iteration of the loop we check the cancellation token
                if (token.IsCancellationRequested)
                {
                    //TODO: add code to cleanup and cancel long running process
                    //options:
                    // 1) throw an exception
                    // 2) just return
                    // 3) return a modified value of the current calculation

                    token.ThrowIfCancellationRequested();
                }
            }
        }

        private void OnCancelClick()
        {
            _tokenSource.Cancel();
        }

    }
}
