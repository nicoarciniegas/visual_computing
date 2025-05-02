# Taller de Jerarquías y Transformaciones

## Three.Js

### 📸 Capturas o GIFs
- ![Taller1_Unity](https://github.com/user-attachments/assets/52299d05-036f-4eb8-bb62-901f5315db0d)

### 🎯 Codigo Relevante

### Comentarios personales sobre el aprendizaje y dificultades encontradas.

## Unity

### 📸 Capturas o GIFs
- ![Taller1_Unity](https://github.com/user-attachments/assets/52299d05-036f-4eb8-bb62-901f5315db0d)

### 🎯 Codigo Relevante

using UnityEngine;
using UnityEngine.UI;

public class FatherTransformControl : MonoBehaviour
{
    public Transform father;

    public Slider sliderPosX;
    public Slider sliderRotY;
    public Slider sliderScaleZ;

    void Start()
    {
        // Inicializa sliders
        sliderPosX.value = father.localPosition.x;
        sliderRotY.value = father.localEulerAngles.y;
        sliderScaleZ.value = father.localScale.z;

        // Listeners
        sliderPosX.onValueChanged.AddListener((v) => UpdatePosition());
        sliderRotY.onValueChanged.AddListener((v) => UpdateRotation());
        sliderScaleZ.onValueChanged.AddListener((v) => UpdateScale());

        // Mostrar valores iniciales
        LogTransform("Inicial");
    }

    void UpdatePosition()
    {
        Vector3 pos = father.localPosition;
        pos.x = sliderPosX.value;
        father.localPosition = pos;
        LogTransform("Posición actualizada");
    }

    void UpdateRotation()
    {
        Vector3 rot = father.localEulerAngles;
        rot.y = sliderRotY.value;
        father.localEulerAngles = rot;
        LogTransform("Rotación actualizada");
    }

    void UpdateScale()
    {
        Vector3 scale = father.localScale;
        scale.z = sliderScaleZ.value;
        father.localScale = scale;
        LogTransform("Escala actualizada");
    }

    void LogTransform(string evento)
    {
        Debug.Log($"[{evento}] Pos: {father.localPosition}, Rot: {father.localEulerAngles}, Scale: {father.localScale}");
    }
}

### Comentarios personales sobre el aprendizaje y dificultades encontradas.

