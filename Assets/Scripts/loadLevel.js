#pragma strict

var levelName : String = 'Enter level Name here';

function OnTriggerEnter2D (other : Collider2D) {
    if(other.tag == 'Player'){
        Application.LoadLevel(levelName);
    }
}
