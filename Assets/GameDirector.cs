using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameDirector : MonoBehaviour
{
    GameObject timerText;
    GameObject pointText;
    GameObject generator;
    GameObject end;
    float time =30.0f;
    int point = 0;
    public void GetApple() {
        point +=100;
    }

    public void GetBomb()
    {
        point /= 2;
    }
    // Start is called before the first frame update
    void Start()
    {
        pointText = GameObject.Find("Point");
        timerText =GameObject.Find("Time");
        generator = GameObject.Find("ItemGenerator");
        end =GameObject.Find("End");
    }

    // Update is called once per frame
    void Update()
    {

        this.time -= Time.deltaTime;
        if (time < 0) {
            time = 0;
            generator.GetComponent<ItemGenerator>().SetParameter(10000.0f,0,0);
            this.end.GetComponent<Text>().text = "”Œœ∑Ω· ¯£°";
            if (Input.GetMouseButtonDown(0)) {

                SceneManager.LoadScene("SampleScene");
            }
        } else if (0<=time&&time<5) {
            generator.GetComponent<ItemGenerator>().SetParameter(0.9f, -0.04f,3);
        }
        else if (5 <= time && time < 10)
        {
            generator.GetComponent<ItemGenerator>().SetParameter(0.4f, -0.06f, 6);
        }
        else if (10 <= time && time < 20)
        {
            generator.GetComponent<ItemGenerator>().SetParameter(0.7f, -0.04f, 4);
        }
        else if (20 <= time && time < 30)
        {
            generator.GetComponent<ItemGenerator>().SetParameter(1.0f, -0.03f, 2);
        }
        this.timerText.GetComponent<Text>().text =this.time.ToString("F1");
        this.pointText.GetComponent<Text>().text = this.point.ToString()+" point";
    }
}
