using System;
using UnityEngine.SceneManagement;

namespace TDS.Infrastructure.SceneLoading
{
    public class SyncSceneLoader : ISceneLoader
    {
        public void Load(string sceneName, Action onLoaded = null)
        {
            UnityEngine.Debug.Log($"Load SyncSceneLoader");
            SceneManager.LoadScene(sceneName);
            
            onLoaded?.Invoke();
        }
    }
}