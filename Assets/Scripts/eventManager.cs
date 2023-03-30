using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class eventManager : MonoBehaviour
{
    public UnityEvent EventSound;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //plus qu'à trouver comment je teste les positions
        {
            EventSound.Invoke();
        }
    }
}
