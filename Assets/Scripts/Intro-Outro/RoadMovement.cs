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
    public bool ContinueAfterStop = false;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        if(!ContinueAfterStop) StartCoroutine("StopCar");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position+= Vector3.left *  (speed * Time.deltaTime);
        if (transform.position.x <= startPos.x - distance)
        {
            transform.position = startPos;
        }
        
    }

    IEnumerator StopCar()
    {
        yield return new WaitForSeconds(TimeBeforeStop);

        while (speed > 0)
        {
            speed -= 1;
            yield return new WaitForSeconds(0.2f);
        }
        if (stop)
        {
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene(2);
        }

    }


    
}
