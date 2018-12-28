using Localisation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public static class LanguageManager
{
    public static bool isChinese = LocalisationManager.Instance.currLangName.Contains("中文");

    public static List<string> PageList = isChinese ? new List<string> { "基础设置", "碰撞设置", "模型设置", "渲染设置" } : new List<string> { "Base", "Collider", "Mesh", "Shader" };

    public static string Hardness = isChinese ? "硬度" : "Hardness";
    public static List<string> HardnessList = isChinese ? new List<string> { "无碳钢", "低碳钢", "中碳钢", "高碳钢" } : new List<string> { "No Carbon Steel", "Low Carbon Steel", "Mid Carbon Steel", "High Carbon Steel" };
    public static string MassFormSize = isChinese ? "尺寸决定质量" : "Mass Form Size";
    public static string Mass = isChinese ? "质量" : "Mass";
    public static string Drag = isChinese ? "阻力" : "Drag";

    public static string EnabledCollider = isChinese ? "启用碰撞" : "Enabled Collider";

    public static string RotationX = isChinese ? "旋转X轴" : "Rot X";
    public static string RotationY = isChinese ? "旋转Y轴" : "Rot Y";
    public static string RotationZ = isChinese ? "旋转Z轴" : "Rot Z";

    public static string OffsetX = isChinese ? "偏移X轴" : "Offset X";
    public static string OffsetY = isChinese ? "偏移Y轴" : "Offset Y";
    public static string OffsetZ = isChinese ? "偏移Z轴" : "Offset Z";

    public static List<string> ShaderList = isChinese ? new List<string> { "漫反射", "透明" } : new List<string> { "Diffuse", "Transparent" };

}

