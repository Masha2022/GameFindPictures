using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UIElements.Image;

public class ScriptableObject : MonoBehaviour
{
    //ScriptableObject(над названием подумаем) должен возвращать выбранный набор в LevelSetting
    private IReadOnlyList<Sprite> LettersSprites => _lettersSprites;
    private IReadOnlyList<Sprite> NumbersSprites => _numbersSprites;
    private IReadOnlyList<Sprite> AnimalsSprites => _animalsSprites;
    
    [SerializeField] private List<Sprite> _lettersSprites;
    [SerializeField]private List<Sprite> _numbersSprites;
    [SerializeField]private List<Sprite> _animalsSprites;
    
    public IReadOnlyList<Sprite> _spritesForGame = new List<Sprite>();

   // [SerializeField] private Camera _camera;
    [SerializeField] private Canvas _playMode;
    [SerializeField] private Canvas _endMode;

    private void Start()
    {
        _playMode.enabled = false;
        _endMode.enabled = false;
    }

    public void ButtonClick(int indexForSet)
    {
        switch (indexForSet)
        {
            case 0:
                _spritesForGame = LettersSprites;
                Debug.Log("ButtonClick letters"+_spritesForGame.Count);
                _playMode.GetComponent<LevelSetting>().ChangeMode();
                break;
            case 1:
                _spritesForGame = NumbersSprites;
                Debug.Log("ButtonClick numbers"+_spritesForGame.Count);
                _playMode.GetComponent<LevelSetting>().ChangeMode();
                break;
            case 2:
                _spritesForGame = AnimalsSprites;
                _playMode.GetComponent<LevelSetting>().ChangeMode();
                Debug.Log("ButtonClick animals " +_spritesForGame.Count);
                break;
        }
    }

    public IReadOnlyList<Sprite> GetSetSprites()//публичнй чтобы вызвать в LevelSetting
    {
        return _spritesForGame;
    }
}
