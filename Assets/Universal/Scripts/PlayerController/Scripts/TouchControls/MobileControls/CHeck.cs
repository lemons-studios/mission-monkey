using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHeck : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Debug.Log("hooray");
        }
    }
}
