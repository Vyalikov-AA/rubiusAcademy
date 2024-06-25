using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject ObjectToSpavn;
    private GameObject ObjectToSpavnPrefab;
    public Transform objectOfGame;
    public float speed, rotationSpeed;
    public string ButonForward, ButonBack, ButonLeft, ButonRight;
    public bool AddPrefab;
    // Start is called before the first frame update
    void Start()
    {
        ObjectToSpavnPrefab = ObjectToSpavn;
        objectOfGame = transform;
        ButonForward = "w";
        ButonBack = "s";
        ButonLeft = "d";
        ButonRight = "a";
        speed = 0.1F;
        rotationSpeed = 0.1F;
        AddPrefab = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Add Prefab
        if (Input.GetKeyDown(KeyCode.Return) && (!AddPrefab))
        {
            ObjectToSpavnPrefab = Instantiate(ObjectToSpavn);
            AddPrefab = true;
            Debug.Log("Add prefab");
        }

        //Delete Prefab
        if (Input.GetKeyDown(KeyCode.Escape) && (AddPrefab))
        {
            Destroy(ObjectToSpavnPrefab);
            AddPrefab = false;
            Debug.Log("Delete Complite");
        }

        //Movements
        if (Input.GetKey(ButonForward))
        {
            objectOfGame.Translate(Vector3.forward * speed);
            Debug.Log("step Up");
        }
        if (Input.GetKey(ButonBack))
        {
            objectOfGame.Translate(Vector3.back * speed);
            Debug.Log("step back");
        }
        if (Input.GetKey(ButonLeft))
        {
            objectOfGame.Rotate(Vector3.up * rotationSpeed);
            Debug.Log("rotation left");
        }
        if (Input.GetKey(ButonRight))
        {
            objectOfGame.Rotate(Vector3.down * rotationSpeed);
            Debug.Log("rotation right");
        }
        /*float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);*/
    }
}
