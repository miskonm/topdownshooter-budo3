using System.Collections.Generic;
using TDS.Game.Common;
using UnityEditor;
using UnityEngine;

namespace TDS.Game.Editor
{
    [CustomEditor(typeof(PatrolPath))]
    public class PatrolPathEditor : UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.Pickable | GizmoType.Active | GizmoType.InSelectionHierarchy)]
        public static void Draw(PatrolPath patrolPath, GizmoType gizmoType)
        {
            List<Transform> points = patrolPath.Points;

            if (points == null || points.Count == 0)
                return;

            Transform previousPoint = points[0];

            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(previousPoint.position, 0.2f);

            for (int i = 1; i < points.Count; i++)
            {
                Transform currentPoint = points[i];
                Gizmos.color = Color.blue;
                Gizmos.DrawSphere(currentPoint.position, 0.2f);

                Gizmos.color = Color.red;
                Gizmos.DrawLine(previousPoint.position, currentPoint.position);
                previousPoint = currentPoint;
            }

            Gizmos.color = Color.red;
            Gizmos.DrawLine(points[points.Count - 1].position, points[0].position);
        }
    }
}