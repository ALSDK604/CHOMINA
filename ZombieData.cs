using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/ZombieData", fileName = "Zombie Data")]
public class ZombieData : ScriptableObject
{
    public float health = 3;
    public float damage = 10;
}
