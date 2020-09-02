using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    private Transform jenkinsTransform;
    private Rigidbody2D enemy;
    public float enemySpeed = 2;
    public GameObject squishedEnemy;
    public float activationDistance = 20f;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        jenkinsTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x - jenkinsTransform.position.x < activationDistance)
        {
            enemy.velocity = new Vector2(-enemySpeed, enemy.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Debug.Log("Enemy dies");
            Instantiate(squishedEnemy, transform.position, quaternion.identity);
        }
        if (other.gameObject.CompareTag("LeftEdge"))
        {
            Destroy(gameObject);
        }
    }

}
