using UnityEngine;
using System.Collections;

public class cameraControls : MonoBehaviour
{

    private float minX, maxX, minY, maxY;

    private float camSize;
    public GameObject[] players;

    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        CalculateBounds(); //Gets the min and max values of each player
        CalculateCameraPosAndSize();
    }
    void CalculateBounds()
    {
        //Finds the players that have the the min and max x and y positions
        minX = Mathf.Infinity;
        maxX = -Mathf.Infinity;
        minY = Mathf.Infinity;
        maxY = -Mathf.Infinity;
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            Vector3 tempPlayer = player.transform.position;
            //X Bounds
            if (tempPlayer.x < minX)
                minX = tempPlayer.x;
            if (tempPlayer.x > maxX)
                maxX = tempPlayer.x;
            //Y Bounds
            if (tempPlayer.y < minY)
                minY = tempPlayer.y;
            if (tempPlayer.y > maxY)
                maxY = tempPlayer.y;
        }
    }
    //Calculates camera position and size
    void CalculateCameraPosAndSize()
    {
        Vector3 cameraCenter = Vector3.zero;

        foreach (GameObject player in players)
        {
            cameraCenter += player.transform.position;
        }
        Vector3 finalCameraCenter = cameraCenter / players.Length;

        //If the distance between the min and the max values get larger than these values the camera will dolly out
        float maxXDist = 30;
        float maxYDist = 8;

        float startZ = -12;

        //Gets the distance between xPoints
        float currXDist = Vector2.Distance(new Vector2(minX, 0), new Vector2(maxX, 0));
        currXDist -= maxXDist;
        //Gets the distance between yPoints
        float currYDist = Vector2.Distance(new Vector2(0, minY), new Vector2(0, maxY));
        currYDist -= maxYDist;
        //Gets the max distance
        float maxDist = Mathf.Max(currXDist, currYDist);
        float newZ = startZ - maxDist;

        Vector3 newPos;

        if (players.Length > 1)
        {
            newPos = new Vector3((minX + maxX) / 2, ((minY + maxY) / 2)+2, Mathf.Clamp(newZ, -Mathf.Infinity, -16));
        }
        else
        {
            newPos = players[0].transform.position + new Vector3(0, 0, -8) + new Vector3(0, 2, 0);
        }
        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime);
    }
}
