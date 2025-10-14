using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Logs;
using UI;
using UI.Core;
using UnityEngine;

namespace Infrastructure
{
    public class UISystem : MonoBehaviour, IUISystem
    {
        ILog _log;
        [SerializeField] private UIConfig uiConfig;
        
        private UIContainer _uiContainer;
        readonly List<BaseView> _openedViews = new();
        
        public void Initialize()
        {
            _log = Context.GetSystem<ILog>();
            _log.Debug(() => "UIManager initialized");
            _uiContainer = Instantiate(uiConfig.GetUIContainerPrefab());
        }

        public void Dispose() { }
        
        public void ShowView<T>(Transform parent = null) where T : BaseView
        {
            ShowViewAsync<T>(parent).Forget();
        }

        public async UniTask<T> ShowViewAsync<T>(Transform parent = null) where T : BaseView
        {
            var view = CreateView<T>(parent);
            await view.Show();
            return view;
        }
        
        public void ShowView<T, Tp>(Tp viewModel, Transform parent = null) where T : BaseDataView<Tp>
        {
            ShowViewAsync<T, Tp>(viewModel, parent).Forget();
        }
        
        public async UniTask<T> ShowViewAsync<T, Tp>(Tp viewData, Transform parent = null) where T : BaseDataView<Tp>
        {
            var view = CreateView<T>(parent);
            view.SetDataContext(viewData);
            await view.Show(viewData);
            return view;
        }

        public void CloseView<T>() where T : BaseView
        {
            CloseViewAsync<T>().Forget();
        }

        public async UniTask CloseViewAsync<T>() where T : BaseView
        {
            var view = _openedViews.FirstOrDefault(view => view is T);
            if (view == null)
            {
                _log.Warning(()=> $"There is no opened view with type {typeof(T)}");
                return;
            }
            
            await view.Close();
            _openedViews.Remove(view);
            Destroy(view.gameObject);
        }

        private T CreateView<T>(Transform parent = null) where T : BaseView
        {
            var openedView = _openedViews.FirstOrDefault(view => view is T);
            if (openedView != null) 
                return openedView as T;
            
            var widgetPrefab = uiConfig.GetView<T>();
            if (widgetPrefab == null)
            {
                _log.Error(() => $"There no prefab with type {typeof(T)}");
                return null;
            }

            var root = _uiContainer.GetLayerRoot(widgetPrefab.Layer);
            var view = Instantiate(widgetPrefab, parent == null ? root : parent);
            _openedViews.Add(view);
            return view;
        }
    }
}