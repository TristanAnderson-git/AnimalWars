using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "Animals/Unit")]
public class UnitData : ScriptableObject
{
    public new string name;
    [TextArea]
    public string description;
    public Sprite portrait;
    public int cost;

    [Space]
    public int health;
    public Stats stats;
}
