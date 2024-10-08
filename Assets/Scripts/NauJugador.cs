using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vector2 = UnityEngine.Vector2;

public class NauJugador : MonoBehaviour
{
    private float vel;

    private Vector2 minPantalla;
    private Vector2 maxPantalla;

    private int VidaJug;

    [SerializeField] private GameObject PrfabProyectil;
    [SerializeField] private GameObject PrfabExplosion;
    [SerializeField] private TMPro.TextMeshProUGUI texto;

    // Start is called before the first frame update
    void Start()
    {
        DatosGlobales.ReiniciarPuntos();

        vel = 8f;
        minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //float TamNaveY = GetComponent<SpriteRenderer>().sprite.bounds.size.y / 2;
        float TamNaveX = GetComponent<SpriteRenderer>().sprite.bounds.size.x * transform.localScale.x /2;
        float TamNaveY = GetComponent<SpriteRenderer>().sprite.bounds.size.y * transform.localScale.y /2;

        //minPantalla.x = (float)(minPantalla.x + 0.75);
        minPantalla.x += TamNaveX;
        minPantalla.y += TamNaveY;
        maxPantalla.x -= TamNaveX;
        maxPantalla.y -= TamNaveY;

        VidaJug = 3;
    }

    // Update is called once per frame
    void Update()
    {
        MovimientoNave();
        DisparaProyectil();
    }



    private void DisparaProyectil()
    {
        if (Input.GetKeyDown("space")) { 
        
            GameObject Proyectil = Instantiate(PrfabProyectil);
            
            Proyectil.transform.position = transform.position;
        }
    }

    private void MovimientoNave()
    {
        
        float direcionIndicadaX = Input.GetAxisRaw("Horizontal");
        float direcionIndicadaY = Input.GetAxisRaw("Vertical");

        //Debug.Log("X: " + direcionIndicadaX + "Y: " + direcionIndicadaY);

        Vector2 direcionIndicada = new Vector2(direcionIndicadaX, direcionIndicadaY).normalized;

        Vector2 nuevaPosi = transform.position;

        nuevaPosi = nuevaPosi + direcionIndicada * vel * Time.deltaTime;

        nuevaPosi.x = Mathf.Clamp(nuevaPosi.x, minPantalla.x, maxPantalla.x);
        nuevaPosi.y = Mathf.Clamp(nuevaPosi.y, minPantalla.y, maxPantalla.y);

        transform.position = nuevaPosi;
    }

    private void OnTriggerEnter2D(Collider2D ObjTocado)
    {


        if (ObjTocado.tag == "Numero")
        {
            VidaJug--;
            texto.text = "Vida :" + VidaJug.ToString();

            if (VidaJug == 0)
            {
                GameObject explosion = Instantiate(PrfabExplosion);
                explosion.transform.position = transform.position;
                SceneManager.LoadScene("PantallaResultados");

                Destroy(gameObject);
            }
        }


    }
}
    