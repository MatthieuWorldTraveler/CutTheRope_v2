using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO")]
public class LevelsSO : ScriptableObject
{
    [SerializeField] string _menuName;

    [SerializeField] string[] _levelNames;
    [SerializeField] int _currentIndex = 0;

    public string[] LevelNames { get => _levelNames; }
    public string MenuName { get => _menuName; }
    public int CurrentIndex { get => _currentIndex; set => _currentIndex = value; }
}
