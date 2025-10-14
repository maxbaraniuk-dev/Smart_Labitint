namespace UI.Core
{
    /// <summary>
    /// Base class for views that are driven by an external view model of type <typeparamref name="T"/>.
    /// Provides a simple mechanism to set and access the bound data.
    /// </summary>
    public class BaseDataView<T> : BaseView
    {
        /// <summary>
        /// Currently bound view model instance.
        /// </summary>
        protected T ViewModel { get; private set; }

        /// <summary>
        /// Binds the provided <paramref name="viewModel"/> instance to the view.
        /// </summary>
        public void SetDataContext(T viewModel)
        {
            ViewModel = viewModel;
        }
    }
}