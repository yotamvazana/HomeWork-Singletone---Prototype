using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    public GameObject EnemyPrefab;
    public Transform SpawnTrue;
    public Transform SpawnFalse;

    private new Vector3 firstSpawnPoint;
    private new Vector3 secondSpawnPoint;


    public float Speed;
    private bool IsSpawning;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        firstSpawnPoint = SpawnTrue.position;
        secondSpawnPoint = SpawnFalse.position;
    }

   
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward * Speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.back * Speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * Speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * Speed);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Score.scoreSingle.AddScore(2);
            Debug.Log(Score.scoreSingle.score);
            IsSpawning = !IsSpawning;
            if (IsSpawning)
            {
                Debug.Log("Created");
                Instantiate(EnemyPrefab, secondSpawnPoint, Quaternion.identity);
            }
            else
            {
                Debug.Log("Created");
                Instantiate(EnemyPrefab, firstSpawnPoint,Quaternion.identity);
            }
        }
    }
    

}
