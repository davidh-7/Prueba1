using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class NauJugador : MonoBehaviour
{
    private float vel;

    private Vector2 minPantalla;
    private Vector2 maxPantalla;

    // Start is called before the first frame update
    void Start()
    {
        vel = 8;
        minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        float TamNaveX = GetComponent<SpriteRenderer>().sprite.bounds.size.x * transform.localScale.x;
        float TamNaveY = GetComponent<SpriteRenderer>().sprite.bounds.size.y / 2;

        //minPantalla.x = (float)(minPantalla.x + 0.75);
        minPantalla.x += TamNaveX;
        minPantalla.y += TamNaveY;
        maxPantalla.x -= TamNaveX;
        maxPantalla.y -= TamNaveY;
    }

    // Update is called once per frame
    void Update()
    {
        float direcionIndicadaX = Input.GetAxisRaw("Horizontal");
        float direcionIndicadaY = Input.GetAxisRaw("Vertical");

        //Debug.Log("X: " + direcionIndicadaX + "Y: " + direcionIndicadaY);

        Vector2 direcionIndicada = new Vector2(direcionIndicadaX,direcionIndicadaY).normalized;

        Vector2 nuevaPosi = transform.position;

        nuevaPosi = nuevaPosi + direcionIndicada * vel * Time.deltaTime;

        nuevaPosi.x = Mathf.Clamp(nuevaPosi.x, minPantalla.x, maxPantalla.x);
        nuevaPosi.y = Mathf.Clamp(nuevaPosi.y, minPantalla.y, maxPantalla.y);

        transform.position = nuevaPosi;
    }
}
