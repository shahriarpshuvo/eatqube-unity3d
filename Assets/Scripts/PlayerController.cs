using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
	public float speed;
	Rigidbody rb;
	public Text countText;
	public Text winText;
	int count;


	void Start()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCount();
		winText.text = "";
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		var moveHorizontal = Input.GetAxis("Horizontal");
		var moveVertical = Input.GetAxis("Vertical");

		var movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		rb.AddForce(movement * speed);
	}

	void OnTriggerEnter(Collider other)
	{		if (other.gameObject.CompareTag("Pick Up")) 
		{
			other.gameObject.SetActive(false);
			count += 1;
			SetCount();
			if ( count >= 12) 
			{
				winText.text = "You win!";
			}

		}
		Destroy(other.gameObject);       
	}

	void SetCount ()
	{
		countText.text = "Score: " + count.ToString();
	}
}
