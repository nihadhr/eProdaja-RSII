using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace eProdaja.MobileApp.ViewModels
{
    public class BaseValidationViewModel : BaseViewModel,INotifyDataErrorInfo
    {
        //readonly IDictionary _errors = new Dictionary();    
        public BaseValidationViewModel()
        {
        }

        public bool HasErrors => throw new NotImplementedException();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            throw new NotImplementedException();
        }
    }
}
