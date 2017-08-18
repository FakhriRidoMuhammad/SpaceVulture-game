using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public AudioClip PlayerDestroyedSfx;
    public GameObject projectile;
    public float Padding = 1f;
    public float moveSensitivity = 5f;
    public float projectileSpeed;
    public float firingRate;
    public float health = 300;
    public float ProjectileOffset = 0.8f;

    private float xMin, xMax, yMin, yMax;
    

    void Start () {

        float distanceZ = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftBottomMost = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, distanceZ));
        Vector3 rightTopMost = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, distanceZ));
        xMin = leftBottomMost.x + Padding;
        xMax = rightTopMost.x - Padding;
        yMin = leftBottomMost.y + Padding;
        yMax = rightTopMost.y - Padding;

    }
	
	void Update () {
        MovementController();
        ActionControler();
        PositionClamp();
    }

    private void OnTriggerEnter2D(Collider2D objCollidedWith)
    {
        Projectile enemyProjectile = objCollidedWith.GetComponent<Projectile>();
        if (enemyProjectile)
        {
            enemyProjectile.Hit();
            health -= enemyProjectile.Damage();
            if (health <= 0)
            {
                AudioSource.PlayClipAtPoint(PlayerDestroyedSfx, transform.position);
                SceneManager.LoadScene("Final");
                Destroy(gameObject);
            }
        }
    }

    void PositionClamp()
    {
        float newX = Mathf.Clamp(transform.position.x, xMin, xMax);
        float newY = Mathf.Clamp(transform.position.y, yMin, yMax);
        transform.position = new Vector3(newX, newY, transform.position.z);
    }

    void MovementController()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * Time.deltaTime * moveSensitivity;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime * moveSensitivity;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * Time.deltaTime * moveSensitivity;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * Time.deltaTime * moveSensitivity;
        }
        
    }

    void ShootProjectile()
    {
        Vector3 Offset = new Vector3(0f,ProjectileOffset,0f);
        GameObject beam = Instantiate(projectile, transform.position + Offset, Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity += new Vector2(0f, projectileSpeed);
    }

    void ActionControler()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("ShootProjectile", 0.000001f, firingRate);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("ShootProjectile");
        }
    }
}
