using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamerController : MonoBehaviour
{
    [SerializeField] private GameObject message, duck;
    [SerializeField] private GameObject pipes, source;

    private float interval = 1f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPipes", 0f, interval);
    }

    private void SpawnPipes()
    {
        Instantiate(
            pipes,                     //Instancia com os pilares
            source.transform.position, //Na posição do objeto source
            Quaternion.identity        //Com rotação padrão (sem rotação, identidade)
        );
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(message); //Elimina a mensagame inicial quando o jogo começa
            duck.SetActive(true);
        }
    }
}
