using TDS.Infrastructure.Services;
using UnityEngine;

namespace TDS.Infrastructure.Assets
{
    public interface IAssetsService : IService
    {
        T GetAsset<T>(string path) where T : Object;
    }
}