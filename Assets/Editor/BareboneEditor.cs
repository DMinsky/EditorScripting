using UnityEditor;

[CustomEditor(typeof(Barebone))]
public class BareboneEditor : Editor
{
    private SerializedProperty healtProperty;

    void OnEnabled()
    {
        healtProperty = serializedObject.FindProperty("health");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        // Do some stuff

        serializedObject.ApplyModifiedProperties();
    }
}
