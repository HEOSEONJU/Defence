using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    //적타워X35기준 18
    float X;

    [SerializeField]
    float speed;
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z);
            Vector3 mousePoint = Camera.main.ScreenToViewportPoint(mousePos);
            if (mousePoint.y <= 0.19) return;//하단의 UI높이

            if (mousePoint.x < 0.5) X -= Time.deltaTime* speed;//좌측이동
            else X += Time.deltaTime* speed;//우측이동
            X = Mathf.Clamp(X, 0, 18);
            transform.position = new Vector3(X, 0, -10);
        }
        
        
    }
}
