using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    private bool jumping; //booleano referente a queda do RedBird
    private Rigidbody2D rb; //Objeto referente ao fenomenos da natureza no RedBird
    [SerializeField] private float jumpSpeed; //Cria o atributo Jump Speed na menu da Unity.
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip soundCollid;


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
            AudioController.instance.PlayAudioClip(jumpSound, false);
            rb.velocity = Vector2.up * jumpSpeed; // (0,1)
            jumping = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Pato colidiu solidamente com: " + gameObject.name + " (Tag: " + gameObject.tag + ")");
        if (other.CompareTag("Score"))
        {
            GameController.instance.IncreaseScore(1);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Pato colidiu solidamente com: " + gameObject.name + " (Tag: " + gameObject.tag + ")");
        if (other.gameObject.CompareTag("pipes") || other.gameObject.CompareTag("base"))
        {
            AudioController.instance.PlayAudioClip(soundCollid, false);
            GameController.instance.GameOver();
        }
    }
}
