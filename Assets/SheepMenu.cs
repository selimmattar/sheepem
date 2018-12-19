using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepMenu : MonoBehaviour {

    
    float RandomIdle;
    Vector2 Movement;
    float movespeed;
    Rigidbody rigidbody;

    private void Start()
    {
       
        RandomIdle = 5f;
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (RandomIdle <= 0)
        {
            Movement = new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
            movespeed = Random.Range(0, 3);
            rigidbody.velocity = new Vector3(Movement.x * movespeed, rigidbody.velocity.y, Movement.y * movespeed);
            transform.eulerAngles = new Vector3(0, Mathf.Atan2(Movement.x, Movement.y) * Mathf.Rad2Deg, 0);
            RandomIdle = Random.Range(0, 3);
          
        }
        RandomIdle -= Time.deltaTime;
        Mathf.Clamp(this.transform.position.x, 16, -2.5f);
        Mathf.Clamp(this.transform.position.z, 12, 5);
    }

   
}
