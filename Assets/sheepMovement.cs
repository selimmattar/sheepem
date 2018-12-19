using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sheepMovement : MonoBehaviour {
    enum State { Idle,Wandering,RunningFromDog,WalkingFromDog }
    State sheepState;
    public GameObject Dog;
    float RandomWander;
    float RandomIdle;
    float RandomRunFD;
    float RandomWalkFD;
    bool isIdle;
    Vector2 Movement;
    float movespeed;
    Rigidbody rigidbody;
    float randomState;
    Vector2 FromDogDirection;
    bool IsRunningFromDog = false;
    public  bool Woof=false;
    
    private void Start()
    {
       
        sheepState = State.Idle;
        RandomIdle = 5f;
        RandomWander = 5f;
        RandomRunFD = 0f;

        isIdle = true;
        rigidbody = GetComponent<Rigidbody>();
    }
    
    void Update()
    {

        if (Vector3.Distance(Dog.transform.position, this.transform.position) <= 2.5f )
         {
             //sheepState = State.RunningFromDog;

         }
             Move();
       
        
    }
    
    private void Move()
    {
        if (sheepState == State.Idle)
        {
            if (RandomIdle <= 0)
            {
                Movement = new Vector2(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));
                movespeed = Random.Range(0, 3);
                rigidbody.velocity = new Vector3(Movement.x * movespeed, rigidbody.velocity.y, Movement.y * movespeed);
                transform.eulerAngles = new Vector3(0, Mathf.Atan2(Movement.x, Movement.y) * Mathf.Rad2Deg, 0);
                RandomIdle = Random.Range(0, 3);
                randomState = Random.Range(0f, 1f);
                if (randomState >= 0.7)
                    sheepState = State.Wandering;
            }
            RandomIdle -= Time.deltaTime;
        }
        else if (sheepState == State.Wandering)
        {
            if (RandomWander <= 0)
            {
                Movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                movespeed = Random.Range(0, 3);
                rigidbody.velocity = new Vector3(Movement.x * movespeed, rigidbody.velocity.y, Movement.y * movespeed);
                transform.eulerAngles = new Vector3(0, Mathf.Atan2(Movement.x, Movement.y) * Mathf.Rad2Deg, 0);
                RandomWander = Random.Range(0, 3);
                sheepState = State.Idle;

            }
            RandomWander -= Time.deltaTime;
        }
        else if (sheepState == State.RunningFromDog)
        {
            Debug.Log("RUN");
          
                if (RandomRunFD <= 0)
                {
                    FromDogDirection = new Vector2(Random.Range(-2f, -1f), Random.Range(-2f, -1f));
                    if (Dog.transform.position.x < this.transform.position.x)
                        FromDogDirection.x = Random.Range(1f, 2f);

                    if (Dog.transform.position.z < this.transform.position.z)
                        FromDogDirection.y = Random.Range(1f, 2f);
                    sheepState = State.RunningFromDog;
                    movespeed = Random.Range(0, 3);
                    rigidbody.velocity = new Vector3(FromDogDirection.x * movespeed, rigidbody.velocity.y, FromDogDirection.y * movespeed);
                    transform.eulerAngles = new Vector3(0, Mathf.Atan2(FromDogDirection.x, FromDogDirection.y) * Mathf.Rad2Deg, 0);
                    RandomRunFD = Random.Range(0f, 2f);
                }
            }
            RandomRunFD -= Time.deltaTime;
            if (Vector3.Distance(Dog.transform.position, this.transform.position) > 3)
            {

                RandomRunFD = 0f;
                sheepState = State.Idle;
            }
            
        
        
    }
   
    private void OnCollisionEnter(Collision collision)
    {
        
        rigidbody.angularVelocity = Vector3.zero;
    }
  
 

}
