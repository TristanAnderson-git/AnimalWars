using UnityEditor;
using UnityEngine;

public class EditorCustomGizmoWindow : EditorWindow
{
    [MenuItem("Window/Custom Gizmo")]
    public static void Open()
    {
        GetWindow<EditorCustomGizmoWindow>().titleContent.text = "Custom Gizmo Properties";
    }

    void OnGUI()
    {
        GUILayout.Label("Action Display");
        Gizmo.show = (Gizmo.Filter)EditorGUILayout.EnumPopup("Filter: ", Gizmo.show);
    }
}
