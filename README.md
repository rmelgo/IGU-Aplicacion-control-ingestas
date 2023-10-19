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

Si se produce alguno de estos casos, se desplegará una pequeña ventana alertando al usuario de la situación. Además, los datos de dicha ingesta serán descartados y no se almacenarán en el sistema. Un posible ejemplo de caso de error es el siguiente:

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

- **Formato incorrecto**: El fichero en el que se encuentran almacenadas las ingestas y se desea cargar no sigue el formato previamente indicado. A partir de este punto finaliza la operación.
- **Fecha duplicada**: En el fichero se encuentran almacenadas dos o mas ingestas con la misma fecha. En este caso, solo se descartará la ingesta con la fecha repetida, cargando el resto de ingestas con éxito.

Si se produce alguno de estos casos, se desplegará una pequeña ventana alertando al usuario de la situación. Un posible ejemplo de caso de error es el siguiente:

<p align="center">
  <img src="https://github.com/rmelgo/IGU-Aplicacion-control-ingestas/assets/145989723/2b65ae2e-e43d-411d-9920-acae8e4e57da">
</p>

En este caso, se ha intentado añadir una ingesta con una fecha repetida.

## Guardar datos de ingestas

Para guardar datos de ingestas que se encuentren almacenados en la aplicación, el usuario debe hacer click en el botón ***Guardar datos*** que se encuentra en la parte izquierda de la ventana principal. Al pulsar este botón, se desplegará una ventana con el siguiente aspecto:

