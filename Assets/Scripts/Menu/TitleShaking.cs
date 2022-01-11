using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleShaking : MonoBehaviour
{

    public MenuTitleShaking shakingPreset;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Shake");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Shake()
    {
        float timePassed = 0;
        while (timePassed <= shakingPreset.timeToRotate)
        {
            transform.rotation = Quaternion.Euler(0,shakingPreset.rotationOvertimeY.Evaluate(timePassed/shakingPreset.timeToRotate)*10, shakingPreset.rotationOvertimeZ.Evaluate(timePassed / shakingPreset.timeToRotate)*2);
            timePassed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        StartCoroutine("Shake");
    }
}
