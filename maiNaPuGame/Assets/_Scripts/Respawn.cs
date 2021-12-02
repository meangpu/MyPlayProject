using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] List<Transform> allSpawnPoint = new List<Transform>();

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.position = allSpawnPoint[Random.Range(0, allSpawnPoint.Count)].transform.position;
        }
    }

}
