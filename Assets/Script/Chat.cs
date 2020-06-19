using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Net;
using System.IO;
using System.Xml;
//using UnityEditor.PackageManager.Requests;

public class Chat : MonoBehaviour
{
    public Text[] ChatText;
    public Text[] ChatList;
    public InputField ChatInput;
    public string msg;
    public Text temperature;
    public GameObject Background;
    public GameObject Background_rain;
    public GameObject Background_snow;
    public GameObject blackbackground;
    public GameObject Wblackground;
    public Slider pleasure;
    public Slider trust;
    public Slider fear;
    public Slider expectation;
    public Slider surprise;
    public Slider sadness;
    public Slider aversion;
    public Slider anger;
    public GameObject[] crown;
    public GameObject[] weather;
    public static bool yn1 = false;
    public static bool yn2 = false;
    public static bool yn3 = false;
    public static bool yn4 = false;
    public static bool yn5 = false;
    public static bool yn6 = false;
    public static bool yn7 = false;
    public static bool yn8 = false;
    public static bool hot = false;
    public static bool cold = false;
    public static bool snow = false;
    public static bool rain = false;
    public static bool good = false;
    public static bool bad = false;
    public static int temp = 0;
    string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    string s1;
    string s2;
    string s3;
    string s4;
    string s5;
    string s6;
    string s7;
    string s8;

    public void readtext()
    {

        DirectoryInfo dtif = new DirectoryInfo(path + "\\test");
        if (!dtif.Exists)
        {
            dtif.Create();
        }

        FileInfo file1 = new FileInfo(path + "\\test\\혐오.txt");
        if (!file1.Exists)
        {
            FileStream fs = file1.Create();
            TextWriter tw = new StreamWriter(fs);
            tw.Write("20");
            tw.Close();
            fs.Close();
        }

        FileInfo file2 = new FileInfo(path + "\\test\\기쁨.txt");
        if (!file2.Exists)
        {
            FileStream fs = file2.Create();
            TextWriter tw = new StreamWriter(fs);
            tw.Write("20");
            tw.Close();
            fs.Close();
        }

        FileInfo file3 = new FileInfo(path + "\\test\\놀라움.txt");
        if (!file3.Exists)
        {
            FileStream fs = file3.Create();
            TextWriter tw = new StreamWriter(fs);
            tw.Write("20");
            tw.Close();
            fs.Close();
        }

        FileInfo file4 = new FileInfo(path + "\\test\\분노.txt");
        if (!file4.Exists)
        {
            FileStream fs = file4.Create();
            TextWriter tw = new StreamWriter(fs);
            tw.Write("20");
            tw.Close();
            fs.Close();
        }

        FileInfo file5 = new FileInfo(path + "\\test\\공포.txt");
        if (!file5.Exists)
        {
            FileStream fs = file5.Create();
            TextWriter tw = new StreamWriter(fs);
            tw.Write("20");
            tw.Close();
            fs.Close();
        }

        FileInfo file6 = new FileInfo(path + "\\test\\슬픔.txt");
        if (!file6.Exists)
        {
            FileStream fs = file6.Create();
            TextWriter tw = new StreamWriter(fs);
            tw.Write("20");
            tw.Close();
            fs.Close();
        }

        FileInfo file7 = new FileInfo(path + "\\test\\신뢰.txt");
        if (!file7.Exists)
        {
            FileStream fs = file7.Create();
            TextWriter tw = new StreamWriter(fs);
            tw.Write("20");
            tw.Close();
            fs.Close();
        }

        FileInfo file8 = new FileInfo(path + "\\test\\기대.txt");
        if (!file8.Exists)
        {
            FileStream fs = file8.Create();
            TextWriter tw = new StreamWriter(fs);
            tw.Write("20");
            tw.Close();
            fs.Close();
        }

        s1 = File.ReadAllText(path + "\\test\\혐오.txt");
        s2 = File.ReadAllText(path + "\\test\\기쁨.txt");
        s3 = File.ReadAllText(path + "\\test\\놀라움.txt");
        s4 = File.ReadAllText(path + "\\test\\분노.txt");
        s5 = File.ReadAllText(path + "\\test\\공포.txt");
        s6 = File.ReadAllText(path + "\\test\\슬픔.txt");
        s7 = File.ReadAllText(path + "\\test\\신뢰.txt");
        s8 = File.ReadAllText(path + "\\test\\기대.txt");

        aversion.value = Convert.ToInt32(s1);  //혐오
        pleasure.value = Convert.ToInt32(s2);  //기쁨
        surprise.value = Convert.ToInt32(s3);  //놀라움
        anger.value = Convert.ToInt32(s4);  //분노
        fear.value = Convert.ToInt32(s5);  //공포
        sadness.value = Convert.ToInt32(s6);  //슬픔
        trust.value = Convert.ToInt32(s7);  //신뢰
        expectation.value = Convert.ToInt32(s8);  //기대

    }

