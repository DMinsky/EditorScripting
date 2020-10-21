using UnityEngine;

[System.Serializable]
public class ScaledCurve
{
    [ContextMenuItem("Sukablyad", "Suka")]
    public float scale = 1f;
    public const float minScale = 0f;
    public const float maxScale = 1f;
    
    [ContextMenuItem("Sukablyad", "Suka")]
    public AnimationCurve animationCurve = AnimationCurve.Linear( 0f, 0f, 1f, 1f );

    private void Suka()
    {
        Debug.Log("Sukablyad");
    }

}