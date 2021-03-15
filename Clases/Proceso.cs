using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace PoorLamport.Clases
{
    public class Proceso
    {
        public int Id { get; set; }
        public int Tiempo { get; set; } = 0;
        public ObservableCollection<Mensaje> MensajesRecibidos { get; set; } = new ObservableCollection<Mensaje>();
        public List<Mensaje> MensajesEnEspera { get; set; } = new List<Mensaje>();

        public Proceso(int id)
        {
            this.Id = id;
        }

        public bool RecibirMensaje(Mensaje mensaje)
        {
            bool mensajeFueRecibido = false;

            if (mensaje.Tiempo <= this.Tiempo)
            {
                int tiempoMaximo = Math.Max(mensaje.Tiempo, Tiempo);
                Tiempo = tiempoMaximo + 1;
                MensajesRecibidos.Add(mensaje);

                mensajeFueRecibido = true;
                VerificarMensajesEnEspera(); 
            }
            else
            {
                MensajesEnEspera.Add(mensaje);
            }

            return mensajeFueRecibido;
        }

        private void VerificarMensajesEnEspera()
        {
            if (MensajesEnEspera.Count > 0)
            {
                foreach (Mensaje mensajeEnEspera in MensajesEnEspera)
                {
                    if (mensajeEnEspera.Tiempo <= this.Tiempo + 1)
                    {
                        MensajesRecibidos.Add(mensajeEnEspera);
                        MensajesEnEspera.Remove(mensajeEnEspera);

                        break;
                    }
                }
            }
        }

        public void EnviarMensaje(Mensaje mensajeAEnviar, Proceso procesoDestino)
        {
            
            bool fueMensajeRecibido = procesoDestino.RecibirMensaje(mensajeAEnviar);

            if (fueMensajeRecibido)
            {
                Tiempo++;
            }
        }
    }
}
