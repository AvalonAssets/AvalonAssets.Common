using System;
using UnityEngine;

// ReSharper disable CheckNamespace

namespace AvalonAssets.Unity.Event
{
    /// <summary>
    ///     Trigger a event related to <see cref="ParticleSystem"/>.
    /// </summary>
    [RequireComponent(typeof (ParticleSystem))]
    public class ParticleSystemEventTrigger : BaseEventTrigger
    {
        private bool _finish;
        private ParticleSystem _particleSystem;

        /// <summary>
        ///     Event type to listen.
        /// </summary>
        [Tooltip("Event type to listen.")]
        public ParticleSystemEventType EventType;

        /// <summary>
        ///     True if you want to repeat multiple time. False if you want to trigger once.
        /// </summary>
        /// <remarks>You should not use this unless you know what you are doing.</remarks>
        [Tooltip("True if you want to repeat multiple time.\nFalse if you want to trigger once.\n" +
                 "WARNNING: You should NOT use this unless you know what you are doing.")]
        public bool Repeat;
        
        protected override void Awake()
        {
            base.Awake();
            _particleSystem = GetComponent<ParticleSystem>();
            if (_particleSystem == null)
                Debug.LogError("You do not have a paraticle system on " + gameObject.name);
        }
        
        private void Update()
        { 
            // Skip if it has finished or there is no paraticle system.
            if (_finish || _particleSystem == null) return;
            bool isTirgger;
            switch (EventType)
            {
                case ParticleSystemEventType.Playing:
                    isTirgger = _particleSystem.isPlaying;
                    break;
                case ParticleSystemEventType.Pause:
                    isTirgger = _particleSystem.isPaused;
                    break;
                case ParticleSystemEventType.Stop:
                    isTirgger = _particleSystem.isStopped;
                    break;
                case ParticleSystemEventType.Dead:
                    isTirgger = !_particleSystem.IsAlive();
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