using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "stat", menuName = "Common/Stat")]
public class Stat : ScriptableObject
{
    public float hp = 100f;
    public float moveSpeed = 5f;
    public float attack = 1f;
    public float defend = 1f;
    public int xp = 0;
}
