using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI keyCounterText;

    public void UpdateKeyCounter(int currentKeys, int totalKeys)
    {
        if (keyCounterText != null)
        {
            keyCounterText.text = currentKeys + "/" + totalKeys;
        }
        else
        {
            Debug.LogWarning("KeyCounterText ยังไม่ได้เชื่อมใน Inspector");
        }
    }
}