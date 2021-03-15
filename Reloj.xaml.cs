using PoorLamport.Clases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PoorLamport
{
    /// <summary>
    /// Lógica de interacción para Reloj.xaml
    /// </summary>
    public partial class Reloj : Window
    {
        public ObservableCollection<Proceso> Procesos { get; set; } = new ObservableCollection<Proceso>();
        public ObservableCollection<Mensaje> Mensajes1 { get; set; }
        public Reloj()
        {
            Procesos.Add(new Proceso(1));
            Procesos.Add(new Proceso(2));
            Procesos.Add(new Proceso(3));

            
            InitializeComponent();

            procesoOrigenCombobox.ItemsSource = Procesos;
            procesoDestinoCombobox.ItemsSource = Procesos;

            mensajesProceso1.ItemsSource = Procesos[0].MensajesRecibidos;
            mensajesProceso2.ItemsSource = Procesos[1].MensajesRecibidos;
            mensajesProceso3.ItemsSource = Procesos[2].MensajesRecibidos;

            tiempoProceso1.Text = Procesos[0].Tiempo.ToString();
            tiempoProceso2.Text = Procesos[1].Tiempo.ToString();
            tiempoProceso3.Text = Procesos[2].Tiempo.ToString();
        }

        private void EnviarMensajeAProceso(object sender, RoutedEventArgs e)
        {
            if (procesoOrigenCombobox.SelectedItem != null && procesoDestinoCombobox.SelectedItem != null)
            {
                if (!String.IsNullOrWhiteSpace(mensajeText.Text) && !String.IsNullOrWhiteSpace(tiempoMensajeText.Text))
                {
                    Proceso procesoOrigen = procesoOrigenCombobox.SelectedItem as Proceso;
                    Proceso procesoDestino = procesoDestinoCombobox.SelectedItem as Proceso;

                    if (procesoOrigen.Id != procesoDestino.Id)
                    {
                        Mensaje mensajeAEnviar = new Mensaje
                        {
                            Tiempo = int.Parse(tiempoMensajeText.Text),
                            Contenido = $"Proceso {procesoOrigen.Id}: {mensajeText.Text}"
                        };

                        procesoOrigen.EnviarMensaje(mensajeAEnviar, procesoDestino);

                        ActualizarVentana();
                    }
                    else
                    {
                        MessageBox.Show("El proceso origen tiene que ser diferente al proceso destino.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor ingresa el tiempo del mensaje y su contenido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor selecciona un proceso origen y un proceso destino.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ActualizarVentana()
        {
            procesoOrigenCombobox.SelectedItem = null;
            procesoDestinoCombobox.SelectedItem = null;
            tiempoMensajeText.Text = "0";
            mensajeText.Text = "";
            tiempoProceso1.Text = Procesos[0].Tiempo.ToString();
            tiempoProceso2.Text = Procesos[1].Tiempo.ToString();
            tiempoProceso3.Text = Procesos[2].Tiempo.ToString();
        }
    }
}
