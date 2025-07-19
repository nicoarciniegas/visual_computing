import cv2
import matplotlib.pyplot as plt
from ultralytics import YOLO

# 1. Cargar la imagen
imagen = cv2.imread('C:\\Users\\nicoa\\Downloads\\image.jpg')  # Reemplaza con la ruta real
imagen_rgb = cv2.cvtColor(imagen, cv2.COLOR_BGR2RGB)  # Convertir a RGB para visualizar correctamente

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

# 5. Visualización de todas las etapas
plt.figure(figsize=(16, 4))

plt.subplot(1, 4, 1)
plt.title('Imagen Original')
plt.imshow(imagen_rgb)
plt.axis('off')

plt.subplot(1, 4, 2)
plt.title('Imagen Suavizada')
plt.imshow(cv2.cvtColor(imagen_suavizada, cv2.COLOR_BGR2RGB))
plt.axis('off')

plt.subplot(1, 4, 3)
plt.title('Bordes Detectados (Canny)')
plt.imshow(bordes, cmap='gray')
plt.axis('off')

plt.subplot(1, 4, 4)
plt.title('Detección con YOLOv8')
plt.imshow(imagen_yolo_rgb)
plt.axis('off')

plt.tight_layout()
plt.show()
