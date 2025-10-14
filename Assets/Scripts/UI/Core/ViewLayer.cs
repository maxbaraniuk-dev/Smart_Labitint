namespace UI.Core
{
    /// <summary>
    /// Logical layers used to organize UI hierarchy and control z-ordering.
    /// </summary>
    public enum ViewLayer
    {
        /// <summary>Persistent UI elements that remain across scenes (HUD, overlays).</summary>
        PersistenceUI = 0,
        /// <summary>Modal and non-modal dialogs.</summary>
        Dialogs = 1,
        /// <summary>Transient notifications and toasts.</summary>
        Notifications = 2
    }
}