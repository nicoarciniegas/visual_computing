# Taller convoluciones personalizadas

## Python

En este laboratorio se cargó una imagen y se convirtió a escala de grises para aplicar convoluciones 2D manuales utilizando NumPy, implementando desde cero una función que recorre píxel por píxel y aplica distintos kernels. Se diseñaron y probaron tres tipos de filtros: uno de enfoque (sharpen) para realzar detalles, otro de suavizado (blur) para reducir ruido, y un tercero de detección de bordes/esquinas basado en la combinación de derivadas de Sobel. Posteriormente, se compararon visualmente los resultados obtenidos con la implementación manual frente a los generados usando la función cv2.filter2D() de OpenCV.

### 📸 Capturas o GIFs
![Untitled ‑ Made with FlexClip](https://github.com/user-attachments/assets/b84a8b8f-cb68-4ec9-9987-f149792d4f03)

### 🎯 Codigo Relevante

    # 1. Kernel de Enfoque (Sharpen) 
    kernel_sharpen = np.array([
        [ 0, -1,  0],
        [-1,  5, -1],
        [ 0, -1,  0]
    ], dtype=np.float32)
    
    # 2. Kernel de Suavizado (Blur Promedio) 
    kernel_blur = np.ones((3, 3), dtype=np.float32) / 9.0
    
    # 3. Detección de esquinas (combinación de Sobel X e Y) 
    kernel_sobel_x = np.array([
        [-1, 0, 1],
        [-2, 0, 2],
        [-1, 0, 1]
    ], dtype=np.float32)
    
    kernel_sobel_y = np.array([
        [-1, -2, -1],
        [ 0,  0,  0],
        [ 1,  2,  1]
    ], dtype=np.float32)

    # Aplicación manual
    img_sharpen_manual = aplicar_convolucion(img_gray, kernel_sharpen)
    img_blur_manual = aplicar_convolucion(img_gray, kernel_blur)
    grad_x = aplicar_convolucion(img_gray, kernel_sobel_x)
    grad_y = aplicar_convolucion(img_gray, kernel_sobel_y)
    img_sobel_manual = np.sqrt(grad_x**2 + grad_y**2)
    
    # Aplicación con OpenCV 
    img_sharpen_cv = cv2.filter2D(img_gray, ddepth=cv2.CV_32F, kernel=kernel_sharpen)
    img_blur_cv = cv2.filter2D(img_gray, ddepth=cv2.CV_32F, kernel=kernel_blur)
    grad_x_cv = cv2.filter2D(img_gray, ddepth=cv2.CV_32F, kernel=kernel_sobel_x)
    grad_y_cv = cv2.filter2D(img_gray, ddepth=cv2.CV_32F, kernel=kernel_sobel_y)
    img_sobel_cv = np.sqrt(grad_x_cv**2 + grad_y_cv**2)
       
### Comentarios personales sobre el aprendizaje y dificultades encontradas.

Al compararse visualmente los resultados obtenidos con la implementación manual frente a los generados usando la función cv2.filter2D() de OpenCV. observando que ambos métodos producen resultados similares aunque OpenCV es más eficiente computacionalmente. Esta comparación permitió comprender mejor el funcionamiento interno de los filtros y el procesamiento de imágenes.
