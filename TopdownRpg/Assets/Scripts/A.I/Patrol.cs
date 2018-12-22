using UnityEngine;

/*
 *  Patrol - AI's movements dependent on distance from the Player
 *  @author Liam Palmeri
 *  @constributors Bryce Thompson
 */ 

public class Patrol : MonoBehaviour
{
    public Transform[] movespot;
    public float speed;
    public float stoppingdistance;
    public float startwaittime;
    private float waittime;
    private int randomspot;
    private int outOfRange;
    private Transform target;
    
    //Instantiates public and private states
    void Start()
    {
        randomspot = Random.Range(0, movespot.Length);
        waittime = startwaittime;
        outOfRange = 10;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    //Moves the AI towards the player if within range, otherwise calls wander function
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > stoppingdistance 
            && Vector2.Distance(transform.position, target.position) < outOfRange)
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        else
            wander();

    }

    //If the Player is out of range of the AI, the AI will move amongst (movespot)'s randomly
    void wander()
    {
        transform.position = Vector2.MoveTowards(transform.position, movespot[randomspot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, movespot[randomspot].position) < 0.2f)
        {
            if (waittime <= 0)
            {
                randomspot = Random.Range(0, movespot.Length);
                waittime = startwaittime;
            }
            else
                waittime -= Time.deltaTime;

        }
    }
}