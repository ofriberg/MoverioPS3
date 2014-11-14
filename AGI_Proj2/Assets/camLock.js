#pragma strict

var target : Transform;
var zDistance : float;
var yDistance : float;
var xDistance : float;
var xRotation: float;
function Update(){
 	
    transform.position.z = target.position.z -zDistance;
    transform.position.y = target.position.y -yDistance;
    transform.position.x = target.position.x -xDistance;
 	transform.rotation.x = target.rotation.x -xRotation;
}
