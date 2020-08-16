using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModuleA.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private string _text = "ViewA";
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        public ViewAViewModel()
        {

        }
    }
}
