using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Practica_final
{
    public class DetalleIngesta : INotifyPropertyChanged
    {
        private String comida;
        private int calorias;
        private SolidColorBrush color;

        public event PropertyChangedEventHandler PropertyChanged;

        public DetalleIngesta()
        {
            calorias = 0;
        }

        public String Comida
        {
            get
            {
                return comida;
            }
            set
            {
                comida = value;
                OnPropertyChanged("Comida");
            }
        }
        public int Calorias
        {
            get
            {
                return calorias;
            }
            set
            {
                calorias = value;
                OnPropertyChanged("Calorias");
            }
        }

        public SolidColorBrush Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;              
            }
        }

        
        public void OnPropertyChanged(string p)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
        }
    }
}
