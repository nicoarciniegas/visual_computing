# Ejercicio 3: Convolución Unidimensional en Python

## Python
En este taller se implementó manualmente una convolución 1D aplicando un *kernel* de tamaño 3 a una señal de entrada. Se utilizó un método de padding por reflexión para conservar la longitud de la señal y se calcularon los valores resultantes aplicando el producto punto entre el kernel y segmentos de la señal. Finalmente, se visualizaron mediante gráficos los tres elementos clave: la señal original, el kernel y el resultado de la convolución, lo que permite analizar cómo el filtro modifica la señal.

### 📸 Capturas o GIFs
- Señal Original
- <img width="379" height="386" alt="señal_original" src="https://github.com/user-attachments/assets/5efea9bb-f659-42be-bf5f-5f61d8559158" />

- Kernel
- <img width="403" height="390" alt="kernel" src="https://github.com/user-attachments/assets/f2191c10-9ebd-457f-827e-68ae69bf0e0f" />

- Resultado
- <img width="381" height="395" alt="Resultado" src="https://github.com/user-attachments/assets/132804ad-113c-40b9-8b00-231e756e0c8e" />

### 🎯 Codigo Relevante

    # Señal de entrada 
    signal = [2, 4, 6, 8, 10, 9, 7, 5, 3, 1]
    
    # Kernel de tamaño 3 
    kernel = [1, 0, -1]
    
    def convolve1d(signal, kernel):
        k_len = len(kernel)
        s_len = len(signal)
        pad = k_len // 2
    
        # Reflejamos los bordes para padding (modo 'reflect')
        padded_signal = ([signal[pad - i] for i in range(pad)][::-1] +
                         signal +
                         [signal[-(i+1)] for i in range(pad)])
    
        result = []
        for i in range(s_len):
            acc = 0
            for j in range(k_len):
                acc += padded_signal[i + j] * kernel[j]
            result.append(acc)
        return result
    

