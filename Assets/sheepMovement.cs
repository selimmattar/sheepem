using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class sheepMovement : MonoBehaviour {
   public enum State { Idle,Wandering,RunningFromDog,WalkingFromDog }
    public State sheepState;
    float RandomWander;
    float RandomIdle;
    public float RandomRunFD;
    public float RandomWalkFD;
    bool isIdle;
    Vector2 Movement;
    public float movespeed;
    new Rigidbody rigidbody;
    float randomState;
    public Vector2 FromDogDirection;
    bool IsRunningFromDog = false;
    public NavMeshAgent agent;
    public Vector3 lastpos;
    private void Start()
    {
       
        sheepState = State.Idle;
        RandomIdle = 0f;
        RandomWander = 5f;
        RandomRunFD = 0f;
        agent.enabled = false;
        isIdle = true;
        rigidbody = GetComponent<Rigidbody>();
        
    }
    
    void Update()
    {
        Move();
        
    }
    private void LateUpdate()
    {
        lastpos = transform.position;
    }
    
    private void Move()
    {
        if (sheepState == State.Idle)
        {
            if (RandomIdle <= 0)
            {
                GetComponent<NavMeshObstacle>().enabled = false;
                agent.enabled = true;
                float xMove = Random.Range(-1, 1);
                float zMove = Random.Range(-1, 1);
                agent.SetDestination(new Vector3(transform.position.x + xMove, 0, transform.position.z + zMove));
                RandomIdle = Random.Range(0f, 1f);
                randomState = Random.Range(0f, 1f);
                if (randomState >= 0.6f)
                    sheepState = State.Wandering;
            }
            if (transform.position == lastpos) RandomIdle -= Time.deltaTime;
        }
        else if (sheepState == State.Wandering)
        {
            if (RandomWander <= 0)
            {
                float xMove = Random.Range(-10, 10);
                float zMove = Random.Range(-10, 10);
                agent.SetDestination(new Vector3(transform.position.x + xMove, 0, transform.position.z + zMove));
                RandomWander = Random.Range(0, 3);
               

            }
            RandomWander -= Time.deltaTime;
            if (transform.position == lastpos) {
                sheepState = State.Idle;
            } 
        }
        else if (sheepState == State.RunningFromDog)
        {



        }
            
        
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag.Equals("Border"))
        {
            Destroy(this.gameObject);
            GameManager.SheepN--;

        }
   
    }

    
    public void runFromDog(sheepMovement sheep)
    {
            
        
        if (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, sheep.transform.position) <= 3f)
        {
            sheep.RandomRunFD = 0;
        }
        
      
        if (sheep.RandomRunFD <= 0)
        {

            sheep.FromDogDirection = new Vector2(Random.Range(-2f, -1f), Random.Range(-2f, -1f));
            if (GameObject.FindGameObjectWithTag("Player").transform.position.x < sheep.transform.position.x)
                sheep.FromDogDirection.x = Random.Range(1f, 2f);

            if (GameObject.FindGameObjectWithTag("Player").transform.position.z < sheep.transform.position.z)
                sheep.FromDogDirection.y = Random.Range(1f, 2f);
            sheep.movespeed = Random.Range(0, 3);
            sheep.agent.SetDestination(new Vector3(sheep.transform.position.x + sheep.FromDogDirection.x * sheep.movespeed, 0, sheep.transform.position.z + sheep.FromDogDirection.y * sheep.movespeed));

            sheep.RandomRunFD = Random.Range(1f, 5f);
        }
        if (transform.position == sheep.lastpos) sheepState=State.Idle;
    }

 

}
