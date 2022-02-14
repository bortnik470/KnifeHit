using System.Collections;
using UnityEngine;

public class knife : MonoBehaviour
{
    private Transform circle_t;
    private Vector3 target = new Vector3(0f, 3.28f);

    private IEnumerator move()
    {
        while (transform.position != target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * 20f);
            yield return null;
        }
    }

    private void end_point() {
            transform.SetParent(circle_t, true);
            Destroy(this);
    }

    private void Start()
    {
        circle.knife_hit.AddListener(end_point);
        circle_t = GameObject.FindWithTag("target").transform;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0)) StartCoroutine(move());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Knife(Clone)") circle.end += end;
    }

    private void end()
    {
        Destroy(this);
    }
}
