using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Json;

public class NetworkManager : MonoBehaviour {
    public string strUrl;
    public string strResult;

    public void network(string strUrl) {
        /* GET */
        // HttpWebRequest 객체 생성, 설정
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strUrl);
        request.Method = "GET";    // 기본값 "GET"
        request.ContentType = "application/x-www-form-urlencoded";

        // 요청, 응답 받기
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        // 응답 Stream 읽기
        Stream stReadData = response.GetResponseStream();
        StreamReader srReadData = new StreamReader(stReadData, Encoding.Default);

        // 응답 Stream -> 응답 String 변환
        strResult = srReadData.ReadToEnd();

        /*
        JsonTextParser parser = new JsonTextParser();
        JsonObject obj = parser.Parse(strResult);
        JsonObjectCollection col = (JsonObjectCollection)obj;
        */
    }
}
