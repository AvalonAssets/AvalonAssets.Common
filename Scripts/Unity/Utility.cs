using System;
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

        /// <summary>
        ///     Split string on specific character(s).
        /// </summary>
        /// <param name="input"><see cref="string" /> to be splited.</param>
        /// <param name="splitFunction">Decide to split on which character.</param>
        /// <returns>Splited string.</returns>
        internal static IEnumerable<string> Split(this string input, Func<char, bool> splitFunction)
        {
            var index = 0;
            for (var i = 0; i < input.Length; i++)
            {
                if (!splitFunction(input[i])) continue;
                yield return input.Substring(index, i - index);
                index = i + 1;
            }
            yield return input.Substring(index);
        }

        /// <summary>
        ///     Remove <paramref name="quote" /> from start and end of the <paramref name="input" />.
        /// </summary>
        /// <param name="input"><see cref="string" /> to be processed.</param>
        /// <param name="quote">Quoting character.</param>
        /// <returns>Trimmed string.</returns>
        internal static string TrimMatchingQuotes(this string input, char quote)
        {
            if ((input.Length >= 2) &&
                (input[0] == quote) && (input[input.Length - 1] == quote))
                return input.Substring(1, input.Length - 2);
            return input;
        }
    }
}