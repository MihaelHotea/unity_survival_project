using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject leopard;
    public GameObject leopardCamera;
    public Animator anim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("vertical", Input.GetAxis("Vertical"));
        anim.SetFloat("horizontal", Input.GetAxis("Horizontal"));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("jump");
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 4))
        {
            //if we are looking at a potate and we press E
            if (hit.transform.gameObject.tag.Equals("leopard") && Input.GetKeyDown(KeyCode.E))
            {
                gameObject.SetActive(false);
                leopard.GetComponent<CarController>().enabled = true;
                leopard.GetComponent<CarUserControl>().enabled = true;
                leopard.GetComponent<CarAudio>().enabled = true;
                leopardCamera.SetActive(true);
            }
        }

    }
}
