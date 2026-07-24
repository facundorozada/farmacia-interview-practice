import { useEffect, useState } from "react";
import "./App.css";

function App() {
  const [medicamentos, setMedicamentos] = useState([]);
  const [cargando, setCargando] = useState(true);
  const [error, setError] = useState("");

  useEffect(() => {
    async function obtenerMedicamentos() {
      try {
        const response = await fetch(
          "https://localhost:7061/api/Medicamentos"
        );

        if (!response.ok) {
          throw new Error("No se pudieron obtener los medicamentos.");
        }

        const datos = await response.json();
        setMedicamentos(datos);
      } catch (error) {
        setError(error.message);
      } finally {
        setCargando(false);
      }
    }

    obtenerMedicamentos();
  }, []);

  if (cargando) {
    return <p>Cargando medicamentos...</p>;
  }

  if (error) {
    return <p>{error}</p>;
  }

  return (
    <main>
      <h1>Medicamentos</h1>

      <table>
        <thead>
          <tr>
            <th>Nombre</th>
            <th>Principio activo</th>
            <th>Precio</th>
            <th>Stock</th>
            <th>Laboratorio</th>
            <th>Activo</th>
          </tr>
        </thead>

        <tbody>
          {medicamentos.map((medicamento) => (
            <tr key={medicamento.id}>
              <td>{medicamento.nombre}</td>
              <td>{medicamento.principioActivo}</td>
              <td>${medicamento.precio}</td>
              <td>{medicamento.stock}</td>
              <td>{medicamento.laboratorioNombre}</td>
              <td>{medicamento.activo ? "Sí" : "No"}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </main>
  );
}

export default App;
