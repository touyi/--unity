using UnityEngine;
using System.Collections;

public class PlayerVillageMove : MonoBehaviour {

    public float velocity = 5;
    private NavMeshAgent agent;

    void Start() {
        agent = this.GetComponent<NavMeshAgent>();
    }

	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 vel = GetComponent<Rigidbody>().velocity;
        if (Mathf.Abs(h) > 0.05f || Mathf.Abs(v) > 0.05f) {
            Quaternion nowrota = Quaternion.LookRotation(new Vector3(-h, 0, -v));
            float angle = Quaternion.Angle(transform.rotation, nowrota);
            
            //iTween.RotateTo(this.gameObject, nowrota.eulerAngles, angle * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, nowrota, 0.5f+angle/50.0f * Time.deltaTime);
            //if (angle < 45)
            {
                GetComponent<Rigidbody>().velocity = new Vector3(-h , vel.y, -v ).normalized * velocity;
            }
        } else {
            if (agent.enabled == false) {
                GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
        if (agent.enabled) {
            transform.rotation = Quaternion.LookRotation ( agent.velocity  );
        }
	}
}
