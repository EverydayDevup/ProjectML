using Cysharp.Threading.Tasks;
using UnityEngine;

namespace EDD
{
    public class Loading : MonoBehaviour
    {
        public bool IsLoadingAnimComplete { get; private set; } = false;
        private bool IsAppearAnim { get; set; } = false;
        
        public async UniTask AppearAsync()
        {
            if (IsAppearAnim)
                return;

            IsAppearAnim = true;
            
            await PlayAsync();
            IsLoadingAnimComplete = true;
        }

        protected async UniTask PlayAsync() { }
        
        public virtual async UniTask DisappearAsync()
        {
            IsAppearAnim = false;
        }
    }
}