using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
	public Animator animatorKanan;
	public Animator animatorKiri;
	public Animator Bola;
	 public int force;
	 public int skorKanan = 0;
	 public int skorKiri = 0;
	 public GameObject selesai;

	 AudioSource audio;
	 public AudioClip suaraBola;

	 Text HasilKanan , HasilKiri, Pemenang;
  Rigidbody2D rigid;

  	


    void Start()
    {
        rigid = GetComponent<Rigidbody2D> ();
  Vector2 arah = new Vector2 (2, 0).normalized;
  rigid.AddForce (arah * force);

  HasilKanan = GameObject.Find("hasilKanan").GetComponent<Text>();
  HasilKiri = GameObject.Find("hasilKiri").GetComponent<Text>();
  
  GameObject.Find("Selesai").SetActive(false);
  audio = GetComponent<AudioSource>();

  
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D (Collision2D coll){

    	audio.PlayOneShot(suaraBola);

    	if(coll.gameObject.name == "GarisKanan"){
    		
    		skorKiri += 1;
    		HasilKiri.text = skorKiri+"";
    		if(skorKiri == 2){
    			selesai.SetActive(true);
    			animatorKanan.SetBool("Kanan", false);
    			animatorKiri.SetBool("Left", false);
    			Pemenang = GameObject.Find("pemenang").GetComponent<Text>();
    			Pemenang.text = "Tim Kiri Menang!";
    			Destroy (gameObject);
    			return;
    		}
    		ResetBall();
    		Vector2 arah = new Vector2(2,0).normalized;
    		rigid.AddForce(arah * force);
    		

    	}else if(coll.gameObject.name == "GarisKiri"){
    		
    		
    		skorKanan += 1;
    		HasilKanan.text = skorKanan+"";
    		if(skorKanan == 2){
    			selesai.SetActive(true);
    			animatorKiri.SetBool("Left", false);
    			animatorKanan.SetBool("Kanan", false);
    			Pemenang = GameObject.Find("pemenang").GetComponent<Text>();
    			Pemenang.text = "Tim Kanan Menang!";
    			Destroy (gameObject);
    			return;
    		}
    		ResetBall();
    		Vector2 arah = new Vector2(-2 , 0).normalized;
    		rigid.AddForce(arah * force);
    		

    		}else if(coll.gameObject.name == "PemukulKanan"){

    		float sudut = (transform.position.y - coll.transform.position.y) * 5f;
    		Vector2 arah = new Vector2(rigid.velocity.x , sudut).normalized;
    		rigid.AddForce(arah * force );
    		animatorKanan.SetBool("Kanan", true);
    		animatorKiri.SetBool("Left", false);
    		Bola.SetBool("Pindah", false);
    		Bola.SetBool("keKiri", true);

    	}else if(coll.gameObject.name == "PemukulKiri"){

    		float sudut = (transform.position.y - coll.transform.position.y) * 5f;
    		Vector2 arah = new Vector2(rigid.velocity.x , sudut).normalized;
    		rigid.AddForce(arah * force );
    		animatorKiri.SetBool("Left", true);
    		Bola.SetBool("Pindah", true);
    		Bola.SetBool("keKanan", true);
       		animatorKanan.SetBool("Kanan", false);

    	


    	}
    }
    public void ResetBall(){
    	transform.localPosition = new Vector2(0,0);
    	rigid.velocity = new Vector2(0,0);
    	animatorKanan.SetBool("Kanan", false);
    	animatorKiri.SetBool("Left", false);
    	Bola.SetBool("keKanan", false);
    	Bola.SetBool("keKiri", false);
    }

    public void StopKiri(){
        animatorKiri.SetBool("Left", false);
    }
    public void StopKanan(){
        animatorKanan.SetBool("Kanan", false);
    }


}