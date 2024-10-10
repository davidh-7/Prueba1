using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        Invoke("DestruirExplo", 1f);
        
    }

    private void DestruirExplo() { 
    
        Destroy(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
