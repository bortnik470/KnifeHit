using UnityEngine;
using UnityEngine.UI;

public class coin : MonoBehaviour
{
    public Text coin_counter;

    private void Start()
    {
        coin_counter = GameObject.FindWithTag("coin_counter").GetComponent<Text>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        circle.knife_hit.AddListener(takeCoin);
    }

    private void takeCoin()
    {
        int k = int.Parse(coin_counter.text);
        k++;
        coin_counter.text = k.ToString();
        Destroy(this.gameObject);
    }
}
