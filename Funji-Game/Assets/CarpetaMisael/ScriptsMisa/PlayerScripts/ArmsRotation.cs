using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmsRotation : MonoBehaviour
{
    public Transform player;
    public Transform leftArm; 
    public Transform rightArm;
    public Camera mainCamera;
    void Update()
    {
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f; ;

        Vector3 direction = (mousePos - player.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

       
        rightArm.rotation = Quaternion.Euler(0, 0, angle);
        leftArm.rotation = Quaternion.Euler(0, 0, angle);

       
        if (direction.x < 0)
        {
            player.localScale = new Vector3(-11, 11, 11);
            rightArm.localScale = new Vector3(1, -1, 1);
            leftArm.localScale = new Vector3(1, -1, 1);
        }
        else
        {
            player.localScale = new Vector3(11, 11, 11);
            rightArm.localScale = new Vector3(1, 1, 1);
            leftArm.localScale = new Vector3(1, 1, 1);
        }
    }
}
