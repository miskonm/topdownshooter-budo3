using System;
using TDS.Infrastructure.Services;

namespace TDS.Infrastructure.SceneLoading
{
    public interface ISceneLoader : IService
    {
        void Load(string sceneName, Action onLoaded = null);
    }
}