using UnityEngine;
using Pathfinding;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Seeker))]
[RequireComponent(typeof(EnemyManager))]
public class PathfindingAI : MonoBehaviour {
    public Transform target;

    public Vector3 dir;

    public float updateRate = 0.5f;

    private Seeker seeker;
    private Rigidbody2D rb;
    private EnemyManager manager;

    //The calculated path
    public Path path;

    //The AI's speed per second
    public float maxJumpHeigth = 2;

    [HideInInspector]
    public bool pathIsEnded = false;

    // The max distance from the AI to a waypoint  for it to continue to the next waypoint
    public float nextWaypointDistance = 3;

    private int currentWaypoint = 0;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        manager = GetComponent<EnemyManager>();
        if (target == null)
        {
            Debug.LogError("No Player found !");
            return;
        }

        seeker.StartPath(transform.position, target.position,OnPathComplete);

        StartCoroutine(UpdatePath());
    }

    IEnumerator UpdatePath()
    {
        if(target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        seeker.StartPath(transform.position, target.position, OnPathComplete);

        yield return new WaitForSeconds(1f / updateRate);
        StartCoroutine(UpdatePath());
    }

    public void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    private void FixedUpdate()
    {
        if (target == null)
        {
            GameObject.FindGameObjectWithTag("Player");
        }

        //TODO : Always look at player ?

        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            if (pathIsEnded)
                return;
            pathIsEnded = true;
            return;
        }
        pathIsEnded = false;

        //Direction to the next waypoint
        dir = (path.vectorPath[currentWaypoint] - transform.position);

        float distBlocsJump = 1;
        float distBlocsWalk = 0;
        

        for(int i=currentWaypoint;i<path.vectorPath.Count-1;i++)
        {
            Vector3 jumpNeed = (path.vectorPath[i+1] - path.vectorPath[i]).normalized;
            
            distBlocsJump += jumpNeed.y;
            distBlocsWalk += Mathf.Abs(jumpNeed.x);
        }

        if (distBlocsJump > distBlocsWalk && manager.m_Grounded && dir.y != 0 && dir.x < 0.1 && dir.x > 0.1)
        {
                if (distBlocsJump > maxJumpHeigth)
                    distBlocsJump = maxJumpHeigth;
                dir.y = distBlocsJump;
        }
        else
        {
            if(dir.x>0)
            {
                dir.x += dir.y;
            }
            else
            {
                dir.x -= dir.y;
            }
            dir.y = 0;
        }

        GetComponent<EnemyManager>().Move(dir.x * Time.fixedDeltaTime, dir.y);
        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
        if (dist<nextWaypointDistance)
        {
            currentWaypoint++;
            return;
        }
    }
    
    // TODO : Ajout routine si hors range => deplacement scripté.


}
