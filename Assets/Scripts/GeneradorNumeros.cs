using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorNumeros : MonoBehaviour   
{
    [SerializeField] private GameObject PrefabNumero;

    // Start is called before the first frame update
    void Start()
    {
        minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        InvokeRepeating("generarNumero", 1f, 2f);
        
    }

    private void InvokeRepeating() { 
    }

    private void generarNumero() { 
    
        GameObject numero = Instantiate(PrefabNumero);

        numero.transform.position = new Vector2( Random.Range(minPantalla.x, maxPantalla.x) , maxPantalla.y);
    }

    private Vector2 minPantalla, maxPantalla;
    // Update is called once per frame
    void Update()
    {
        
    }



}
