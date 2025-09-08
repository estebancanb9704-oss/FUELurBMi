using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Security.Cryptography;

public class PlayerUI : MonoBehaviour 
{
    [SerializeField]
    private TextMeshProUGUI promtText;

    void Start() 
    {

    }

    public void UpdateText(string promptMessage) 
    {
        promtText.text = promptMessage;
    }



}
