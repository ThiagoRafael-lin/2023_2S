import { useEffect, useState } from "react";
import Title from "../../Components/Title/Title";
import "./Eventos.css";
import MainContent from "../../Components/MainContent/MainContent";
import ImageIllustrator from "../../Components/ImageIllustrator/ImageIllustrator";

import "../../Components/FormComponents/FormComponents";
import eventTypeImage from "../../assets/images/evento.svg";
import Container from "../../Components/Container/Container";
import { Input, Button } from "../../Components/FormComponents/FormComponents";
import api from "../../Services/Services";
import TableEv from "./TableEv/TableEv";

import Notification from "../../Components/Notification/Notification";
import Spinner from "../../Components/Spinner/Spinner";

const Eventos = () => {
  const [notifyUser, setNotifyUser] = useState({});
  const [showSpinner, setShowSpinner] = useState(true);

  const [nome, setNome] = useState("");
  const [descricao, setDescricao] = useState("");
  const [data, setData] = useState();

  const [evento, setEvento] = useState([]);

  const [frmEdit, setFrmEdit] = useState(false);

  const [titulo, setTitulo] = useState("");
  const [idEvento, setIdEvento] = useState(null);

  const [tipoEventos, setTipoEventos] = useState([]);

  //************************useEffect ******************************/
  useEffect(() => {
    async function getEventos() {
      try {
        const promise = await api.get("/Evento");
        console.log(promise.data);
        setTipoEventos(promise.data);
      } catch (error) {
        setNotifyUser({
          titleNote: "Atenção",
          textNote: `Deu ruim na api`,
          imgIcon: "danger",
          imgAlt:
            "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
          showMessage: true,
        });
      }
      setShowSpinner(false);
    }
    getEventos();
  }, []);

  //************************getState ******************************/

  async function getState() {
    const retornoGet = await api.get("/Evento");
    console.log(retornoGet.data);
    setTipoEventos(retornoGet.data);
  }

  //************************Submit ******************************/

  async function handleSubmit(e) {
    //para o submit da pagina
    e.preventDefault();

    if (titulo.trim().length < 3) {
      alert("O titulo deve ter no minimo 3 caracteres");
      return;
    }
    try {
      const retorno = await api.post("/Evento", { titulo });

      setNotifyUser({
        titleNote: "Sucesso",
        textNote: `Cadastrado com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });

      console.log(retorno.data);
      setTitulo("");
      getState();
    } catch (e) {
      setNotifyUser({
        titleNote: "Atenção",
        textNote: `Erro ao cadastrar`,
        imgIcon: "danger",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
    }
  }

  //************************EdictAbort ******************************/

  function editActionAbort() {
    setFrmEdit(false);
    setTitulo = "";
    setIdEvento(null);
  }

  //************************Update ******************************/

  async function handleUpdate(e) {
    //parar o submit da página
    e.preventDefault();

    try {
      const retorno = await api.put("/Evento" + idEvento, {
        titulo: titulo,
      });

      setNotifyUser({
        titleNote: "Sucesso",
        textNote: `Atualizado com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });

      setTitulo("");
      getState();
    } catch (e) {
      setNotifyUser({
        titleNote: "Atenção",
        textNote: `Erro ao cadastrar`,
        imgIcon: "danger",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
    }
  }

  //************************ShowUpdateForm ******************************/

  async function showUpdateForm(idElemento) {
    setFrmEdit(true);
    try {
      const retorno = await api.get("/Evento" + idElemento)

      setTitulo(retorno.data.titulo);
      setIdEvento(retorno.data.idTipoEvento);

    } catch (error) {

      alert("Não foi possivel mostrar a tela de edição. tente novamente")

    }
  }

  //************************Delete ******************************/

  async function handleDelete(idEvento) {
    try {
      const retorno = await api.delete(`/Evento/${idEvento}`);

      setNotifyUser({
        titleNote: "Sucesso",
        textNote: `Apagado com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });

      getState();

    } catch (error) {

      setNotifyUser({
        titleNote: "Atenção",
        textNote: `Erro ao tentar apagar`,
        imgIcon: "danger",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });

    }
  }


  //************************Return ******************************/

  return (
    <MainContent>
      <Notification {...notifyUser} setNotifyUser={setNotifyUser} />
      {showSpinner ? <Spinner /> : null}

      <Spinner />

      <section className="cadastro-evento-section">
        <Container>
          <div className="cadastro-evento__box">
            <Title titleText={"Página de Evento"} />

            <ImageIllustrator
              alterText={"?????"}
              imageRender={eventTypeImage}
            />

            <form
              className="ftipo-evento"
            >
              <>
                <Input
                  type={"text"}
                  id={"nome"}
                  name={"nome"}
                  placeholder={"Nome"}
                  required={"required"}
                  value={nome}
                  manipulationFunction={(e) => {
                    setNome(e.target.value);
                  }}
                />

                <Input
                  type={"text"}
                  id={"descrição"}
                  name={"descrição"}
                  placeholder={"Descrição"}
                  required={"required"}
                  value={descricao}
                  manipulationFunction={(e) => {
                    setDescricao(e.target.value);
                  }}
                />

                <select
                  name=""
                  id="">
                  <option
                    value="Evento"
                  >
                    Tipo Evento
                  </option>
                </select>

                <Input
                  type={"date"}
                  id={"data"}
                  name={"data"}
                  placeholder={"dd / mm / aaaa"}
                  required={"required"}
                  value={data}
                  manipulationFunction={(e) => {
                    setData(e.target.value);
                  }}
                />

                <Button
                  type={"submit"}
                  id={"botao"}
                  name={"botao"}
                  textButton={"Cadastrar"}
                />
              </>
            </form>
          </div>
        </Container>
      </section>
      <section className="lista-eventos-section">
        <Container>
          <Title titleText={"Lista de Evento"} color="white" />
          <TableEv
            dados={evento}
            fnUpdate={handleUpdate}        
            fnDelete={handleDelete}
          />
        </Container>
      </section>
    </MainContent>
  );
};

export default Eventos;
