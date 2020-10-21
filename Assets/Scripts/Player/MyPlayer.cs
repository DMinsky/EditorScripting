using UnityEngine;

public class MyPlayer : MonoBehaviour
{

    public int armor;
    public int damage;
    [ContextMenuItem("Sukablyad", "Sukablyad")]
    public GameObject gun;
    [ContextMenuItem("Sukablyad", "Sukablyad")]
    [Curve]
    public ScaledCurve scaledCurve;
    
    [ContextMenuItem("Sukablyad", "Sukablyad")]
    public ScaledCurve scaledCurve02;
    
    private void Sukablyad()
    {
        Debug.Log("Sukablyad");
    }
    
}
