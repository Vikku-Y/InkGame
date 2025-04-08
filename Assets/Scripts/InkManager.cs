using Ink.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

public class InkManager : MonoBehaviour
{
    [SerializeField]
    private TextAsset _inkJsonAsset;
    private Story _story;

    [SerializeField]
    private TMP_Text _textField;

    [SerializeField]
    private VerticalLayoutGroup _choiceButtonsContainer;

    [SerializeField]
    private Button _choiceButtonPrefab;

    [SerializeField]
    private Color _normalTextColor;

    [SerializeField]
    private Color _thoughtTextColor;

    private CharacterManager _characterManager;

    // Start is called before the first frame update
    void Start()
    {
        _characterManager = FindObjectOfType<CharacterManager>();
        StartStory();
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

        DisplayNextLine();
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
        if (_story.currentTags.Contains("pensamiento"))
        {
            _textField.color = _thoughtTextColor;
            //_textField.fontStyle = TMP_Style.; <- SE PONE EN CURSIVA
        } else
        {
            _textField.color = _normalTextColor;
            //Estilo normal
        }
    }
}
