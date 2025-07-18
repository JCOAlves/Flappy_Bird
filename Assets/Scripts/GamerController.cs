using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamerController : MonoBehaviour
{
    [SerializeField] private GameObject message, duck;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(message); //Elimina a mnsgame inicial quando o jogo começa
            duck.SetActive(true);
        }
    }
}
