using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    public Sprite emptyHeart;
    public Sprite fullHeart;
    public Image[] hearts;

    public Player player;

    void Start()
    {
        if (player == null)
        {
            player = FindObjectOfType<Player>();
        }
    }

    void Update()
    {
        if (player == null) return;

        int health = player.playerHealth / 20;

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;

            hearts[i].enabled = i < 5;
        }
    }
}
