using Pathfinding;
using System.Collections;
using UnityEngine;

    [RequireComponent (typeof(Rigidbody2D))]
    [RequireComponent (typeof(Seeker))]
public class wraithEnemyAI : MonoBehaviour
{
    public Transform target;
    public float updateRate = 2f;

    // caching
    private Seeker seeker;
    private Rigidbody2D rb;

    //calculated path

    public Path path;

    //Ai Speed
    public float speed = 300f;
    public ForceMode2D fMode;

    [HideInInspector]
    public bool PathisEnded = false;

    //max distance from ai to waypoint to continue along to next waypoint
    public float nextWaypointDistance = 3;
    private int currentWaypoint = 0;

    private bool searchingForPlayer = false;

    void Start() {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        if(target == null){
            if(!searchingForPlayer){
                searchingForPlayer = true;
                StartCoroutine (searchForPlayer());
            }

            return;
        }
        seeker.StartPath(transform.position, target.position, OnPathComplete);

        StartCoroutine (UpdatePath ());
    }
    IEnumerator searchForPlayer(){
        
    }

    IEnumerator UpdatePath () {
        if(target == null){
            //TODO insert a search mechanic
            yield return false;
        }

        seeker.StartPath(transform.position, target.position, OnPathComplete);

        yield return new WaitForSeconds(1 / updateRate);
        StartCoroutine(UpdatePath());
    }
    public void OnPathComplete (Path p) {
        Debug.Log(" Path Found " + p.error);
        if(!p.error){
            path = p;
            currentWaypoint = 0;
        }
    }
    
    void FixedUpdate () {
        if(target == null){
            //TODO insert a search mechanic
            return;
        }

        //TODO always look at player

        if(path == null){
            return;
        }

        if(currentWaypoint >= path.vectorPath.Count){
            if(PathisEnded){
                return;
            }
            Debug.Log("End of Path Reached");
            PathisEnded = true;
            return;
        }
        PathisEnded = false;

        //Direction to waypoint
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        dir *= speed * Time.fixedDeltaTime;

        rb.AddForce (dir, fMode);
        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
        if (dist< nextWaypointDistance){
            currentWaypoint++;
            return;
        }
    }

}
