using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ImageArrayManager : MonoBehaviour
{
    public Transform cameraTransform;
    public Transform[] targets;
    public float speed;

    int actualPositionIndex = 0;
    bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 initialPosition = new Vector3(targets[0].position.x, cameraTransform.position.y, -10);
        cameraTransform.position = initialPosition;
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            MoveToNext();
        }
    }

    public void MoveToNext() 
    {
        if (canMove) 
        {
            if (actualPositionIndex == targets.Length - 1)
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                actualPositionIndex++;
                Vector3 newPos = targets[actualPositionIndex].position;
                StartCoroutine(Move(newPos));
            }
        }
        
    }

    IEnumerator Move(Vector3 target) 
    {
        canMove = false;
        Vector3 newPosition = new Vector3(target.x, cameraTransform.position.y, cameraTransform.position.z);

        while (cameraTransform.position.x != target.x) 
        {
            cameraTransform.position = Vector3.MoveTowards(cameraTransform.position, newPosition, speed * Time.deltaTime);
            yield return null;
            print(122);
        }
       
        canMove = true;
    }
}
