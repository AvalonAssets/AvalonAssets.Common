using UnityEngine;

// ReSharper disable CheckNamespace

namespace AvalonAssets.Unity.Event
{
    /// <summary>
    ///     Trigger a event when certain amount of time passed.
    /// </summary>
    /// <remarks>The time does not count when it is disabled.</remarks>
    public class TimeoutEventTrigger : BaseEventTrigger
    {
        private bool _finish;
        private float _timePassed;

        /// <summary>
        ///     True if you want to repeat multiple time. False if you want to trigger once.
        /// </summary>
        [Tooltip("True if you want to repeat multiple time.\nFalse if you want to trigger once.")]
        public bool Repeat;
        
        /// <summary>
        ///     Amount of time to trigger the event.
        /// </summary>
        [Tooltip("Amount of time to trigger the event.")]
        public float TimeSpan;
        
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
        protected override void Initialization()
        {
            _timePassed = 0;
            _finish = false;
            if (TimeSpan >= 0) return;
            _finish = true;
            Debug.LogError("TimeSpan must greater than 0.");
        }
    }
}