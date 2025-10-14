using System;

namespace Infrastructure
{
    /// <summary>
    /// Common lifecycle contract for application systems/services.
    /// </summary>
    public interface ISystem : IDisposable
    {
        /// <summary>
        /// Performs system initialization (e.g., allocate resources, subscribe to events).
        /// </summary>
        void Initialize();
    }
}