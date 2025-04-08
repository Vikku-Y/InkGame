using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Assets.Scripts;
using System;

public class CharacterManager : MonoBehaviour
{
    private List<Character> _characters;

    [SerializeField]
    private GameObject _characterPrefab;

    [SerializeField]
    private CharacterMoods _amogusMoods;

    // Start is called before the first frame update
    void Awake()
    {
        _characters = new List<Character>();
    }

    public void CreateCharacter(string name, string position, string mood)
    {
        if (!Enum.TryParse(name, out CharacterName nameEnum))
        {
            Debug.LogWarning($"Fallo al parsear nombre de personaje a enum: {name}");
            return;
        }

        if (!Enum.TryParse(position, out CharacterPosition positionEnum))
        {
            Debug.LogWarning($"Fallo al parsear position de personaje a enum: {name}");
            return;
        }

        if (!Enum.TryParse(mood, out CharacterMood moodEnum))
        {
            Debug.LogWarning($"Fallo al parsear mood de personaje a enum: {name}");
            return;
        }
        
        CreateCharacter(nameEnum, positionEnum, moodEnum);
    }

    public void CreateCharacter (CharacterName name, CharacterPosition position, CharacterMood mood)
    {
        var character = _characters.FirstOrDefault(x => x.Name == name); //Mira los personajes de la lista, el primero

        if (character == null) //Si el personaje no existe en la listaa
        {
            var CharacterObject = Instantiate(_characterPrefab, gameObject.transform, false); //Crea el personaje

            character = CharacterObject.GetComponent<Character>(); //Coge su script

            _characters.Add(character); //Añade a la lista de personajes

            Debug.Log(character.Name);
        } else if (character.IsShowing)
        {
            Debug.LogWarning($"Error al mostrar personaje {name}, ya esta en pantalla");
            return;
        }

        character.Init(name, position, mood, GetMoodsetForCharacter(name));
    }
    public void HideCharacter(string name)
    {
        if (!Enum.TryParse(name, out CharacterName nameEnum))
        {
            Debug.LogWarning($"Fallo al parsear nombre de personaje a enum: {name}");
            return;
        }

        HideCharacter(nameEnum);
    }

    public void HideCharacter(CharacterName name)
    {
        var character = _characters.FirstOrDefault(_x => _x.Name == name);

        if (character?.IsShowing != true)
        {
            Debug.LogWarning($"Character {name} no esta siendo mostrado, no se puede esconder");
        }
        else
        {
            character?.Hide();
        }
    }

    public void ChangeMood(string name, string mood) 
    {
            if (!Enum.TryParse(name, out CharacterName nameEnum))
            {
                Debug.LogWarning($"Fallo al parsear nombre de personaje a enum: {name}");
                return;
            }

            if (!Enum.TryParse(mood, out CharacterMood moodEnum))
            {
                Debug.LogWarning($"Fallo al parsear mood de personaje a enum: {name}");
                return;
            }

            ChangeMood(nameEnum, moodEnum);
    }

    public void ChangeMood(CharacterName name, CharacterMood mood)
    {
        var character = _characters.FirstOrDefault(x =>x.Name == name);

        if (character?.IsShowing != true)
        {
            Debug.LogWarning($"El character {name} no está en pantalla");
            return;
        } else
        {
            character.ChangeMood(mood);
        }
    }

    private CharacterMoods GetMoodsetForCharacter(CharacterName name)
    {
        switch (name)
        {
            case CharacterName.Amogus:
                return _amogusMoods;
            default:
                Debug.LogError($"No se encontró el moodset de {name}");
                return null;

        }
    }
}
