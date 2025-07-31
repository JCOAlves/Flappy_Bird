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
    {   //Condicionais de verificação de elementos nulos
        if (pipes == null)
        {
            Debug.LogError("ERRO: O Prefab 'pipes' não foi atribuído no Inspector do " + gameObject.name + "!");
            enabled = false; // Desabilita este script
            return;
        }

        if (source == null)
        {
            Debug.LogError("ERRO: O GameObject 'source' não foi atribuído no Inspector do " + gameObject.name + "!");
            enabled = false; // Desabilita este script
            return;
        }

        if (message == null)
        {
            Debug.LogWarning("AVISO: O GameObject 'message' não foi atribuído no Inspector do " + gameObject.name + ". A funcionalidade de mensagem inicial pode não funcionar.");
        }

        if (duck == null)
        {
            Debug.LogWarning("AVISO: O GameObject 'duck' não foi atribuído no Inspector do " + gameObject.name + ". O pato pode não ser ativado.");
        }

        InvokeRepeating("SpawnPipes", 0f, interval);
    }

    private void SpawnPipes()
    {
        if (pipes != null && source != null)
        {
            Instantiate(
                pipes,                     //Instancia com os pilares
                source.transform.position, //Na posição do objeto source
                Quaternion.identity        //Com rotação padrão (sem rotação, identidade)
            );
        }
        else
        {
            Debug.LogError("Não foi possível gerar pipes: 'pipes' ou 'source' está nulo. Verifique as atribuições no Inspector ou se o 'source' foi destruído.");
            CancelInvoke("SpawnPipes"); // Para de tentar chamar SpawnPipes se algo estiver errado
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (message != null) //Verifica se 'message' não é nulo antes de tentar destruí-lo
            {
                Destroy(message); //Elimina a mensagame inicial quando o jogo começa
                message = null; //Opcional, mas boa prática: zera a referência para evitar tentar usar novamente
            }
            if (duck != null) //Verifica se 'duck' não é nulo antes de tentar destruí-lo
            {
                duck.SetActive(true); // Ativa o pato (personagem do jogador)
            }
        }
    }
}
