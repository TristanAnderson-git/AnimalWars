#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class Gizmo
{
    public enum Filter { None = 0, Agent, Action, All };
    public static Filter show;

    public static bool IsPlaying { get { return Application.isPlaying; } }
    public static GameObject SelectedInHierachy { get { return Selection.activeGameObject; } }

    public static void DrawText(Vector3 position, string text)
    {
        Handles.Label(position, text);
    }

    public static void DrawLine(Vector3 from, Vector3 to, Color colour)
    {
        Gizmos.color = colour;

        Gizmos.DrawLine(from, to);
    }

    public static void DrawCircle(Vector3 position, int segments, float scale, Color colour)
    {
        Gizmos.color = colour;

        Vector3 from, to;
        for (int i = 0; i < segments; i++)
        {
            float angle = i * (2f * Mathf.PI / segments);
            from = new Vector3(Mathf.Cos(angle) * scale, 0.1f, Mathf.Sin(angle) * scale);

            angle = (i + 1) % segments * (2f * Mathf.PI / segments);
            to = new Vector3(Mathf.Cos(angle) * scale, 0.1f, Mathf.Sin(angle) * scale);

            Gizmos.DrawLine(from + position, to + position);
        }
    }
}
#endif