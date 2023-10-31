using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerrr : MonoBehaviour
{
    [SerializeField] Transform ddd;
    [SerializeField] Vector2 pos;
    [SerializeField] Transform cam;
    [SerializeField] int sped1;
    [SerializeField] Camera ccc;

    void Start()
    {
        pos = new Vector2(ddd.position.x, ddd.position.y);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);   //pos = глобальные координаты мыши(которые были переведены)

            
        }

        cam.position = new Vector3(Mathf.Lerp(cam.position.x, pos.x, sped1 * Time.deltaTime), Mathf.Lerp(cam.position.y, pos.y, sped1 * Time.deltaTime), -10);


        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            pos = new Vector2(ddd.position.x, ddd.position.y);
        }



        if ((Input.GetMouseButton(1)))
        {
            ccc.orthographicSize = Mathf.Lerp(ccc.orthographicSize, 3.2f, 12 * Time.deltaTime);
        }
        else
        {
            ccc.orthographicSize = Mathf.Lerp(ccc.orthographicSize, 5, 20 * Time.deltaTime);
        }    
    }
}
