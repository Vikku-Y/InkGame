using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class CharacterMoods : MonoBehaviour
{
    public CharacterName Name;
    public Sprite Neutral;
    public Sprite Victory;
    public Sprite Pensive;

    public Sprite GetMoodSprite(CharacterMood mood)
    {
        switch (mood) { 
            case CharacterMood.Neutral:
                return Neutral;
            case CharacterMood.Victory:
                return Victory ?? Neutral;
            case CharacterMood.Pensive:
                return Pensive ?? Neutral;
            default:
                Debug.Log($"No se encontró el sprite {mood} del personaje {Name}");
                return Neutral;
        }
    }
}
