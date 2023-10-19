# Aplicación de escritorio en Windows par la gestión de las calorias ingeridas por una persona

<p align="center">
  <img src="https://github.com/rmelgo/IGU-Aplicacion-control-ingestas/assets/145989723/4445c3ad-21bf-4cd1-a223-890f9064c23b">
</p>

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

## Añadir ingestas

Para añadir una nueva ingesta, el usuario debe hacer click en el botón ***Añadir ingesta*** que se encuentra en la parte izquierda de la ventana principal. Al pulsar este botón, se desplegará una ventana con el siguiente aspecto:

<p align="center">
  <img src="https://github.com/rmelgo/IGU-Aplicacion-control-ingestas/assets/145989723/c6193589-805e-4de9-bd66-f24a1b6c6b3b">
</p>

### Estructura y funcionamiento de la nueva ventana

En esta nueva ventana, se distinguen 2 secciones:

- Una sección en la parte izquierda en la que el usuario introducirá la fecha de la ingesta que desea añadir
- Una sección en la parte derecha en la que el usuario introducirá las calorias consumidas en cada una de las comidas del día

Para añadir la fecha, el usuario puede introducirla directamente en el recuadro blanco o bien puede desplazarse por el calendario interactivo y seleccionar la fecha correspondiente.

Cada ingesta esta formada por 6 comidas (*Desayuno*, *Aperitivo*, *Comida*, *Merienda*, *Cena* y *Otros*). Si el usuario no introduce ningun valor para alguna de estas comidas, la aplicación considerará que las calorias ingeridas para esa determinada comida es de 0.

Una vez completada toda la información sobre una ingesta, para añadir definitivamente la ingesta, el usuario una vez introduce los datos correspondientes pulsará el botón de *"Aceptar"*. Si por alguna razón, el usuario quiere cancelar el proceso de añadir la ingesta puede pulsar el botón de *"Cancelar"* para finalizar la operación.

Al añadir la ingesta, se actualizará la ventana principal de forma que el gráfico de barras se actualizará con la información de la última ingesta añadida. De esta manera, cada vez que el usuario añada una ingesta, se representará de manera automática en el gráfico los valores calóricos del ingesta así como su fecha.

En las siguientes imágenes, se adjunta un ejemplo de adicción de una ingesta:

<p align="center">
  <img src="https://github.com/rmelgo/IGU-Aplicacion-control-ingestas/assets/145989723/a2940223-827d-4586-9b70-fd214a84fc02">
</p>

