using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBird : MonoBehaviour
{
    private bool jumping; //booleano referente a queda do RedBird
    private Rigidbody2D rb; //Objeto referente ao fenomenos da natureza no RedBird

    [SerializeField] private float jumpSpeed; //Cria o atributo Jump Speed na menu da Unity.

    // Start is called before the first frame update
    void Start()
    {
        jumping = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Teclou a tecla espaço.");
            jumping = true;
        }
    }

    void FixedUpdate()
    {
        if (jumping)
        {
            rb.velocity = Vector2.up * jumpSpeed; // (0,1)
            jumping = false;
        }
    }
}
