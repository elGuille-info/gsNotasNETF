# gsNotasNETF
 Gestionar notas y grupos de notas con editor integrado.
 
>**NOTA:**<br>
>El **NETF** del nombre es para indicar que está compilado con .NET Framework y no con .NET (Core)
 
Si quieres ir a la página en mi blog: [gsNotasNETF](http://www.elguillemola.com/utilidades-net/utilidades-para-net-framework-4-8/gsnotasnetf/)
<br>
<br>
 
## Actualizaciones
Hay varias actualizaciones desde que publiqué esto por primera vez.<br>
<br>
**Nota 18-oct-22 (v1.0.0.151):**
<br>
El directorio de "documentos" ahora es el indicado en %LOCALAPPDATA% (C:\Users\\[usuario]\AppData\Local)<br>
Ahí se creará el directorio **gsNotas** con el fichero de las notas y dentro de esa carpeta estará el birectorio **Backup** con las copias.<br>
En las versiones anteriores a la v1.0.0.151 se usaba el directorio de Documentos para guardar el fichero de notas y la carpeta **gsNotasNETF** para guardar las copias de seguridad.<br>
>El fichero de notas anterior y el directorio con las copias de seguridad anteriores se mantienen.<br>

<br>
**Nota 18-oct-22 (v1.0.0.150):**
<br>
Mover las notas mostradas de forma independiente.<br>
Pongo el título con el de la nota y en el status el nombre del grupo (antes mostraba el valor predeterminado).<br>
Pongo scroll en el texto de AcercaDe.<br>
Cambio tamaño fuente de los tabs. Diseño de editar grupos y notas.

**Nota 15-oct-22 (v1.0.0.149):**
<br>
He cambiado el .NET Framework a la versión 4.8.1 y está firmado con nombre seguro usando _elGuille_compartido.snk_ (que seguramente no esté en el código fuente porque tengo filtrado que publique todos los .snk)<br>
<br>
**Los cambios realizados después de la versión 1.0.0.139 del 19-dic-2020:**
<br>
```
v1.0.0.140  24-dic-20  Cambio el icono de la aplicación.
v1.0.0.141             Y el del formulario y por tanto el del icono de notificación.
v1.0.0.142  26-dic-20  Se puede iniciar con Windows (se debe ejecutar como administrador).
v1.0.0.143  30-dic-20  Añado un tab para acerca de y hago comprobación de si es la versión más reciente.
                       Añado menú contextual de edición a la caja de texto.
v1.0.0.144  10-feb-21  Quito el aviso cuando se inicia y no puede acceder al registro.
                       Si se quiere seguir mostrando el aviso, asignar true a mostrarAvisoReg
                       Añado la propiedad StatusInfo a NotaUC para mostrar un mensaje en la barra de estado.
v1.0.0.145             Se movieron los botones de Guardar/Cancelar en la pestaña de opciones.
                       Al iniciar la aplicación (o guardar los datos de configuración)
                       ocultar la aplicación si se inicia minimizada.
v1.0.0.146             Para que esto funcione bien en el evento Load hay que usar un temporizador.
v1.0.0.147  14-abr-21  Cambio el icono de FormEditarNotaUC.
v1.0.0.148  21-abr-21  Se "perdieron" los botones de Guardar y Deshacer en las Opciones.
                       Pongo el tamaño mínimo en 800x400, el tamaño en diseño es 823; 659
v1.0.0.149  15-oct-22  Cambio a .NET Framework 4.8.1

```
<br>
<br>

Ahora estoy haciendo [**releases**](https://github.com/elGuille-info/gsNotasNETF/releases) con cada nueva versión, incluyendo tanto el ejecutable como el código fuente (aparte del código fuente aquí publicado).

<br>
<br>
  
## Nota sobre la versión de C# usada y cómo configurar los proyectos de .NET Framework para que use la última
 
Código escrito con C# 9.0 y Visual Studio 2019 con .NET Framework 4.8.1
 
Para usar las características de C# 9.0 en un proyecto de .NET Framework 4.8 (por defecto se usa C# 7.3) hay que indicar esto en el fichero del proyecto:<br>
 
```html
<PropertyGroup>
    <LangVersion>latest</LangVersion>
</PropertyGroup>
```

<br>
Y en el código (ponerlo al final del la definición del namespace principal)<br>

```c#
/* 
Para evitar el error al usar init:
Error CS0518 Predefined type ‘System.Runtime.CompilerServices.IsExternalInit’ is not defined or imported
*/
namespace System.Runtime.CompilerServices
{
    public class IsExternalInit { }
}
```

<br>
Si no, no se podrá usar el modificador <b>init</b> en la definición de las propiedades.
