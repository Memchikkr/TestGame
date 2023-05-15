using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiEnemy : MonoBehaviour
{   
    private Transform player;
    [SerializeField]
    private float movingSpeed;
    [SerializeField]
    private float approachSpeed;
    [SerializeField]
    private float distanceToMove;
    [SerializeField]
    private float distanceToApproach;

    private Vector3 startPos;
    private bool isApproaching;
    private Vector3 targetPos;

    private void Start () 
    {
        player = GameObject.FindWithTag("Player").transform;
        startPos = transform.position;
        targetPos = player.position;
    }

    private void Update () 
    {
        float playerDistance = Vector3.Distance(transform.position, player.position);

        // Проверяем, должен ли объект находиться в движении
        if (playerDistance > distanceToMove) 
        {
            MoveObject(startPos);
        }
        else if (playerDistance > distanceToApproach) 
        {
            isApproaching = false;
            MoveObject(player.position);
        }
        else 
        {
            // Объект должен приблизиться к игроку
            if (!isApproaching) 
            {
                isApproaching = true;
                targetPos = player.position + (transform.position - player.position).normalized * 20f;
            }
            ApproachObject(targetPos);
        }
    }

    private void MoveObject (Vector3 target) 
    {        
        transform.position = Vector3.MoveTowards(transform.position, target, movingSpeed * Time.deltaTime);
    }

    private void ApproachObject(Vector3 target) 
    {             
        transform.position = Vector3.MoveTowards(transform.position, target, approachSpeed * Time.deltaTime);
    }
}
