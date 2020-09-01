using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWall : MonoBehaviour
{

    // Pemain yang akan bertambah skornya jika bola menyentuh dinding ini.
    public PlayerControl player;

    [SerializeField]
    private GameManager gameManager;

    void OnTriggerEnter2D(Collider2D anotherCollider)
    {
        if (anotherCollider.name == "Ball")
        {
            player.IncrementScore();

            if (player.Score < gameManager.maxScore)
            {
                anotherCollider.gameObject.SendMessage("RestartGame", 2.0f, SendMessageOptions.RequireReceiver);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
