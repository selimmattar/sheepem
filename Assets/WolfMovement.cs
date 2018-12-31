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
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        WolfState = State.Wandering;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Random.RandomRange(0, 1000) == 50) { 
            if (WolfState == State.Wandering) {
            float DogDist;
            float WolfDist;
        foreach (var gameObj in GameObject.FindGameObjectsWithTag("sheep") as GameObject[])
        {
                
               DogDist = Vector3.Distance(gameObj.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);
                WolfDist = Vector3.Distance(gameObj.transform.position, transform.position);
                if (WolfDist < DogDist && DogDist > 10)
                {
                   
                    WolfState = State.Attacking;
                    VictimSheep = gameObj;
                    break;
                }
                    
                
            }
            }
        }
        Move();
    }
    void Attack(GameObject sheep)
    {

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
                if (transform.position.x > -32.4f && transform.position.x < 57.7f) { 
                    zMove = Mathf.Clamp(zMove, -46.7f, -31.6f);  
                }
                

                agent.SetDestination(new Vector3( xMove, 0,  zMove));
                RandomWanderTime = Random.Range(0f, 10f);
            }
            RandomWanderTime -= Time.deltaTime;
        }else if (WolfState == State.Attacking)
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
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("sheep"))
        {
            GameManager.SheepN--;
        }
    }
}
