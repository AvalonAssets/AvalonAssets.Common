using System;
using UnityEngine;

// ReSharper disable CheckNamespace

namespace AvalonAssets.Unity.Event
{
    [RequireComponent(typeof (AudioSource))]
    public class AudioSourceEventTrigger : BaseEventTrigger
    {
        private AudioSource _audioSource;
        private bool _finish;

        /// <summary>
        ///     Event type to listen.
        /// </summary>
        [Tooltip("Event type to listen.")]
        public AudioSourceEventType EventType;

        /// <summary>
        ///     True if you want to repeat multiple time. False if you want to trigger once.
        /// </summary>
        [Tooltip("True if you want to repeat multiple time.\nFalse if you want to trigger once.")]
        public bool Repeat;

        protected override void Awake()
        {
            base.Awake();
            _audioSource = GetComponent<AudioSource>();
            if (_audioSource == null)
                Debug.LogError("You do not have a paraticle system on " + gameObject.name);
        }

        private void Update()
        {
            // Skip if it has finished or there is no paraticle system.
            if (_finish || _audioSource == null) return;
            bool isTirgger;
            switch (EventType)
            {
                case AudioSourceEventType.Playing:
                    isTirgger = _audioSource.isPlaying;
                    break;
                case AudioSourceEventType.Stop:
                    isTirgger = !_audioSource.isPlaying;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            if (!isTirgger) return;
            Event.Invoke(gameObject); // Trigger event.
            if (!Repeat)
                _finish = true; // Stop if not repeat.
            else
                Initialization(); // Reset if repeat.
        }

        protected override void Initialization()
        {
            _finish = false;
        }
    }
}