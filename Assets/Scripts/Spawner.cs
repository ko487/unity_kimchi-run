using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Settings")]
    public float minSpawnDelay;
    public float maxSpawnDelay;
    [Header("Preferences")]
    public GameObject[] gameObjects;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("Spawn", Random.Range(minSpawnDelay, maxSpawnDelay));
    }


    void Spawn()
    {
        var randomObject = gameObjects[Random.Range(0, gameObjects.Length)];    // 0~배열의 길이 사이의 랜덤 정수 뱉기
        Instantiate(randomObject, transform.position, Quaternion.identity);
        Invoke("Spawn", Random.Range(minSpawnDelay, maxSpawnDelay));
    }
}
