using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMovement : MonoBehaviour {
    float degree=0;

    private void Start()
    {
    }

    void Update () {

        if (transform.localRotation == Quaternion.Euler(0f, 0f, 90))
        {
            if (Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                StartCoroutine("PullOutGun");

            }
        }
        else
        {
            if (Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                transform.localRotation = Quaternion.Euler(0f, 0f, 90);
                degree = 0;
                StopAllCoroutines();
            }
        }


    }
    IEnumerator PullOutGun()
    {
        while (degree < 90)
        {
            yield return new WaitForSeconds(0.1f);

            degree += 10;
           transform.localRotation = Quaternion.Euler(0f, 0f, 90-degree);
            
        }
        degree = 0;
        while(true)
        {
            yield return null;
            Vector3 mPosition = Input.mousePosition; 
            Vector3 oPosition = transform.position; 
            mPosition.z = oPosition.z - Camera.main.transform.position.z;

            Vector3 target = Camera.main.ScreenToWorldPoint(mPosition);

            float dy = target.y - oPosition.y;
            float dx = target.x - oPosition.x;

            float rotateDegree = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0f, 0f, rotateDegree);
        }

    }

}


