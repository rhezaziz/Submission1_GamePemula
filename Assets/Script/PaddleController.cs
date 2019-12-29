using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PaddleController : MonoBehaviour
{
    public float kecepatan;
    public string axis;
    public float batasAtas;
    public float batasBawah;



    [Header("Events")]
    [Space]

    public UnityEvent Animator;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    void Start(){

    }
    void Update(){
    	float gerak = Input.GetAxis(axis) * kecepatan * Time.deltaTime;
    	


    	float nextPos = transform.position.y + gerak;
    	if(nextPos < batasBawah){
    		gerak = 0;
    	
    	}else if(nextPos > batasAtas){
    		gerak = 0;
    	
    	}
    	transform.Translate(0, gerak, 0);
    }
}
