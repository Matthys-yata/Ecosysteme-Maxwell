using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkdestroyed : MonoBehaviour
{


    void OnDestroy()
    {
        randomspawnwool spawner = FindObjectOfType<randomspawnwool>();
        if (spawner != null)
        {
            spawner.whooldestroyed();
        }
    }
}