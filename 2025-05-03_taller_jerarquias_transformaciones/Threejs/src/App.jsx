import './App.css'
import { Canvas, useFrame } from '@react-three/fiber'
import { OrbitControls } from '@react-three/drei'
import { useRef } from 'react'
import { Leva, useControls } from 'leva'

function AnimatedGroup() {
  const groupRef = useRef()
  const childGroupRef = useRef()

  // Controles de Leva
  const { rotationSpeed, positionX, positionZ } = useControls({
    rotationSpeed: { value: 0.03, min: 0, max: 0.1, step: 0.01 },
    positionX: { value: 0, min: -5, max: 5, step: 0.1 },
    positionZ: { value: 0, min: -5, max: 5, step: 0.1 },
  })

  useFrame(({ clock }) => {
    const t = clock.getElapsedTime()
    // Movimiento circular del grupo principal
    groupRef.current.position.x = positionX + Math.sin(t) * 2
    groupRef.current.position.z = positionZ + Math.cos(t) * 2
    groupRef.current.rotation.y += rotationSpeed

    // Rotación adicional para el grupo hijo
    if (childGroupRef.current) {
      childGroupRef.current.rotation.x += 0.02
      childGroupRef.current.rotation.z += 0.02
    }
  })

  return (
    <group ref={groupRef}>
      {/* Hijo 1 */}
      <mesh position={[-1.5, 0, 0]}>
        <boxGeometry args={[1, 1, 1]} />
        <meshNormalMaterial />
      </mesh>
      {/* Hijo 2 */}
      <group ref={childGroupRef} position={[1.5, 0, 0]}>
        <mesh>
          <sphereGeometry args={[0.5, 20, 20]} />
          <meshStandardMaterial color="orange" />
        </mesh>
        {/* Hijo de la esfera */}
        <mesh position={[0, 1, 0]}>
          <torusGeometry args={[0.3, 0.1, 16, 100]} />
          <meshStandardMaterial color="green" />
        </mesh>
      </group>
      {/* Hijo 3 */}
      <mesh position={[0, 1.5, 2]}>
        <coneGeometry args={[0.5, 1, 32]} />
        <meshStandardMaterial color="blue" />
      </mesh>
    </group>
  )
}

function App() {
  return (
    <>
      <h1>3D NIKO</h1>
      <Leva collapsed />
      <div className="canvas-container">
        <Canvas>
          <ambientLight intensity={0.5} />
          <pointLight position={[10, 10, 10]} />
          <AnimatedGroup />
          <OrbitControls />
        </Canvas>
      </div>
    </>
  )
}

export default App