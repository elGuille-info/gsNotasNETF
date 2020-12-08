# gsNotasNETF
 Gestionar notas y grupos de notas con editor integrado.
 
 Código escrito con C# 9.0 y Visual Studio 2019 copn .NET Framework 4.8
 
 Para usar las características de C# 9.0 en un proyecto de .NET Framework 4.8 (por defecto se usa C# 7.3)
 hay que indicar esto en el fichero del proyecto:<br>
 
 ```
   &lt;PropertyGroup&gt;<br>
    &lt;LangVersion>latest</LangVersion&gt;<br>
  &lt;/PropertyGroup&gt;<br>

<br>
Y en el código (ponerlo al final del la definición del namespace principal)<br>

``` c#
/* <br>
Para evitar el error al usar init:<br>
Error CS0518 Predefined type ‘System.Runtime.CompilerServices.IsExternalInit’ is not defined or imported<br>
*/<br>
namespace System.Runtime.CompilerServices<br>
{<br>
    public class IsExternalInit { }<br>
}<br>

<br>
Si no, no se podrá usar el mopdificador <b>init</b> en la definición de las propiedades.
