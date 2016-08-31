using UnityEngine;
using System.Collections;

public class FollowPath : MonoBehaviour {

    public PathEditor path;
    public float speed = 5f;
    public int currentPoint = 0;
    
    public bool MoveAsForce;

	// Use this for initialization
	void Start () {
        transform.position = path.pathObj[currentPoint].position;
    }
	
	// Update is called once per frame
	void Update () {
        float dist = Vector3.Distance(path.pathObj[currentPoint].position, transform.position);
        var rotation = Quaternion.LookRotation(path.pathObj[currentPoint].position, transform.position);

        if (MoveAsForce)
        {
            transform.position = Vector3.Lerp(transform.position, path.pathObj[currentPoint].position, Time.deltaTime * speed);
            if (dist <= 0.2)
            {
                currentPoint++;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, path.pathObj[currentPoint].position, Time.deltaTime * speed);
            if (dist == 0)
            {
                currentPoint++;
            }
        }



        if (currentPoint >= path.pathObj.Count)
        {
            currentPoint = 0;
        }
	}
}