    public void Maxparameter()
    {

        int[] maxparameter = { (int)pleasure.value, (int)trust.value, (int)fear.value, (int)expectation.value, (int)surprise.value, (int)sadness.value, (int)aversion.value, (int)anger.value };
        int maxemotion = 0;

        for (int i = 0; i <= 7; i++)
        {
            crown[i].SetActive(false);
            if (maxemotion < maxparameter[i])
            {
                maxemotion = maxparameter[i];
                temp = i;
            }
        }
        if (temp == 0)
        {
            crown[0].SetActive(true);
        }
        if (temp == 1)
        {
            crown[1].SetActive(true);
        }
        if (temp == 2)
        {
            crown[2].SetActive(true);
        }
        if (temp == 3)
        {
            crown[3].SetActive(true);
        }
        if (temp == 4)
        {
            crown[4].SetActive(true);
        }
        if (temp == 5)
        {
            crown[5].SetActive(true);
        }
        if (temp == 6)
        {
            crown[6].SetActive(true);
        }
        if (temp == 7)
        {
            crown[7].SetActive(true);
        }
    }

    public void Parameter()
    {
        WebRequest request = WebRequest.Create("http://api.adams.ai/datamixiApi/omAnalysis?query=" + msg + "%20&type=1&key=5223256679464228919"); // 호출할 url
        request.Method = "GET";

        WebResponse response = request.GetResponse();
        Stream dataStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream);

        string responseFromServer = reader.ReadToEnd();
        yn1 = responseFromServer.Contains("기쁨");
        yn2 = responseFromServer.Contains("신뢰");
        yn3 = responseFromServer.Contains("공포");
        yn4 = responseFromServer.Contains("기대");
        yn5 = responseFromServer.Contains("놀라움");
        yn6 = responseFromServer.Contains("슬픔");
        yn7 = responseFromServer.Contains("혐오");
        yn8 = responseFromServer.Contains("분노");

        if (yn1 == true)
        {
            pleasure.value += 4;
            fear.value--;
            sadness.value--;
            aversion.value--;
            anger.value--;
        }
        if (yn2 == true)
        {
            trust.value += 4;
            fear.value--;
            sadness.value--;
            aversion.value--;
            anger.value--;
        }
        if (yn3 == true)
        {
            fear.value += 4;
            pleasure.value--;
            trust.value--;
            expectation.value--;
            surprise.value--;
        }
        if (yn4 == true)
        {
            expectation.value += 4;
            fear.value--;
            sadness.value--;
            aversion.value--;
            anger.value--;
        }
        if (yn5 == true)
        {
            surprise.value += 4;
            fear.value--;
            sadness.value--;
            aversion.value--;
            anger.value--;
        }
        if (yn6 == true)
        {
            sadness.value += 4;
            pleasure.value--;
            trust.value--;
            expectation.value--;
            surprise.value--;
        }
        if (yn7 == true)
        {
            aversion.value += 4;
            pleasure.value--;
            trust.value--;
            expectation.value--;
            surprise.value--;
        }
        if (yn8 == true)
        {
            anger.value += 4;
            pleasure.value--;
            trust.value--;
            expectation.value--;
            surprise.value--;
        }

        StreamWriter writer;
        writer = File.CreateText(path + "\\test\\혐오.txt");
        writer.WriteLine(aversion.value);
        writer.Close();
        writer = File.CreateText(path + "\\test\\기쁨.txt");
        writer.WriteLine(pleasure.value);
        writer.Close();
        writer = File.CreateText(path + "\\test\\놀라움.txt");
        writer.WriteLine(surprise.value);
        writer.Close();
        writer = File.CreateText(path + "\\test\\분노.txt");
        writer.WriteLine(anger.value);
        writer.Close();
        writer = File.CreateText(path + "\\test\\공포.txt");
        writer.WriteLine(fear.value);
        writer.Close();
        writer = File.CreateText(path + "\\test\\슬픔.txt");
        writer.WriteLine(sadness.value);
        writer.Close();
        writer = File.CreateText(path + "\\test\\신뢰.txt");
        writer.WriteLine(trust.value);
        writer.Close();
        writer = File.CreateText(path + "\\test\\기대.txt");
        writer.WriteLine(expectation.value);
        writer.Close();

