//-----------------------------------------------------------------------------
// Para definir los delegados                                       (09/Dic/20)
//
//
// (c) Guillermo (elGuille) Som, 2020
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gsNotasNETF
{
    /// <summary>
    /// Delegado para manejar los errores y otros mensajes de esta clase.
    /// </summary>
    /// <param name="mensaje">El texto a devolver en el evento.</param>
    public delegate void MensajeDelegate(string mensaje);

    /// <summary>
    /// Delegado para los eventos de seleccionar grupo y nota.
    /// </summary>
    /// <param name="nota">El texto del elemento seleccionado.</param>
    /// <param name="index">El índice del elemento seleccionado.</param>
    public delegate void TextoModificado(string nota, int index);
}

/* 
Para evitar el error al usar init:
Error CS0518 Predefined type ‘System.Runtime.CompilerServices.IsExternalInit’ is not defined or imported
*/
namespace System.Runtime.CompilerServices
{
    public class IsExternalInit { }
}

