using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class setupSelf : MonoBehaviour
{
    [SerializeField] private TMP_Text textNum;
    [SerializeField] private TMP_Text textData;

    public string selfNum;
    public string selfText;

    public void SetData(string _textNum, string _textData)
    {
        textNum.text = _textNum;
        textData.text = _textData;
        selfNum = _textNum;
        selfText = _textData;
    }

    public void Setname(string _textData)
    {
        textData.text = _textData;
        selfText = _textData;
    }

    public void RemoveSelf()
    {
        GameManager.instance.removeFromList(selfText);
    }

}
