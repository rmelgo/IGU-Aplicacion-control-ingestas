using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.Caching;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Practica_final
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Ingesta> ingestas = new ObservableCollection<Ingesta>();
        private VentanaVisualizarIngestas vvi; 
        private Boolean detalle = false;
        private Boolean sectores = false;
        private Ingesta ingestaSeleccionada;
        private Line[] Guias = new Line[12];
        private Label[] Nombre_guias = new Label[11];
        private Line[] Lineas_ingesta = new Line[6];
        private int ingestas_por_canvas = 10;
        private int posicion = 0;
        private int maximo = 0;

        public MainWindow()
        {
            InitializeComponent();
            ingestas.CollectionChanged += Ingestas_CollectionChanged;
            dibujarEjes();
        }

        private void dibujarEjes()
        {
            for (int i = 0; i < Guias.Length - 1; i++)
            {
                Guias[i] = new Line();
                Guias[i].X1 = 30;
                Guias[i].Y1 = lienzoGrafico.ActualHeight * (Guias.Length - 1 - i) / 12;
                Guias[i].X2 = lienzoGrafico.ActualWidth - 30;
                Guias[i].Y2 = lienzoGrafico.ActualHeight * (Guias.Length - 1 - i) / 12;
                Guias[i].Stroke = Brushes.Black;
                Guias[i].StrokeThickness = 0.5;
                lienzoGrafico.Children.Add(Guias[i]);
            }

            Guias[Guias.Length - 1] = new Line();
            Guias[Guias.Length - 1].X1 = 40;
            Guias[Guias.Length - 1].Y1 = lienzoGrafico.ActualHeight * 1 / 12;
            Guias[Guias.Length - 1].X2 = 40;
            Guias[Guias.Length - 1].Y2 = lienzoGrafico.ActualHeight * 11 / 12;
            Guias[Guias.Length - 1].Stroke = Brushes.Black;
            Guias[Guias.Length - 1].StrokeThickness = 1;
            lienzoGrafico.Children.Add(Guias[Guias.Length - 1]);

            for (int i = 0; i < Nombre_guias.Length; i++)
            {
                Nombre_guias[i] = new Label();
                Nombre_guias[i].Content = buscarDietaMaximaRedondeadaCentena(ingestas_por_canvas * posicion, ingestas_por_canvas * (posicion + 1)) * i / 10;
                Canvas.SetLeft(Nombre_guias[i], 0);
                Canvas.SetTop(Nombre_guias[i], (lienzoGrafico.ActualHeight * (Nombre_guias.Length - i) / 12) - 12);
                lienzoGrafico.Children.Add(Nombre_guias[i]);
            }
        }
      
        private void dibujarIngesta(Ingesta ing, bool animacion)
        {
            int i;
            for (i = 0; i < ingestas.Count; i++) 
            {
                if (ingestas[i].Equals(ing))
                {
                    break;
                }
            }

            int n = i - ingestas_por_canvas * posicion;
            int coordenadasx_inicio = 100;
            int salto = (int)((lienzoGrafico.ActualWidth - coordenadasx_inicio - 30) / ingestas_por_canvas);

            Label fecha_ingesta = new Label();
            fecha_ingesta.Content = ing.Fecha;
            fecha_ingesta.FontSize = 10;
            Canvas.SetLeft(fecha_ingesta, 70 + salto * n);
            Canvas.SetTop(fecha_ingesta, lienzoGrafico.ActualHeight * 11 / 12);
            lienzoGrafico.Children.Add(fecha_ingesta);


            for (int j = 0; j < ingestas[i].ListaDetallesIngestas.Count; j++) {
                Lineas_ingesta[j] = new Line();
                Lineas_ingesta[j].Stroke = ingestas[i].ListaDetallesIngestas[j].Color;
                Lineas_ingesta[j].StrokeThickness = (lienzoGrafico.ActualWidth / ingestas_por_canvas) / 3;
                if (j == 0)
                {
                    Lineas_ingesta[j].X1 = coordenadasx_inicio + n * salto;
                    Lineas_ingesta[j].Y1 = lienzoGrafico.ActualHeight * 11 / 12;
                    Lineas_ingesta[j].X2 = coordenadasx_inicio + n * salto;
                    Lineas_ingesta[j].Y2 = (lienzoGrafico.ActualHeight * 11 / 12) - ((lienzoGrafico.ActualHeight * 11 / 12) - (lienzoGrafico.ActualHeight * 1 / 12)) * ingestas[i].ListaDetallesIngestas[j].Calorias / buscarDietaMaximaRedondeadaCentena(ingestas_por_canvas * posicion, ingestas_por_canvas * (posicion + 1));
                }     
                else
                {
                    Lineas_ingesta[j].X1 = coordenadasx_inicio + n * salto;
                    Lineas_ingesta[j].Y1 = Lineas_ingesta[j - 1].Y2;
                    Lineas_ingesta[j].X2 = coordenadasx_inicio + n * salto;
                    Lineas_ingesta[j].Y2 = Lineas_ingesta[j - 1].Y2 - ((lienzoGrafico.ActualHeight * 11 / 12) - (lienzoGrafico.ActualHeight * 1 / 12)) * ingestas[i].ListaDetallesIngestas[j].Calorias / buscarDietaMaximaRedondeadaCentena(ingestas_por_canvas * posicion, ingestas_por_canvas * (posicion + 1));
                }
                if (animacion)
                {
                    this.RegisterName("Linea" + ingestas[i].ListaDetallesIngestas[j].Comida + i, Lineas_ingesta[j]);

                    DoubleAnimation myDoubleAnimation = new DoubleAnimation();
                    myDoubleAnimation.From = 0;
                    myDoubleAnimation.To = 1;
                    myDoubleAnimation.Duration = new
                    Duration(TimeSpan.FromSeconds(0.5));
                    myDoubleAnimation.AutoReverse = false;

                    Storyboard myStoryboard = new Storyboard();
                    myStoryboard.Children.Add(myDoubleAnimation);
                    Storyboard.SetTargetName(myDoubleAnimation, "Linea" + ingestas[i].ListaDetallesIngestas[j].Comida + i);
                    Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Line.OpacityProperty));

                    myStoryboard.Begin(this);

                    lienzoGrafico.Children.Add(Lineas_ingesta[j]);

                    this.UnregisterName("Linea" + ingestas[i].ListaDetallesIngestas[j].Comida + i);
                }
                else
                {
                    lienzoGrafico.Children.Add(Lineas_ingesta[j]);
                }
            }

            for (int j = 0; j < Nombre_guias.Length; j++)
            {
                Nombre_guias[j].Content = buscarDietaMaximaRedondeadaCentena(ingestas_por_canvas * posicion, ingestas_por_canvas * (posicion + 1)) * j / 10;
            }
        }

        private void Ingestas_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            int j;
            if (e.OldItems != null) 
            {
                foreach (Ingesta i in e.OldItems)
                {
                    BotonVolverGraficoPrincipal.Visibility = Visibility.Hidden;
                    RectaguloVolverPrincipal.Visibility = Visibility.Hidden;
                    BotonVerGraficoSectores.Visibility = Visibility.Hidden;
                    RectaguloGraficoSectores.Visibility = Visibility.Hidden;
                    lienzoGrafico.Children.RemoveRange(23, lienzoGrafico.Children.Count - 1);

                    if (sectores)
                    {
                        lienzoGrafico.Children.Clear();
                        dibujarEjes();
                        sectores = false;
                    }
                    detalle = false;

                    maximo = (int)((ingestas.Count - 1) / ingestas_por_canvas);
                    if (maximo < posicion)
                    {
                        moverIzquierda();
                    }
                    else if (posicion == maximo)
                    {
                        for (int n = ingestas_por_canvas * posicion; n < ingestas.Count; n++)
                        {
                            dibujarIngesta(ingestas[n], true);
                        }
                    }
                    else
                    {
                        for (int n = ingestas_por_canvas * posicion; n < ingestas_por_canvas * (posicion + 1); n++)
                        {
                            dibujarIngesta(ingestas[n], true);
                        }
                    }
                    if (posicion != 0)
                    {
                        Boton_izquierda.IsEnabled = true;
                    }
                    if (posicion != maximo)
                    {
                        Boton_derecha.IsEnabled = true;
                    }
                }
            }
            if (e.NewItems != null)
            {
                foreach (Ingesta i in e.NewItems)
                {
                    i.PropertyChanged += Ingesta_PropertyChanged;
                    maximo = (int)((ingestas.Count - 1) / ingestas_por_canvas);
                    if (posicion == maximo)
                    {
                        Boton_derecha.IsEnabled = false;
                    }
                    else
                    {
                        Boton_derecha.IsEnabled = true;
                    }
                    if (posicion == 0)
                    {
                        Boton_izquierda.IsEnabled = false;
                    }
                    else
                    {
                        Boton_izquierda.IsEnabled = true;
                    }
                    if (buscarDietaMaximaRedondeadaCentena(ingestas_por_canvas * posicion, ingestas_por_canvas * (posicion + 1)) > int.Parse(Nombre_guias[10].Content.ToString()))
                    {
                        lienzoGrafico.Children.RemoveRange(23, lienzoGrafico.Children.Count - 1);

                        if (posicion == maximo)
                        {
                            for (int n = ingestas_por_canvas * posicion; n < ingestas.Count; n++)
                            {
                                dibujarIngesta(ingestas[n], true);
                            }
                        }
                        else
                        {
                            for (int n = ingestas_por_canvas * posicion; n < ingestas_por_canvas * (posicion + 1); n++)
                            {
                                dibujarIngesta(ingestas[n], true);
                            }
                        }
                    }
                    else
                    {
                        for (j = 0; j < ingestas.Count; j++)
                        {
                            if (ingestas[j].Equals(i))
                            {
                                break;
                            }
                        }

                        if (j >= ingestas_por_canvas * posicion && j < ingestas_por_canvas * (posicion + 1))
                        {
                            dibujarIngesta(i, true);
                        }
                    }
                }
            }
        }

        private void Ingesta_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Console.WriteLine("KJHBDSFH");
            if (sectores)
            {
                lienzoGrafico.Children.Clear();
                dibujarGraficoSectores(true);
            }
            else
            {
                lienzoGrafico.Children.RemoveRange(23, lienzoGrafico.Children.Count - 1);
                dibujarDetalleIngesta(true);
            }
        }

        private void BotonIngesta_Click(object sender, RoutedEventArgs e)
        {
            VentanaAgregarIngesta vai = new VentanaAgregarIngesta();
            vai.Owner = this; 

            vai.ShowDialog();
            if (vai.DialogResult == true)
            {
                Boolean ingesta_correcta = true;
                for (int i = 0; i < ingestas.Count; i++)
                {
                    if (ingestas[i].Fecha.Equals(vai.CajaFecha.Text)) {
                        ingesta_correcta = false;
                        break;
                    }
                }

                if (ingesta_correcta && vai.CajaFecha.Text != "")
                {
                    try
                    {
                        Ingesta temp = new Ingesta();
                        temp.Fecha = vai.CajaFecha.Text;
                        if (vai.CajaCaloriasDesayuno.Text != "Calorias desayuno")
                        {
                            temp.CaloriasDesayuno = Int32.Parse(vai.CajaCaloriasDesayuno.Text);
                        }
                        else
                        {
                            temp.CaloriasDesayuno = 0;
                        }

                        if (vai.CajaCaloriasAperitivo.Text != "Calorias aperitivo")
                        {
                            temp.CaloriasAperitivo = Int32.Parse(vai.CajaCaloriasAperitivo.Text);
                        }
                        else
                        {
                            temp.CaloriasAperitivo = 0;
                        }

                        if (vai.CajaCaloriasComida.Text != "Calorias comida")
                        {
                            temp.CaloriasComida = Int32.Parse(vai.CajaCaloriasComida.Text);
                        }
                        else
                        {
                            temp.CaloriasComida = 0;
                        }

                        if (vai.CajaCaloriasMerienda.Text != "Calorias merienda")
                        {
                            temp.CaloriasMerienda = Int32.Parse(vai.CajaCaloriasMerienda.Text);
                        }
                        else
                        {
                            temp.CaloriasMerienda = 0;
                        }

                        if (vai.CajaCaloriasCena.Text != "Calorias cena")
                        {
                            temp.CaloriasCena = Int32.Parse(vai.CajaCaloriasCena.Text);
                        }
                        else
                        {
                            temp.CaloriasCena = 0;
                        }

                        if (vai.CajaCaloriasOtros.Text != "Calorias otros")
                        {
                            temp.CaloriasOtros = Int32.Parse(vai.CajaCaloriasOtros.Text);
                        }
                        else
                        {
                            temp.CaloriasOtros = 0;
                        }

                        ingestas.Add(temp);
                    }
                    catch (Exception)
                    {
                        string msg = "Error, los datos de la ingesta no tienen el formato correcto.\nLa ingesta no se ha podido añadir correctamente";
                        string titulo = "Mi aplicación";
                        MessageBoxButton botones = MessageBoxButton.OK;
                        MessageBoxImage icono = MessageBoxImage.Error;
                        MessageBox.Show(msg, titulo, botones, icono);
                    }
                }
                else if (vai.CajaFecha.Text == "")
                {
                    string msg = "Error, no se pueden añadir ingestas sin fecha.\nLa ingesta no se ha podido guardar correctamente";
                    string titulo = "Mi aplicación";
                    MessageBoxButton botones = MessageBoxButton.OK;
                    MessageBoxImage icono = MessageBoxImage.Error;
                    MessageBox.Show(msg, titulo, botones, icono);
                }
                else
                {
                    string msg = "Error, ya existe una ingesta con la fecha " + vai.CajaFecha.Text + ".\nLa ingesta no se ha podido guardar correctamente";
                    string titulo = "Mi aplicación";
                    MessageBoxButton botones = MessageBoxButton.OK;
                    MessageBoxImage icono = MessageBoxImage.Error;
                    MessageBox.Show(msg, titulo, botones, icono);
                }
            }
        }
     
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (vvi != null)
            {
                return;
            }
            vvi = new VentanaVisualizarIngestas(ingestas);
            vvi.Owner = this;

            vvi.Closed += Cdnm_Closed;
            vvi.SeleccionItem += Vvi_SeleccionItem;

            vvi.Show();
        }

        private void Cdnm_Closed(object sender, EventArgs e)
        {
            vvi = null;
        }

        private void Vvi_SeleccionItem(object sender, ItemSeleccionadoEventsArgs e)
        {
            ingestaSeleccionada = e.IngestaSeleccionada;
            detalle = true;
            BotonVolverGraficoPrincipal.Visibility = Visibility.Visible;
            RectaguloVolverPrincipal.Visibility = Visibility.Visible;
            Boton_derecha.IsEnabled = false;
            Boton_izquierda.IsEnabled = false;
            lienzoGrafico.Children.RemoveRange(23, lienzoGrafico.Children.Count - 1); 

            if (sectores)
            {
                lienzoGrafico.Children.Clear();
                detalle = false;
                dibujarGraficoSectores(true);
            }
            else
            {
                detalle = true;
                BotonVerGraficoSectores.Content = "Ver el grafico de sectores";
                BotonVerGraficoSectores.Visibility = Visibility.Visible;
                RectaguloGraficoSectores.Visibility = Visibility.Visible;

                dibujarDetalleIngesta(true);               
            }
        }

        private void dibujarDetalleIngesta(bool animacion)
        {
            int coordenadasx_inicio = 100;
            double salto_detalle = (lienzoGrafico.ActualWidth - coordenadasx_inicio - 30) / ingestaSeleccionada.ListaDetallesIngestas.Count;

            for (int i = 0; i < ingestaSeleccionada.ListaDetallesIngestas.Count; i++)
            {
                Label tipo_ingesta = new Label();
                tipo_ingesta.Content = ingestaSeleccionada.ListaDetallesIngestas[i].Comida;
                tipo_ingesta.FontSize = 10;
                Canvas.SetLeft(tipo_ingesta, coordenadasx_inicio - 30 + salto_detalle * i);
                Canvas.SetTop(tipo_ingesta, lienzoGrafico.ActualHeight * 11 / 12);
                lienzoGrafico.Children.Add(tipo_ingesta);

                Line linea = new Line();
                linea.Stroke = ingestaSeleccionada.ListaDetallesIngestas[i].Color;
                linea.StrokeThickness = (lienzoGrafico.ActualWidth / ingestaSeleccionada.ListaDetallesIngestas.Count) / 3;
                linea.X1 = coordenadasx_inicio + i * salto_detalle;
                linea.Y1 = lienzoGrafico.ActualHeight * 11 / 12;
                linea.X2 = coordenadasx_inicio + i * salto_detalle;
                linea.Y2 = (lienzoGrafico.ActualHeight * 11 / 12) - ((lienzoGrafico.ActualHeight * 11 / 12) - (lienzoGrafico.ActualHeight * 1 / 12)) * ingestaSeleccionada.ListaDetallesIngestas[i].Calorias / buscarIngestaMaximaRedondeadaCentena(ingestaSeleccionada);

                if (animacion)
                {
                    this.RegisterName("Linea" + ingestaSeleccionada.ListaDetallesIngestas[i].Comida, linea);
                    DoubleAnimation myDoubleAnimation2 = new DoubleAnimation();
                    myDoubleAnimation2.From = lienzoGrafico.ActualHeight * 11 / 12;
                    myDoubleAnimation2.To = (lienzoGrafico.ActualHeight * 11 / 12) - ((lienzoGrafico.ActualHeight * 11 / 12) - (lienzoGrafico.ActualHeight * 1 / 12)) * ingestaSeleccionada.ListaDetallesIngestas[i].Calorias / buscarIngestaMaximaRedondeadaCentena(ingestaSeleccionada);
                    myDoubleAnimation2.Duration = new Duration(TimeSpan.FromSeconds(0.5));
                    myDoubleAnimation2.AutoReverse = false;

                    Storyboard myStoryboard = new Storyboard();
                    myStoryboard.Children.Add(myDoubleAnimation2);
                    Storyboard.SetTargetName(myDoubleAnimation2, "Linea" + ingestaSeleccionada.ListaDetallesIngestas[i].Comida);
                    Storyboard.SetTargetProperty(myDoubleAnimation2, new PropertyPath(Line.Y2Property));

                    myStoryboard.Begin(this);

                    lienzoGrafico.Children.Add(linea);
                    this.UnregisterName("Linea" + ingestaSeleccionada.ListaDetallesIngestas[i].Comida);
                }
                else
                {
                    lienzoGrafico.Children.Add(linea);
                }
            }

            for (int j = 0; j < Nombre_guias.Length; j++)
            {
                Nombre_guias[j].Content = buscarIngestaMaximaRedondeadaCentena(ingestaSeleccionada) * j / 10;
            }
        }

        private void lienzoGrafico_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            lienzoGrafico.Children.Clear();

            dibujarEjes();

            if (sectores)
            {
                dibujarGraficoSectores(false);
            }
            else if (detalle)
            {
                dibujarDetalleIngesta(false);
            }
            else
            {
                maximo = (int)((ingestas.Count - 1) / ingestas_por_canvas);

                if (maximo == posicion)
                {
                    for (int i = ingestas_por_canvas * posicion; i < ingestas.Count; i++)
                    {
                        dibujarIngesta(ingestas[i], false);
                    }
                }
                else
                {
                    for (int i = ingestas_por_canvas * posicion; i < ingestas_por_canvas * (posicion + 1); i++)
                    {
                        dibujarIngesta(ingestas[i], false);
                    }
                }              
            }
        }

        private void BotonVolverGraficoPrincipal_Click(object sender, RoutedEventArgs e)
        {
            BotonVolverGraficoPrincipal.Visibility = Visibility.Hidden;
            RectaguloVolverPrincipal.Visibility = Visibility.Hidden;
            BotonVerGraficoSectores.Visibility = Visibility.Hidden;
            RectaguloGraficoSectores.Visibility = Visibility.Hidden;

            if (sectores)
            {
                lienzoGrafico.Children.Clear();
                dibujarEjes();
            }
            else
            {
                lienzoGrafico.Children.RemoveRange(23, lienzoGrafico.Children.Count - 1); 
            }

            detalle = false;
            sectores = false;

            if (posicion == maximo)
            {
                for (int n = ingestas_por_canvas * posicion; n < ingestas.Count; n++)
                {
                    dibujarIngesta(ingestas[n], true);
                }
            }
            else
            {
                for (int n = ingestas_por_canvas * posicion; n < ingestas_por_canvas * (posicion + 1); n++)
                {
                    dibujarIngesta(ingestas[n], true);
                }
            }

            if (posicion != 0)
            {
                Boton_izquierda.IsEnabled = true;
            }
            if (posicion != maximo)
            {
                Boton_derecha.IsEnabled = true;
            }
        }

        public int buscarDietaMaximaRedondeadaCentena(int ingesta_minima, int ingesta_maxima)
        {
            int maximo = 0;
            if (ingesta_maxima > ingestas.Count)
            {
                for (int i = ingesta_minima; i < ingestas.Count; i++)
                {
                    if (ingestas[i].TotalCalorias > maximo)
                    {
                        maximo = ingestas[i].TotalCalorias;
                    }
                }
            }
            else
            {
                for (int i = ingesta_minima; i < ingesta_maxima; i++)
                {
                    if (ingestas[i].TotalCalorias > maximo)
                    {
                        maximo = ingestas[i].TotalCalorias;
                    }
                }
            }

            while (maximo % 100 != 0 || maximo == 0) 
            {
                maximo = maximo + 1;
            }
            return maximo;
        }

        private int buscarIngestaMaximaRedondeadaCentena(Ingesta ingestaSeleccionada)
        {
            int maximo = 0;
            for (int i = 0; i < ingestaSeleccionada.ListaDetallesIngestas.Count; i++)
            {
                if (ingestaSeleccionada.ListaDetallesIngestas[i].Calorias > maximo)
                {
                    maximo = ingestaSeleccionada.ListaDetallesIngestas[i].Calorias;
                }
            }

            while (maximo % 100 != 0 || maximo == 0)
            {
                maximo = maximo + 1;
            }
            return maximo;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String nombre_fichero = System.String.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                nombre_fichero = openFileDialog.FileName;

                String line;
                String[] vector = new String[7];
                try
                {
                    StreamReader sr = new StreamReader(nombre_fichero);
                    ingestas.Clear();
                    lienzoGrafico.Children.RemoveRange(23, lienzoGrafico.Children.Count - 1);
                    line = sr.ReadLine();
                    while (line != null)
                    {
                        Ingesta temp = new Ingesta();
                        Console.WriteLine(line);
                        vector = line.Split(' ');
                        temp.Fecha = vector[0];
                        temp.CaloriasDesayuno = Int32.Parse(vector[1]);
                        temp.CaloriasAperitivo = Int32.Parse(vector[2]);
                        temp.CaloriasComida = Int32.Parse(vector[3]);
                        temp.CaloriasMerienda = Int32.Parse(vector[4]);
                        temp.CaloriasCena = Int32.Parse(vector[5]);
                        temp.CaloriasOtros = Int32.Parse(vector[6]);

                        Boolean ingesta_correcta = true;
                        for (int i = 0; i < ingestas.Count; i++)
                        {
                            if (ingestas[i].Fecha.Equals(temp.Fecha))
                            {
                                ingesta_correcta = false;
                                break;
                            }
                        }

                        if (ingesta_correcta)
                        {
                            ingestas.Add(temp);
                        }
                        else
                        {
                            string msg = "Error, ya existe una ingesta con la fecha " + temp.Fecha + ".\nLa ingesta no se ha podido guardar correctamente";
                            string titulo = "Mi aplicación";
                            MessageBoxButton botones = MessageBoxButton.OK;
                            MessageBoxImage icono = MessageBoxImage.Error;
                            MessageBox.Show(msg, titulo, botones, icono);
                        }
                        line = sr.ReadLine();
                    }
                    sr.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                    string msg = "Error en la lectura de datos \nEl fichero no tiene el formato adecuado";
                    string titulo = "Mi aplicación";
                    MessageBoxButton botones = MessageBoxButton.OK;
                    MessageBoxImage icono = MessageBoxImage.Error;
                    MessageBox.Show(msg, titulo, botones, icono);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            String nombre_fichero = System.String.Empty;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                nombre_fichero = saveFileDialog.FileName;

                String[] line = new String[7];

                if (nombre_fichero.EndsWith(".txt"))
                {
                    try
                    {
                        StreamWriter sw = new StreamWriter(nombre_fichero);
                        for (int i = 0; i < ingestas.Count; i++)
                        {
                            sw.WriteLine(ingestas[i].Fecha + " " + ingestas[i].CaloriasDesayuno + " " + ingestas[i].CaloriasAperitivo + " " + ingestas[i].CaloriasComida + " " + ingestas[i].CaloriasMerienda + " " + ingestas[i].CaloriasCena + " " + ingestas[i].CaloriasOtros);
                        }
                        sw.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception: " + ex.Message);
                        string msg = "Error en el guardado de datos";
                        string titulo = "Mi aplicación";
                        MessageBoxButton botones = MessageBoxButton.OK;
                        MessageBoxImage icono = MessageBoxImage.Error;
                        MessageBox.Show(msg, titulo, botones, icono);
                    }
                    finally
                    {
                        string msg = "Datos guardados con exito";
                        string titulo = "Mi aplicación";
                        MessageBoxButton botones = MessageBoxButton.OK;
                        MessageBoxImage icono = MessageBoxImage.Information;
                        MessageBox.Show(msg, titulo, botones, icono);
                    }
                }
                else
                {
                    string msg = "Error, el archivo escogido no es un archivo de texto";
                    string titulo = "Mi aplicación";
                    MessageBoxButton botones = MessageBoxButton.OK;
                    MessageBoxImage icono = MessageBoxImage.Error;
                    MessageBox.Show(msg, titulo, botones, icono);
                }
            }
        }

        private void BotonVerGraficoSectores_Click(object sender, RoutedEventArgs e)
        {
            if (sectores == false)
            {
                sectores = true;
                BotonVerGraficoSectores.Content = "Ver el grafico de barras";
                dibujarGraficoSectores(true);
            }
            else
            {
                BotonVerGraficoSectores.Content = "Ver el grafico de sectores";

                sectores = false;

                lienzoGrafico.Children.Clear();
                dibujarEjes();
                dibujarDetalleIngesta(true);
            }
        }

        public void dibujarGraficoSectores(Boolean animacion)
        {
            lienzoGrafico.Children.Clear();
            
            int numpuntos;
            double ancho, alto;
            ancho = lienzoGrafico.ActualWidth;
            alto = lienzoGrafico.ActualHeight;

            double xreal, xrealmin, xrealmax, xpantmin, xpantmax, yrealmin, yrealmax, ypantmin, ypantmax;
            xrealmin = -3;
            xrealmax = 3;
            xpantmin = Math.Ceiling((lienzoGrafico.ActualWidth / 2) - (lienzoGrafico.ActualHeight / 3));
            xpantmax = Math.Ceiling(lienzoGrafico.ActualWidth / 2 + (lienzoGrafico.ActualHeight / 3));
            yrealmin = -3;
            yrealmax = 3;
            ypantmin = Math.Ceiling(lienzoGrafico.ActualHeight / 2 - (lienzoGrafico.ActualHeight / 3));
            ypantmax = Math.Ceiling(lienzoGrafico.ActualHeight / 2 + (lienzoGrafico.ActualHeight / 3));
            numpuntos = (((int)(xpantmax - xpantmin)) * 40) + 2; 

            Polyline polilinea = new Polyline();
            polilinea.Stroke = Brushes.Black;
            Point[] puntos = new Point[numpuntos];
            int indice_puntos = 0;
            double n = (int)xpantmin;
            while (n <= (int)xpantmax)
            {
                xreal = (xrealmax - xrealmin) * ((n - xpantmin) / (xpantmax - xpantmin)) + xrealmin;
                puntos[indice_puntos].X = (xpantmax - xpantmin) * ((xreal - xrealmin) / (xrealmax - xrealmin)) + xpantmin;
                puntos[indice_puntos].Y = (ypantmin - ypantmax) * ((Math.Sqrt(9 - xreal * xreal) - yrealmin) / (yrealmax - yrealmin)) + ypantmax;
                indice_puntos = indice_puntos + 1;
                n = n + 0.05;
                n = Math.Round(n, 2);
            }
            n = (int)xpantmin;
            while (n <= (int)xpantmax)
            {
                xreal = (xrealmax - xrealmin) * ((n - xpantmin) / (xpantmax - xpantmin)) + xrealmin;
                puntos[indice_puntos].X = (xpantmax + xpantmin) - ((xpantmax - xpantmin) * ((xreal - xrealmin) / (xrealmax - xrealmin)) + xpantmin);
                puntos[indice_puntos].Y = (ypantmin - ypantmax) * ((-Math.Sqrt(9 - xreal * xreal) - yrealmin) / (yrealmax - yrealmin)) + ypantmax;
                indice_puntos = indice_puntos + 1;
                n = n + 0.05;
                n = Math.Round(n, 2);
            }
            polilinea.Points = new PointCollection(puntos);
            lienzoGrafico.Children.Add(polilinea); 


            int indice = 0;
            int j;

            double modulo_circulo = 0;
            for (int i = 0; i < puntos.Length - 1; i++)
            {
                modulo_circulo = modulo_circulo + Math.Sqrt(((puntos[i + 1].X - puntos[i].X) * (puntos[i + 1].X - puntos[i].X)) + ((puntos[i + 1].Y - puntos[i].Y) * (puntos[i + 1].Y - puntos[i].Y)));
            }
            int[] numpuntosSector = new int[ingestaSeleccionada.ListaDetallesIngestas.Count]; 
            for (int x = 0; x < ingestaSeleccionada.ListaDetallesIngestas.Count; x++)
            {
                Polyline polilineaSector = new Polyline();
                polilineaSector.Stroke = ingestaSeleccionada.ListaDetallesIngestas[x].Color;
                polilineaSector.StrokeThickness = ((lienzoGrafico.ActualHeight / 2) - (lienzoGrafico.ActualHeight / 3)) / 3;
                double distanciaSector = modulo_circulo * ingestaSeleccionada.ListaDetallesIngestas[x].Calorias / ingestaSeleccionada.TotalCalorias;
                numpuntosSector[x] = 0;

                int temp = 0;
                for (int k = 1; k <= x; k++) {
                    temp = temp + numpuntosSector[k - 1];
                }
                for (int i = temp - x; i < puntos.Length - 1; i++)
                {
                    if (distanciaSector <= 0)
                    {
                        break;
                    }
                    distanciaSector = distanciaSector - Math.Sqrt(((puntos[i + 1].X - puntos[i].X) * (puntos[i + 1].X - puntos[i].X)) + ((puntos[i + 1].Y - puntos[i].Y) * (puntos[i + 1].Y - puntos[i].Y)));
                    numpuntosSector[x] = numpuntosSector[x] + 1;
                }
                numpuntosSector[x] = numpuntosSector[x] + 1;


                Point[] puntosSector = new Point[numpuntosSector[x]];
                j = 0;
                if (x != 0)
                {
                    indice = indice - 1;
                }

                for (int i = indice; i < temp + numpuntosSector[x] - x; i++)
                {
                    puntosSector[j] = puntos[i];
                    indice = indice + 1;
                    j = j + 1;
                }
                polilineaSector.Points = new PointCollection(puntosSector);
                if (animacion)
                {
                    this.RegisterName("Linea" + ingestaSeleccionada.ListaDetallesIngestas[x].Comida, polilineaSector);
                    DoubleAnimation myDoubleAnimation2 = new DoubleAnimation();
                    myDoubleAnimation2.From = 0;
                    myDoubleAnimation2.To = ((lienzoGrafico.ActualHeight / 2) - (lienzoGrafico.ActualHeight / 3)) / 3;
                    myDoubleAnimation2.Duration = new Duration(TimeSpan.FromSeconds(1));
                    myDoubleAnimation2.AutoReverse = false;

                    Storyboard myStoryboard = new Storyboard();
                    myStoryboard.Children.Add(myDoubleAnimation2);
                    Storyboard.SetTargetName(myDoubleAnimation2, "Linea" + ingestaSeleccionada.ListaDetallesIngestas[x].Comida);
                    Storyboard.SetTargetProperty(myDoubleAnimation2, new PropertyPath(Polyline.StrokeThicknessProperty));

                    myStoryboard.Begin(this);

                    lienzoGrafico.Children.Add(polilineaSector);
                    this.UnregisterName("Linea" + ingestaSeleccionada.ListaDetallesIngestas[x].Comida);
                }
                else
                {
                    lienzoGrafico.Children.Add(polilineaSector);
                }
            }

            double porcentaje;
            for (int i = 0; i < ingestaSeleccionada.ListaDetallesIngestas.Count; i++)
            {
                Rectangle leyenda = new Rectangle();
                leyenda.Width = 10;
                leyenda.Height = 10;
                leyenda.Fill = ingestaSeleccionada.ListaDetallesIngestas[i].Color;
                Canvas.SetLeft(leyenda, 10);
                Canvas.SetTop(leyenda, 20 * i + 8.5);
                lienzoGrafico.Children.Add(leyenda);

                Label etiqueta = new Label();
                porcentaje = 100.0 * ingestaSeleccionada.ListaDetallesIngestas[i].Calorias / ingestaSeleccionada.TotalCalorias;
                etiqueta.Content = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(ingestaSeleccionada.ListaDetallesIngestas[i].Comida.ToLower()) + " " + porcentaje.ToString("N2") + "%";
                Canvas.SetLeft(etiqueta, 25);
                Canvas.SetTop(etiqueta, 20 * i);
                lienzoGrafico.Children.Add(etiqueta);
            }          
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            String nombre_fichero = System.String.Empty;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "HTML files (*.html)|*.html|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    nombre_fichero = saveFileDialog.FileName;

                    StreamWriter sw = new StreamWriter(nombre_fichero);
                    sw.WriteLine("<!DOCTYPE hmtl>\n"
                            + "<HTML>\n"
                            + "<HEAD>\n"
                            + "<meta charset=\"UTF-8\">\n"
                            + "<H1>Registro ingestas</H1>\n"
                            + "</HEAD>\n"
                            + "<BODY>");
                    sw.WriteLine("<TABLE BORDER=1>\n");

                    String encabezado;

                    encabezado = "<TR><TD>FECHA</TD>";

                    for (int j = 0; j < ingestas[0].ListaDetallesIngestas.Count; j++)
                    {
                        encabezado = encabezado + "<TD>" + ingestas[0].ListaDetallesIngestas[j].Comida + "</TD>";
                    }

                    encabezado = encabezado + "<TD>TOTAL CALORIAS</TD></TR>";

                    sw.WriteLine(encabezado); 

                    for (int i = 0; i < ingestas.Count; i++)
                    {
                        String fila = String.Format("<TR><TD>" + ingestas[i].Fecha + "</TD>");

                        for (int j = 0; j < ingestas[i].ListaDetallesIngestas.Count; j++)
                        {
                            fila = fila + String.Format("<TD>" + ingestas[i].ListaDetallesIngestas[j].Calorias + "</TD>");
                        }

                        fila = fila + String.Format("<TD>" + ingestas[i].TotalCalorias + "</TD></TR>");

                        sw.WriteLine(fila);
                    }
                    sw.WriteLine("</TABLE>\n</BODY>\n</HTML>\n");
                    sw.Close();
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Error en la creacion del HTML");
                    string msg = "Error en la creacion del archivo HTML";
                    string titulo = "Mi aplicación";
                    MessageBoxButton botones = MessageBoxButton.OK;
                    MessageBoxImage icono = MessageBoxImage.Error;
                    MessageBox.Show(msg, titulo, botones, icono);
                }
                finally
                {
                    string msg = "Archivo HTML creado con exito";
                    string titulo = "Mi aplicación";
                    MessageBoxButton botones = MessageBoxButton.OK;
                    MessageBoxImage icono = MessageBoxImage.Information;
                    MessageBox.Show(msg, titulo, botones, icono);
                }
            }
        }

        private void Boton_derecha_Click(object sender, RoutedEventArgs e)
        {
            moverDerecha();
        }

        private void Boton_izquierda_Click(object sender, RoutedEventArgs e)
        {
            moverIzquierda();
        }

        public void moverDerecha()
        {
            posicion = posicion + 1;
            if (posicion == maximo)
            {
                Boton_derecha.IsEnabled = false;

                lienzoGrafico.Children.RemoveRange(23, lienzoGrafico.Children.Count - 1);
                for (int n = ingestas_por_canvas * posicion; n < ingestas.Count; n++)
                {
                    dibujarIngesta(ingestas[n], true);
                }
            }
            else
            {
                lienzoGrafico.Children.RemoveRange(23, lienzoGrafico.Children.Count - 1);
                for (int n = ingestas_por_canvas * posicion; n < ingestas_por_canvas * (posicion + 1); n++)
                {
                    dibujarIngesta(ingestas[n], true);
                }
            }
            if (posicion > 0)
            {
                Boton_izquierda.IsEnabled = true;
            }
        }

        public void moverIzquierda()
        {
            posicion = posicion - 1;
            if (posicion == 0)
            {
                Boton_izquierda.IsEnabled = false;
            }
            if (posicion != maximo)
            {
                Boton_derecha.IsEnabled = true;
            }

            lienzoGrafico.Children.RemoveRange(23, lienzoGrafico.Children.Count - 1);
            for (int n = ingestas_por_canvas * posicion; n < ingestas_por_canvas * (posicion + 1); n++)
            {
                dibujarIngesta(ingestas[n], true);
            }
        }
    }
}