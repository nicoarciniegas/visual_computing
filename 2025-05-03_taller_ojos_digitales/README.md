# Taller de Ojos Digitales

En este taller se implemento la aplicacion de filtros convulcionales (Blur y Sharpening) interactuando con los diferentes kernels en distintos tamaños. Además se realizó la deteccion de bordes con los filtros Sobel y el filtro Laplaciano

### 📸 Capturas o GIFs
- Imagen a color y Escala en grises
![descarga](https://github.com/user-attachments/assets/2fa19ae0-d2c5-40ee-b290-7d6e14003761)

- Filtro Blur y Sharpening aplicado
![descarga (1)](https://github.com/user-attachments/assets/ef451cc2-f23d-471f-838a-5142f3e842d4)

- Imagen a color, Sobel en X, Sobel en Y, Magnitud de los bordes
![descarga (2)](https://github.com/user-attachments/assets/e3face7a-d279-435d-95cb-1691aafee737)

- Escala de grises y filtro Laplaciano
![descarga (3)](https://github.com/user-attachments/assets/5fa0cb1e-6396-4ee6-83e2-ee536baf3a77)


### 🎯 Codigo Relevante

    blurred = cv2.GaussianBlur(img_gray_np, (35, 35), 0) filtro blur (desenfoque) usando una convolución con un kernel 35x35 (para mayor desenfoque)
    
  
    sharpen_kernel = np.array([[ -1, -1,  -1], # Kernel de sharpening (enfoque)
                               [-1,  9, -1],
                               [ -1, -1,  -1]])

    sobel_x = cv2.Sobel(img_gray_np, cv2.CV_64F, 1, 0, ksize=3)  # Sobel en X
    sobel_y = cv2.Sobel(img_gray_np, cv2.CV_64F, 0, 1, ksize=3)  # Sobel en Y

    laplacian = cv2.Laplacian(img_gray_np, cv2.CV_64F, ksize=31)

### Comentarios personales sobre el aprendizaje y dificultades encontradas.

Al poder interactuar con los diferentes kernel y como eso afecta de distintas maneras la imagen es cuando uno correlaciona su fincionamiento y que es lo que hace realmente con los pixeles de la imagen
