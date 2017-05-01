using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bloc
{
    public List<GameObject> obstacles;
    public List<GameObject> floors;

    public Vector3 position;
    public Vector3 size;


    public Bloc(Vector3 startingPosition)
    {
        obstacles = new List<GameObject>();
        floors = new List<GameObject>();

        position = startingPosition;
        size = new Vector3(20, 1, 1);
    }

    public void Destroy()
    {
        foreach (GameObject gameObject in obstacles)
        {
            GameObject.Destroy(gameObject);
        }

        foreach(GameObject floor in floors)
        {
            GameObject.Destroy(floor);
        }
    }

    public void setPosition(Vector3 newPosition)
    {
        Vector3 deltaPosition = newPosition - position;

        Move(deltaPosition);
    }

    public void Move(Vector3 deplacement)
    {
        position += deplacement;

        foreach (GameObject obstacle in obstacles)
        {
            if(obstacle != null)
                obstacle.transform.Translate(deplacement);
        }

        foreach(GameObject floor in floors)
        {
            if (floor != null)
                floor.transform.Translate(deplacement);
        }
    }
}
