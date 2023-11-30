using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSpaceShipControl : MonoBehaviour
{
    const float hareketGucu = 8;

    [SerializeField]
    GameObject kursunPrefab = default;

    [SerializeField]
    GameObject patlamaPrefab = default;

    GameControl gameControl;

    // Start is called before the first frame update
    void Start()
    {
        gameControl = Camera.main.GetComponent<GameControl>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;

        float yatayInput = Input.GetAxis("Horizontal");
        float dikeyInput = Input.GetAxis("Vertical");

        if (yatayInput != 0)
        {
            position.x += yatayInput * hareketGucu * Time.deltaTime;
        }

        if (dikeyInput != 0)
        {
            position.y += dikeyInput * hareketGucu * Time.deltaTime;
        }

        transform.position = position;

        if (Input.GetButtonDown("Jump"))
        {

            GameObject.FindGameObjectWithTag("Audio").GetComponent<SesKontrol>().Ates();
            Vector3 kursunPozisyon = gameObject.transform.position;
            kursunPozisyon.y += 3;
            Instantiate(kursunPrefab, kursunPozisyon, Quaternion.identity);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            GameObject.FindGameObjectWithTag("Audio").GetComponent<SesKontrol>().GemiPatlama();
            gameControl.GameOver();
            Instantiate(patlamaPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
