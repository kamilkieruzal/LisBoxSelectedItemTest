namespace WpfApp1
{
    public class ValueViewModel : ViewModelBase
    {
        private int calculationValue;

        public int CalculationValue
        {
            get => calculationValue;
            set
            {
                calculationValue = value;
                OnPropertyChanged();
            }
        }
    }
}
