using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ForeBorder : MonoBehaviour
{
    public Image Danger;
    private GameObject Dog;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        Dog = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag.Equals("sheep"))
        {
            
            /* if(Vector3.Distance(Dog.transform.position, other.gameObject.transform.position) >= Mathf.Sqrt(Mathf.Pow(Screen.width,2)+Mathf.Pow(Screen.height,2)) )
             {
                 Danger.rectTransform.position = new Vector3(370,0,0);
                 if(Dog.transform.position.x>other.transform.position.x)
                     Danger.rectTransform.position = new Vector3(-370, 0, 0);
             } */
            float xDist = Dog.transform.position.x - other.transform.position.x;
            float yDist= Dog.transform.position.z - other.transform.position.z;
            Vector3 screenPoint = cam.WorldToViewportPoint(other.gameObject.transform.position);
            bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
            if (!onScreen)
            {
                Debug.Log(":')");
               Danger.rectTransform.localPosition = new Vector3(Screen.width/2, 0, 0);
                if (xDist<0)
                    Danger.rectTransform.localPosition = new Vector3(-Screen.width / 2, 0, 0);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
