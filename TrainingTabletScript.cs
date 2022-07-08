using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TrainingTabletScript : MonoBehaviour
{
    public int step;
    public int Cursorstep;

    public ControllerScript Controller;
    public TrainingScript Cursor;
    public Text text;
    public List<string> words = new List<string>();
    void Start()
    {
        step = 0;
        if (PlayerPrefs.GetInt("Training") == 0)
        {
            Destroy(gameObject);
        }

        words.Add("В этом обучение тебе помогут разобраться с интерфейсом игры, начнем с простого нажми кнопку дальше в низу этой таблички, " + //0
            "чтобы продолжить.");

        words.Add("В начале нам предстоит расставить таблички со значениями в дано, что бы вам это было удобнее можно переключить режим " + //1
            "отображение. Нажав на синею кнопку вы увидите единицы измерение, белый же отвечает за отображение значения.");

        words.Add("Выберете для себя более удобную форму отображение, ее так же можно менять отдельно на одной табличке двойным щелчку по ней." + //2
            " Теперь с помощью подсказки расставьте значение по их местам.");

        words.Add("Что бы проверить правильность своего решение нажмите на дальше, если все верно, то вас переведет на следующий этап, " + //3
            "в противном случае вылезет сообщение о неверно решении.");

        words.Add("Вы всегда можете вернуться к условию нажав “<”, а здесь вам предстоит решить задачу использую операторы, значение " + //4
            "и заметки. Перетаскиваете их с помощью мышки. Давайте вытащим оператор умножение.");

        words.Add("Подставим в него R2 и I2, чтобы найти U2 по формуле."); //5

        words.Add("Вы можете вытаскивать сколько угодно операторов и вкладывать их друг в друга, а посмотреть результат вычислений " +
            "можно только у активного оператора, который обведен зеленой рамкой."); //6

        words.Add("Что бы сделать оператор активным достаточно нажать на него, а ответ от активного оператора вы можете взять под доской. " +
            "Давайте вытащим число которое у нас вышло."); //7

        words.Add("Таким образом мы нашли U2, чтобы не терять значение мы можем их записать, так их удобнее использовать в других формулах. " +
            "Это может быть очень полезным при решение большой задачи и так для начала введи имя в табличку - заметку."); //8

        words.Add("Ваше название для переменой может быть любым, хотя удобнее использовать имена физических величин, которые вы хотите запомнить. " +
            "Название можно менять только до вытаскивание таблички, однако вы всегда можете взять новую табличку с новым именем."); //9

        words.Add("Вводим U2 и жмем enter для подтверждение.Теперь, когда наше название отобразилась на табличке ее можно вытащить."); //10

        words.Add("Теперь перенесем найденное нами значение в нашу табличку, после чего мы сможем его брать оттуда в любых количествах для " +
            "использование в других примеров. Заменить значение у вас уже не выйдет."); //11

        words.Add("Вы всегда можете удалить любую табличку просто перетащив ее в низ экрана, в зону удаление."); //12

        words.Add("Теперь найдите U1 по формуле U2 * K, хочу напомнить, что вы так же можете включить удобный вам режим отображение с помощью " +
            "меню над доской. Составляете формулы по названиям физических величин или по их единицы измерения."); //13

        words.Add("На этом все, \nудачной игры!"); //end
        text.text = words[step];
        //TODO: Время будет оцени что по возможностям еще есть у VS
    }
    
    // Update is called once per frame
    void Update()
    {
        
        text.text = words[step];
    }
    public void next()
    {
        step++;
        if(step >= words.Count)
        {
            Destroy(Cursor.gameObject);
            Destroy(gameObject);
        }

        switch (step)
        {
            case 1:
                Cursor.click = true;
                Cursor.clickPosition = new Vector3(-18.9f, -22, 28);
                break;
            case 2:
                Cursor.anim = true;
                Cursor.stopClick();
                break;
            case 3:
                Cursor.anim = false;                
                Cursor.click = true;
                Cursor.clickPosition = new Vector3(66.8f, 31.1f, 28);
                break;
            case 4:
                Cursor.v1 = new Vector3(105.6f, -21.8f, 28);
                Cursor.v2 = new Vector3(143, 12.9f, 28);
                Cursor.anim = true;
                Cursor.stopClick();
                break;
            case 5:
                Cursor.MovementPosition(new List<Vector3>() { new Vector3(35.4f, 9.3f, 28), new Vector3(35.4f, 3.5f, 28)}, Controller.GetPositionGiven());
                break;
            case 6:
                Cursor.anim = false;
                Cursor.click = false;
                break;
            case 7:
                Cursor.anim = true;
                Cursor.v1 = new Vector3(148.7f, -20, 28);
                Cursor.v2 = new Vector3(167.7f, 1.7f, 28);
                break;
            case 8:
                Cursor.anim = false;
                Cursor.click = true;
                Cursor.clickPosition = new Vector3(109.1f, -29.6f, 28);
                break;
            case 9:
                Cursor.stopClick();
                break;
            case 10:
                Cursor.click = false;
                Cursor.anim = true;
                Cursor.v1 = new Vector3(142.5f, -30.2f, 28);
                Cursor.v2 = new Vector3(163.9f, 9.9f, 28);
                break;
            case 11:
                Cursor.anim = true;
                Cursor.v1 = Controller.GetLastTablet();
                Cursor.v2 = Controller.GetLastGiven();
                break;
            case 13:
                Cursor.anim = false;
                Cursor.click = true;
                Cursor.clickPosition = new Vector3(170.6f, 47.5f, 28);
                break;
            default:
                Cursor.click = false;
                Cursor.anim = false;
                break;

        }


    }
}
