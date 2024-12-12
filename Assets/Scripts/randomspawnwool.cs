using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using Unity.VisualScripting;
using UnityEngine;

public class randomspawnwool : MonoBehaviour
{
    public GameObject Sphere;
    private int _spawnCount = 0;
    public int spawnLimit = 5;
    public float spawnInterval = 5f;
    private float _timer = 0f;

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= spawnInterval)
        {
            if (_spawnCount < spawnLimit)//on check la diff entre spawncount et spawnlimit
            {
                Vector3 randomSpawnPosition = new Vector3(Random.Range(-25, 25), 1, Random.Range(-25, 25));//la zone de spawn
                Instantiate(Sphere, randomSpawnPosition, Quaternion.identity);//l'object a spawn sa position sa rotation
                Debug.Log(_spawnCount);
                _spawnCount++;//on augmente le compteur de spawn de 1
                _timer = 0f;
                Debug.Log(_timer);
            }
        }
    }
    public void whooldestroyed()
    {
        _spawnCount--;


    }
}