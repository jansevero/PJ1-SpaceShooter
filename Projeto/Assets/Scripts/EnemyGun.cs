using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject EnemyBulletGO;

    void Start()
    {
        Invoke("FireEnemyBullet", 1f);
        Invoke("FireEnemyBullet", 2f);
    }

    void FireEnemyBullet()
    {
        GameObject playerShip = GameObject.Find("PlayerGO");

        if(playerShip != null)
        {
            GameObject bullet = Instantiate(EnemyBulletGO);

            bullet.transform.position = transform.position;
        }
    }
}
