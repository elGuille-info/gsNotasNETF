# gsNotasNETF
 Gestionar notas y grupos de notas con editor integrado.
 
 >**NOTA:**<br>
 >El **NETF** del nombre es para indicar que está compilado con .NET Framework y no con .NET (Core)
 
 Si quieres ir a la página en mi blog: [gsNotasNETF](http://www.elguillemola.com/utilidades-net/utilidades-para-net-framework-4-8/gsnotasnetf/)
 
 Código escrito con C# 9.0 y Visual Studio 2019 copn .NET Framework 4.8
 
 Para usar las características de C# 9.0 en un proyecto de .NET Framework 4.8 (por defecto se usa C# 7.3)
 hay que indicar esto en el fichero del proyecto:<br>
 
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
Si no, no se podrá usar el mopdificador <b>init</b> en la definición de las propiedades.
