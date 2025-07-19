import matplotlib.pyplot as plt

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

output = convolve1d(signal, kernel)


plt.figure(figsize=(12, 4))

plt.subplot(1, 3, 1)
plt.stem(signal)
plt.title("Señal original")
plt.grid(True)

plt.subplot(1, 3, 2)
plt.stem(kernel)
plt.title("Kernel")
plt.grid(True)

plt.subplot(1, 3, 3)
plt.stem(output)
plt.title("Resultado de la convolución")
plt.grid(True)

plt.tight_layout()
plt.show()
