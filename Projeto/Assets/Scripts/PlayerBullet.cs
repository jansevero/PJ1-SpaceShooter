using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    float speed;

    void Start()
    {
        speed = 8f;
    }

    void Update()
    {
        //posição atual
        Vector2 position = transform.position;

        //nova posição
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);
        transform.position = position;

        //ponto máximo da tela
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //se auto-destrói ao sair da tela
        if(transform.position.y > max.y)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "EnemyShipTag")
        {
            Destroy(gameObject);
        }
    }
}
