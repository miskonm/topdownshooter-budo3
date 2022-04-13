using TDS.Game.Enemy;
using UnityEditor;
using UnityEngine;

namespace TDS.Game.Editor
{
    [CustomEditor(typeof(EnemySpawnPoint))]
    public class EnemySpawnPointEditor : UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.Active)]
        public static void Draw(EnemySpawnPoint spawnPoint, GizmoType gizmoType)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(spawnPoint.transform.position, 0.5f);
        }
    }
}