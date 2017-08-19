using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBehavior : MonoBehaviour {

    public float health = 150;
    public GameObject enemyProjectile;
    public float ProjectileOffset = -1;
    public int scoreValue = 150;
    public AudioClip EnemyDestroyedSfx;
   
    private float projectileSpeed = 10;
    private float rdm;
    private ScoreKeeper scoreKeeper;
    private PowerUpSpawner PUspawner;

    private void Start()
    {
        PUspawner = GetComponent<PowerUpSpawner>();
        scoreKeeper = GameObject.Find("ScoreText").GetComponent<ScoreKeeper>();
    }

    private void OnTriggerEnter2D(Collider2D ObjCollidingWith)
    {
        Projectile playerBeam = ObjCollidingWith.GetComponent<Projectile>();
        PlayerController playerShip = ObjCollidingWith.GetComponent<PlayerController>();
        if (playerBeam)
        {
            health -= playerBeam.Damage();
            playerBeam.Hit();
            if (health <= 0)
            {
                AudioSource.PlayClipAtPoint(EnemyDestroyedSfx, transform.position);
                PUspawner.SpawnPU();
                Destroy(gameObject);
                scoreKeeper.Score(scoreValue);
            }
        }
        if (playerShip)
        {
            Destroy(ObjCollidingWith.gameObject);
            Destroy(gameObject);
            SceneManager.LoadScene("Final");
        }
    }

    private void Update()
    {
        rdm = Random.Range(1, 100);
        if (rdm == 1)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Vector3 offset = new Vector3(0f, ProjectileOffset, 0f);
        GameObject projectile = Instantiate(enemyProjectile, transform.position + offset, Quaternion.identity) as GameObject;
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -projectileSpeed);
    }
}
