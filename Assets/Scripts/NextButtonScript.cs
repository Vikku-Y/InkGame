using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextButtonScript : MonoBehaviour
{
    private InkManager _inkmanager;

    // Start is called before the first frame update
    void Start()
    {
        _inkmanager = FindObjectOfType<InkManager>();

        Button myButton = GetComponent<Button>();
        myButton.onClick.AddListener(OnClick);

        if (_inkmanager == null )
        {
            Debug.LogError("NO HAY NO HAY");
        }
    }

    public void OnClick()
    {
        _inkmanager?.DisplayNextLine();
    }
}
