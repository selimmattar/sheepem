using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class WolfMovement : MonoBehaviour
{
    public enum State {Wandering,Attacking,Returning};
    private State WolfState;
    float RandomWanderTime;
    private NavMeshAgent agent;
    private Vector2[] Wanderpoints;
    private GameObject VictimSheep;
    private bool isReturning = false;
    private Vector3 lastpos;
    private Vector3 lastWanderPos;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        WolfState = State.Wandering;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Random.RandomRange(0, 1000) <= 50) { 
            if (WolfState == State.Wandering) {
            float DogDist;
            float WolfDist;
        foreach (var gameObj in GameObject.FindGameObjectsWithTag("sheep") as GameObject[])
        {
                
               DogDist = Vector3.Distance(gameObj.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);
                WolfDist = Vector3.Distance(gameObj.transform.position, transform.position);
                if (WolfDist < DogDist && DogDist > 10)
                {
                        lastWanderPos = transform.position;
                        WolfState = State.Attacking;
                    VictimSheep = gameObj;
                    break;
                }
                    
                
            }
            }
        }
        Move();
    }
    private void LateUpdate()
    {
        lastpos = transform.position;
    }
    public void Return()
    {
     if(Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < 5f && WolfState==State.Attacking)
        {
           WolfState = State.Returning;
        }
    }
    void Move()
    {
        if (WolfState == State.Wandering)
        {
            if (RandomWanderTime <= 0)
            {
                float xMove = Random.Range(-44.1f, 72.3f);
                float zMove = Random.Range(-31.6f, 20.4f);

                if (transform.position.z >= -34.59f)
                {
                    if (transform.position.x > 0)
                        xMove = Mathf.Clamp(xMove, 57.7f, 72.3f);
                    else
                        xMove = Mathf.Clamp(xMove, -44.1f, -32.4f);
                }
                if (transform.position.x > -32.4f && transform.position.x < 57.7f)
                {
                    zMove = Mathf.Clamp(zMove, -46.7f, -31.6f);
                }


                agent.SetDestination(new Vector3(xMove, 0, zMove));
                RandomWanderTime = Random.Range(0f, 10f);
            }
            RandomWanderTime -= Time.deltaTime;
        }
        else if (WolfState == State.Attacking)
        {
            foreach (var gameObj in GameObject.FindGameObjectsWithTag("sheep") as GameObject[])
            {
                if (gameObj.name.Equals(VictimSheep.name))
                {
                    VictimSheep = gameObj;
                    break;
                }
            }
            agent.SetDestination(VictimSheep.transform.position);

        }
        else if (WolfState == State.Returning)
        {
            if (!isReturning) { 
            agent.SetDestination(lastWanderPos);
                isReturning = true;
            }
            /* float xMove;
             float zMove;
             if(transform.position.z>-25f )
             {
                 if (!isReturning) {
                 zMove = Random.Range(-25f, 20.4f);
                 xMove = Random.Range(-44.1f, -32.4f);
                 if (transform.position.x > 20f)
                 {
                     xMove = Random.Range(57.7f, 72.3f);
                 }
             }else
             {
                 zMove = Random.Range(-46.7f, -31f);
                 xMove = Random.Range(-44.1f, 20f);
                 if (transform.position.x > 20f)
                 {
                     xMove = Random.Range(20, 72.3f);  
                 }
             }
             agent.SetDestination(new Vector3(xMove, 0, zMove));
                 isReturning = true;
             }
         }*/
            if (lastpos == transform.position)
            {
                WolfState = State.Wandering;
                isReturning = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("sheep"))
        {
            GameManager.SheepN--;
        }
    }
}
