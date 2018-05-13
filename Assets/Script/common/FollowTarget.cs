using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour {

    public Vector3 offset;
    public float moveLerp = 0.5f;
    private Transform player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {

        //transform.position = Vector3.Slerp(transform.position, player.position + offset, moveLerp);
        transform.position = player.position + offset;
    }
}
