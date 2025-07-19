# Ejercicio 1: Procesamiento de Imagen y Detección con YOLO

## Python

En este ejercicio se realizó un procesamiento completo de una imagen en Python utilizando OpenCV y YOLOv8. Primero, se carga una imagen y se convierte a formato RGB para su visualización. Luego, se le aplica un filtro de suavizado Gaussiano para reducir el ruido, seguido de la detección de bordes utilizando el método Canny. Posteriormente, se utiliza el modelo preentrenado YOLOv8 para detectar objetos dentro de la imagen original, generando una versión anotada con etiquetas y cuadros delimitadores. Finalmente, se muestran en pantalla las cuatro etapas del procesamiento: imagen original, imagen suavizada, bordes detectados y la imagen con detección de objetos.

### 📸 Capturas o GIFs

- Imagen Original:
- <img width="342" height="247" alt="img_original" src="https://github.com/user-attachments/assets/5b70491c-5115-48a4-925e-ce286714c47d" />

- Imagen Suavizada:
- <img width="341" height="225" alt="img_suavizada" src="https://github.com/user-attachments/assets/8329bd3d-bc9a-4045-8012-fd758f81fc00" />

- Imagen con bordes detectados:
- <img width="345" height="235" alt="img_bordes_detectados" src="https://github.com/user-attachments/assets/6d22dc32-2783-4a0d-a790-76fed2915059" />

- Deteccion de objetos y su respectiva etiqueta:
- <img width="344" height="261" alt="img_deteccion" src="https://github.com/user-attachments/assets/8fe05be8-a2d8-434c-8750-52d5a227d5ee" />


### 🎯 Codigo Relevante

        # 2. Aplicar filtro de suavizado (Gaussiano)
        imagen_suavizada = cv2.GaussianBlur(imagen, (9, 9), 0)
        
        # 3. Detección de bordes (Canny)
        gris = cv2.cvtColor(imagen_suavizada, cv2.COLOR_BGR2GRAY)
        bordes = cv2.Canny(gris, 100, 200)
        
        # 4. Detección de objetos con YOLOv8
        modelo = YOLO("C:\\Users\\nicoa\\Downloads\\yolov8n(1).pt")  # Modelo liviano preentrenado (puedes cambiar a yolov8s.pt, etc.)
        resultados = modelo(imagen)[0]  # Usa la imagen original en BGR
        imagen_con_bboxes = resultados.plot()  # Imagen con bounding boxes y etiquetas
        
        # Convertir imagen YOLO de BGR a RGB para matplotlib
        imagen_yolo_rgb = cv2.cvtColor(imagen_con_bboxes, cv2.COLOR_BGR2RGB)
