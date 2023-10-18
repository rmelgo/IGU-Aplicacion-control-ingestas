# Simulación del tráfico de un cruce mediante programación concurrente en el entorno UNIX

![Captura inicial](https://github.com/rmelgo/IGU-Aplicacion-control-ingestas/assets/145989723/a0cd2c98-4743-4983-aef5-a2f940079616)

# - Introducción

Proyecto realizado en la asignatura de Interfaces Gráficas de Usuario del grado de Ingenieria Informática de la Universidad de Salamanca. El enunciado del proyecto se encuentra subido en el repositorio en un archivo PDF llamado *ENUNCIADO_Práctica_2021.pdf*.
  
El principal objetivo de este proyecto es la realización de una aplicación en el entorno de WPF que permita almacenar y controlar el conjunto de calorias consumida por una persona.
De esta manera, el objetivo es diseñar una interfaz que permita al usuario introducir las calorias de las distintas ingestas de comida que realizan una persona a lo largo de un día determinado y mostrar esa información en distintos gráficos.

# - Comentarios sobre el entorno de ejecución y el material adjuntado

Para ejecutar este programa, se requerirá de una distribución del Sistema Operativo **Windows**.  
  
La aplicación ha sido desarrollada a través de ***Visual Studio 2019***.    

En este repositorio, se van a adjuntar 2 carpetas principales:

- Una carpeta llamada **Practica_final** que contiene el proyecto completo, el cual puede ser abierto a traves de ***Visual Studio 2019*** para observar el código interno y realizar cambios si es necesario.
- Una carpeta llamada **Bin** que contiene los siguientes ficheros:
  
  - Un fichero llamado ***Practica_final.exe*** el cual se trata de la aplicación final, lista para ser usada.
  - Un fichero llamado ***ingestas.txt*** que contiene información sobre varias ingestas realizadas por una persona. Se utilizará para probar distintas funcionalidades de la aplicación.
  - Un fichero llamado ***muchasIngestas.txt*** que contiene información sobre muchas ingestas realizadas por una persona. Se utilizará para probar distintas funcionalidades de la aplicación.
  - Un fichero llamado ***datos.html*** que contiene una tabla con datos de distintas ingestas. Este fichero ha sido generado a través de la aplicación, a través de la funcionalidad HTML que se explicará mas adelante.
 
Por otro lado, también se adjunta un documento PDF llamado **Memoria_Ejercicio_Práctico.pdf** que contiene un manual del usuario donde se explica brevemente las funcionalidades de la aplicación y un manual del programador donde se explican las distintas clases utilizadas, su función y los aspectos mas relevantes de la implementación del proyecto.

# - Funcionalidades de la aplicación

## Pantalla principal

Al abrir el fichero ***Practica_final.exe***, inicialmente se presentará una ventana similar a la que se presenta en la siguiente imagen:

![Ejemplo ejecucion 1](https://github.com/rmelgo/IGU-Aplicacion-control-ingestas/assets/145989723/1105c553-fe2c-4ed2-bedb-d7d777f67d62)

La ventana principal se agrupa en **2 secciones principales**:

- Por un lado, existe una sección grande de color salmón donde se representarán gráficamente (a través de un gráfico de barras) los valores de las ingestas almacenadas. Esta sección se encuentra inicialmente vacía ya que no se han almacenado ingestas en la aplicación. 

- Por otro lado, existe una barra lateral con 5 botones que implementan 5 funcionalidades básicas. A continuación se explicarán brevemente cada una de estas 5 funcionalidades:

  - **Añadir ingesta**: Esta funcionalidad permite al usuario añadir el valor de una nueva ingesta. Se solicitará al usuario la fecha de la ingesta y los valores calóricos de cada una de las comidas realizadas durante ese día.
  - **Ver detalle ingesta**: Esta funcionalidad permite al usuario ver con mayor detalle la información de cada una de las ingestas que se encuentran almacenadas en la aplicación. Dentro de este apartado el usuario podra utilizar filtros para la busqueda de ingestas, así como eliminar un ingesta o modificar los valores caloricos de una ingesta determinada.
  - **Cargar datos**: Esta funcionalidad permite cargar datos de una serie de ingestas, los cuales deben estar almacenados en un fichero de texto siguiendo un formato determinado.
  - **Guardar datos**: Esta funcionalidad permite guardar los datos de las ingestas almacenados en la aplicación en un fichero de texto. El formato en el que se guarden las ingestas será el mismo que maneja la aplicación en el cargado de ingestas.
  - **HTML**: Esta funcionalidad permite guardar los datos de las ingestas almacenados en la aplicación en un fichero HTML. Similar a la funcionalidad anterior pero los datos se agrupan en una tabla HTML.
 
A continuación se describirá de manera mas detallada cada una de estas funcionalidades de la aplicación.


