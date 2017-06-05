using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {


    private WorldParams _worldParams;

    // Use this for initialization
    void Start()
    {

        //this. 

        _worldParams = GetComponentInParent<WorldParams>();


    }

    // Update is called once per frame
    void Update()
    {
        var radius = _worldParams.worldRadius + 10;
        var player = GameObject.Find("Player");
        var playerMovement = player.GetComponent<Movement>();
        var theta = playerMovement.theta;

        var x = Mathf.Cos(theta) * radius;
        var y = 0;
        var z = Mathf.Sin(theta) * radius;
        transform.LookAt(_worldParams.transform);



        transform.localPosition = new Vector3(x, y, z);
    }
}
