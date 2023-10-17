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
    /// Lógica de interacción para VentanaVisualizarIngestas.xaml
    /// </summary>
    /// 
    public class ItemSeleccionadoEventsArgs : EventArgs
    {
        public Ingesta IngestaSeleccionada 
        {
            get; set;
        }
    }

    public partial class VentanaVisualizarIngestas : Window
    {
        private ObservableCollection<Ingesta> ingestas = new ObservableCollection<Ingesta>();
        private ObservableCollection<Ingesta> ingestasFiltro = new ObservableCollection<Ingesta>();
        public event EventHandler<ItemSeleccionadoEventsArgs> SeleccionItem;
        private VentanaModificarIngesta vmi;

        public VentanaVisualizarIngestas(ObservableCollection<Ingesta> i)
        {
            InitializeComponent();
            ingestas = i;
            ListView1.ItemsSource = ingestas;
        }

        private void ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = ListView1.SelectedIndex;
            if (ListView1.SelectedItem != null)
            {
                ListView2.ItemsSource = ingestas[i].ListaDetallesIngestas;
                BotonEliminarIngesta.Visibility = Visibility.Visible;
                RectanguloModificarIngesta.Visibility = Visibility.Visible;
                BotonModificarIngesta.Visibility = Visibility.Visible;
                RectanguloEliminarIngesta.Visibility = Visibility.Visible;
                ItemSeleccionadoEventsArgs ise = new ItemSeleccionadoEventsArgs();
                ise.IngestaSeleccionada = ingestas[i];
                OnSeleccionItem(ise);
            }
            else
            {
                ListView2.ItemsSource = null;
                BotonEliminarIngesta.Visibility = Visibility.Hidden;
                RectanguloModificarIngesta.Visibility = Visibility.Hidden;
                BotonModificarIngesta.Visibility = Visibility.Hidden;
                RectanguloEliminarIngesta.Visibility = Visibility.Hidden;
            }
        }

        private void OnSeleccionItem(ItemSeleccionadoEventsArgs e)
        {
            SeleccionItem?.Invoke(this, e);
        }

        private void ListView1_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ListView1.FontSize = ListView1.ActualHeight * 14 / 300; 
            Columna_fecha.Width = (ListView1.ActualWidth * 150 / 700) - 5; 
            Columna_total.Width = (ListView1.ActualWidth * 550 / 700) - 5;
        }

        private void LaVentanaVisualizarIngestas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ListView1.Width = (LaVentanaVisualizarIngestas.ActualWidth - ColumnaFiltros.ActualWidth) * 700 / 785;
            ListView1.Height = LaVentanaVisualizarIngestas.ActualHeight * 300 / 750;
            ListView2.Width = (LaVentanaVisualizarIngestas.ActualWidth - ColumnaFiltros.ActualWidth) * 700 / 785;
            ListView2.Height = LaVentanaVisualizarIngestas.ActualHeight * 300 / 750;
        }

        private void ListView2_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ListView2.FontSize = ListView1.ActualHeight * 14 / 300;
            Columna_comida.Width = (ListView2.ActualWidth * 175 / 700) - 5;
            Columna_calorias.Width = (ListView2.ActualWidth * 525 / 700) - 5;
        }

        private void BotonEliminarIngesta_Click(object sender, RoutedEventArgs e)
        {
            int i = ListView1.SelectedIndex;
            ingestas.RemoveAt(i);
        }

        private void BotonModificarIngesta_Click(object sender, RoutedEventArgs e)
        {
            if (vmi != null)
            {
                return;
            }
            vmi = new VentanaModificarIngesta(ingestas[ListView1.SelectedIndex]);
            vmi.Owner = this;

    
            vmi.ShowDialog();
            if (vmi.DialogResult == true)
            {
                int i = ListView1.SelectedIndex;
                Boolean ingesta_correcta = true;
                for (int j = 0; j < ingestas.Count; j++)
                {
                    if (ingestas[j].Fecha.Equals(vmi.CajaFecha.Text) && j != i)
                    {
                        ingesta_correcta = false;
                        break;
                    }
                }

                if (ingesta_correcta && vmi.CajaFecha.Text != "")
                {
                    try
                    {                       
                        if (ingestas[i].Fecha != vmi.CajaFecha.Text)
                        {
                            ingestas[i].Fecha = vmi.CajaFecha.Text;
                        }
                        if (ingestas[i].CaloriasDesayuno != Int32.Parse(vmi.CajaCaloriasDesayuno.Text))
                        {
                            ingestas[i].CaloriasDesayuno = Int32.Parse(vmi.CajaCaloriasDesayuno.Text);
                        }
                        if (ingestas[i].CaloriasAperitivo != Int32.Parse(vmi.CajaCaloriasAperitivo.Text))
                        {
                            ingestas[i].CaloriasAperitivo = Int32.Parse(vmi.CajaCaloriasAperitivo.Text);
                        }
                        if (ingestas[i].CaloriasComida != Int32.Parse(vmi.CajaCaloriasComida.Text))
                        {
                            ingestas[i].CaloriasComida = Int32.Parse(vmi.CajaCaloriasComida.Text);
                        }
                        if (ingestas[i].CaloriasMerienda != Int32.Parse(vmi.CajaCaloriasMerienda.Text))
                        {
                            ingestas[i].CaloriasMerienda = Int32.Parse(vmi.CajaCaloriasMerienda.Text);
                        }
                        if (ingestas[i].CaloriasCena != Int32.Parse(vmi.CajaCaloriasCena.Text))
                        {
                            ingestas[i].CaloriasCena = Int32.Parse(vmi.CajaCaloriasCena.Text);
                        }
                        if (ingestas[i].CaloriasOtros != Int32.Parse(vmi.CajaCaloriasOtros.Text))
                        {
                            ingestas[i].CaloriasOtros = Int32.Parse(vmi.CajaCaloriasOtros.Text);
                        }
                    }
                    catch (Exception)
                    {
                        string msg = "Error, los datos de la ingesta no tienen el formato correcto.\nLa ingesta no se ha podido modificar correctamente";
                        string titulo = "Mi aplicación";
                        MessageBoxButton botones = MessageBoxButton.OK;
                        MessageBoxImage icono = MessageBoxImage.Error;
                        MessageBox.Show(msg, titulo, botones, icono);
                    }
                }
                else if (vmi.CajaFecha.Text == "")
                {
                    string msg = "Error, no se pueden añadir ingestas sin fecha.\nLa ingesta no se ha podido modificar correctamente";
                    string titulo = "Mi aplicación";
                    MessageBoxButton botones = MessageBoxButton.OK;
                    MessageBoxImage icono = MessageBoxImage.Error;
                    MessageBox.Show(msg, titulo, botones, icono);
                }
                else
                {
                    string msg = "Error, ya existe una ingesta con la fecha " + vmi.CajaFecha.Text + ".\nLa ingesta no se ha podido modificar correctamente";
                    string titulo = "Mi aplicación";
                    MessageBoxButton botones = MessageBoxButton.OK;
                    MessageBoxImage icono = MessageBoxImage.Error;
                    MessageBox.Show(msg, titulo, botones, icono);
                }
            }
            vmi = null;
        }

        private void FiltroCalorias_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (FiltroCalorias.Text.Equals("Buscar..."))
            {
                FiltroCalorias.Text = "";
                FiltroCalorias.Foreground = Brushes.LightGray;
            }
        }

        private void FiltroCalorias_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (FiltroCalorias.Text.Equals(""))
            {
                FiltroCalorias.Text = "Buscar...";
                FiltroCalorias.Foreground = Brushes.DimGray;
            }
        }

        private void FiltroFecha_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (FiltroFecha.Text.Equals("Buscar..."))
            {
                FiltroFecha.Text = "";
                FiltroFecha.Foreground = Brushes.LightGray;
            }
        }

        private void FiltroFecha_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (FiltroFecha.Text.Equals(""))
            {
                FiltroFecha.Text = "Buscar...";
                FiltroFecha.Foreground = Brushes.DimGray;
            }
        }

        private void AplicarFiltrosCalorias_Click(object sender, RoutedEventArgs e)
        {
            ingestasFiltro.Clear();
          
            if (FiltroCalorias.Text.Equals("Buscar...") == false && FiltroFecha.Text.Equals("Buscar...") == false)
            {
                try
                {
                    for (int i = 0; i < ingestas.Count; i++)
                    {
                        if (ingestas[i].TotalCalorias == Int32.Parse(FiltroCalorias.Text) && ingestas[i].Fecha == FiltroFecha.Text)
                        {
                            ingestasFiltro.Add(ingestas[i]);
                        }
                    }
                    ListView1.ItemsSource = ingestasFiltro;
                }
                catch (Exception)
                {
                    string msg = "Error, los filtros del total de calorias no tienen el formato correcto.";
                    string titulo = "Mi aplicación";
                    MessageBoxButton botones = MessageBoxButton.OK;
                    MessageBoxImage icono = MessageBoxImage.Error;
                    MessageBox.Show(msg, titulo, botones, icono);
                }
            }
            if (FiltroCalorias.Text.Equals("Buscar...") == false && FiltroFecha.Text.Equals("Buscar...") == true)
            {
                try
                {
                    for (int i = 0; i < ingestas.Count; i++)
                    {
                        if (ingestas[i].TotalCalorias == Int32.Parse(FiltroCalorias.Text))
                        {
                            ingestasFiltro.Add(ingestas[i]);
                        }
                    }
                    ListView1.ItemsSource = ingestasFiltro;
                }
                catch (Exception) {
                    string msg = "Error, los filtros del total de calorias no tienen el formato correcto.";
                    string titulo = "Mi aplicación";
                    MessageBoxButton botones = MessageBoxButton.OK;
                    MessageBoxImage icono = MessageBoxImage.Error;
                    MessageBox.Show(msg, titulo, botones, icono);
                }
            }
            if (FiltroCalorias.Text.Equals("Buscar...") == true && FiltroFecha.Text.Equals("Buscar...") == false)
            {
                for (int i = 0; i < ingestas.Count; i++)
                {
                    if (ingestas[i].Fecha == FiltroFecha.Text)
                    {
                        ingestasFiltro.Add(ingestas[i]);
                    }
                }
                ListView1.ItemsSource = ingestasFiltro;
            }
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            String fecha = Calendario.SelectedDate.ToString().Substring(0, 10);
            FiltroFecha.Text = fecha;
            FiltroFecha.Foreground = Brushes.LightGray;
        }

        private void RestaurarFiltros_Click(object sender, RoutedEventArgs e)
        {
            FiltroCalorias.Text = "Buscar...";
            FiltroCalorias.Foreground = Brushes.DimGray;
            FiltroFecha.Text = "Buscar...";
            FiltroFecha.Foreground = Brushes.DimGray;
            ListView1.ItemsSource = ingestas;
        }
    }
}
