using System;
using UnityEngine;
using UnityEngine.Events;

// ReSharper disable CheckNamespace

namespace AvalonAssets.Unity.Event
{
    /// <summary>
    ///     A serializable <see cref="UnityEvent{T}" />.
    /// </summary>
    [Serializable]
    public class CommenEvent : UnityEvent<GameObject>
    {
    }
}