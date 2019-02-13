using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class SheepMovement1 : MonoBehaviour
{
    public enum State { Idle, Wandering, RunningFromDog, WalkingFromDog }
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

        sheepState = State.Wandering;
        RandomIdle = 0f;
        RandomWander = 0f;
        RandomRunFD = 0f;
        
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
         if (sheepState == State.Wandering)
        {
           
            if (RandomWander <= 0)
            {
                
                float xMove = Random.Range(10f, 20f);
                float zMove = Random.Range(-10f, 10f);
                agent.SetDestination(new Vector3(transform.position.x - xMove, 0, transform.position.z + zMove));
                RandomWander = Random.Range(0, 3);


            }
            RandomWander -= Time.deltaTime;
            if (lastpos == transform.position) RandomWander = 0;
        }
        else if (sheepState == State.RunningFromDog)
        {

            if (RandomRunFD <= 0)
            {

                FromDogDirection = new Vector2(Random.Range(10f, 20f), Random.Range(-10, -5));
                if (transform.position.z < -22.35f )
                    FromDogDirection.y= Random.Range(5, 10);

                if (transform.position.z >= -8.2f)
                    FromDogDirection.y = Random.Range(-10, -5);
                movespeed = Random.Range(1f, 3f);
                agent.SetDestination(new Vector3(transform.position.x - FromDogDirection.x * movespeed, 0, transform.position.z + FromDogDirection.y * movespeed));

                RandomRunFD = Random.Range(0, 7);
                if (transform.position == lastpos) { sheepState = SheepMovement1.State.Wandering;
                    RandomRunFD = 0;
                }
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
