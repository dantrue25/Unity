using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour {

    public static float poop;

    public float theta;
    public float height;
    public float verticalSpeed;
    public float speedAtUnitCircle;
    //public float radius = WorldParams.worldRadius;

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
        var radius = _worldParams.worldRadius;

        var thetaSpeed = speedAtUnitCircle / radius;

        var random = new Random();
        //var randomHorizontal = Random.Range(-1f, 1f);
        var randomVertical = Random.Range(-1f, 1f);

        //var player = GameObject.Find("Player");
        //var playerMovement = player.GetComponent<Movement>();
        var playerMovement = _worldParams.PlayerMovement;


        var towardsPlayerHorizontal = Mathf.Sign(playerMovement.theta - theta);


        theta += thetaSpeed * towardsPlayerHorizontal * Time.deltaTime * 60;
        height += verticalSpeed * randomVertical * Time.deltaTime * 60;

        theta = theta % (Mathf.PI*2);

        var x = Mathf.Cos(theta) * radius;
        var y = height;
        var z = Mathf.Sin(theta) * radius;

        transform.localPosition = new Vector3(x, y, z);
    }
}
