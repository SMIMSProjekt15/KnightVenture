using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;

public class NamenSpeichern : MonoBehaviour
{
    public static NamenSpeichern instance;
    public Text myText;
    public InputField myInputField;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void Absenden()
    {
        print(myInputField.text);
    }
}