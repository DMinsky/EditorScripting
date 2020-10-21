using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( BoxCollider ) )]
public class Relic : MonoBehaviour
{
    public float currHP = 1.5f;
    public int maxHP = 10;

    public enum RelicType
    {
        Heartbreaker,
        MaskedSpider,
        ScorpionTail,
        BladedPinchers
    }

    public RelicType relicType;

    // void OnDrawGizmos()
    // {
    //     string customName = "Relics\\" + relicType + ".png";
    //     Gizmos.DrawIcon( transform.position, customName, true );
    // }
}
