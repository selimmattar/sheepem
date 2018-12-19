using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoystickScript : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image BckgImg;
    private Image JoystickImg;
    private Vector3 InputVector;
    // Use this for initialization
    void Start()
    {
        BckgImg = GetComponent<Image>();
        JoystickImg = transform.GetChild(0).GetComponent<Image>();
        InputVector = Vector3.zero;
    }
    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(BckgImg.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            pos.x = (pos.x / BckgImg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / BckgImg.rectTransform.sizeDelta.y);
            InputVector = new Vector3(pos.x * 2, 0, pos.y * 2);
            InputVector = (InputVector.magnitude > 1.0f) ? InputVector.normalized : InputVector;
            JoystickImg.rectTransform.anchoredPosition =
                new Vector3(InputVector.x * (BckgImg.rectTransform.sizeDelta.x / 2), InputVector.z * (BckgImg.rectTransform.sizeDelta.y / 2));

        }
       
    }
    public virtual void OnPointerUp(PointerEventData ped)
    {
        InputVector = Vector3.zero;
        JoystickImg.rectTransform.anchoredPosition = Vector3.zero;

    }
    public virtual void OnPointerDown(PointerEventData ped)
    {

        OnDrag(ped);

    }

    public float Horizontal()
    {

        return InputVector.x;

    }

    public float Vertical()
    {

        return InputVector.z;

    }
    public Vector2 Movement()
    {
        Vector2 Mv = new Vector2(InputVector.x, InputVector.z);
        return Mv;
    }
}
