using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepManager : MonoBehaviour
{
    public GameObject Danger;
    // Start is called before the first frame update
    void Start()
    {
    /*    foreach (var gameObj in GameObject.FindGameObjectsWithTag("sheep") as GameObject[])
        {

            runFromDog(gameObj.GetComponent<sheepMovement>());
        }*/
    }

    // Update is called once per frame
    void Update()
    {
     

    }
    public void dogBark()
    {
        
    }
    public void runFromDog(sheepMovement sheep)
    {

       
            if (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, sheep.transform.position) <= 3f)
        {
            sheep.sheepState = sheepMovement.State.RunningFromDog;
            sheep.RandomRunFD = 0;
        }

        
        if (sheep.RandomRunFD <= 0)
        {

            sheep.FromDogDirection = new Vector2(Random.Range(-10, -5), Random.Range(-10, -5));
            if (GameObject.FindGameObjectWithTag("Player").transform.position.x < sheep.transform.position.x)
                sheep.FromDogDirection.x = Random.Range(5, 10);

            if (GameObject.FindGameObjectWithTag("Player").transform.position.z < sheep.transform.position.z)
                sheep.FromDogDirection.y = Random.Range(5, 10);
            sheep.movespeed = Random.Range(0, 3);
            sheep.agent.SetDestination(new Vector3(sheep.transform.position.x + sheep.FromDogDirection.x * sheep.movespeed, 0, sheep.transform.position.z + sheep.FromDogDirection.y * sheep.movespeed));

            sheep.RandomRunFD = Random.Range(5, 10);
        }
        
        if (sheep.transform.position == sheep.lastpos) sheep.sheepState = sheepMovement.State.Idle;
    }
}
