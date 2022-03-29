using TDS.Game.Utility;
using TDS.Infrastructure.Services;
using TDS.Infrastructure.StateMachine;
using TDS.Infrastructure.StateMachine.State;
using UnityEngine;

namespace TDS.Game.Object
{
    [RequireComponent(typeof(Collider2D))]
    public class TransitionTrigger : MonoBehaviour
    {
        [SerializeField] private string _transitionSceneName;

        private IGameStateMachine _stateMachine;
        private bool _isTriggered;

        private void Start()
        {
            _stateMachine = Services.Container.Get<IGameStateMachine>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_isTriggered)
                return;

            if (!other.CompareTag(Tags.Player))
                return;
            
            _isTriggered = true;
            _stateMachine.Enter<LoadingState, string>(_transitionSceneName);
        }
    }
}