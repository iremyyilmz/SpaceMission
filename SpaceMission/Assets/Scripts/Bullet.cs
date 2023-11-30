using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    CountdownTimer countdownTimer;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 30), ForceMode2D.Impulse);
        countdownTimer = gameObject.AddComponent<CountdownTimer>();
        countdownTimer.ToplamSure = 3;
        countdownTimer.Calistir();
    }

    // Update is called once per frame
    void Update()
    {
        if (countdownTimer.Bitti)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Asteroid")
        {
            Destroy(gameObject);
        }
    }
}
