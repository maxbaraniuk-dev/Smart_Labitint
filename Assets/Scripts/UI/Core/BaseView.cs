using Cysharp.Threading.Tasks;
using UnityEngine;

namespace UI.Core
{
    public abstract class BaseView : MonoBehaviour
    {
        [SerializeField] private ViewLayer layer;

        public ViewLayer Layer => layer;

        public virtual UniTask Show()
        {
            return UniTask.CompletedTask;
        }

        public virtual UniTask Show<T>(T viewModel)
        {
            return UniTask.CompletedTask;
        }

        public virtual UniTask Close()
        {
            return UniTask.CompletedTask;
        }
    }
}