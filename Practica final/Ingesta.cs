using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Practica_final
{
    public class Ingesta : INotifyPropertyChanged
    {
        String fecha;
        ObservableCollection<DetalleIngesta> detallesIngesta = new ObservableCollection<DetalleIngesta>();
        int totalCalorias = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        public Ingesta()
        {
            DetalleIngesta det = new DetalleIngesta();
            det.Comida = "DESAYUNO";
            det.Color = Brushes.Red;
            detallesIngesta.Add(det);

            det = new DetalleIngesta();
            det.Comida = "APERITIVO";
            det.Color = Brushes.Blue;
            detallesIngesta.Add(det);

            det = new DetalleIngesta();
            det.Comida = "COMIDA";
            det.Color = Brushes.Pink;
            detallesIngesta.Add(det);

            det = new DetalleIngesta();
            det.Comida = "MERIENDA";
            det.Color = Brushes.Gray;
            detallesIngesta.Add(det);

            det = new DetalleIngesta();
            det.Comida = "CENA";
            det.Color = Brushes.Green;
            detallesIngesta.Add(det);

            det = new DetalleIngesta();
            det.Comida = "OTROS";
            det.Color = Brushes.Orange;
            detallesIngesta.Add(det);
        }

        public void OnPropertyChanged(string p)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
        }

        public String Fecha
        {
            get
            {
                return fecha;
            }
            set
            {
                fecha = value;
                OnPropertyChanged("Fecha");
            }
        }

        public int CaloriasDesayuno
        {
            get
            {
                for (int i = 0; i < detallesIngesta.Count; i++)
                {
                    if (detallesIngesta[i].Comida.Equals("DESAYUNO")) {
                        return detallesIngesta[i].Calorias;
                    }
                }
                return 0;
            }
            set
            {
                totalCalorias = 0;
                for (int i = 0; i < detallesIngesta.Count; i++)
                {
                    if (detallesIngesta[i].Comida.Equals("DESAYUNO"))
                    {
                        detallesIngesta[i].Calorias = value;
                    }
                    totalCalorias = totalCalorias + detallesIngesta[i].Calorias;
                }
                OnPropertyChanged("TotalCalorias");
            }
        }

        public int CaloriasAperitivo
        {
            get
            {
                for (int i = 0; i < detallesIngesta.Count; i++)
                {
                    if (detallesIngesta[i].Comida.Equals("APERITIVO"))
                    {
                        return detallesIngesta[i].Calorias;
                    }
                }
                return 0;
            }
            set
            {
                totalCalorias = 0;
                for (int i = 0; i < detallesIngesta.Count; i++)
                {
                    if (detallesIngesta[i].Comida.Equals("APERITIVO"))
                    {
                        detallesIngesta[i].Calorias = value;
                    }
                    totalCalorias = totalCalorias + detallesIngesta[i].Calorias;
                }
                OnPropertyChanged("TotalCalorias");
            }
        }

        public int CaloriasComida
        {
            get
            {
                for (int i = 0; i < detallesIngesta.Count; i++)
                {
                    if (detallesIngesta[i].Comida.Equals("COMIDA"))
                    {
                        return detallesIngesta[i].Calorias;
                    }
                }
                return 0;
            }
            set
            {
                totalCalorias = 0;
                for (int i = 0; i < detallesIngesta.Count; i++)
                {
                    if (detallesIngesta[i].Comida.Equals("COMIDA"))
                    {
                        detallesIngesta[i].Calorias = value;
                    }
                    totalCalorias = totalCalorias + detallesIngesta[i].Calorias;
                }
                OnPropertyChanged("TotalCalorias");
            }
        }

        public int CaloriasMerienda
        {
            get
            {
                for (int i = 0; i < detallesIngesta.Count; i++)
                {
                    if (detallesIngesta[i].Comida.Equals("MERIENDA"))
                    {
                        return detallesIngesta[i].Calorias;
                    }
                }
                return 0;
            }
            set
            {
                totalCalorias = 0;
                for (int i = 0; i < detallesIngesta.Count; i++)
                {
                    if (detallesIngesta[i].Comida.Equals("MERIENDA"))
                    {
                        detallesIngesta[i].Calorias = value;
                    }
                    totalCalorias = totalCalorias + detallesIngesta[i].Calorias;
                }
                OnPropertyChanged("TotalCalorias");
            }
        }

        public int CaloriasCena
        {
            get
            {
                for (int i = 0; i < detallesIngesta.Count; i++)
                {
                    if (detallesIngesta[i].Comida.Equals("CENA"))
                    {
                        return detallesIngesta[i].Calorias;
                    }
                }
                return 0;
            }
            set
            {
                totalCalorias = 0;
                for (int i = 0; i < detallesIngesta.Count; i++)
                {
                    if (detallesIngesta[i].Comida.Equals("CENA"))
                    {
                        detallesIngesta[i].Calorias = value;
                    }
                    totalCalorias = totalCalorias + detallesIngesta[i].Calorias;
                }
                OnPropertyChanged("TotalCalorias");
            }
        }

        public int CaloriasOtros
        {
            get
            {
                for (int i = 0; i < detallesIngesta.Count; i++)
                {
                    if (detallesIngesta[i].Comida.Equals("OTROS"))
                    {
                        return detallesIngesta[i].Calorias;
                    }
                }
                return 0;
            }
            set
            {
                totalCalorias = 0;
                for (int i = 0; i < detallesIngesta.Count; i++)
                {
                    if (detallesIngesta[i].Comida.Equals("OTROS"))
                    {
                        detallesIngesta[i].Calorias = value;
                    }
                    totalCalorias = totalCalorias + detallesIngesta[i].Calorias;
                }
                OnPropertyChanged("TotalCalorias");
            }
        }

        public int TotalCalorias
        {
            get
            {
                return totalCalorias;
            }
        }

        public ObservableCollection<DetalleIngesta> ListaDetallesIngestas
        {
            get
            {
                return detallesIngesta;
            }
            set
            {
                detallesIngesta = value;
            }
        }

    }
}