        Maxparameter();
        reader.Close();
        dataStream.Close();
        response.Close();

    }
    public void Weather()
    {
        XmlDocument docX = new XmlDocument();
        XmlDocument docY = new XmlDocument();  //XmlDocument 생성
        int x = 0, y = 0;

        //ip주소로 지역코드 찾기
        try
        {
            docY.Load("http://ip-api.com/xml"); //url로 xml 파일로드
        }
        catch
        {
            return;
        }

        XmlNodeList regionlist = docY.GetElementsByTagName("region"); //지역코드
        XmlNodeList namelist = docY.GetElementsByTagName("regionName"); //지역이름

        //Console.WriteLine(namelist[0].InnerText); 지역이름 출력되는지 확인

        switch (regionlist[0].InnerText)
        {
            case "11": { x = 61; y = 125; break; } //서울
            case "26": { x = 93; y = 73; break; } //부산
            case "27": { x = 88; y = 90; break; } //대구
            case "28": { x = 51; y = 131; break; } //인천
            case "29": { x = 57; y = 74; break; } //광주
            case "30": { x = 68; y = 101; break; } //대전
            case "31": { x = 102; y = 84; break; } //울산
            case "41": { x = 69; y = 132; break; } //경기도
            case "42": { x = 93; y = 131; break; } //강원도
            case "43": { x = 76; y = 111; break; } //충북
            case "44": { x = 65; y = 99; break; } //충남 
            case "45": { x = 55; y = 80; break; } //전북
            case "46": { x = 57; y = 63; break; } //전남
            case "47": { x = 91; y = 89; break; } //경북
            case "48": { x = 89; y = 68; break; } //경남 
            case "50": { x = 56; y = 33; break; } //제주도
        }


        //기상청 날씨 받아오기
        try
        {

            docX.Load("http://www.kma.go.kr/wid/queryDFS.jsp?gridx=" + x + "&gridy=" + y); // url로 xml 파일 로드

        }
        catch
        {
            return;
        }


        XmlNodeList tempList = docX.GetElementsByTagName("temp"); //온도
        XmlNodeList weatherList = docX.GetElementsByTagName("wfKor"); //맑음,구름조금,구름많음,흐림,비,눈/비,눈
        string weatherSource = weatherList[0].InnerText;
        string tempSource = tempList[0].InnerText;
        float h = float.Parse(tempSource);
        temperature.text = tempSource + "º";
        if (weatherSource.Equals("맑음"))
        {
            weather[0].SetActive(true);
            if (h > 27.0)
            {
                hot = true;
            }
            else if (h < 5.0)
            {
                cold = true;
            }
            else
            {
                good = true;
            }
        }
        if (weatherSource.Equals("구름 조금"))
        {
            weather[1].SetActive(true);
            if (h > 27.0)
            {
                hot = true;
            }
            else if (h < 5.0)
            {
                cold = true;
            }
            else
            {
                bad = true;
            }
        }
        if (weatherSource.Equals("구름 많음"))
        {
            weather[2].SetActive(true);
            if (h > 27.0)
            {
                hot = true;
            }
            else if (h < 5.0)
            {
                cold = true;
            }
            else
            {
                bad = true;
            }
        }
        if (weatherSource.Equals("흐림"))
        {
            weather[3].SetActive(true);
            if (h > 27.0)
            {
                hot = true;
            }
            else if (h < 5.0)
            {
                cold = true;
            }
            else
            {
                bad = true;
            }
        }
        if (weatherSource.Equals("눈"))
        {
            weather[4].SetActive(true);
            snow = true;
            Background.SetActive(false);
            Background_rain.SetActive(false);
            Background_snow.SetActive(true);
        }
        if (weatherSource.Equals("비"))
        {
            weather[5].SetActive(true);
            rain = true;
            Background.SetActive(false);
            Background_snow.SetActive(false);
            Background_rain.SetActive(true);
        }
        if (weatherSource.Equals("눈/비"))
        {
            weather[6].SetActive(true);
            rain = true;
            Background.SetActive(false);
            Background_snow.SetActive(false);
            Background_rain.SetActive(true);
        }


    }

    public void Chatting()
    {
        bool isinput = false;

        for (int i = 0; i < ChatText.Length; i++)
        {
            if (ChatText[i].text == "")
            {
                isinput = true;
                ChatText[i].text = msg;
                ChatList[i].text = "  " + msg;
                break;
            }
        }
        if (!isinput)
        {
            for (int i = 1; i < ChatText.Length; i++)
            {
                ChatText[i - 1].text = ChatText[i].text;
                ChatList[i - 1].text = ChatList[i].text;
            }
            ChatText[ChatText.Length - 1].text = msg;
            ChatList[ChatList.Length - 1].text = msg;
        }
    }

    void Start()
    {
        readtext();
        Maxparameter();

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            msg = ChatInput.text;
            ChatInput.text = "";
            Chatting();
            if (msg.Contains("날씨"))
            {
                Weather();
                Wblackground.SetActive(true);
            }
            else
            {
                Parameter();
            }

        }

    }
    public void SubWindow()
    {
        blackbackground.SetActive(true);
    }
    public void Exit()
    {
        blackbackground.SetActive(false);
    }

}
