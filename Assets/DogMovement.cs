using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogMovement : MonoBehaviour {
    public float moveSpeed = 5f;
    public float turnSpeed = 80f;
    public JoystickScript joystick;
    public Camera cam;
    public NavMeshAgent agent;
    private Rigidbody rigidbody;
    // Use this for initialization
    void Start () {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        
        rigidbody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
                agent.SetDestination(hit.point);
        }
       /* rigidbody.velocity = new Vector3(joystick.Movement().x * moveSpeed, rigidbody.velocity.y, joystick.Movement().y * moveSpeed);
        if (joystick.Movement() != Vector2.zero)
            transform.eulerAngles = new Vector3(0, Mathf.Atan2(-joystick.Movement().y, joystick.Movement().x) * Mathf.Rad2Deg, 0);*/
      /*  Debug.Log(" hor "+joystick.Horizontal);
        Debug.Log(" ver "+joystick.Vertical);*/
        
        //  transform.eulerAngles=new Vector3(0,,0);
        /* if (Input.GetKey(KeyCode.Z))
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.S))
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Q))
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);*/
    }
    
}
