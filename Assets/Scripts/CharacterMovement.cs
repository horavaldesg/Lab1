using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
	[SerializeField] private Animator playerAnimator;
	[SerializeField] private Animator sniperAnimator;
	[SerializeField] private float walkSpeed;
	AudioSource bulletShot;
	private float speedboost = 0;
	float t = 0;
	private float facing = 1;
	float y;
	bool canShoot = true;
    private void Start()
    {
		bulletShot = GetComponent<AudioSource>();
    }
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
        
		else if(Input.GetKeyUp(KeyCode.LeftShift))
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
			playerAnimator.SetBool("Jump", true);
        }
		else if (Input.GetKeyUp(KeyCode.Space))
		{
			playerAnimator.SetBool("Jump", false);
		}
        if (Input.GetMouseButton(1))
        {
			playerAnimator.SetBool("ADS", true);
        }



		else
		{
			playerAnimator.SetBool("ADS", false);
		}
        if (Input.GetMouseButtonDown(0))
        {
            if (canShoot)
            {
                StartCoroutine(Shoot());
            }
        }

        //if (facing < 0)
        //{
        //	transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, 270f, 0f), Time.deltaTime * 4f);
        //}
        //else if (facing > 0)
        //{
        //	transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, 90f, 0f), Time.deltaTime * 4f);
        //}
        transform.position += new Vector3(0f, 0f, input * walkSpeed * speedboost * Time.deltaTime);

		playerAnimator.SetFloat("Speed", input);
		Debug.Log(walkSpeed * speedboost);
	}
	IEnumerator Shoot()
    {
        canShoot = false;
        bulletShot.Play();
		ShootBullet.Spark(ShootBullet.bulletSpark);
		yield return new WaitForSeconds(0.05f);
		sniperAnimator.Play("Bolt");
		yield return new WaitForSeconds(1.5f);
		canShoot = true;
    }
}
