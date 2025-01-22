using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EDD
{
    public class SceneManager
    {
        public static string CurrentSceneName { get; private set; }

        private const string LoadSceneName = "Loading";

        public static async UniTask ChangeScene(string sceneName)
        { 
            if (!string.IsNullOrEmpty(CurrentSceneName))
                await UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(CurrentSceneName); 
            
            await UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(LoadSceneName, LoadSceneMode.Additive);

            Loading loading = null;
            
            do
            {
                loading = GameObject.FindFirstObjectByType<Loading>();
                if (loading)
                    await loading.AppearAsync();

            } while (!loading || !loading.IsLoadingAnimComplete);
            
            var sceneAsync = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            if (sceneAsync == null)
                return;

            CurrentSceneName = sceneName;
            
            while (!sceneAsync.isDone)
                await UniTask.WaitForEndOfFrame();
            
            await loading.DisappearAsync();
            
            await UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(LoadSceneName);
        }
    }
}
