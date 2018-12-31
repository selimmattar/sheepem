using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class DogMovement : MonoBehaviour, IPointerDownHandler
{
    public float moveSpeed = 5f;
    public float turnSpeed = 80f;
    public JoystickScript joystick;
    public Camera cam;
    public NavMeshAgent agent;
    private Rigidbody rigidbody;
    public GameObject DestinationTarget;
    private Vector3 lastpos;
    public void OnPointerDown(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
    private bool IsPointerOverUIObject()
    {
        var eventDataCurrentPosition = new PointerEventData(EventSystem.current)
        {
            position = new Vector2(Input.mousePosition.x, Input.mousePosition.y)
        };
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
    // Use this for initialization
    void Start () {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        Physics.IgnoreLayerCollision(10,9);
        rigidbody = GetComponent<Rigidbody>();
    }
    private void LateUpdate()
    {
        lastpos = transform.position;
        
    }

    // Update is called once per frame
    void Update () {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -37.2f, 65.5f), transform.position.y, Mathf.Clamp(transform.position.z, -42.4f, 20.4f));
        if (Input.GetMouseButtonDown(0) && !IsPointerOverUIObject())
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
                DestinationTarget.transform.position = new Vector3(hit.point.x, DestinationTarget.transform.position.y, hit.point.z);
                DestinationTarget.GetComponent<Renderer>().enabled=true;
                
            }
            
           

        }
        if (lastpos == transform.position && !agent.isStopped)
            DestinationTarget.GetComponent<Renderer>().enabled = false;
        else DestinationTarget.GetComponent<Renderer>().enabled = true;
        /*else
        {
            rigidbody.velocity = new Vector3(joystick.Movement().x * moveSpeed, rigidbody.velocity.y, joystick.Movement().y * moveSpeed);
            if (joystick.Movement() != Vector2.zero)
                transform.eulerAngles = new Vector3(0, Mathf.Atan2(-joystick.Movement().y, joystick.Movement().x) * Mathf.Rad2Deg, 0);
        }*/
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
