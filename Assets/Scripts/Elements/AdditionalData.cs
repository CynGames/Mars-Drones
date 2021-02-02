using System;
using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using UnityEngine;

public class AdditionalData : MonoBehaviour
{
    public string StringedType;
    public string StringedSecType;

    public enum Type
    {
        Fabricacion_Util,
        Fabricacion_Inutil,
        Herramienta,
        Basura
    }
    public Type type;

    public enum SecondaryType
    {
        Electrico,
        Mecanico
    }
    public SecondaryType SecType;

    public void InitObjectString()
    {
        switch (type)
        {
            case Type.Fabricacion_Util:
                StringedType = "FABRICACION";
                break;
            case Type.Fabricacion_Inutil:
                StringedType = "FABRICACION";
                break;
            case Type.Herramienta:
                StringedType = "HERRAMIENTA";
                break;
            case Type.Basura:
                StringedType = "BASURA";
                break;
        }

        switch (SecType)
        {
            case SecondaryType.Electrico:
                StringedSecType = "ELECTRICO";
                break;
            case SecondaryType.Mecanico:
                StringedSecType = "MECANICO";
                break;
        }
    }

    private void Awake()
    {
        if (StringedType.Equals(""))
        {
            InitObjectString();
        }
    }
}