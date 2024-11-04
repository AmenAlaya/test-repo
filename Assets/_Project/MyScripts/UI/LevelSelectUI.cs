using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectUI : MonoBehaviour
{
    [SerializeField] private int _levelCount = 5;

    [SerializeField] private LevelBtn _levelSelectUI;
    [SerializeField] private Transform _levelParent;


    private void Awake()
    {
        for (int i = 0; i < _levelCount; i++)
        {
            LevelBtn levelBtn = Instantiate(_levelSelectUI, _levelParent);
            levelBtn.SetIndex(i);
        }
    }
}
