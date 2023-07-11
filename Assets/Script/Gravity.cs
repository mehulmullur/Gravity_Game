using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public GameObject hologram, player;

    bool isEnterPressed = false;
    Vector3 gravityDir, holoDir, playerDir, gravityRefZ, gravityRefX;

    public Movement move;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isEnterPressed && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SetHologramPos();//Set hologram position

            //Show the hologram
            holoDir = new Vector3(0f, 0f, 90f);
            hologram.SetActive(true);
            hologram.transform.Rotate(holoDir, Space.Self);

            //Gravity Direction set
            gravityRefZ += new Vector3(0f, 0f, 90f);
            CheckZ();

            //Player Direction set
            playerDir = new Vector3(player.transform.rotation.x, player.transform.rotation.y, 90f);

            isEnterPressed = true;
        }

        else if (!isEnterPressed && Input.GetKeyDown(KeyCode.RightArrow))
        {
            SetHologramPos();

            holoDir = new Vector3(0f, 0f, -90f);
            hologram.SetActive(true);
            hologram.transform.Rotate(holoDir, Space.Self);

            gravityRefZ += new Vector3(0f, 0f, -90f);
            CheckZ();

            playerDir = new Vector3(player.transform.rotation.x, player.transform.rotation.y, -90f);

            isEnterPressed = true;
        }
        else if (!isEnterPressed && Input.GetKeyDown(KeyCode.UpArrow))
        {
            SetHologramPos();

            holoDir = new Vector3(90f, 0f, 0f);
            hologram.SetActive(true);
            hologram.transform.Rotate(holoDir, Space.Self);

            gravityRefX += new Vector3(90f, 0f, 0f);
            CheckX();

            playerDir = new Vector3(90f, player.transform.rotation.y, player.transform.rotation.z);

            isEnterPressed = true;
        }
        else if (!isEnterPressed && Input.GetKeyDown(KeyCode.DownArrow))
        {
            SetHologramPos();

            holoDir = new Vector3(-90f, 0f, 0f);
            hologram.SetActive(true);
            hologram.transform.Rotate(holoDir, Space.Self);

            gravityRefX += new Vector3(-90f, 0f, 0f);
            CheckX();

            playerDir = new Vector3(-90f, player.transform.rotation.y, player.transform.rotation.z);

            isEnterPressed = true;
        }

        if (Input.GetKeyDown(KeyCode.Return) && isEnterPressed)//Check for Enter key press
        {
            //Changing gravity to the necessary direction
            Physics.gravity = gravityDir;
            hologram.SetActive(false);

            //Rotate the player
            player.transform.Rotate(playerDir, Space.World);

            //Playing fall animation
            move.playerAnim.SetBool("Fall", true);
            isEnterPressed = false;
        }
    }

    void CheckZ()
    {
        //Changing gravity using z rotation for all possible scenarios

        if (gravityRefZ.z == 90 || gravityRefZ.z == -270)
            gravityDir = new Vector3(10f, 0f, 0f);
        else if (gravityRefZ.z == 180 || gravityRefZ.z == -180)
            gravityDir = new Vector3(0f, 10f, 0f);
        else if (gravityRefZ.z == 270 || gravityRefZ.z == -90)
            gravityDir = new Vector3(-10f, 0f, 0f);
        else if (gravityRefZ.z == 0 || gravityRefZ.z == 360 || gravityRefZ.z == -360)
            gravityDir = new Vector3(0f, -10f, 0f);
    }

    void CheckX()
    {
        //Changing gravity using x rotation for all possible scenarios

        if (gravityRefX.x == 90 || gravityRefX.x == -270)
            gravityDir = new Vector3(0f, 0f, -10f);
        else if (gravityRefX.x == 180 || gravityRefX.x == -180)
            gravityDir = new Vector3(0f, 10f, 0f);
        else if (gravityRefX.x == 270 || gravityRefX.x == -90)
            gravityDir = new Vector3(0f, 0f, 10f);
        else if (gravityRefX.x == 0 || gravityRefX.x == 360 || gravityRefX.z == -360)
            gravityDir = new Vector3(0f, -10f, 0f);
    }

    void SetHologramPos()
    {
        //Set hologram position to player position

        hologram.transform.position = player.transform.position;
        hologram.transform.rotation = player.transform.rotation;
    }
}
