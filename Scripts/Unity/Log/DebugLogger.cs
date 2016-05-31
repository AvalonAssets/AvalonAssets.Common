using AvalonAssets.Log;
using UnityEngine;

// ReSharper disable CheckNamespace

namespace AvalonAssets.Unity.Log
{
    /// <summary>
    ///     A <see cref="IWriter" /> using Unity editor logger.
    /// </summary>
    public class DebugLogger : IWriter
    {
        /// <summary>
        ///     Write a message.
        /// </summary>
        /// <param name="message">Message to be written.</param>
        public void Write(string message)
        {
            Debug.Log(message);
        }

        /// <summary>
        ///     Write a colored message.
        /// </summary>
        /// <remarks><paramref name="hexColor" /> need to have a # at the front.</remarks>
        /// <param name="message">Message to be written.</param>
        /// <param name="hexColor">Hex value of the color.</param>
        public void Write(string message, string hexColor)
        {
            Debug.Log("<color=" + hexColor + ">" + message + "</color>");
        }
    }
}