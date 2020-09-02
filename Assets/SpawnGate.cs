using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGate : MonoBehaviour
{
    public GameObject enemy;
    public Vector3 enemySpawn;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("I am in the spawn gate function");
            Instantiate(enemy, transform.position, Quaternion.identity);
        }
        
    }
}
