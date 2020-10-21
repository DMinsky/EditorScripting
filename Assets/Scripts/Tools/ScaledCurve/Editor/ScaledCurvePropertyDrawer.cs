using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer( typeof( CurveAttribute ) )]
public class ScaledCurvePropertyDrawer : PropertyDrawer
{
    const float curveWidth = 60f;

    void Expand() 
    {
        Debug.Log("Expand");
    }

    static void Unexpand() 
    {
        Debug.Log("Unexpand");
    }

    public override void OnGUI( Rect pos, SerializedProperty property, GUIContent label )
    {
        // Custom context menu
        Event e = Event.current;     
        if (e.type == EventType.MouseDown && e.button == 1 && pos.Contains(e.mousePosition)) {         
            GenericMenu context = new GenericMenu ();         
            context.AddItem (new GUIContent ("Expand"), false, Expand);
            context.AddItem (new GUIContent ("Unexpand"), false, Unexpand);         
            context.ShowAsContext ();
        }

        var animationCurveProp = property.FindPropertyRelative( "animationCurve" );
        var scaleProp = property.FindPropertyRelative( "scale" );

        int indent = EditorGUI.indentLevel;
        EditorGUI.Slider( 
            new Rect( pos.x, pos.y, pos.width - curveWidth - 20f, pos.height ), 
            scaleProp, 
            ScaledCurve.minScale, 
            ScaledCurve.maxScale, 
            label );
        EditorGUI.indentLevel = 0;
        EditorGUI.PropertyField(
            new Rect( pos.width - curveWidth + 20f, pos.y, curveWidth, pos.height),
            animationCurveProp,
            GUIContent.none );
        EditorGUI.indentLevel = indent;

    }

}