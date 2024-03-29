﻿using UnityEngine;
using UnityEngine.UI;

public class LeftButton_Train : MonoBehaviour
{

    public Scrollbar bar;
    public float moveSpeed = 0.005f;
    private float final;

    public GameObject movie1;
    public GameObject movie2;
    public GameObject movie3;

    public void OnClick()
    {
        GetComponent<Button>().interactable = false;

        if (bar.value > 0.49f && bar.value < 0.51f)
        {
            final = 0f;     
            InvokeRepeating("smoothMove", 0f, 0.01f);
        }
        else if (bar.value > 0.99f && bar.value < 1.01f)
        {
            final = 0.5f;
            InvokeRepeating("smoothMove", 0f, 0.01f);
        }
        else
        {
            GetComponent<Button>().interactable = true;
        }
        
    }

    private void smoothMove()
    {
        if (bar.value > final)
        {
            /*Debug.Log (bar.value);
			Debug.Log (final);*/
            bar.value -= moveSpeed;
        }
        else
        {
            bar.value = final;

            if (final == 0f)
            {
                movie2.GetComponent<movie_Train>().movieSource.Stop();
                movie2.GetComponent<movie_Train>().GetComponent<AudioSource>().Stop();

                movie1.GetComponent<movie_Train>().movieSource.Play();
                movie1.GetComponent<movie_Train>().GetComponent<AudioSource>().Play();
            }
            else if (final == 0.5)
            {
                movie3.GetComponent<movie_Train>().movieSource.Stop();
                movie3.GetComponent<movie_Train>().GetComponent<AudioSource>().Stop();

                movie2.GetComponent<movie_Train>().movieSource.Play();
                movie2.GetComponent<movie_Train>().GetComponent<AudioSource>().Play();
            }

            GetComponent<Button>().interactable = true;

            CancelInvoke();
        }
    }

}
