// ReSharper disable CheckNamespace

namespace AvalonAssets.Unity.Event
{
    /// <summary>
    ///     Event types used by <see cref="ParticleSystemEventTrigger" />
    /// </summary>
    /// <seealso cref="ParticleSystemEventTrigger" />
    public enum ParticleSystemEventType
    {
        /// <summary>
        ///     Particle system is playing.
        /// </summary>
        Playing,

        /// <summary>
        ///     Particle system is paused.
        /// </summary>
        Pause,

        /// <summary>
        ///     Particle system is paused.
        /// </summary>
        Stop,

        /// <summary>
        ///     All particles in Particle system is dead.
        /// </summary>
        Dead
    }
}