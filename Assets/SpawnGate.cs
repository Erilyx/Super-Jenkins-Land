using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGate : MonoBehaviour
{
    public GameObject enemy;
    public Vector3 enemySpawn;


    private void OnTriggerEnter2D(Collider2D other)
    {      
        Debug.Log("I am in the spawn gate function");
        if (other.gameObject.CompareTag("Player"))
        {

            Instantiate(enemy, transform.position, Quaternion.identity);
        }
        
    }
}
