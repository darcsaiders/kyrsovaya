using UnityEngine;
using System.Collections;

public class HatController : MonoBehaviour
{

    public Camera cam;
    private bool canControl;

    private float maxWidth;//максимальная ширина экрна

    void Start()
    {//метод который устанавливает границы на которых может передвигаться предмет 
        if (cam == null)
        {
            cam = Camera.main;
        }
        canControl = false;
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float hatWidth = GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - hatWidth;
    }

    //метод который двигает предмет при передвижении мыши
    void FixedUpdate()
    {
        if (canControl)
        {
            Vector3 rawPosition = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 targetPosition = new Vector3(rawPosition.x, -3.0f, 0.0f);
            float targetWidth = Mathf.Clamp(targetPosition.x, -maxWidth, maxWidth);
            targetPosition = new Vector3(targetWidth, targetPosition.y, targetPosition.z);
            GetComponent<Rigidbody2D>().MovePosition(targetPosition);
        }
    }

    public void ToggleControl(bool toggle)//убирает движение предмета в моем меню
    {
        canControl = toggle;
    }
}
