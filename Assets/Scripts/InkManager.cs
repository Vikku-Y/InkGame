using Ink.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;
using UnityEngine.Audio;

public class InkManager : MonoBehaviour
{
    [SerializeField]
    private TextAsset _inkJsonAsset;
    private Story _story;

    [SerializeField]
    private TMP_Text _textField;

    [SerializeField]
    private AudioMixer audioMixer;

    [SerializeField]
    private VerticalLayoutGroup _choiceButtonsContainer;

    [SerializeField]
    private Button _choiceButtonPrefab;

    [SerializeField]
    private Color _normalTextColor;

    [SerializeField]
    private Color _narratorTextColor;

    private CharacterManager _characterManager;

    public GameObject TavernBackground;
    public GameObject OutsideBackground;

    public AudioClip RegularMusic;
    public AudioClip TensionMusic;

    // Start is called before the first frame update
    void Start()
    {
        _characterManager = FindObjectOfType<CharacterManager>();
        StartStory();

        audioMixer.SetFloat("MasterVolume", Mathf.Log10(PlayerPrefs.GetFloat("MasterVolume", 0.8f)) * 20);

        gameObject.GetComponentInChildren<AudioSource>().playOnAwake = false;
    }

    //Inicializa la historia
    void StartStory()
    {
        _story = new Story(_inkJsonAsset.text);
        //Conecta la llamada a función externa en ink con la función en código
        _story.BindExternalFunction("ShowCharacter", (string name, string position, string mood) =>
        _characterManager.CreateCharacter(name, position, mood));

        _story.BindExternalFunction("HideCharacter", (string name) => _characterManager.HideCharacter(name));

        _story.BindExternalFunction("ChangeMood", (string name, string mood) => _characterManager.ChangeMood(name, mood));

        _story.BindExternalFunction("ChangeScene", (string name) => ChangeScene(name));

        _story.BindExternalFunction("ChangeMusic", (string name) => ChangeMusic(name));

        DisplayNextLine();
    }

    private void ChangeScene(string sceneName)
    {
        switch (sceneName)
        {
            case "Tavern":
                TavernBackground.SetActive(true);
                OutsideBackground.SetActive(false);
                break;
            case "Outside":
                OutsideBackground.SetActive(true);
                TavernBackground.SetActive(false);
                break;
        }
    }
    private void ChangeMusic(string musicName)
    {
        switch (musicName)
        {
            case "Regular":
                GetComponentInChildren<AudioSource>().clip = RegularMusic;
                GetComponentInChildren<AudioSource>().Play();
                break;
            case "Tension":
                GetComponentInChildren<AudioSource>().clip = TensionMusic;
                GetComponentInChildren<AudioSource>().Play();
                break;
        }
    }

    //Muestra la siguiente linea de la historia
    public void DisplayNextLine()
    {
        if (_story.canContinue)
        {
            string text = _story.Continue(); //Recoge la siguiente linea y la guarda en text
            text = text?.Trim(); //Trim recorta los espacios sobrantes
            ApplyStyling();
            _textField.text = text;
        } else if (_story.currentChoices.Count > 0)
        {
            DisplayChoices();
        }
        
    }

    private void DisplayChoices()
    {
        if (_choiceButtonsContainer.GetComponentsInChildren<Button>().Length > 0) return; //Comprueba si hay elecciones mostrandose

        for (int i = 0; i < _story.currentChoices.Count; i++)
        {
            var choice = _story.currentChoices[i];
            var button = CreateChoiceButton(choice.text); //Crea boton de elección

            button.onClick.AddListener(() => OnClickButtonChoice(choice)); //Añade el escuchador para que se ejecute el codigo al pulsar el botón
        }
    }


    Button CreateChoiceButton(string text)
    {
        var newButton = Instantiate(_choiceButtonPrefab);
        newButton.transform.SetParent(_choiceButtonsContainer.transform, false);

        var buttonText = newButton.GetComponentInChildren<TMP_Text>();
        buttonText.text = text;

        return newButton;
    }

    //Seleccionar una opción de dialogo
    void OnClickButtonChoice(Choice choice)
    {
        _story.ChooseChoiceIndex(choice.index); //Le dice a ink cual de las opciones se ha escogido
        ClearChoices();
        _story.Continue();
        DisplayNextLine();
    }

    void ClearChoices()
    {
        if (_choiceButtonsContainer != null)
        {
            foreach (var button in _choiceButtonsContainer.GetComponentsInChildren<Button>())
            {
                Destroy(button.gameObject);
            }
        }
    }

    //Aplica estilos en base a los tags de la linea
    private void ApplyStyling()
    {
        if (_story.currentTags.Contains("narrador"))
        {
            _textField.color = _narratorTextColor;
        } else if (_story.currentTags.Contains("credit"))
        {
            _textField.text = "<b>" + _textField.text;
            _textField.alignment = TextAlignmentOptions.Center;
            _textField.verticalAlignment = VerticalAlignmentOptions.Middle;
        } else
        {
            _textField.color = _normalTextColor;
        }
    }
    public void changeMasterVolume(float sliderValue)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MasterVolume", sliderValue);
    }
}
