using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPlayer : MonoBehaviour
{

    public Vector3 Position1 = new Vector3();
    public Vector3 Position2 = new Vector3();
    public Vector3 Position3 = new Vector3();
    public int speed = 20;

    private int Moveto = 1;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Moveto == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, Position1, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, Position1) < 2f)
                Moveto = 2;            
        }
        else if (Moveto == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, Position2, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, Position2) < 2f)
                Moveto = 3;
        }
        else if (Moveto == 3)
        {
            transform.position = Vector3.MoveTowards(transform.position, Position3, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, Position3) < 2f)
            {
                Moveto = 0;
                var screenCanv = GameObject.Find("Alert");
                screenCanv.transform.Find("Panel").gameObject.transform.Find("Message").GetComponent<Text>().text = "Wow ! You passed without hitting any cube.";
                screenCanv.transform.Find("Panel").gameObject.SetActive(true);
                gameObject.SetActive(false);  
            }
        }
    }
}