![Ejemplo ejecucion 9](https://github.com/rmelgo/IGU-Aplicacion-control-ingestas/assets/145989723/5f612b78-593d-4e36-86b4-6a21760e26a7)

Como se puede observar, se abre el explorador de archivos de Windows, el cual va a permitir al usuario navegar por los archivos por todo el equipo y seleccionar la ubicación en la que se guardará el fichero que contendrá los datos de las ingestas.

Al guardar los datos de las distintas ingestas, se mostrara un mensaje al usuario indicando que el proceso de guardado se ha realizado correctamente. El mensaje tiene el siguiente aspecto:

<p align="center">
  <img src="https://github.com/rmelgo/IGU-Aplicacion-control-ingestas/assets/145989723/36fe7ce9-d2c5-4284-8bb2-73b284ac6a92">
</p>

**Nota**: En el guardado de las ingestas no se considera ningún escenario de error, ya que las ingestas están correctamente almacenadas en la aplicación y no se pueden producir errores de formato o de duplciado de fechas.

### Formato del fichero en el guardado de ingestas

El formato de las ingestas guardadas sera el mismo que el formato explicado en la funcionalidad de cargado de ingestas.  
Esto se realiza así para que los datos guardados por un usuario puedan ser posteriormente reutilizados y cargados de nuevo en la aplicación

### Resultados obtenidos en el guardado de ingestas

En las siguientes imagenes, se adjunta un ejemplo de guardado de una serie de ingestas:

![Ejemplo ejecucion 10](https://github.com/rmelgo/IGU-Aplicacion-control-ingestas/assets/145989723/2df16f89-12b4-4695-90ea-5f73fc8f56ec)

![Ejemplo ejecucion 11](https://github.com/rmelgo/IGU-Aplicacion-control-ingestas/assets/145989723/e4e441f1-ab25-47b3-a5fd-3ab9fa8615b2)

## Generar HTML con los datos de las ingestas

Para generar un fichero HTML con una tabla que incluya los datos de las ingestas que se encuentran almacenados en la aplicación, el usuario debe hacer click en el botón ***HTML*** que se encuentra en la parte izquierda de la ventana principal. Al pulsar este botón, se desplegará una ventana con el siguiente aspecto:

![Ejemplo ejecucion 12](https://github.com/rmelgo/IGU-Aplicacion-control-ingestas/assets/145989723/9be6d020-bf53-4965-8b3d-b1d741657cd8)

Como se puede observar, se abre el explorador de archivos de Windows, el cual va a permitir al usuario navegar por los archivos por todo el equipo y seleccionar la ubicación en la que se guardará el fichero HTML que contendrá los datos de las ingestas.

Al guardar los datos de las distintas ingestas, se mostrara un mensaje al usuario indicando que el proceso de generación del HTML se ha realizado correctamente. El mensaje tiene el siguiente aspecto:

<p align="center">
  <img src="https://github.com/rmelgo/IGU-Aplicacion-control-ingestas/assets/145989723/b5365fcf-1ad9-4ac0-9469-93d79a81c64e">
</p>

**Nota**: En la generación del fichero HTML con los datos de las ingestas no se considera ningún escenario de error, ya que las ingestas están correctamente almacenadas en la aplicación y no se pueden producir errores de formato o de duplciado de fechas.

### Formato de la tabla HTML

En la tabla HTML, existe una columna para la fecha de la ingesta y una columna para cada ingesta del día. También existe una última columna en la que se incluye el total de calorias ingerido en ese día.

### Resultados obtenidos en la generacion del HTML

En las siguientes imagenes, se adjunta un ejemplo de generación de un fichero HTML con los datos de una serie de ingestas:

![Ejemplo ejecucion 10](https://github.com/rmelgo/IGU-Aplicacion-control-ingestas/assets/145989723/2df16f89-12b4-4695-90ea-5f73fc8f56ec)

![Ejemplo ejecucion 14](https://github.com/rmelgo/IGU-Aplicacion-control-ingestas/assets/145989723/078ed7a7-e5a9-468a-94a7-168630324189)

## Ver detalle de ingestas

Para ver el detalle de una ingesta almacenada en la aplicación, el usuario debe hacer click en el botón ***Ver detalle ingesta*** que se encuentra en la parte izquierda de la ventana principal. Al pulsar este botón, se desplegará una ventana con el siguiente aspecto:

![Ejemplo ejecucion 15](https://github.com/rmelgo/IGU-Aplicacion-control-ingestas/assets/145989723/bc90980e-5362-4704-8747-d0b01359ee95)

La ventana del detalle de la ingesta se agrupa en **2 secciones principales**:

- Por un lado, existe una sección grande de color gris que cuenta con 2 tablas:

  - La **primera tabla** muestra todas las ingestas almacenadas en el sistema. Para cada ingesta se muestra su fecha y el total de calorias ingeridas en dicha fecha
  - La **segunda tabla** muestra los datos caloricos de cada una de las comidas de una ingesta. Inicialmente esta tabla se encuentra vacía. Solo se mostrará información detallada de una ingesta cuando el usuario seleccione una ingesta en la primera tabla.
  
- Por otro lado, existe una barra lateral donde dicha barra lateral a su vez se divide en 3 secciones:

  - En la **primera sección**, existe una caja de texto donde el usuario puede filtrar las ingestas que tengan un total de calorias determinado.
  - En la **segunda sección**, existe una caja de texto donde el usuario puede buscar una ingesta con una fecha determinada. Para añadir la fecha, el usuario puede introducirla directamente en la caja de texto o bien puede desplazarse por el calendario interactivo y seleccionar la fecha correspondiente.
  - En la **tercera sección**, existen 2 botones que implementan 2 funcionalidades básicas. A continuación se explicarán brevemente cada una de estas 2 funcionalidades:

    - **Aplicar filtros**: Esta funcionalidad permite al usuario filtrar las ingestas almacenadas en el sistema en función de los filtros introducidos por el usuario, de forma que solo se muestren las ingestas que cumplan con los filtros.
    - **Restaurar filtros**: Esta funcionalidad permite al usuario resetear los filtros aplicados de manera que vuelvan a mostrarse todas las ingestas almacenadas en el sistema.

A continuación se describirá de manera mas detallada cada una de estas funcionalidades de esta ventana secundaria.

### Aplicar filtros

Para filtrar las ingestas almacenadas en el sistema, el usuario debe hacer click en el botón ***Aplicar filtros*** que se encuentra en la parte izquierda de la ventana. 

La ventana cuenta con 2 filtros fundamentales:

- **Total calorias**: El usuario puede introducir en el recuadro correspondiente el número total de calorias de las ingestas que desea filtrar.
- **Fecha de la ingesta**: El usuario puede introducir en el recuadro correspondiente la fecha de la ingesta que desea filtrar.

En la siguiente imagen, se muestra un ejemplo de filtrado de ingesta, combinando los 2 filtros simultaneamente:

![Ejemplo ejecucion 17](https://github.com/rmelgo/IGU-Aplicacion-control-ingestas/assets/145989723/f79fd5e7-baa7-4fb8-b91e-b8b38f27de3a)

#### Errores en el filtrado

Al realizar el filtrado de ingestas, es posible que se produzca un error. Existen 2 causas principales por las que se puede producir un error al realizar el filtrado de ingestas:

- **Total de calorias con formato incorrecto**: El usuario ha introducido algo distinto a un número en el recuadro correspondiente el número total de calorias.
- **Fecha de la ingesta con formato incorrecto**: El usuario ha introducido la fecha de la ingesta recuadro correspondiente la fecha de la ingesta sin seguir el formato adecuado. El formato de las fechas debe ser ```dd\mm\aaaa```.

Si se produce alguno de estos casos, se desplegará una pequeña ventana alertando al usuario de la situación. Un posible ejemplo de caso de error es el siguiente:

<p align="center">
  <img src="https://github.com/rmelgo/IGU-Aplicacion-control-ingestas/assets/145989723/f0bd1ed7-b54d-43a2-9198-8519ca85e5cf">
</p>

### Restaurar filtros

Para restaurar los filtros aplicados sobre las ingestas almacenadas en el sistema, el usuario debe hacer click en el botón ***Restaurar filtros*** que se encuentra en la parte izquierda de la ventana. 

Al pulsar este botón, se producen 2 cambios fundamentales:

- Por un lado, se limpian los recuadros asociados a los filtros, devolviendolos a su estado original, es decir, vacíos.
- Por otro lado, se muestran de nuevo todas las ingestas almacenadas en el sistema en la primera tabla.

### Funcionalidades adicionales

Cuando el usuario selecciona una de las ingestas representada en la primera tabla, se muestra el detalle de dicha ingesta seleccionada en la segunda tabla, mostrandose los valores caloricos de cada una de las comidas que conforman la ingesta.
Por otra parte, en la barra lateral aparecen 2 nuevos botones que implementan 2 "nuevas" funcionalidades. A continuación se explicarán brevemente cada una de estas 2 funcionalidades:

- **Modificar ingesta**: El usuario puede modificar los datos de la ingesta seleccionada.
- **Eliminar ingesta**: El usuario puede eliminar del sistema la ingesta seleccionada.

Al seleccionar una ingesta en la primera tabla, la apariencia de la ventana es la siguiente:

![Ejemplo ejecucion 18](https://github.com/rmelgo/IGU-Aplicacion-control-ingestas/assets/145989723/bed6b9eb-fb25-4aa7-b86e-3ce3db1f1508)

### Modificar ingesta

Para modificar una ingesta, el usuario debe hacer click en el botón ***Modificar ingesta*** que se encuentra en la parte izquierda de la ventana. Al pulsar este botón, se desplegará una ventana con el siguiente aspecto:

<p align="center">
  <img src="https://github.com/rmelgo/IGU-Aplicacion-control-ingestas/assets/145989723/217fd85b-83d8-477f-8eff-c3d96bcdf224">
</p>

#### Estructura y funcionamiento de la nueva ventana

Como se puede observar, se despliega una ventana similar a la ventana que se desplegaba al añadir una ingesta. Sin embargo, los recuadros de la ventana en vez de encontrarse vacíos se encuentran rellenos con los datos de la ingesta que se desea modificar.
De esta manera, el usuario puede modificar con libertad los valores de la ingesta.

Una vez modificada toda la información sobre una ingesta, para modificar definitivamente la ingesta, el usuario pulsará el botón de *"Aceptar"*. Si por alguna razón, el usuario quiere cancelar el proceso de modificación de la ingesta puede pulsar el botón de *"Cancelar"* para finalizar la operación.

Al modificar la ingesta, se actualizará la ventana principal de forma que el gráfico de barras se actualizará con la información de la ingesta modificada.

En las siguientes imágenes, se adjunta un ejemplo de modificación de una ingesta:

<p align="center">
  <img src="https://github.com/rmelgo/IGU-Aplicacion-control-ingestas/assets/145989723/46d811fb-f41f-4c84-a3cd-81f15d22cfec">
</p>

![Ejemplo ejecucion 21](https://github.com/rmelgo/IGU-Aplicacion-control-ingestas/assets/145989723/728fb335-de54-4f28-813f-6597f70b63e8)

#### Errores en la modificación de ingestas

Al modificar una ingesta, es posible que se produzca un error. Existen 3 causas principales por las que se puede producir un error al modificar una ingesta:

- **Fecha de ingesta incorrecta**: El usuario o bien no ha introducido una fecha o bien el formato de la fecha introducida es erróneo. La fecha debe introducirse en el formato ````dd/mm/aaaa```.
- **Fecha de ingesta repetida**: El usuario intenta asignar a la ingesta una fecha que coincide con la fecha de otra ingesta almacenada en la aplicación.
- **Formato de calorias erróneo**: El usuario no ha introducido un valor númerico en alguna de las comidas que forman la ingesta.

Si se produce alguno de estos casos, se desplegará una pequeña ventana alertando al usuario de la situación. Además, los datos de dicha modificación serán descartados y no se almacenarán en el sistema, manteniendose en el sistema los datos originales de la ingesta, antes de realizar la modificación. Un posible ejemplo de caso de error es el siguiente:

<p align="center">
  <img src="https://github.com/rmelgo/IGU-Aplicacion-control-ingestas/assets/145989723/1b32cb50-374d-45c0-ad3c-fb3de7914110">
</p>

En este caso, se ha intentado asignar a la ingesta una fecha que coincide con la fecha de otra ingesta almacenada en la aplicación.

### Eliminar ingesta

Para modificar una ingesta, el usuario debe hacer click en el botón ***Eliminar ingesta*** que se encuentra en la parte izquierda de la ventana. Al pulsar este botón, se eliminará la ingesta seleccionada y ya no se encontrará almacenada en la aplicación. A continuación se muestra un ejemplo:

![Ejemplo ejecucion 23](https://github.com/rmelgo/IGU-Aplicacion-control-ingestas/assets/145989723/f390bf62-3615-4f7f-bd56-86b196a74390)

## Funcionalidades adicionales en la ventana principal

Cuando el usuario selecciona una de las ingestas en la ventana de detalle de ingestas, se muestra el detalle de dicha ingesta seleccionada en la segunda tabla, mostrandose los valores caloricos de cada una de las comidas que conforman la ingesta. 

Por otra parte, en la ventana principal se muestra un nuevo gráfico de barrras donde se representa con barras cada uno de los valores caloricos de las comidas que conforman la ingesta que se ha seleccionado.

Además, en la barra lateral aparecen 2 nuevos botones que implementan 2 "nuevas" funcionalidades. A continuación se explicarán brevemente cada una de estas 2 funcionalidades:

- **Volver al gráfico principal**: La aplicación vuelve a mostrar el gráfico principal en el que se representan gráficamente todas las ingestas.
- **Ver el gráfico de sectores**: La aplicación muestra la información detallada de la ingesta seleccionada pero en un gráfico de sectores en vez de un gráfico de barras.

Al seleccionar una ingesta en la primera tabla, la apariencia de la ventana principal es la siguiente:

![Ejemplo ejecucion 24](https://github.com/rmelgo/IGU-Aplicacion-control-ingestas/assets/145989723/5bb82eaf-da55-4a83-b6c5-22d9d9d7cc5e)

### Volver al gráfico principal

Para volver al gráfico principal, el usuario debe hacer click en el botón ***Volver al gráfico principal*** que se encuentra en la parte izquierda de la ventana. Al pulsar este botón, el usuario podrá visualizar de nuevo gráficamente todas las ingestas almacenadas en la aplicación.

### Ver el gráfico de sectores

Para ver el gráfico de sectores, el usuario debe hacer click en el botón ***Ver el gráfico de sectores*** que se encuentra en la parte izquierda de la ventana. Al pulsar este botón, el usuario podrá visualizar la información detallada de la ingesta seleccionada en un gráfico de sectores. 

Complementariamente, se muestra una pequeña leyenda indicando el porcentaje con respecto a las calorias totales que representa las calorias de cada una de las comidas de la ingesta. A continuación se muestra un ejemplo:

![Ejemplo ejecucion 25](https://github.com/rmelgo/IGU-Aplicacion-control-ingestas/assets/145989723/e446bf46-5e7f-4f1b-a7b4-de48db2e6012)

### Comentario adicional sobre la representación de ingestas en el gráfico de barras

En la sección gráfica de la ventana principal, existe hueco para representar los datos de **10 ingestas**. Si en la aplicación se encuentran almacenadas más de 10 ingestas, no podrán representarse todas las ingestas al mismo tiempo. 

Es por esto por lo que existen 2 pequeños botones en la esquina superior derecha que permiten avanzar hacia delante (*botón ">"*) y hacia atrás (*botón "<"*) repectivamente permitiendo ver las ***10 siguientes ingestas*** o las ***10 ingestas anteriores***.