![Ejemplo ejecucion 4](https://github.com/rmelgo/IGU-Aplicacion-control-ingestas/assets/145989723/b5f8b00e-8dd4-40de-85ca-a36a9020841b)

### Errores en la adicción de ingestas

Al añadir una ingesta, es posible que se produzca un error. Existen 3 causas principales por las que se puede producir un error al añadir una ingesta:

- **Fecha de ingesta incorrecta**: El usuario o bien no ha introducido una fecha o bien el formato de la fecha introducida es erroneo. La fecha debe introducirse en el formato ````dd/mm/aaaa```.
- **Fecha de ingesta repetida**: El usuario intenta añadir una ingesta cuando ya existe una ingesta almacenada en la aplicación con la misma fecha.
- **Formato de calorias erróneo**: El usuario no ha introducido un valor númerico en alguna de las comidas que forman la ingesta.

Si se produce alguno de estos casos, se desplegará una pequeña ventana alertando al usuario de la situación. Además, los datos de dicha ingesta serán descartados y no se almacenarán en el sistema.

Un posible ejemplo de caso de error es el siguiente:

<p align="center">
  <img src="https://github.com/rmelgo/IGU-Aplicacion-control-ingestas/assets/145989723/f89ab1a5-ede0-4a2d-88a2-734d704e0c17">
</p>

En este caso, se ha intentado añadir una ingesta sin fecha.

## Cargar datos de ingestas

Para cargar datos de ingestas que se encuentren almacenados en un fichero de texto, el usuario debe hacer click en el botón ***Cargar datos*** que se encuentra en la parte izquierda de la ventana principal. Al pulsar este botón, se desplegará una ventana con el siguiente aspecto:

![Ejemplo ejecucion 6](https://github.com/rmelgo/IGU-Aplicacion-control-ingestas/assets/145989723/a63b2cfd-a42c-4530-992d-ad1ca4eadbe9)

Como se puede observar, se abre el explorador de archivos de Windows, el cual va a permitir al usuario buscar y navegar por los archivos por todo el equipo y seleccionar el fichero que contenga los datos de las ingestas.

### Formato del fichero en la carga de ingestas

Para cargar los datos de una serie de ingestas, el fichero de texto donde se almacenan las ingestas debe cumplir la siguiente sintaxis:

```<fecha-ingesta> <calorias-desayuno> <calorias-aperitivo> <calorias-comida> <calorias-merienda> <calorias-cena> <calorias-otros>```

Significado de los parámetros:

- **fecha-ingesta**: Fecha en la que se produce la ingesta siguiendo el formato ```dd/mm/aaaa```
- **calorias-desayuno**: Número entero que representa las calorias ingeridas en el desayuno
- **calorias-aperitivo**: Número entero que representa las calorias ingeridas en el aperitivo
- **calorias-comida**: Número entero que representa las calorias ingeridas en la comida
- **calorias-merienda**: Número entero que representa las calorias ingeridas en la merienda
- **calorias-cena**: Número entero que representa las calorias ingeridas en la cena
- **calorias-otros**: Número entero que representa las otras calorias ingeridas

Es importante que cada uno de estos valores este separado por un carácter espacio y que cada línea del fichero contenga los valores de una única ingesta.

En la siguiente imagen, se adjunta un ejemplo de un fichero que almacena una serie de ingestas siguiendo el formato especificado:

![Ejemplo ejecucion 7](https://github.com/rmelgo/IGU-Aplicacion-control-ingestas/assets/145989723/ef4c6d6c-165d-45ec-aca3-87455fe55ac2)

### Resultados obtenidos en la carga de ingestas

Al añadir los datos de las distintas ingestas, se actualizará la ventana principal de forma que el gráfico de barras se actualizará con la información de las últimas ingestas añadidas. De esta manera, cada vez que el usuario cargué una serie de ingestas, se representará de manera automática en el gráfico los valores calóricos de dichas ingestas así como su fecha.

**Nota**: Cuando se cargan los valores de una serie de ingestas, se borrarán de la aplicación los datos de las ingestas previamente almacenadas.

En las siguiente imagen, se adjunta un ejemplo de cargado de una serie de ingestas, utilizando el fichero ***ingestas.txt***:

![Captura inicial](https://github.com/rmelgo/IGU-Aplicacion-control-ingestas/assets/145989723/14a62de6-c1c4-4ed1-a140-3911666d4546)

### Errores en la carga de ingestas

Al realizar el cargado de ingestas, es posible que se produzca un error. Existen 2 causas principales por las que se puede producir un error al realizar el cargado de una serie de ingestas:

- **Formato incorrecto**: El fichero en el que se encuentran almacenadas las ingestas y se desea cargar no sigue el formato previamente indicado. A parrtir de este punto finaliza la opracion.
- **Fecha duplicada**: En el fichero se encuentran almacenadas dos o mas ingestas con la misma fecha. En este caso, solo se descartará la ingesta con la fecha repetida, cargando el resto de ingestas con éxito.

Si se produce alguno de estos casos, se desplegará una pequeña ventana alertando al usuario de la situación.

Un posible ejemplo de caso de error es el siguiente:

<p align="center">
  <img src="https://github.com/rmelgo/IGU-Aplicacion-control-ingestas/assets/145989723/2b65ae2e-e43d-411d-9920-acae8e4e57da">
</p>

En este caso, se ha intentado añadir una ingesta con una fecha repetida.




