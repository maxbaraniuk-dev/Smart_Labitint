using Cysharp.Threading.Tasks;
using UI.Core;
using UnityEngine;

namespace Infrastructure
{
    public interface IUISystem : ISystem
    {
        public void ShowView<T>(Transform parent = null) where T : BaseView;
        
        public UniTask<T> ShowViewAsync<T>(Transform parent = null) where T : BaseView;
        
        public void ShowView<T, Tp>(Tp viewModel, Transform parent = null) where T : BaseDataView<Tp>;
        
        public UniTask<T> ShowViewAsync<T, Tp>(Tp viewData, Transform parent = null) where T : BaseDataView<Tp>;

        public void CloseView<T>() where T : BaseView;
        
        public UniTask CloseViewAsync<T>() where T : BaseView;
    }
}