using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class MeshEntityData
{
    public long ID { get; set; }
    public Color Color { get; set; }
    public string MaterialName { get; set; }

    public MeshEntityData() { }
    public MeshEntityData(long id, Color color,string name)
    {
        ID = id; Color = color;MaterialName = name;
    }
    public MeshEntityData(string dataString)
    {
        string[] vs = dataString.Split('|');
        ID = long.Parse(vs[0]);

        try { Color = new Color(float.Parse(vs[1]), float.Parse(vs[2]), float.Parse(vs[3]), float.Parse(vs[4])); }
        catch { Color = new Color(1, 1, 1, 1); }

        try { MaterialName = vs[5]; }
        catch { MaterialName = "Default"; }  
    }
    public MeshEntityData(long id)
    {
        ID = id; Color = new Color(1, 1, 1, 1); MaterialName = "Default";
    }

    public override string ToString()
    {
        return string.Format("{0}|{1}|{2}|{3}|{4}|{5}", ID, Color.r, Color.g, Color.b, Color.a, MaterialName);
    }
}
