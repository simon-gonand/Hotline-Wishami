using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoadMovement : MonoBehaviour
{
    private Vector3 startPos;
    public float speed = 10f;
    public float distance = 10f;
    public float TimeBeforeStop = 5f;
    public bool stop = false;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position+= Vector3.left *  (speed * Time.deltaTime);
        if (transform.position.x <= startPos.x - distance)
        {
            transform.position = startPos;
        }
        if (Time.timeSinceLevelLoad > 5f && stop)
        {
            SceneManager.LoadScene(2);
        }
    }


    
}
