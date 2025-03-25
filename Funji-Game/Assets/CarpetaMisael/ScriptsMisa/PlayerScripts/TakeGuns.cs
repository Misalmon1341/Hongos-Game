using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeGuns : MonoBehaviour
{
    public GameObject[] guns;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ActiveGuns(int numero)
    {
        for (int i = 0; i < guns.Length; i++)
        {
            guns[i].SetActive(false);
        }

        guns[numero].SetActive(true);
    }
}
