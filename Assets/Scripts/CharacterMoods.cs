using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class CharacterMoods : MonoBehaviour
{
    public CharacterName Name;
    public Sprite Normal;
    public Sprite Angry;
    public Sprite Sigh;
    public Sprite Happy;

    public Sprite GetMoodSprite(CharacterMood mood)
    {
        switch (mood) { 
            case CharacterMood.Normal:
                return Normal;
            case CharacterMood.Angry:
                return Angry ?? Normal;
            case CharacterMood.Sigh:
                return Sigh ?? Normal;
            case CharacterMood.Happy:
                return Happy ?? Normal;
            default:
                Debug.Log($"No se encontró el sprite {mood} del personaje {Name}");
                return Normal;
        }
    }
}
