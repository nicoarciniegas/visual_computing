void setup() {
  size(600, 600);
  ellipseMode(CENTER);
}

void draw() {
  background(240);

  // Animaciones con sin() y frameCount
  float angle = sin(frameCount * 0.05) * PI / 4; // Oscila entre -π/4 y π/4
  float scaleFactor = 1 + 0.5 * sin(frameCount * 0.05); // Oscila entre 0.5 y 1.5
  float xOffset = 100 * sin(frameCount * 0.02); // Oscila horizontalmente

  pushMatrix(); // Aisla las transformaciones
  translate(width / 2 + xOffset, height / 2); // Mover al centro con desplazamiento
  rotate(angle); // Rotar
  scale(scaleFactor); // Escalar

  fill(100, 150, 255);
  stroke(0);
  ellipse(0, 0, 100, 60); // Dibuja la elipse en el centro del sistema actual
  popMatrix(); // Restaura el sistema de coordenadas original
}
