using UnityEngine;
using UnityEditor;
using System.Collections;

public class Example : EditorWindow
{
    [MenuItem("Window/Example")]

    public static void  ShowWindow()
    {
        EditorWindow.GetWindow(typeof(Example));
    }

    void OnEnable()
    {
        EditorApplication.contextualPropertyMenu += OnPropertyContextMenu;
    }

    void OnDestroy()
    {
        EditorApplication.contextualPropertyMenu -= OnPropertyContextMenu;
    }

    void OnPropertyContextMenu(GenericMenu menu, SerializedProperty property)
    {
        // show a custom menu item only for Vector3 properties
        if (property.propertyType != SerializedPropertyType.Vector3)
            return;

        // and only when called on a Transform component
        if (property.serializedObject.targetObject.GetType() != typeof(Transform))
            return;

        var propertyCopy = property.Copy();
        menu.AddItem(new GUIContent("Randomize Vector"), false, () =>
        {
            propertyCopy.vector3Value = Random.insideUnitSphere * 5;
            propertyCopy.serializedObject.ApplyModifiedProperties();
        });
    }
}