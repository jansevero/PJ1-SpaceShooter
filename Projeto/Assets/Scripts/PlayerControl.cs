using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public GameObject GameManagerGO; //referência ao gamemanager
    public GameObject PlayerBulletGO; //prefab
    public GameObject bulletPosition;
    public Text LivesUIText;
    const int MaxLives = 3;
    int lives;
    private float speed = 4;

    public void Init()
    {
        lives = MaxLives;

        LivesUIText.text = lives.ToString();

        transform.position = new Vector2(0, 0);

        gameObject.SetActive(true);
    }

    void Update()
    {
        //atira
        if(Input.GetKeyDown("space"))
        {
            //instancia um clone de tiro
            GameObject bullet = Instantiate(PlayerBulletGO);
            bullet.transform.position = bulletPosition.transform.position;
        }
        
        //anda nas setas
        float x = Input.GetAxisRaw ("Horizontal");
        float y = Input.GetAxisRaw ("Vertical");

        Vector2 direction = new Vector2(x, y).normalized;

        Move (direction);
    }

    void Move(Vector2 direction)
    {
        //Encontra limite da camera
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2 (0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2 (1, 1));

        max.x = max.x - 0.225f;
        min.x = min.x + 0.0225f;

        max.y = max.y - 0.285f;
        min.y = min.y + 0.285f;

        //posição atual
        Vector2 pos = transform.position;

        //nova posição
        pos += direction * speed * Time.deltaTime;

        //nova posição impedindo que saia da tela
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        //atualiza posição
        transform.position = pos;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //detecta colisão
        if((collision.tag == "EnemyShipTag") || (collision.tag == "EnemyBulletTag"))
        {
            lives--;
            LivesUIText.text = lives.ToString();

            if(lives == 0)
            {
                //muda estado do gamemanager pra gameover
                GameManagerGO.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOver);
         
                gameObject.SetActive(false);
            }
        }

        if(collision.tag == "ItemTag")
        {
            GameManagerGO.GetComponent<GameManager>().subject.Notify();
        }
    }
}
