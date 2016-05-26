using UnityEngine;
using UnityEngine.Events;

// ReSharper disable CheckNamespace

namespace AvalonAssets.Unity.Event
{
    /// <summary>
    ///     Trigger a event when certain amount of time passed.
    /// </summary>
    /// <remarks>The time does not count when it is disabled.</remarks>
    public class TimeoutEventTrigger : MonoBehaviour, IEventTrigger
    {
        private bool _finish;
        private float _timePassed;

        /// <summary>
        ///     Event to be triggered.
        /// </summary>
        [Tooltip("Event to be triggered.")]
        public CommenEvent Event;

        /// <summary>
        ///     True if you want to repeat multiple time. False if you want to trigger once.
        /// </summary>
        [Tooltip("True if you want to repeat multiple time.\nFalse if you want to trigger once.")]
        public bool Repeat;

        /// <summary>
        ///     Reset the trigger when it is set to active.
        /// </summary>
        [Tooltip("Reset the trigger when it is set to active.")]
        public bool ResetOnActive;

        /// <summary>
        ///     Amount of time to trigger the event.
        /// </summary>
        [Tooltip("Amount of time to trigger the event.")]
        public float TimeSpan;

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

        private void Awake()
        {
            Initialization();
        }

        private void OnEnable()
        {
            Initialization();
        }

        private void Update()
        {
            if (_finish) return; // Skip if it has finished.
            _timePassed += Time.deltaTime; // Add time passed from last frame.
            if (_timePassed <= TimeSpan) return;
            Event.Invoke(gameObject); // Trigger event.
            if (!Repeat)
                _finish = true; // Stop if not repeat.
            else
                Initialization(); // Reset if repeat.
        }

        /// <summary>
        ///     Reset all the parameters.
        /// </summary>
        private void Initialization()
        {
            _timePassed = 0;
            _finish = false;
            if (TimeSpan >= 0) return;
            _finish = true;
            Debug.LogError("TimeSpan must greater than 0.");
        }
    }
}