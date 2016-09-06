using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MeteorController : MonoBehaviour {

    void Start() {
        GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-1.00f, 1.00f), -5000f, Random.Range(-1.00f, 1.00f)));
    }

    void OnTriggerEnter(Collider coll) {
        GetComponent<Rigidbody>().AddExplosionForce(1000f, transform.position, 100f);
        GetComponent<SphereCollider>().isTrigger = false;
        Destroy(gameObject, Random.Range(0.00f, 100.00f));
    }
}
