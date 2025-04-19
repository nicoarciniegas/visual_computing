# 💫 Elipse Animada en Processing
Este proyecto en Processing genera una animación suave de una elipse que rota, cambia de tamaño y se desplaza horizontalmente, simulando un efecto de "respiración" o movimiento fluido. 

## 🛠️ Tecnologías
- [Processing](https://processing.org/) (lenguaje de programación visual)
- Funciones de animación integradas (`sin()`, `frameCount`)
- Transformaciones: `translate()`, `rotate()`, `scale()`

## ✨ Funcionalidades
- 🔄 Rotación oscilante de la elipse
- 🔍 Escalado dinámico que simula respiración
- ↔️ Movimiento horizontal continuo
- 🖼️ Redibujo en tiempo real con `draw()`

## 🧠 Cómo funciona
1. Se crea un lienzo de 600x600 píxeles y se centra el modo de dibujo de la elipse.
2. En cada fotograma (`draw()`):
   - Se calcula un **ángulo de rotación** basado en `sin(frameCount)`.
   - Se determina un **factor de escala** que varía suavemente.
   - Se aplica un **desplazamiento horizontal** animado.
3. Se combinan las transformaciones usando `pushMatrix()` y `popMatrix()` para aislarlas del resto del lienzo.
4. Se dibuja una elipse que responde a esas transformaciones en tiempo real.

## ▶️ Cómo ejecutarlo
1. Abre el archivo `.pde` en el editor de **Processing**.
2. Haz clic en **Run ▶️** para iniciar la animación.
3. Observa cómo la elipse rota, se escala y se desplaza con suavidad.

## 📸 Vista previa
![Taller1_Processing](https://github.com/user-attachments/assets/11a79830-8999-483e-93de-eb7db841d828)
