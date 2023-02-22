using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Canvas _startMode;
    

    private void Awake()
    {
       var _sprites = _startMode.GetComponent<ScriptableObject>().GetSetSprites();
    }
}
