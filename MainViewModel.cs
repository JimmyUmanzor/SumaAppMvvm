using System.ComponentModel;
using System.Windows.Input;

namespace SumaAppMvvm
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string primerNumero;
        private string segundoNumero;
        private string resultado;
        private string mensajeError;
        private bool tieneError;

        public string PrimerNumero
        {
            get => primerNumero;
            set
            {
                if (primerNumero != value)
                {
                    primerNumero = value;
                    OnPropertyChanged(nameof(PrimerNumero));
                }
            }
        }

        public string SegundoNumero
        {
            get => segundoNumero;
            set
            {
                if (segundoNumero != value)
                {
                    segundoNumero = value;
                    OnPropertyChanged(nameof(SegundoNumero));
                }
            }
        }

        public string Resultado
        {
            get => resultado;
            set
            {
                if (resultado != value)
                {
                    resultado = value;
                    OnPropertyChanged(nameof(Resultado));
                }
            }
        }

        public string MensajeError
        {
            get => mensajeError;
            set
            {
                if (mensajeError != value)
                {
                    mensajeError = value;
                    OnPropertyChanged(nameof(MensajeError));
                }
            }
        }

        public bool TieneError
        {
            get => tieneError;
            set
            {
                if (tieneError != value)
                {
                    tieneError = value;
                    OnPropertyChanged(nameof(TieneError));
                }
            }
        }

        public ICommand ComandoSumar { get; }
        public ICommand ComandoLimpiar { get; }

        public MainViewModel()
        {
            ComandoSumar = new Command(Sumar);
            ComandoLimpiar = new Command(Limpiar);
        }

        private void Sumar()
        {
            if (string.IsNullOrWhiteSpace(PrimerNumero) || string.IsNullOrWhiteSpace(SegundoNumero))
            {
                MensajeError = "Todos dos campos son obligatorios";
                TieneError = true;
                Resultado = string.Empty;
                return;
            }

            TieneError = false;
            if (double.TryParse(PrimerNumero, out double num1) && double.TryParse(SegundoNumero, out double num2))
            {
                Resultado = $"Resultado: {num1 + num2}";
            }
            else
            {
                MensajeError = "Ingrese números válidos.";
                TieneError = true;
            }
        }

        private void Limpiar()
        {
            PrimerNumero = string.Empty;
            SegundoNumero = string.Empty;
            Resultado = string.Empty;
            MensajeError = string.Empty;
            TieneError = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
