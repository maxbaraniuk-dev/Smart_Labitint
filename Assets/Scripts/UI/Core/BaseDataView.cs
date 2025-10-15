namespace UI.Core
{
    public class BaseDataView<T> : BaseView
    {
        protected T ViewModel { get; private set; }

        public void SetDataContext(T viewModel)
        {
            ViewModel = viewModel;
        }
    }
}