using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldMan : MonoBehaviour
{
    //OldMans gridposition
    public int fieldNumber;
    public char fieldCharacter;
    // Start is called before the first frame update
    void Start()
    {
        // these are nonesense values
        // the range of alphanumerical values on a 10x10 board are from 1 to 10, not including zero
        // and from A to J, all valid characters are capitalized
        fieldCharacter = 'z';
        fieldNumber = -1;
    }

    // Update is called once per frame
    void Update()
    {
        //Input.mousePosition;
    }

    // on which Grid is OldMan standing? we dont know yet, so lets see if we can get the values of the script
    // set them
    // and conversely, read them from script when the player clicks on a grid that is valid for that character
    void OnCollisionStay(Collision col)
    {
        GridMechanic grid = col.gameObject.GetComponent<GridMechanic>();

        fieldNumber = grid.fieldNumber;
        fieldCharacter = grid.fieldCharacter;
    }
}
