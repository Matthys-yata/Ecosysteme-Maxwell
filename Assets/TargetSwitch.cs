using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleTargetSwitcher : MonoBehaviour
{
    public List<GameObject> targets;
    public float moveSpeed = 5f;
    private int currentTargetIndex = 0;

    void Update()
    {
        if (targets.Count == 0)
            return;

        Transform currentTarget = targets[currentTargetIndex].transform;

        Vector3 direction = (currentTarget.position - transform.position).normalized;

        transform.position += direction * moveSpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, currentTarget.position) < 0.5f)
        {
            SwitchToNextTarget();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == targets[currentTargetIndex])
        {
            Debug.Log($"Capsule a atteint la cible : {collision.gameObject.name}");
            SwitchToNextTarget();
        }
    }

    private void SwitchToNextTarget()
    {
        currentTargetIndex++;

        if (currentTargetIndex >= targets.Count)
        {
            Debug.Log("Toutes les cibles ont été atteintes !");
            currentTargetIndex = 0;
        }
    }
}
