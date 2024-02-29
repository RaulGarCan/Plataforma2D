using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteCaida : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        JohnMovement john = collider.GetComponent<JohnMovement>();

        //Codigo que colocaremos en la función de OnCollisionEnter2D ...

        if (john != null)
        { //hemos impactado con john
            john.Hit(john.getMaxHealth());
        }
    }
}
