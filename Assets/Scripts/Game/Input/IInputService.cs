using TDS.Infrastructure.Services;
using UnityEngine;

namespace TDS.Game.Input
{
    public interface IInputService : IService
    {
        Vector2 Axis { get; }
        Vector3 MousePosition { get; } // TODO: Change to V2 LookDirection

        bool IsFireButtonClicked();
    }
}