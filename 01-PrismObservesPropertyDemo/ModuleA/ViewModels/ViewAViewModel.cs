﻿using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleA.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private string _text = "Hello from ViewAViewModel";

        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        private bool _canExecute;
        public bool CanExecute
        {
            get { return _canExecute; }
            set { SetProperty(ref _canExecute, value); }
        }

        public DelegateCommand ClickCommand { get; private set; }

        public ViewAViewModel()
        {
            ClickCommand = new DelegateCommand(Click, CanClick).ObservesProperty(() => CanExecute);
        }

        private bool CanClick()
        {
            return CanExecute;
        }

        private void Click()
        {
            Text = "You Clicked me!";
        }
    }
}
