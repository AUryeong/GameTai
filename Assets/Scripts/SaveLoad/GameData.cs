using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable] // ����ȭ

public class GameData 
{
    public bool cleartutorial = false;
    public string name = "�����";
    public List<Worker> workers = new List<Worker>();
}