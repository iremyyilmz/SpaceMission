using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDestroy : MonoBehaviour
{
    CountdownTimer countdownTimer;

    // Start is called before the first frame update
    void Start()
    {
        countdownTimer = gameObject.AddComponent<CountdownTimer>();
    
        countdownTimer.ToplamSure = 1;
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
}
