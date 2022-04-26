﻿using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TripLog.Services;

namespace TripLog.ViewModels
{
    public class BaseValidationViewModel : BaseViewModel, INotifyDataErrorInfo
    {
        private readonly Dictionary<string, List<string>> _errors = new();
        public bool HasErrors => _errors.All(e => e.Value.Any());

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public BaseValidationViewModel(INavigationService navigationService) : base(navigationService)
        {

        }

        public IEnumerable GetErrors(string? propertyName)
        {
            if(string.IsNullOrWhiteSpace(propertyName))
            {
                return _errors.SelectMany(x => x.Value);
            }

            if(_errors.ContainsKey(propertyName) && _errors[propertyName].Any())
            {
                return _errors[propertyName];
            }

            return new List<string>();
        }

        protected void Validate(Func<bool> rule, string error, [CallerMemberName] string propertyName = "")
        {
            if (string.IsNullOrWhiteSpace(propertyName))
            {
                return;
            }

            if(_errors.ContainsKey(propertyName))
            {
                _errors.Remove(propertyName);
            }

            if(rule() == false)
            {
                _errors.Add(propertyName, new List<string>() { error });
            }

            OnPropertyChanged(nameof(HasErrors));

            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}
