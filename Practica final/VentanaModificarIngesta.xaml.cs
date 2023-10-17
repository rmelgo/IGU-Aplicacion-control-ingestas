using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Practica_final
{
    /// <summary>
    /// Lógica de interacción para VentanaModificarIngesta.xaml
    /// </summary>
    /// 
    public partial class VentanaModificarIngesta : Window
    {
        private ObservableCollection<Ingesta> ingestas = new ObservableCollection<Ingesta>();
        private Ingesta ing;
        public VentanaModificarIngesta(Ingesta i)
        {
            InitializeComponent();
            ing = i;
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {           
            CajaFecha.Text = ing.Fecha;
            CajaCaloriasDesayuno.Text = ing.CaloriasDesayuno.ToString();
            CajaCaloriasAperitivo.Text = ing.CaloriasAperitivo.ToString();
            CajaCaloriasComida.Text = ing.CaloriasComida.ToString();
            CajaCaloriasMerienda.Text = ing.CaloriasMerienda.ToString();
            CajaCaloriasCena.Text = ing.CaloriasCena.ToString();
            CajaCaloriasOtros.Text = ing.CaloriasOtros.ToString();
            Calendario.SelectedDate = DateTime.Parse(ing.Fecha);
            Calendario.DisplayDate = DateTime.Parse(ing.Fecha); 
        }

        private void CancelarIngesta_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void AceptarIngesta_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void CajaCaloriasDesayuno_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (CajaCaloriasDesayuno.Text.Equals("Calorias desayuno"))
            {
                CajaCaloriasDesayuno.Text = "";
                CajaCaloriasDesayuno.Foreground = Brushes.LightGray;
            }
        }

        private void CajaCaloriasDesayuno_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (CajaCaloriasDesayuno.Text.Equals(""))
            {
                CajaCaloriasDesayuno.Text = "Calorias desayuno";
                CajaCaloriasDesayuno.Foreground = Brushes.DimGray;
            }
        }

        private void CajaCaloriasAperitivo_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (CajaCaloriasAperitivo.Text.Equals("Calorias aperitivo"))
            {
                CajaCaloriasAperitivo.Text = "";
                CajaCaloriasAperitivo.Foreground = Brushes.LightGray;
            }
        }

        private void CajaCaloriasAperitivo_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (CajaCaloriasAperitivo.Text.Equals(""))
            {
                CajaCaloriasAperitivo.Text = "Calorias aperitivo";
                CajaCaloriasAperitivo.Foreground = Brushes.DimGray;
            }
        }

        private void CajaCaloriasComida_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (CajaCaloriasComida.Text.Equals("Calorias comida"))
            {
                CajaCaloriasComida.Text = "";
                CajaCaloriasComida.Foreground = Brushes.LightGray;
            }
        }

        private void CajaCaloriasComida_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (CajaCaloriasComida.Text.Equals(""))
            {
                CajaCaloriasComida.Text = "Calorias comida";
                CajaCaloriasComida.Foreground = Brushes.DimGray;
            }
        }

        private void CajaCaloriasMerienda_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (CajaCaloriasMerienda.Text.Equals("Calorias merienda"))
            {
                CajaCaloriasMerienda.Text = "";
                CajaCaloriasMerienda.Foreground = Brushes.LightGray;
            }
        }

        private void CajaCaloriasMerienda_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (CajaCaloriasMerienda.Text.Equals(""))
            {
                CajaCaloriasMerienda.Text = "Calorias merienda";
                CajaCaloriasMerienda.Foreground = Brushes.DimGray;
            }
        }

        private void CajaCaloriasCena_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (CajaCaloriasCena.Text.Equals("Calorias cena"))
            {
                CajaCaloriasCena.Text = "";
                CajaCaloriasCena.Foreground = Brushes.LightGray;
            }
        }

        private void CajaCaloriasCena_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (CajaCaloriasCena.Text.Equals(""))
            {
                CajaCaloriasCena.Text = "Calorias cena";
                CajaCaloriasCena.Foreground = Brushes.DimGray;
            }
        }

        private void CajaCaloriasOtros_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (CajaCaloriasOtros.Text.Equals("Calorias otros"))
            {
                CajaCaloriasOtros.Text = "";
                CajaCaloriasOtros.Foreground = Brushes.LightGray;
            }
        }

        private void CajaCaloriasOtros_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (CajaCaloriasOtros.Text.Equals(""))
            {
                CajaCaloriasOtros.Text = "Calorias otros";
                CajaCaloriasOtros.Foreground = Brushes.DimGray;
            }
        }

        private void CajaFecha_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Calendario.SelectedDate = CajaFecha.SelectedDate;
            if (CajaFecha.SelectedDate != null)
            {
                Calendario.DisplayDate = (DateTime)CajaFecha.SelectedDate;
            }
        }

        private void Calendario_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            CajaFecha.Text = Calendario.SelectedDate.ToString();
        }
    }
}
