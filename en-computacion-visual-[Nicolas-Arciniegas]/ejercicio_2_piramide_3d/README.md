# Taller de Jerarquías y Transformaciones

## Three.Js
Se ha construido una pirámide utilizando múltiples cubos (Box) en React con la librería @react-three/fiber, aplicando materiales PBR (texturas diffuse, normal y roughness) para lograr un aspecto realista. Además, se ha configurado una iluminación adecuada con luces ambiental, direccional y puntual, y se han incluido controles de cámara (OrbitControls) para permitir la interacción y exploración de la escena en 3D.a

### 📸 Capturas o GIFs
<img width="1366" height="768" alt="Captura" src="https://github.com/user-attachments/assets/8fd86fde-6f12-492f-9f57-3482449269f9" />


### 🎯 Codigo Relevante

        import { Canvas } from '@react-three/fiber'
        import { Box, OrbitControls } from '@react-three/drei'
        import { TextureLoader } from 'three'
        import { useLoader } from '@react-three/fiber'
        import './App.css'
        
        function Pyramid() {
          // Carga de texturas PBR
          const diffuse = useLoader(TextureLoader, '/textures/DiamondPlate.png')
          const normal = useLoader(TextureLoader, '/textures/jean.png')
          const roughness = useLoader(TextureLoader, '/textures/Travert.png')
        
          // Pirámide de base 3x3, 2x2 y 1x1
          const layers = [
            { size: 3, y: 0 },
            { size: 2, y: 1.1 },
            { size: 1, y: 2.2 }
          ]
        
          return (
            <>
              {layers.map((layer, i) =>
                Array.from({ length: layer.size }).map((_, x) =>
                  Array.from({ length: layer.size }).map((_, z) => (
                    <Box
                      key={`${i}-${x}-${z}`}
                      args={[1, 1, 1]}
                      position={[
                        x - (layer.size - 1) / 2,
                        layer.y,
                        z - (layer.size - 1) / 2
                      ]}
                    >
                      <meshStandardMaterial
                        map={diffuse}
                        normalMap={normal}
                        roughnessMap={roughness}
                        metalness={0.2}
                        roughness={0.8}
                      />
                    </Box>
                  ))
                )
              )}
            </>
          )
        }
        
        function App() {
          return (
            <Canvas camera={{ position: [7, 7, 7], fov: 50 }}>
              {/* Luz ambiental suave */}
              <ambientLight intensity={0.6} />
              {/* Luz direccional principal */}
              <directionalLight position={[10, 15, 10]} intensity={1.2} castShadow />
              {/* Luz puntual para resaltar */}
              <pointLight position={[0, 8, 0]} intensity={1.8} />
              <Pyramid />
              {/* Controles de órbita para mover la cámara */}
              <OrbitControls enablePan={true} enableZoom={true} enableRotate={true} />
            </Canvas>
          )
        }
        
        export default App
