using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    float speed;

    void Start()
    {
        speed = 3f;
    }

    void Update()
    {
        //posição atual     
        Vector2 position = transform.position;

        //nova posição
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);
        transform.position = position;

        //destrói ao sair da câmera
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerShipTag")
        {
            Destroy(gameObject);
        }
    }
}
