
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class SceneViewPivot
{

    private static bool _setPivotOnMouseUp;

    static SceneViewPivot()
    {
        SceneView.duringSceneGui += OnSceneGUI;
    }

    private static void OnSceneGUI(SceneView sceneView)
    {
        Event e = Event.current;

        if (e.type == EventType.MouseDown)
        {
            _setPivotOnMouseUp = (e.button == 2);
        }
        else if (e.type == EventType.MouseDrag)
        {
            _setPivotOnMouseUp = false;
        }
        else if (e.type == EventType.MouseUp && _setPivotOnMouseUp)
        {
            UpdatePivot(sceneView, e.mousePosition);
            _setPivotOnMouseUp = false;
        }
    }

    private static void UpdatePivot(SceneView sceneView, Vector2 mousePosition)
    {
        Ray ray = HandleUtility.GUIPointToWorldRay(mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            sceneView.pivot = hitInfo.point;
            sceneView.size = (hitInfo.distance / 2.0f);
        }
    }
}
