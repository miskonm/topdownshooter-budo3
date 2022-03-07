using System;
using System.Collections;
using TDS.Utility;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TDS.Infrastructure.SceneLoading
{
    public class AsyncSceneLoader : ISceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public AsyncSceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void Load(string sceneName, Action onLoaded = null) => 
            _coroutineRunner.StartCoroutine(LoadScene(sceneName, onLoaded));

        private IEnumerator LoadScene(string sceneName, Action onLoaded = null)
        {
            UnityEngine.Debug.Log($"Load AsyncSceneLoader");
            AsyncOperation waitScene = SceneManager.LoadSceneAsync(sceneName);
            
            while (!waitScene.isDone) 
                yield return null;

            onLoaded?.Invoke();
        }
    }
}