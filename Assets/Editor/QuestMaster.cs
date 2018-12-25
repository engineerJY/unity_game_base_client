using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMaster : ScriptableObject {

    public List<Sheet> sheets = new List<Sheet>();

    [System.SerializableAttribute]
    public class Sheet
    {
        public string name = string.Empty;
        public List<Param> list = new List<Param>();
    }

    [System.SerializableAttribute]
    public class Param
    {
        public int id;
        public string questname;
        public string type;
    }
}
