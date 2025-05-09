using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            if (player != null && player.hasKey)
            {
                Debug.Log("ชนะแล้ว!");
                SceneManager.LoadScene("Ui_Win");
            }
            else
            {
                Debug.Log("ยังไม่มีลูกกุญแจนะ!");
            }
        }
    }
}
