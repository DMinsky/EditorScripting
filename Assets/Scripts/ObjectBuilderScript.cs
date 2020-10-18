using System.Collections;
using UnityEngine;

public class ObjectBuilderScript : MonoBehaviour
{
    public GameObject obj;

    [ContextMenuItem("Randomize", "RandomizeSpawnPoint")]
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

    private void RandomizeSpawnPoint()
    {
        spawnPoint = Vector3.one * Random.Range(0.1f, 18f);
    }
}