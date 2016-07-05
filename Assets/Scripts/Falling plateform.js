#pragma strict

var plateform : GameObject;
var sound : AudioClip;
private var hasPlayed = false;


function OnTriggerEnter2D (other : Collider2D) {
    if(other.tag == "Player"){
        //Debug.Log("dected");

        if(hasPlayed == false){
            hasPlayed = true;
            GetComponent.<AudioSource>().PlayOneShot(sound);
        }

        plateform.GetComponent.<Rigidbody2D>().isKinematic = false;
    }
}
