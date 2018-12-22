using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform[] movespot;
    public float speed;
    private int randomspot;
    private float waittime;
    public float startwaittime;
    private Transform target;
    public float stoppingdistance;


    void Start()
    {
        randomspot = Random.Range(0, movespot.Length);
        waittime = startwaittime;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > stoppingdistance && Vector2.Distance(transform.position,
            target.position) < 10)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, movespot[randomspot].position, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, movespot[randomspot].position) < 0.2f)
            {
                if (waittime <= 0)
                {
                    randomspot = Random.Range(0, movespot.Length);
                    waittime = startwaittime;
                }
                else { waittime -= Time.deltaTime; }

            }
        }

    }
}