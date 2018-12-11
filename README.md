# SAMPLES DTE

SAMPLES-DTE es una solución Visual Studio, que pretende ejemplificar, la mayor cantidad de las operaciones disponibles en [SIMPLE SDK](http://www.chilesystems.com/Productos). Este utilitario, muestra como operar todos los pasos que se componen en la emisión de los documentos (DTE) y otros varios, como el IECV, Libro de boletas, RCOF, entre otros.

[SIMPLE SDK](http://www.chilesystems.com/Productos) viene con la conexión incorporada al SII para el envío de los documentos.

## Comenzando 🚀

Para utilizar *SIMPLE SDK*, es necesario contar con un código de activación tipo Serial Key. La que viene incluída en el archivo Handler.cs, tiene una duración limitada y cuenta con un tope de 100 documentos.

Más información en [www.chilesystems.com](http://www.chilesystems.com) o solicitandola a contacto@chilesystems.com

### Pre-requisitos 📋

```
.NET Framework 4.6
```
### Instalación 🔧

1. Dentro de la carpeta donde correrá el proyecto (Debug o Release según corresponda en el caso del entorno de VS), debes tener la siguiente estructura de carpetas:

* out

Dentro de **out** las carpetas
 * caf
 * temp

En la carpeta _temp_ se guardarán los archivos XML. En la carpeta _caf_ los códigos de autorización de folios que entrega el SII. **Estas rutas son alternativas**.

2. Debes agregar la referencia a SIMPLE_SDK a tu proyecto.

### Apoyo externo 🔩

En 3 videos distintos, se muestra cómo utilizar este mismo proyecto (el de los videos es un poco más antiguo, pero las variaciones son mínimas).

* [Simulación y generación de Timbre impreso con API Simple](https://www.youtube.com/watch?v=ZLRxZ58b-w4)
* [Generación y envío de documentos al SII Chile con Simple API](https://www.youtube.com/watch?v=q20kf8eke50)
* [Certificación de boletas electrónicas con Simple API](https://www.youtube.com/watch?v=gq5mBIAyf6o)


