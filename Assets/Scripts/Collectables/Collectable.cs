using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Collecting : MonoBehaviour
{
    private int _cherriesCollected = 0;
    private int _gemsCollected = 0;
    [SerializeField] private TMP_Text _gemsText;
    [SerializeField] private TMP_Text _cherriesText;

    void OnTriggerEnter2D(Collider2D otherCol)
    {
        if(otherCol.tag == "Gem"){
            otherCol.gameObject.SetActive(false);
            _gemsCollected ++;
            UpdateText();
            return;
        }
        if(otherCol.tag == "Cherry"){
            otherCol.gameObject.SetActive(false);
            _cherriesCollected ++;
            UpdateText();
            return;
        }  
    }

    private void UpdateText(){
        _cherriesText.text = _cherriesCollected.ToString();
        _gemsText.text = _gemsCollected.ToString();
    }
}
