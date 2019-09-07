using UnityEngine;
using TMPro;

public class Collectable : MonoBehaviour
{
    private int _cherriesCollected = 0;
    private int _gemsCollected = 0;
    [SerializeField] private TMP_Text _gemsText;
    [SerializeField] private TMP_Text _cherriesText;

    void OnTriggerEnter2D(Collider2D otherCol)
    {
        if (otherCol.tag == "Gem")
        {
            otherCol.gameObject.GetComponent<Animator>().SetTrigger("Collected");
            otherCol.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            _gemsCollected++;
            UpdateText();
            return;
        }
        if (otherCol.tag == "Cherry")
        {
            otherCol.gameObject.GetComponent<Animator>().SetTrigger("Collected");
            otherCol.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            _cherriesCollected++;
            UpdateText();
            return;
        }
    }

    private void UpdateText()
    {
        _cherriesText.text = _cherriesCollected.ToString();
        _gemsText.text = _gemsCollected.ToString();
    }
}
