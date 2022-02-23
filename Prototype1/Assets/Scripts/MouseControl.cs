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
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                if (hit.collider.transform.tag == "OldMan")
                {
                    OldManSelected = true;
                    OldMan = hit.collider.transform;
                    OldMan oldman = hit.collider.transform.gameObject.GetComponent<OldMan>();
                }
                else if (hit.collider.transform.tag == "Grid" && OldManSelected)
                {
                    // deselect old man
                    OldManSelected = false;
                    // get fieldNumber and fieldCharacter from scriptobject, but first get the clicked on grids script
                    GridMechanic grid = hit.collider.transform.gameObject.GetComponent<GridMechanic>();

                    // we want to check where the old man or any character is going before letting them go there
                    // for now we will output a debug log so we know the input has been registered and taken care off

                    int number = grid.fieldNumber;
                    char character = grid.fieldCharacter;

                    // we will compare how the old mans grid number and character correlate to the clicked on grid and if 
                    // the old man is allowed to move there or not
                    // but not today.

                    // NOTE: Open scripts OldMan and GridMechanic to work on functionality 

                    OldMan.position = hit.collider.transform.position;
                }
            }
        }
    }

    // maybe every character has their own method to keep update small
    void OldManMovementRules()
    {
        
    }
}
