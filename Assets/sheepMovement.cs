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

        if (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position) <= 3f)
        {
           
            this.sheepState = State.RunningFromDog;
        }
            
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

            if (RandomRunFD <= 0)
            {

               FromDogDirection = new Vector2(Random.Range(-10, -5), Random.Range(-10, -5));
                if (transform.position.x < 20f)
                   FromDogDirection.x = Random.Range(5, 10);

                if (transform.position.z <-15f)
                    FromDogDirection.y = Random.Range(5, 10);
                movespeed = Random.Range(1f, 3f);
                agent.SetDestination(new Vector3(transform.position.x + FromDogDirection.x * movespeed, 0, transform.position.z + FromDogDirection.y * movespeed));

                RandomRunFD = Random.Range(3, 5);
                if (transform.position == lastpos) sheepState = sheepMovement.State.Idle;
            }
            RandomRunFD -= Time.deltaTime;

           

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

    
    

 

}
