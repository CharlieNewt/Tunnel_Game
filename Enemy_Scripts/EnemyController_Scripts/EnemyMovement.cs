using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    private Rigidbody rb;
    private Vector3 nextPosition;
    public Vector3 NextPosition
    {
        get { return nextPosition; }
        set { nextPosition = value; }
    }

    public Vector3 currentPosition;

    private Vector3 heading;
    private Vector3 direction;

    private float distance;

    private float velTimer;
    float gatlingWaitTimer;

    public int pointOffset;
    public float velMag;

    private List<GameObject> points = new List<GameObject>();

    float gameSpeed;

	// Use this for initialization
	void Start () {
        gameSpeed = GameObject.Find("GameController").GetComponent<GameController>().GameSpeed;


        currentPosition = gameObject.transform.localPosition;

        rb = GetComponent<Rigidbody>();
        
        points = transform.parent.GetComponent<EnemySpawn>().points;

        gatlingWaitTimer = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        gameSpeed = GameObject.Find("GameController").GetComponent<GameController>().GameSpeed;

        currentPosition = gameObject.transform.localPosition;

        if (WithinBorder())
        {
            pointOffset++;
        }
        if (points.Count > 1)
        {
            if (points.Count == 2)
            {
                ForwardMovement();
            }
            else {
                RotatingMovement(nextPosition);
            }
        }
        else {
            transform.localPosition = new Vector3(0f, 0f, 0f);
            ForwardMovement();
        }
        //Debug.Log(nextPosition + gameObject.name);
    }

    void RotatingMovement(Vector3 endPosition)
    {
        velTimer = Time.deltaTime * 2000f * gameSpeed;

        direction = heading / Distance(nextPosition);

        //Debug.Log(direction);

        rb.velocity = (direction * velTimer);

        if (transform.parent.GetComponent<EnemySpawn>().isGatlingEnemy)
        {
            ShouldWait();
        }
        else {
            ForwardMovement();
        }

        velMag = rb.velocity.magnitude;

        //Debug.Log("currentPosition: " + currentPosition + ", nextPosition: " + nextPosition);
    }

    void ForwardMovement()
    {
        //gameObject.transform.localPosition -= new Vector3(10f, 0f, 0f);
        if (points.Count > 0)
        {
            transform.parent.transform.position -= new Vector3(500f / points.Count, 0f, 0f) * Time.deltaTime * gameSpeed;
        }
        else
        {
            Debug.Log("Points not found");
        }
    }

    bool WithinBorder()
    {
        float nextDistance;
        nextDistance = Distance(nextPosition);
        if (nextDistance <= 3f && nextDistance >= -3f)
        { return true; }
        else
        { return false; }
    }

    float Distance(Vector3 nextPointPos)
    {
        heading = nextPointPos - currentPosition;
        distance = heading.magnitude;
        return distance;
    }

    void ShouldWait()
    {
        if ((gatlingWaitTimer < 10) && (transform.position.x < 1900) && transform.position.x > 1800)
        {
            gatlingWaitTimer += Time.deltaTime;
        }
        else 
        {
            if (transform.position.x < 1800)
            {
                gatlingWaitTimer = 0;
            }
            ForwardMovement();
        }
    }
}
