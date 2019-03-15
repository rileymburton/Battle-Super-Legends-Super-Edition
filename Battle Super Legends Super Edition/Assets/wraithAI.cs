using Pathfinding;
using UnityEngine;

    [RequireComponent (typeof(Rigidbody2D))]
    [RequireComponent (typeof(Seeker))]
public class wraithAI : MonoBehaviour
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

    void Start() {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        if(target == null){
            Debug.LogError("No Target Found");
        }
        seeker.StartPath(transform.position, target.position, OnPathComplete);
    }

    public void OnPathComplete (Path p) {
        Debug.Log(" Path Found " + p.error);
        if(!p.error){
            path = p;
            currentWaypoint = 0;
        }
    }
    
}
