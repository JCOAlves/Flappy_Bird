using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    [SerializeField] private float speed;
    //[SerializeField] private float OriginPosition;
    //[SerializeField] private float limitPosition;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(
            transform.position.x - speed * Time.deltaTime,
            transform.position.y
        );

        /*if (transform.position.x < limitPosition)
        {
            transform.position = new Vector2(
            OriginPosition,
            transform.position.y
            );
        }*/
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DestroyPoints"))
        {
            Destroy(gameObject);
        }
    }
}
