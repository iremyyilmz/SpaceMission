using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class Control : MonoBehaviour
{
    float colliderBoyYarim;
    float colliderEnYarim;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D myRigidbody = GetComponent<Rigidbody2D>();
        myRigidbody.AddForce(new Vector2(Random.Range(-5,5), Random.Range(-5, 5)), ForceMode2D.Impulse);
        BoxCollider2D collider = GetComponent<BoxCollider2D>();

        colliderBoyYarim = collider.size.y / 2;
        colliderEnYarim = collider.size.x / 2;
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       // Debug.Log("Sıkı tutunun");
    }

    // Update is called once per frame
    void Update()
    {
        //Asteroid mouse imlecini takip eder
    //    Vector3 position = Input.mousePosition;
    //    position.z = -Camera.main.transform.position.z;
    //    position = Camera.main.ScreenToWorldPoint(position);
    //    transform.position = position;
    //    StayOnScreen();

    }

    void StayOnScreen()
    {
        Vector3 position = transform.position;

        if(position.x - colliderEnYarim < SceneCalculator.Left)
        {
            position.x = SceneCalculator.Left + colliderEnYarim;
        }else if(position.x + colliderEnYarim > SceneCalculator.Right)
        {
            position.x = SceneCalculator.Right - colliderEnYarim;
        }
        if(position.y + colliderBoyYarim > SceneCalculator.Top)
        {
            position.y = SceneCalculator.Top - colliderBoyYarim;
        }else if(position.y - colliderBoyYarim < SceneCalculator.Bottom)
        {
            position.y = SceneCalculator.Bottom + colliderBoyYarim;
        }


        transform.position = position;
    }
}
