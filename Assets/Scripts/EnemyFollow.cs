using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public GameObject player;
    public float followDistance = 10f;
    public float moveSpeed = 5f;

    private void Update()
    {
        // Check the distance to the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        // If the player is within the follow distance
        if (distanceToPlayer <= followDistance)
        {
            // Calculate direction towards the player only on the X-Z plane
            Vector3 directionToPlayer = player.transform.position - transform.position;
            directionToPlayer.y = 0f; // Set Y component to zero to prevent vertical movement

            // Normalize the direction and move towards the player
            if (directionToPlayer.magnitude > 0.1f)
            {
                transform.position += directionToPlayer.normalized * moveSpeed * Time.deltaTime;
            }
        }
    }
}
