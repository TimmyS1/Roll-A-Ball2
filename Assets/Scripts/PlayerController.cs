using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;
	public float distToGround = 0.5f;
	public int jumpForce;

	private Rigidbody rb;
	private int count;
	private Vector3 startPosition;

	void Start () 
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText ();
		winText.text = "";
		startPosition = transform.position;
	}

	void FixedUpdate ()
	{
		if (Input.GetKey(KeyCode.Space) && isGrounded()) {
			rb.AddForce (0, jumpForce, 0);
		}

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical"); 

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);

		if (transform.position.y < -10) {
			transform.position = startPosition;
		}
	}

	bool isGrounded() {
		return Physics.Raycast (transform.position, Vector3.down, distToGround);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up")) 
		{
			other.gameObject.SetActive (false);
			count++;
			SetCountText ();

		}
	}
	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 12) 
		{
			winText.text = "You Win!";
		}
	}
}
