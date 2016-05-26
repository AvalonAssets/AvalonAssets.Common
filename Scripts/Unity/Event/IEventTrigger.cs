// ReSharper disable CheckNamespace

using UnityEngine;
using UnityEngine.Events;

namespace AvalonAssets.Unity.Event
{
    /// <summary>
    ///     A event trigger interface.
    /// </summary>
    public interface IEventTrigger
    {
        /// <summary>
        ///     Add a listerner to event through script.
        /// </summary>
        /// <param name="callBack">Call back function.</param>
        void AddListener(UnityAction<GameObject> callBack);

        /// <summary>
        ///     Remove a listerner from event through script.
        /// </summary>
        /// <param name="callBack">Call back function.</param>
        void RemoveListener(UnityAction<GameObject> callBack);
    }
}