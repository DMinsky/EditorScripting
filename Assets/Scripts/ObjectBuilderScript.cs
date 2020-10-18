using System.Collections;
using UnityEngine;

public class ObjectBuilderScript : MonoBehaviour
{
    public GameObject obj;
    public Vector3 spawnPoint;

    public void BuildObject()
    {
        Instantiate(obj, spawnPoint, Quaternion.identity);
    }

    [ContextMenu("Hello")]
    private void Hello()
    {
        Debug.Log("Hello " + this.name);
    }

    [ContextMenu("Hello", true)]
    private bool HelloValidation()
    {
        return Random.Range(0, 3) == 2;
    }
}