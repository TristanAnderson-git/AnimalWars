using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Building", menuName = "Animals/Building")]
public class BuildingData : ScriptableObject
{
    public new string name;
    [TextArea]
    public string description;
    public Sprite portrait;
    public GameObject prefab;
    public int cost;
}
