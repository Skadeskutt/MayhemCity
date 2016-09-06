using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class NPCRandomWalking : MonoBehaviour {
    public float walkingSpeed = 12f;
    public float runningSpeed = 50f;

    public bool isRunning = false;

    public Nationality.COUNTRY nationality;


    private Vector3 moveDirection = Vector3.zero;
    private Animator anim;


    void Start() {
        System.Array values = System.Enum.GetValues(typeof(Nationality.COUNTRY));
        nationality = (Nationality.COUNTRY) values.GetValue(Random.Range(0, values.Length));

        anim = GetComponent<Animator>();

        if(nationality == Nationality.COUNTRY.SWEDEN) {
            walkingSpeed -= 2f;
            runningSpeed -= 10f;
        } else if(nationality == Nationality.COUNTRY.NORWAY) {
            walkingSpeed += 2f;
            runningSpeed += 5f;
        } else if(nationality == Nationality.COUNTRY.ICELAND) {
            walkingSpeed += 2f;
            runningSpeed += 5f;
        }

    }
	
	void FixedUpdate() {
        if(anim.GetBool("running") != isRunning)
            anim.SetBool("running", isRunning);
        
        transform.Rotate(new Vector3(0f, -.3f, 0f));

        moveDirection = new Vector3(0f, 0, .6f);
        moveDirection *= isRunning ? runningSpeed : walkingSpeed;
        transform.Translate(moveDirection * Time.deltaTime);
    }
}
