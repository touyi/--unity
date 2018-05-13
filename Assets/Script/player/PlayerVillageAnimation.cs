using UnityEngine;
using System.Collections;

public class PlayerVillageAnimation : MonoBehaviour {

    private Animator anim;
	// Use this for initialization
	void Start () {
        anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Rigidbody rigi = GetComponent<Rigidbody>();
        anim.SetFloat("MoveSpeed", rigi.velocity.magnitude / GetComponent<PlayerVillageMove>().velocity);
	}
}


