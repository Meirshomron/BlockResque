using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameManager manager;
    public GameObject dethParticles;
    public float moveSpeed;
    private Vector3 input;
    private float maxSpeed = 10f;
    private Vector3 spawn;
    private bool onTheGround = true;
    // Use this for initialization
    void Start()
    {
        manager = manager.GetComponent<GameManager>();
        spawn = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (PlayerPrefs.GetInt("Level Completed") == 4)
        {
            if ((onTheGround || (transform.position.y == 0.25)) && Input.GetButtonDown("Jump"))
            {
                GetComponent<Rigidbody>().AddForce(this.transform.up * 10, ForceMode.VelocityChange);
                input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Jump"), Input.GetAxis("Vertical"));
                GetComponent<Rigidbody>().AddForce(this.transform.up * 10, ForceMode.VelocityChange);
                onTheGround = false;
            }
            else
            {
                input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            }
        }
        if (GetComponent<Rigidbody>().velocity.magnitude < maxSpeed)
        {
            GetComponent<Rigidbody>().AddForce(input * moveSpeed);
        }
        if (transform.position.y < -2)
        {
            PlayerPrefs.SetInt("Lives", PlayerPrefs.GetInt("Lives") - 1);
            if (PlayerPrefs.GetInt("Lives") > 0)
                Die();
            else
                Application.LoadLevel(7);
        }
    }
    private void OnCollisionStay(Collision other)
    {
        if ((other.gameObject.tag.Equals("Enemy")) || (other.gameObject.tag.Equals("portal_enemy")))
        {
            PlayerPrefs.SetInt("Lives", PlayerPrefs.GetInt("Lives") - 1);
            if (PlayerPrefs.GetInt("Lives") > 0)
                Die();
            else
                Application.LoadLevel(7);
        }
        if (other.transform.tag.Equals("ground"))
            onTheGround = true;
        if (other.transform.tag == "Bonus")
        {
            PlayerPrefs.SetInt("Level Score", PlayerPrefs.GetInt("Level Score") + 50);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag.Equals("jmp_bonus_lvl"))
        {
            PlayerPrefs.SetInt("old score", PlayerPrefs.GetInt("Level Score"));
            PlayerPrefs.SetInt("in_bonus_lvl", 1);
            Application.LoadLevel(9);
        }

        if (other.transform.tag.Equals("portal"))
            transform.position = new Vector3(-0.5f, 0.25f, 27f);
        if (other.transform.tag.Equals("portal1"))
            transform.position = new Vector3(-21f, 0.25f, 18.8f);
        if (other.transform.tag.Equals("portal2"))
            transform.position = new Vector3(-1, 0.25f, -1);
        if (other.transform.tag.Equals("portal3"))
            transform.position = new Vector3(18.7f, 0.25f, 18.2f);
        if (other.transform.tag.Equals("ground"))
            onTheGround = true;

        if ((other.gameObject.tag.Equals("Enemy")) || (other.gameObject.tag.Equals("portal_enemy")))
        {
            PlayerPrefs.SetInt("Lives", PlayerPrefs.GetInt("Lives") - 1);
            if (PlayerPrefs.GetInt("Lives") > 0)
                Die();
            else
                Application.LoadLevel(7);
        }
        if (other.transform.tag == "goal")
        {
            manager.completeLevel();
        }
        if (other.transform.tag.Equals("finish"))
            Application.LoadLevel(10);
        if (other.transform.tag == "coin")
        {
            PlayerPrefs.SetInt("Level Score", PlayerPrefs.GetInt("Level Score") + 10);
            if (PlayerPrefs.GetInt("in_bonus_lvl") == 1)
            {
                if (PlayerPrefs.GetInt("Level Score") == (PlayerPrefs.GetInt("old score") + 440))
                {
                    PlayerPrefs.SetInt("in_bonus_lvl", 0);
                    PlayerPrefs.SetInt("Level Completed", 5);
                    Application.LoadLevel(6);
                }
            }
        }
        if (other.transform.tag == "Bonus")
        {
            PlayerPrefs.SetInt("Level Score", PlayerPrefs.GetInt("Level Score") + 50);
        }
    }
    public void Die()
    {
        Instantiate(dethParticles, transform.position, Quaternion.identity);
        transform.position = spawn;
    }
}
