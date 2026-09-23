import {useState, useEffect} from 'react'


function App(){

  // useState cria uma variável que, quando alterada, atualiza a tela automaticamente
  const [lotes, setLotes] = useState([])
  const [carregando, setCarregando] = useState(true)

  // useEffect roda uma vez assim que o componente aparece na tela
  useEffect(() => {
    // Vamos chamar a sua API C# aqui!
    fetch('http://localhost:5135/api/LoteCarne')
    .then(resposta => resposta.json())
    .then(dados => {
      setLotes(dados)
      setCarregando(false)
    })
    .catch(erro => console.error ("Erro ao buscar dados: ", erro))
  }, []) // O array vazio [] significa "execute apenas uma vez"

  return(
    // Container principal centralizado e com largura máxima
    <div style={{ padding: '40px', fontFamily: 'Arial, sans-serif', maxWidth: '800px', margin: '0 auto', color: '#333' }}>
      
      <h1 style={{ textAlign: 'center', color: '#2c3e50', marginBottom: '30px'}}>Controle de Lotes - Frigorífico</h1>

      {carregando ? (
        <p style={{textAlign: 'center'}}>A carregar dados...</p>
      ) : (
        <table style={{
          width: '100%',
          borderCollapse: 'collapse',
          boxShadow: '0 4px 8px rgba(0,0,0,0.1)',
          backgroundColor: '#ffffff'
        }}>
          {/* Cabeçalho com fundo escuro e texto branco */}
          <thead>
            <tr style={{ backgroundColor: '#34495e', color: 'white', textAlign: 'center'}}>
              <th style={{ padding: '15px', borderBottom: '2px solid #ddd' }}>ID</th>
              <th style={{ padding: '15px', borderBottom: '2px solid #ddd' }}>Código de Rastreio</th>
              <th style={{ padding: '15px', borderBottom: '2px solid #ddd' }}>Corte</th>
              <th style={{ padding: '15px', borderBottom: '2px solid #ddd' }}>Peso (Kg)</th>
            </tr>
          </thead>
          <tbody>
            {/* O método map() itera sobre a lista e cria uma linha na tabela para cada lote */}
            {lotes.map(lote => (
              <tr key={lote.id} style={{borderBottom: '1px solid #ddd', textAlign: 'center'}}>
                <td>{lote.id}</td>  
                <td style={{ padding: '15px'}}>{lote.codigoRastreio}</td>
                <td style={{ padding: '15px'}}>{lote.tipoCorte}</td>
                <td style={{ padding: '15px'}}>{lote.pesoKg}</td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </div>

  )

}

export default App
