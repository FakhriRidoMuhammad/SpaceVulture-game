using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public float movementSpeed = 5;
    public float spawnDelay = 0.5f;

    private float xMin, xMax, yMin, yMax;
    private float width = 12f;
    private float height = 6f;
    private bool movingX,movingY = true;

    void Start() {
        SpawnUntilFull();

        float distanceZ = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftBottomMost = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, distanceZ));
        Vector3 rightTopMost = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, distanceZ));
        xMin = leftBottomMost.x;
        xMax = rightTopMost.x;
        yMin = leftBottomMost.y;
        yMax = rightTopMost.y;
    }

    void SpawnUntilFull()
    {
        Transform nextPosition = NextFreePosition();
        if (nextPosition)
        {
            GameObject enemy = Instantiate(enemyPrefab, nextPosition.position, Quaternion.identity);
            enemy.transform.parent = nextPosition;
        }

        if (NextFreePosition())
        {
            Invoke("SpawnUntilFull", spawnDelay);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }

    void Update () {
        FormationMovement();
        if (AllEnemiesDead())
        {
            Debug.Log("All enemy dead!");
            SpawnUntilFull();        }
	}

    Transform NextFreePosition()
    {
        foreach (Transform childOfPosition in transform)
        {
            if (childOfPosition.childCount == 0)
            {
                return childOfPosition;
            }
        }
        return null;
    }

    bool AllEnemiesDead()
    {
        foreach(Transform childOfPosition in transform)
        {
            if (childOfPosition.childCount > 0)
            {
                return false;
            }
        }
        return true; 
    }

   void FormationMovement()
    {
        if (movingX)
        {
            transform.position += new Vector3(movementSpeed * Time.deltaTime, 0f);
        } else
        {
            transform.position += new Vector3(-movementSpeed * Time.deltaTime, 0f);
        }
        if (movingY)
        {
            transform.position += new Vector3(0f, movementSpeed * Time.deltaTime);
        }
        else
        {
            transform.position += new Vector3(0f, -movementSpeed * Time.deltaTime);
        }

        float leftBorderPosition = transform.position.x - (width / 2f);
        float rightBorderPosition = transform.position.x + (width / 2f);
        float bottomBorderPosition = transform.position.y- (height / 2f);
        float topBorderPosition = transform.position.y + (height / 2f);

        if (leftBorderPosition <= xMin)
        {
            movingX = true;
        }else if (rightBorderPosition >= xMax)
        {
            movingX = false;
        }

        if (bottomBorderPosition <= yMin)
        {
            movingY = true;
        }
        else if (topBorderPosition >= yMax)
        {
            movingY = false;
        }


    }
}
