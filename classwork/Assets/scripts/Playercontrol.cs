using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontrol : MonoBehaviour {
	
	public float MaxForce = 300;
	public float MaxSpeed = 5;
	public float JumpForce = 400;
	public bool bFaceRight = true;
	private Rigidbody2D heroBody;
	private Transform mGroundCheck;
	private bool bGrounded = true;
	private void Awake()
	{
		mGroundCheck = transform.Find("GroundCheck");
	}
	// Use this for initialization
	void Start () {
		heroBody = gameObject.GetComponent<Rigidbody2D> ();
		//heroBody.mass = 2;
	}
	private void FixedUpdate()
	{
		float h = Input.GetAxis ("Horizontal");
//		Debug.Log (h);
		if (heroBody.velocity.x < MaxSpeed)
			heroBody.AddForce (Vector2.right * h * MaxForce);
		if (Mathf.Abs(heroBody.velocity.x) > MaxSpeed)
			heroBody.velocity = new Vector2 (Mathf.Sign(heroBody.velocity.x) * MaxSpeed, 0); 

		if (h > 0 && !bFaceRight)
			flip ();
		else if (h < 0 && bFaceRight)
			flip ();

		if (Input.GetButtonDown ("Jump") && bGrounded)
			heroBody.AddForce (new Vector2(0,JumpForce));
			
	}
	// Update is called once per frame
	void Update () {
		bGrounded = Physics2D.Linecast (transform.position,
										mGroundCheck.position,
										1<<LayerMask.NameToLayer ("ground"));
		Debug.Log ("h");
	}
	void flip()
	{
		bFaceRight = !bFaceRight;
		Vector3 localscale = transform.localScale;
		localscale.x *= -1;
		transform.localScale = localscale;
	}
}
