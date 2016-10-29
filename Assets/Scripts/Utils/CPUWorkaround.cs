#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class CPUWorkaround : EditorWindow
{
    [MenuItem("Window/CPU Workaround")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<CPUWorkaround>("100% CPU Workaround", true, typeof(EditorWindow)).minSize = Vector2.zero;
    }
    void OnGUI()
    {
        this.Repaint();
    }
}
#endif