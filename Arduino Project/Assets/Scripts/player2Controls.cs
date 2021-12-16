using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class player2Controls : MonoBehaviour
{
    public RawImage darkScreen;
    public ArdTilt invertControls;
    public SphereCollider ballMaterial;

    public float darkTime, abilityCD, dyDrag = 0.075f, stDrag = 0.15f;
    public bool darkness = false, abilityReady = true, _isInverted;
   
    //public Color tempAlpha;

    void Start()
    {

    }

    
    void Update()
    {
        if (abilityReady)
        {
            if (Input.GetKeyDown("space"))
            {
                StartCoroutine(Darkness());
                StartCoroutine(CoolDown());
            }
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                StartCoroutine(Invert());
                StartCoroutine(CoolDown());
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                StartCoroutine(Drag());
                StartCoroutine(CoolDown());
            }
        }
    }
    public IEnumerator Darkness()
    {
        {
            darkScreen.gameObject.SetActive(true);
            yield return new WaitForSeconds(darkTime);
            darkScreen.gameObject.SetActive(false);
        }
    }
    public IEnumerator Invert()
    {
        {
            _isInverted = true;
            yield return new WaitForSeconds(darkTime);
            _isInverted = false;
        }
    }

    public IEnumerator Drag()
    {
        {
            ballMaterial.material.dynamicFriction = dyDrag / 2;
            ballMaterial.material.staticFriction = stDrag / 2;
            yield return new WaitForSeconds(darkTime); 
            ballMaterial.material.dynamicFriction = dyDrag;
            ballMaterial.material.staticFriction = stDrag;
        }
    }

    public IEnumerator CoolDown()
    {
        {
            abilityReady = false;
            yield return new WaitForSeconds(abilityCD);
            abilityReady = true;
        }
    }
}
