using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UIElements.Image;

public class ScriptableObject : MonoBehaviour
{
    //ScriptableObject(над названием подумаем) должен возвращать выбранный набор в GameController
    private IReadOnlyList<Sprite> LettersSprites => _lettersSprites;
    private IReadOnlyList<Sprite> NumbersSprites => _numbersSprites;
    private IReadOnlyList<Sprite> AnimalsSprites => _animalsSprites;
    
    [SerializeField] private List<Sprite> _lettersSprites;
    [SerializeField]private List<Sprite> _numbersSprites;
    [SerializeField]private List<Sprite> _animalsSprites;
    
    private List<Sprite> _spritesForGame = new List<Sprite>();
    
    public void ButtonClick(int indexForSet)
    {
        switch (indexForSet)
        {
            case 0:
                foreach (var sprite in LettersSprites)
                {
                    _spritesForGame.Add(sprite);
                }
                Debug.Log("ButtonClick letters");
                break;
            case 1:
                foreach (var sprite in NumbersSprites)
                {
                    _spritesForGame.Add(sprite);
                }
                Debug.Log("ButtonClick numbers");
                break;
            case 2:
                foreach (var sprite in AnimalsSprites)
                {
                    _spritesForGame.Add(sprite);
                }
                Debug.Log("ButtonClick animals " +_spritesForGame.Count);
                break;
        }
    }

    public List<Sprite> GetSetSprites()//публичнй чтобы вызвать в GameController
    {
        return _spritesForGame;
    }
}
