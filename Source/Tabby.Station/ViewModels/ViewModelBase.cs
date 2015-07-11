using System;
using System.ComponentModel;
using System.IO;


namespace Tabby.Station.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual string DisplayName { get; protected set; }


        public void VerifyPropertyName(string propertyName)
        {
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                throw new InvalidDataException(string.Format("Invalid property name: {0}", propertyName));
            }
        }


        public void Dispose()
        {
            OnDispose();
        }


        protected virtual void OnDispose()
        {
        }


        protected virtual void RaisePropertyChangedEvent(string propertyName)
        {
            VerifyPropertyName(propertyName);

            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
    }
}
