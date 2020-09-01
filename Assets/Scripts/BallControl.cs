using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{

    private Rigidbody2D rigidbody2D;

    public float xInitialForce;
    public float yInitialForce;
    public float ballForce;

    // titik asal lintasan bola
    private Vector2 trajectorayOrigin;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        trajectorayOrigin = transform.position;
        // Mulai game
        RestartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        trajectorayOrigin = transform.position;
    }

    // untuk mengakses informasi titik asal lintasan
    public Vector2 TrajectoryOrigin
    {
        get { return trajectorayOrigin; }
    }

    void ResetBall()
    {
        // reset posisi ke (0,0)
        transform.position = Vector2.zero;
        // reset kecepatan
        rigidbody2D.velocity = Vector2.zero;
    }

    void PushBall()
    {
        // bikin daya dorong secara acak
        float yRandomInitialForce = Random.Range(-yInitialForce, yInitialForce);

        // tentukan arahnya secara acak
        float randomDirection = Random.Range(0, 2);

        if (randomDirection < 1.0f)
        {
            // gerakan ke kanan
            rigidbody2D.AddForce(new Vector2(-xInitialForce, yRandomInitialForce).normalized * ballForce);
        }
        else
        {
            rigidbody2D.AddForce(new Vector2(xInitialForce, yRandomInitialForce).normalized * ballForce);
        }
    }

    void RestartGame()
    {
        ResetBall();
        Invoke("PushBall", 2);
    }
}
