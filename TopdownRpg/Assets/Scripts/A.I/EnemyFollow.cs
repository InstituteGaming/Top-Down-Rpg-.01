using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    private Transform target;
    public float stoppingdistance;
    

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    private void Update() {

        if (Vector2.Distance(transform.position, target.position) > stoppingdistance&&Vector2.Distance(transform.position, target.position) <10)
                
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        {
        }

        }
    
}
