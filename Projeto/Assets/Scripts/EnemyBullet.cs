using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public float speed = 5f;
    public float rotatingSpeed = 20f;
    GameObject target;
    Rigidbody2D rb;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("PlayerShipTag");
        rb = GetComponent<Rigidbody2D>();     
        Destroy(gameObject, 12f);
    }

    void Update()
    {
        //atualiza posição do alvo
        target = GameObject.FindGameObjectWithTag("PlayerShipTag");
        if(target == null)
        {   
            //se auto destrói se o jogdor tiver morrido
            Destroy(gameObject);
        } else
        {
            //seek steering behavior
            Vector2 pointToTarget = (Vector2)transform.position - (Vector2)target.transform.position;
            pointToTarget.Normalize();
            float value = Vector3.Cross(pointToTarget, transform.up).z;

            rb.angularVelocity = rotatingSpeed * value;
            rb.velocity = transform.up * speed;
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
