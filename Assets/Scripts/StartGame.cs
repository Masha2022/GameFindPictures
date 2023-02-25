using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UIElements.Image;

public class StartGame : MonoBehaviour
{
    private IReadOnlyList<Sprite> LettersSprites => _lettersSprites;
    private IReadOnlyList<Sprite> NumbersSprites => _numbersSprites;
    private IReadOnlyList<Sprite> AnimalsSprites => _animalsSprites;
    
    [SerializeField] private List<Sprite> _lettersSprites;
    [SerializeField]private List<Sprite> _numbersSprites;
    [SerializeField]private List<Sprite> _animalsSprites;
    
    [SerializeField] private Canvas _playMode;
    [SerializeField] private Canvas _endMode;
    
    private IReadOnlyList<Sprite> _spritesForGame = new List<Sprite>();

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
                _playMode.GetComponent<LevelSettings>().ChangeMode();
                
                break;
            case 1:
                _spritesForGame = NumbersSprites;
                _playMode.GetComponent<LevelSettings>().ChangeMode();
                
                break;
            case 2:
                _spritesForGame = AnimalsSprites;
                _playMode.GetComponent<LevelSettings>().ChangeMode();
                
                break;
        }
    }

    public IReadOnlyList<Sprite> GetSetSprites()
    {
        return _spritesForGame;
    }
}
