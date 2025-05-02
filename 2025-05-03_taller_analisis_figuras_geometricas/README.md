# Taller Imagen Matriz Pixeles

En este taller se trabajó con procesamiento de imágenes utilizando OpenCV en Google Colab. Se comenzó cargando una imagen en color y visualizando sus canales RGB y HSV por separado. Luego, se modificaron regiones específicas de la imagen mediante slicing, cambiando colores y sustituyendo áreas. Se calculó y graficó el histograma de intensidades en escala de grises y por canal de color para analizar la distribución tonal. Finalmente, se aplicaron ajustes manuales de brillo y contraste usando una ecuación lineal, visualizando los efectos de manera comparativa.

### 📸 Capturas o GIFs
![Untitled ‑ Made with FlexClip](https://github.com/user-attachments/assets/14332098-61b8-489e-b21c-af82f6355e0c)


### 🎯 Codigo Relevante

    # Detectar contornos
    contours, hierarchy = cv2.findContours(binary_img, cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_SIMPLE)
    
    # Dibujar los contornos sobre una copia de la imagen original (en color)
    img_color = cv2.cvtColor(img, cv2.COLOR_GRAY2BGR)  # convertir a BGR para dibujar en color
    cv2.drawContours(img_color, contours, -1, (0, 255, 0), 2)  # contornos verdes

    # Recorremos cada contorno
    for i, contour in enumerate(contours):
        # Área
        area = cv2.contourArea(contour)

        # Perímetro
        perimeter = cv2.arcLength(contour, True)
    
        # Momentos para calcular el centroide
        M = cv2.moments(contour)
    
        # Centroide (cx, cy) con manejo de división por cero
        if M['m00'] != 0:
            cx = int(M['m10'] / M['m00'])
            cy = int(M['m01'] / M['m00'])
        else:
            cx, cy = 0, 0

    # Dibujar centroides sobre la imagen con contornos
    for contour in contours:
        M = cv2.moments(contour)
        if M['m00'] != 0:
            cx = int(M['m10'] / M['m00'])
            cy = int(M['m01'] / M['m00'])
            cv2.circle(img_color, (cx, cy), 4, (0, 0, 255), -1)  # punto rojo
            
### ✅ Descripción general de los prompts usados (si aplican).
link chat: [[https://chatgpt.com/share/68144eaf-7fd4-800a-b772-7b3f6b034457](https://chatgpt.com/share/6815045f-c454-800a-bd8a-e36501e72350)](https://chatgpt.com/share/68152cec-6df4-800a-afda-f017e5f0fef0)
Se realizó los prompts para ayuda en la carga de la imagen, binarizar la imagen, identificar contornos, dibujarlos encima de la imagen original individualmente y calcular las areas, perimetros y centroides de esas figuras

### Comentarios personales sobre el aprendizaje y dificultades encontradas.

Hubo una dificultad al momento de ajustar el humbral al binarizar la imagen. Se realizaron bastantes cambios del valor del humnbral para que posteriormente se detectaran la menos cantidad posibles de contornos que no eran de la figura o no eran importantes
