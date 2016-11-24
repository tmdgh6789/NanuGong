using UnityEngine;
using System.Net;
using System.Text;
using System.IO;

public class userInsert : MonoBehaviour {

	// Use this for initialization
	public void insert () {
        // 요청을 보내는 URl
        string strUri = "http://localhost:5000/insert/test3/test3/test3";

        /* POST */
        // HttpWebRequest 객체 생성, 설정
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strUri);
        request.Method = "GET";    // 기본값 "GET"
        request.ContentType = "application/x-www-form-urlencoded";
        
        // 요청, 응답 받기
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        // 응답 Stream 읽기
        Stream stReadData = response.GetResponseStream();
        StreamReader srReadData = new StreamReader(stReadData, Encoding.Default);

        // 응답 Stream -> 응답 String 변환
        string strResult = srReadData.ReadToEnd();

        Debug.Log(strResult);
    }
}
