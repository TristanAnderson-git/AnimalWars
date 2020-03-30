using UnityEngine;

public class Billboard : MonoBehaviour
{
    private static Quaternion billboard;
    private bool billboardSet = false;

    void Awake()
    {
        if (!billboardSet)
        {
            billboard = Quaternion.LookRotation(Camera.main.transform.forward, Vector3.up);
            billboardSet = true;
        }
    }

    void LateUpdate()
    {
        transform.rotation = billboard;
    }
}