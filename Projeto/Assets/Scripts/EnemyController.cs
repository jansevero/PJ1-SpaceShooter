using UnityEngine;

public class EnemyController : MonoBehaviour
{
    float speed;
    GameObject scoreUITextGO; //referência para aumentar a pontuação
    GameObject enemyController;

    void Start()
    {
        speed = 2f;
        scoreUITextGO = GameObject.FindGameObjectWithTag("ScoreTextTag");
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
        if(transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBulletTag" || collision.tag == "PlayerShipTag")
        {
            scoreUITextGO.GetComponent<GameScore>().Score += 10;

            Destroy(gameObject);
        }
    }
}
