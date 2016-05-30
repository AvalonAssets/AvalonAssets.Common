using UnityEngine;
using UnityEngine.Events;

// ReSharper disable CheckNamespace

namespace AvalonAssets.Unity.Event
{
    public abstract class BaseEventTrigger : MonoBehaviour, IEventTrigger
    {
        /// <summary>
        ///     Event to be triggered.
        /// </summary>
        [Tooltip("Event to be triggered.")]
        [SerializeField]
        protected CommenEvent Event;
        
        /// <summary>
        ///     Reset the trigger when it is set to active.
        /// </summary>
        [Tooltip("Reset the trigger when it is set to active.")]
        public bool ResetOnActive;

        protected virtual void Awake()
        {
            Initialization();
        }

        protected virtual void OnEnable()
        {
            if (ResetOnActive)
                Initialization();
        }

        /// <summary>
        ///     Add a listerner to event through script.
        /// </summary>
        /// <param name="callBack">Call back function.</param>
        public void AddListener(UnityAction<GameObject> callBack)
        {
            Event.AddListener(callBack);
        }

        /// <summary>
        ///     Remove a listerner from event through script.
        /// </summary>
        /// <param name="callBack">Call back function.</param>
        public void RemoveListener(UnityAction<GameObject> callBack)
        {
            Event.RemoveListener(callBack);
        }

        protected abstract void Initialization();
    }
}