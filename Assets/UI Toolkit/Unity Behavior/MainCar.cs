using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCar : MonoBehaviour
{

    private bool CanShowPlane = true;
    public Object plane;

    private void OnMouseDown()
    {
        if (CanShowPlane)
        {
            Debug.Log("test");
            GameObject p = (GameObject)Instantiate(plane);
            p.transform.position = transform.position + (Vector3.up * 3) + (Vector3.left * 15) + (Vector3.back * 5);
            p.GetComponent<RoadMovement>().speed = 5f;
            CanShowPlane = false;
        }
        

    }

}
