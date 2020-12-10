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
using System.ComponentModel;

namespace gsNotasNETF
{
    /// <summary>
    /// Delegado para avisar del cambio de tema.
    /// </summary>
    /// <param name="tema">El tema asignado.</param>
    public delegate void TemaCambiado(Temas tema);

    /// <summary>
    /// Delegado para manejar el reemplazo de una nota.
    /// </summary>
    /// <param name="grupo">El grupo.</param>
    /// <param name="texto">El texto de la nota.</param>
    /// <param name="index">El índice del elemento que se edita.</param>
    public delegate void ReemplazarNota(string grupo, string texto, int index);

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

    /// <summary>
    /// Enumeración para los temas a usar.
    /// Light/Claro, Dark/Oscuro.
    /// </summary>
    [Browsable(false)]
    [Description("Enumeración para los temas a usar. Light/Claro, Dark/Oscuro.")]
    [Category("NotasUC")]
    public enum Temas
    {
        /// <summary>
        /// Tema claro (0)
        /// </summary>
        Claro = 0,
        /// <summary>
        /// Tema oscuro (1)
        /// </summary>
        Oscuro = 1,
    }
}

/* 
Para evitar el error al usar init:
Error CS0518 Predefined type ‘System.Runtime.CompilerServices.IsExternalInit’ is not defined or imported
*/
namespace System.Runtime.CompilerServices
{
    public class IsExternalInit { }
}

