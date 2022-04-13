using UnityEngine;

namespace TDS.Infrastructure.Assets
{
    public class AssetsService : IAssetsService
    {
        public T GetAsset<T>(string path) where T : Object =>
            Resources.Load<T>(path);
    }
}