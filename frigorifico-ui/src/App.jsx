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
}