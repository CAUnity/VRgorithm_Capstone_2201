using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using UnityEngine;
using UnityEngine.Networking;

[Serializable]
public struct Result
{
    public Result(string studentId, bool isCorrect, int problemId)
    {
        this.studentId = studentId;
        this.isCorrect = isCorrect;
        this.problemId = problemId;
    }

    public string studentId;
    public bool isCorrect;
    public int problemId;
}

[Serializable]
public struct Problem
{
    public int id;
    public string name;
    public string input;
    public string output;
    public string description;
    public string teacherId;
    public string createdAt;
}

[Serializable]
public struct ProblemRes
{
    public List<Problem> data;
    public bool success;
    public string message;

}

public static class RequestManager
{
    private const string url = "http://3.39.186.84:3000";
    
    public static void ReqProbs(Action<string> callback)
    {
        Thread thread = new Thread(()=>Get(url+"/problems", callback));
        thread.Start();
    }
    
    public static void OnStageEnd(bool isCorrect, ArrayList userResult = null)
    {
        Result res = new Result(ProblemData.studentId, isCorrect, ProblemData.problemId);
        ReqMakeResult(res, (a) => { Debug.Log("result sent!");});
    }
    
    public static void ReqMakeResult(Result res, Action<string> callback)
    {
        string jsonfile = JsonUtility.ToJson(res);
        Thread thread = new Thread(()=>Post(url+"/results", jsonfile, callback));
        thread.Start();
    }

    private static void Post(string URL, string jsonfile, Action<string> callback)
    {
        WebRequest request = HttpWebRequest.Create(URL);
        request.ContentType = "application/json";
        request.Method = "POST";
        
        using (var streamWriter = new StreamWriter(request.GetRequestStream()))
        {
            streamWriter.Write(jsonfile);
        }

        var response = (HttpWebResponse)request.GetResponse();
        string result;
        using (var streamReader = new StreamReader(response.GetResponseStream()))
        {
            result = streamReader.ReadToEnd();
        }
        callback(result);
        
    }
    
    private static void Get(string URL, Action<string> callback)
    {
        WebRequest request = HttpWebRequest.Create(URL);
        request.Method = "GET";
        
        var response = (HttpWebResponse)request.GetResponse();
        string result;
        using (var streamReader = new StreamReader(response.GetResponseStream()))
        {
            result = streamReader.ReadToEnd();
        }
        callback(result);
        
        
    }
}
