using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace WpfApp1
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<ValueViewModel> values;
        private ValueViewModel selectedValue;

        public MainWindowViewModel()
        {
            Values = new ObservableCollection<ValueViewModel>
            {
                new ValueViewModel { CalculationValue = 2 },
                new ValueViewModel { CalculationValue = 4 },
                new ValueViewModel { CalculationValue = 9 },
                new ValueViewModel { CalculationValue = 4 },
                new ValueViewModel { CalculationValue = 4 },
                new ValueViewModel { CalculationValue = 9 },
                new ValueViewModel { CalculationValue = 9 },
            };

            OnButtonClick = new RelayCommand(x => OnButtonClickHandler(), x => true);
        }

        public ObservableCollection<ValueViewModel> Values { get => values; set => values = value; }

        public ValueViewModel SelectedValue { get => selectedValue; set => selectedValue = value; }

        public RelayCommand OnButtonClick { get; set; }

        private void OnButtonClickHandler()
        {
            if (SelectedValue != null)
            {
                Values.Remove(SelectedValue);
            }
        }
    }

    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
