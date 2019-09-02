using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Collectable : MonoBehaviour
{
    private int _cherriesCollected;
    private int _gemsCollected;
    [SerializeField] private TMP_Text _gemsText;
    [SerializeField] private TMP_Text _cherriesText;

    void OnTriggerEnter2D(Collider2D otherCol)
    {
        if(otherCol.tag == "Gem"){
            _gemsCollected++;
            otherCol.gameObject.SetActive(false);
        }
        if(otherCol.tag == "Cherry"){
            _cherriesCollected++;
            otherCol.gameObject.SetActive(false);
        }  
    }

    private void Update(){
        _cherriesText.text = _cherriesCollected.ToString();
        _gemsText.text = _gemsCollected.ToString();
    }
}
