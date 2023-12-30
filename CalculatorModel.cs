using System.ComponentModel;

namespace HW12_calc
{
    public class CalculatorModel : INotifyPropertyChanged
    {
        private double _numberA;
        private double _numberB;
        private double _result;

        public double NumberA
        {
            get { return _numberA; }
            set
            {
                if (_numberA != value)
                {
                    _numberA = value;
                    OnPropertyChanged(nameof(NumberA));
                    UpdateResult();
                }
            }
        }

        public double NumberB
        {
            get { return _numberB; }
            set
            {
                if (_numberB != value)
                {
                    _numberB = value;
                    OnPropertyChanged(nameof(NumberB));
                    UpdateResult();
                }
            }
        }

        public double Result
        {
            get { return _result; }
            private set
            {
                if (_result != value)
                {
                    _result = value;
                    OnPropertyChanged(nameof(Result));
                }
            }
        }

        public void UpdateResult()
        {
            Result = NumberA + NumberB;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}