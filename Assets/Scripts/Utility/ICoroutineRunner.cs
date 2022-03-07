using System.Collections;
using UnityEngine;

namespace TDS.Utility
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator routine);
    }
}