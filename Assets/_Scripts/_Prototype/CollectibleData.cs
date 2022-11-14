using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Collectible Data")]
public class CollectibleData : ScriptableObject
{
    public string _name;
    public int _score;
    public int _heal;
    public GameObject _prefab;
}
