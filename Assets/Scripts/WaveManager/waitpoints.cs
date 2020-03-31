using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waitpoints : MonoBehaviour
{
    // Start is called before the first frame update
    public static Transform[] points;

    void Awake ()
    {
        points = new Transform[transform.childCount];

        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }

#if UNITY_EDITOR
    public bool refresh;

    private void OnDrawGizmos()
    {
        if (points == null || refresh)
        {

            points = new Transform[transform.childCount];
            
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = transform.GetChild(i);
            }

            refresh = false;
        }

        DrawDebugPath(points);
    }

    void DrawDebugPath(Transform[] path)
    {
        if (path.Length > 1)
        {
            for (int i = 1; i < path.Length; i++)
                Gizmo.DrawLine(path[i - 1].position + Vector3.up * 0.1f, path[i].position + Vector3.up * 0.1f, Color.red);
        }
    }
#endif
}
