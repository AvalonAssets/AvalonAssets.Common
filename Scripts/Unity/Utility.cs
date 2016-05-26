using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// ReSharper disable CheckNamespace

namespace AvalonAssets.Unity
{
    /// <summary>
    ///     This is an internal utilities class for Unity.
    /// </summary>
    internal static class Utility
    {
        /// <summary>
        ///     Returns the component with interface type if the game object has one attached, null if it doesn't.
        /// </summary>
        /// <typeparam name="T">The type of Component to retrieve.</typeparam>
        /// <param name="obj"><see cref="GameObject" /> to be searched.</param>
        /// <returns>The component with interface type</returns>
        internal static T GetInterface<T>(this GameObject obj) where T : class
        {
            if (typeof (T).IsInterface) return obj.GetComponents<Component>().OfType<T>().FirstOrDefault();
            Debug.LogError(typeof (T) + ": is not an interface.");
            return null;
        }

        /// <summary>
        ///     Returns all components of interface type in the GameObject.
        /// </summary>
        /// <typeparam name="T">The type of Component to retrieve.</typeparam>
        /// <param name="obj"><see cref="GameObject" /> to be searched.</param>
        /// <returns>All components of interface type.</returns>
        internal static IEnumerable<T> GetInterfaces<T>(this GameObject obj) where T : class
        {
            if (typeof (T).IsInterface) return obj.GetComponents<Component>().OfType<T>();
            Debug.LogError(typeof (T) + ": is not an interface.");
            return Enumerable.Empty<T>();
        }
    }
}