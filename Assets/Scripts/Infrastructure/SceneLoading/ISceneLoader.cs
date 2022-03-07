using System;

namespace TDS.Infrastructure.SceneLoading
{
    public interface ISceneLoader
    {
        void Load(string sceneName, Action onLoaded = null);
    }
}