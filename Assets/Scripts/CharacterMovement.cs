using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
	[SerializeField] private Animator animator;
	[SerializeField] private float walkSpeed;
	private float speedboost = 0;
	float t = 0;
	private float facing = 1;
	float y;
	private void Update()
	{
		float input = (Input.GetAxisRaw("Horizontal"));
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.D))
        {
			speedboost = 1.5f;
			input = Mathf.Lerp(input, 1.5f, t);
			t += 0.01f;
			//input = 1.5f;
			
        }
        
		if(Input.GetKeyUp(KeyCode.LeftShift) && Input.GetKey(KeyCode.D))
        {
			t = 0;
			
		}
		else if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.A))
        {
			speedboost = 1.5f;
			input = Mathf.Lerp(input, -1.5f, -0.2f);
			//input = -1.5f;
		}
        else
        {
			speedboost = 1;
        }
		facing = input;

        if (Input.GetKeyDown(KeyCode.Space))
        {
			animator.SetBool("Jump", true);
        }
		else if (Input.GetKeyUp(KeyCode.Space))
		{
			animator.SetBool("Jump", false);
		}

		//if (facing < 0)
		//{
		//	transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, 270f, 0f), Time.deltaTime * 4f);
		//}
		//else if (facing > 0)
		//{
		//	transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, 90f, 0f), Time.deltaTime * 4f);
		//}
		y -= 1;
		transform.position += new Vector3(0f, y, input * walkSpeed * speedboost * Time.deltaTime);

		animator.SetFloat("Speed", input);
		Debug.Log(walkSpeed * speedboost);
	}
}
