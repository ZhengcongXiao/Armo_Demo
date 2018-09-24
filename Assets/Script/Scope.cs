using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour {
    private Animator animator;

    public GameObject scopeScene;
    public GameObject scopeCamera;
    public GameObject curs;
    public Camera mainCamera;

    public float scopeFOV = 15.0f;
    private float nomalFOV;

    private bool isScoped = false;
    private bool isReload = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            isScoped = !isScoped;
            animator.SetBool("AWP_Scope", isScoped);

            if (isScoped)
            {
                StartCoroutine("OnScoped");
            }
            else
            {
                UnScoped();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine("Reload_AWP");
        }
    }
    IEnumerator Reload_AWP()
    {
        isReload = !isReload;
        animator.SetBool("ReloadAWP", isReload);
        yield return new WaitForSeconds(2.0f);
        //isReload = false;
    }
    IEnumerator OnScoped()
    {
        yield return new WaitForSeconds(0.25f);
        curs.SetActive(false);
        scopeScene.SetActive(true);
        scopeCamera.SetActive(false);

        nomalFOV = mainCamera.fieldOfView;
        mainCamera.fieldOfView = scopeFOV;
    }

    void UnScoped()
    {
        scopeScene.SetActive(false);
        scopeCamera.SetActive(true);
        curs.SetActive(true);

        mainCamera.fieldOfView = nomalFOV;
    }
}
