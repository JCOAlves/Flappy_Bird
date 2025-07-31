using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBird : MonoBehaviour
{
    private bool jumping; //booleano referente a queda do RedBird
    private Rigidbody2D rb; //Objeto referente ao fenomenos da natureza no RedBird
    [SerializeField] private float jumpSpeed; //Cria o atributo Jump Speed na menu da Unity.
    [SerializeField] private GameObject GameOver;

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
            Debug.Log("Teclou a tecla espaço. Red Bird pulou.");
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

    //ESTUDAR E CORRIGIR FUNÇÃO GAME OVER
    private void OnCollisionEnter2D(Collider2D collision)
    { //Game Over
        if (collision.gameObject.CompareTag("pipes"))
        {
            if (GameOver != null)
            {
                GameOver.SetActive(true);
            }
            Debug.Log("GAME OVER: Pato colidiu solidamente com cano!");
            Time.timeScale = 0f;
        }
    }
}
