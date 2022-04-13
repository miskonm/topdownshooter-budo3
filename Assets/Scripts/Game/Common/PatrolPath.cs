using System.Collections.Generic;
using UnityEngine;

namespace TDS.Game.Common
{
    public class PatrolPath : MonoBehaviour
    {
        [SerializeField] private List<Transform> _points;

        [SerializeField] private int _currentIndex;

        public List<Transform> Points => _points;

        public Transform CurrentPoint() =>
            _points[_currentIndex];

        public bool IsReachPosition(Vector3 currentPosition, float distanceToNextPoint)
        {
            Vector3 pointPosition = CurrentPoint().position;
            float distance = Vector2.Distance(pointPosition, currentPosition);
            return distance <= distanceToNextPoint;
        }

        public void SetNextPoint()
        {
            _currentIndex++;

            if (_currentIndex >= _points.Count)
                _currentIndex = 0;
        }
    }
}