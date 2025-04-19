import './App.css'
import { Canvas, useFrame } from '@react-three/fiber'
import { OrbitControls } from '@react-three/drei'
import { useRef } from 'react'


function AnimatedBox() {
  const meshRef = useRef()

  useFrame(({ clock }) => {
    const t = clock.getElapsedTime()
    // Movimiento circular
    meshRef.current.position.x = Math.sin(t) * 2
    meshRef.current.position.z = Math.cos(t) * 2
    // Rotación sobre el eje Y
    meshRef.current.rotation.y += 0.03
    // Escalado suave
    const scale = Math.abs(Math.sin(t)) + 0.5 // Asegura que el tamaño mínimo sea 0.5
    meshRef.current.scale.set(scale, scale, scale)
  })

  return (
    <mesh ref={meshRef}>
      <boxGeometry args={[1, 1, 1]} />
      <meshNormalMaterial />
    </mesh>
  )
}

function App() {
  return (
    <>
      <h1>3D NIKO</h1>
      <div className="canvas-container">
        <Canvas>
          <AnimatedBox />
          <OrbitControls />
        </Canvas>
      </div>
    </>
  )
}

export default App
