using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrouille : MonoBehaviour {

    public Transform alpha;
    public Transform beta;

    //public List<Transform> positions = new List<Transform>();

    public Transform current;

    public float speed;

    //private void Start()
    //{
    //    if (this.gameObject.transform.position != alpha.transform.position)
    //    {
    //        this.gameObject.transform.position = alpha.transform.position;
    //    }
    //}

    private void Update()
    {
        if (this.gameObject.transform.position != current.transform.position)
        {

            Vector3 targetDir = current.position - transform.position;

            float step = speed * Time.deltaTime;

            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);

            transform.rotation = Quaternion.LookRotation(newDir);

            //float step = speed * Time.deltaTime;
            this.transform.position = Vector3.MoveTowards(this.transform.position, current.transform.position, step);
        }

        // Si liste, la logique change
        else
        {
            if (current == alpha)
            {
                current = beta;
            }
            else if (current == beta)
            {
                current = alpha;
            }

            //Logique différente ici
        }

        //if (this.gameObject.transform.position == beta.transform.position)
        //{
        //    Vector3 targetDir = alpha.position - transform.position;

        //    float step = speed * Time.deltaTime;

        //    Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);

        //    transform.rotation = Quaternion.LookRotation(newDir);
        //}

        //else if (this.gameObject.transform.position != alpha.transform.position)
        //{
        //    Vector3 targetDir = alpha.position - transform.position;

        //    float step = speed * Time.deltaTime;

        //    Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);

        //    transform.rotation = Quaternion.LookRotation(newDir);

        //    //float step = speed * Time.deltaTime;
        //    this.transform.position = Vector3.MoveTowards(this.transform.position, alpha.transform.position, step);
        //}
    }
}
