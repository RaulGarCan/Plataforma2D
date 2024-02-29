using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SiguienteNivel : MonoBehaviour
{
    private int EscenaUltimoNivel;
    // Start is called before the first frame update
    void Start()
    {
        EscenaUltimoNivel = 3;
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
            if (SceneManager.GetActiveScene().buildIndex == EscenaUltimoNivel)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
