using System.Collections;
using TDS.Infrastructure.Services;
using UnityEngine;

namespace TDS.Utility
{
    public interface ICoroutineRunner : IService
    {
        Coroutine StartCoroutine(IEnumerator routine);
    }
}