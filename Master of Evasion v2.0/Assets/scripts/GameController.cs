using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{

    public Camera cam;
    public GameObject[] balls;
    public float timeLeft;
    public Text timerText;
    public GameObject gameOverText;
    public GameObject restartButton;
    public GameObject splashScreen;
    public GameObject startButton;
    public HatController hatController;

    private float maxWidth;//максимальная ширина экрна
    private bool playing;

    void Start()
    {//метод который устанавливает границы на которых может передвигаться и появлятся предмет 
        if (cam == null)
        {
            cam = Camera.main;
        }
        playing = false;
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float ballWidth = balls[0].GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - ballWidth;
        timerText.text = "Time Left:\n" + Mathf.RoundToInt(timeLeft);
    }

    void FixedUpdate()//метод времени которое мы можем играть
    {
        if (playing)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                timeLeft = 0;
            }
            timerText.text = "Time Left:\n" + Mathf.RoundToInt(timeLeft);
        }
    }

    public void StartGame()//методы выполняющиеся при начале игры
    {
        splashScreen.SetActive(false);
        startButton.SetActive(false);
        hatController.ToggleControl(true);
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()//метод который вызывает спавн бесконечного коллицества шаров и бомб, а так же вывод надписей и кнопок 
    {
        yield return new WaitForSeconds(2.0f);
        playing = true;
        while (timeLeft>0)
        {
            GameObject ball = balls[Random.Range(0, balls.Length)];
            Vector3 spawnPosition = new Vector3(
            Random.Range(-maxWidth, maxWidth),
            transform.position.y,
            0.0f);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(ball, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(Random.Range(0.75f, 1.0f));
        }
        yield return new WaitForSeconds(2.0f);
        gameOverText.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        restartButton.SetActive(true);
    }

    void UpdateText()
    {
        timerText.text = "Time Left:\n" + Mathf.RoundToInt(timeLeft);
    }
}