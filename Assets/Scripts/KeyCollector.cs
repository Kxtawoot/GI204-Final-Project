using UnityEngine;
using TMPro;

public class KeyCollector : MonoBehaviour
{
    public int totalKeys = 1;
    private int keysCollected = 0;

    public TextMeshProUGUI keyText;

    void Start()
    {
        UpdateKeyUI();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Key"))
        {
            keysCollected++;
            Destroy(other.gameObject);
            UpdateKeyUI();
        }
    }

    void UpdateKeyUI()
    {
        keyText.text = keysCollected + "/" + totalKeys;
    }
}