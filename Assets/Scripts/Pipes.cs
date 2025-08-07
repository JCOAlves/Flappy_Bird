using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        /*yVariable = Random.Range(-1, 5) < 0;
        if (yVariable)
        {
            
        }*/

        float randomY = Random.Range(-2f, 2f);
        transform.position = new Vector2(transform.position.x, randomY);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(
            transform.position.x - speed * Time.deltaTime,
            transform.position.y
        );
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DestroyPoints"))
        {
            Debug.Log("Pila destruido.");
            Destroy(gameObject);
        }
    }
}
