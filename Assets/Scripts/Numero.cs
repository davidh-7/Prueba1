using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Numero : MonoBehaviour
{

    private float vel;
    private Vector2 minPantalla;

    public Sprite[]  PossiNum = new Sprite[10];

    private int numero;


    // Start is called before the first frame update
    void Start()
    {
        vel = 5f;
        minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0,0));

        System.Random aleatorio = new System.Random();
        numero = aleatorio.Next(0, 10);
        GetComponent<SpriteRenderer>().sprite = PossiNum[numero];



    }

    // Update is called once per frame
    void Update()
    {
        Vector2 nuevaPos  = transform.position;
        nuevaPos = nuevaPos + new Vector2(0, -1) * vel * Time.deltaTime;
        transform.position = nuevaPos;

        if (transform.position.y < minPantalla.y) {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D ObjTocado)
    {
        if (ObjTocado.tag == "ProyectilJugador" || ObjTocado.tag == "NauJugador")
        {

            Destroy(gameObject);
        }
    }

}
