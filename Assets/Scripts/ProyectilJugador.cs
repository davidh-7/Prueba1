using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilJugador : MonoBehaviour
{
    [SerializeField] private float vel;

    private Vector2 maxpantalla;
    // Start is called before the first frame update
    void Start()
    {
        vel = 13f;
        maxpantalla = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 posAct = transform.position;
        posAct = posAct + new Vector2(0, 1) * vel * Time.deltaTime;
        transform.position = posAct;

        if (transform.position.y > maxpantalla.y){
        Destroy(gameObject);
        }
    }
}
