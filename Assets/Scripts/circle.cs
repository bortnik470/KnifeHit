using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class circle : MonoBehaviour
{
    public static UnityEvent knife_hit = new UnityEvent();
    public static UnityAction end;

    [SerializeField] private GameObject pause_menu;
    [SerializeField] private Text knifes_counter;
    [SerializeField] private GameObject knife_s;
    [SerializeField] private GameObject coin;

    public int knifes = 0;

    private void Start()
    {
        int coins = Random.Range(1, 7);
        knifes = Random.Range(coins, 12);

        knifes_counter.text = knifes.ToString();

        float angel = Random.Range(0f, 360f);
        for (int i = 0; i < coins; i++)
        {
            angel += 20f;
            Instantiate(coin, new Vector2(1.3f * Mathf.Cos(angel), 1.3f * Mathf.Sin(angel) + 3.28f), new Quaternion(), transform);
        }
    }

    void Update()
    {
        transform.Rotate(Vector3.forward, Time.deltaTime * 100f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (end != null) { end(); end_game(); }
        if (knifes != 0)
        {
            knifes--;
            knifes_counter.text = knifes.ToString();
            knife_hit.Invoke();

            if (knifes == 0) end_game();

            Instantiate(knife_s, new Vector3(0, 1.4f), new Quaternion());
        }
    }

    private void end_game()
    {
        pause_menu.SetActive(true);
        Time.timeScale = 0;
    }
}
