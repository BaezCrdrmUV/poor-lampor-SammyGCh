# poor-lampor-SammyGCh
poor-lampor-SammyGCh created by GitHub Classroom

El programa es una simulación del envío y ordenamiento de mensajes que utiliza el [ordenamiento lógico de Lamport](https://es.wikipedia.org/wiki/Tiempos_l%C3%B3gicos_de_Lamport#:~:text=El%20algoritmo%20de%20los%20tiempos,computaci%C3%B3n%20m%C3%A1s%20relevantes%2C%20Leslie%20Lamport.).

La aplicación está desarrollada en Windows Presentation Foundation en .NET. Es importante remarcar que esta aplicación no realiza envío de mensajes a través de la red.

Para esto se utilizó la clase `Proceso.cs` donde se implementa la lógica para envíar y recibir mensajes. Para esto último, se realizó la clase `Mensaje.cs` donde
simplemente se hace uso de sus propiedades públicas.

## Funcionamiento del programa

Para el envío de un mensaje es necesario específicar el Proceso Origen y el Proceso Destino, los cuales se seleccionan de los ComboBox correspondientes. Posteriormente,
se especifica el tiempo del mensaje y el contenido del mensaje, después se selecciona el botón "Enviar". Con esto, el programa verifica los tiempos del mensaje con el 
del proceso destino y actualiza su historial de mensajes, si es que es necesario.
