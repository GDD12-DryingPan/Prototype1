using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseControl : MonoBehaviour
{
    private bool OldManSelected = false;
    private Transform OldMan;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit))
            {
                Debug.Log(raycastHit.transform.tag);

                if (raycastHit.transform.tag == "OldMan")
                {
                    OldManSelected = true;
                    OldMan = raycastHit.transform;
                }
                else if (raycastHit.transform.tag == "Grid" && OldManSelected)
                {
                    OldManSelected = false;
                    OldMan.position = raycastHit.transform.position;
                }
            }
        }
    }
}
