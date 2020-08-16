using ModuleA.Business;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModuleA.ViewModels
{
    public class PersonDetailViewModel : BindableBase, INavigationAware
    {
        private Person _selectedPerson;
        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set { SetProperty(ref _selectedPerson, value); }
        }
        public PersonDetailViewModel()
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters.ContainsKey("person"))
            {
                //Can use either one of these calls to get the person parameter
                SelectedPerson = navigationContext.Parameters.GetValue<Person>("person");
                //SelectedPerson = navigationContext.Parameters["person"] as Person;
            }

        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            var person = navigationContext.Parameters.GetValue<Person>("person");
            if (SelectedPerson.LastName == person.LastName)
                return true;
            else
                return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
    }
}
