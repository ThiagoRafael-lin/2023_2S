import { useState, useEffect } from "react";
import Title from "../../Components/Title/Title";
import "./TipoEventosPage.css";
import MainContent from "../../Components/MainContent/MainContent";
import ImageIllustrator from "../../Components/ImageIllustrator/ImageIllustrator";

import eventTypeImage from "../../assets/images/tipo-evento.svg";
import Container from "../../Components/Container/Container";
import { Input, Button } from "../../Components/FormComponents/FormComponents";
import api from "../../Services/Services";
import TableTp from "./TableTp/TableTp";

import Notification from "../../Components/Notification/Notification";
import Spinner from  "../../Components/Spinner/Spinner";

const TipoEventosPage = () => {
  const [notifyUser, setNotifyUser] = useState({});
  const [showSpinner, setShowSpinner] = useState(true);

  const [frmEdit, setFrmEdit] = useState(false);

  const [titulo, setTitulo] = useState("");
  const [idEvento, setIdEvento] = useState(null);

  const [tipoEventos, setTipoEventos] = useState([]); //array


  // **********************Notify**********************

  setNotifyUser({
    titleNote: "Sucesso",
    textNote: `Cadastrado com sucesso!`,
    imgIcon: "success",
    imgAlt:
      "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
    showMessage: true,
  });

  //  *************************EDITAR*****************************

  async function handleSubmit(e) {
    e.preventDefault();

    if (titulo.trim().length < 3) {
      alert("o Titulo deve ter no minimo 3 caracteres");
      return;
    }
    try {
      const retorno = await api.post("/TiposEvento", { titulo: titulo });

      console.log("Cadastrado com sucesso");
      console.log(retorno.data);

      setTitulo("");
      const retornoGet = await api.get("/TiposEvento");

      setTipoEventos(retornoGet.data);
    } catch (error) {
      console.log("Deu ruim na api");
      console.log(error);
    }
  }

  //********************Update *********************/

  async function handleUpdate(e) {
    e.preventDefault();
    try {
      
      const retorno = await api.put('/TiposEvento/' + idEvento, {
        titulo: titulo
      });

      const retornoGet = await api.get('/TiposEvento');
      setTipoEventos(retornoGet.data);
      alert("Atualizado com sucesso");

      editActionAbort();

    } catch (error) {
      
      alert("Problemas na atualização. Tente novamente")

    }
  }

  //********************Delete *********************/

  async function handleDelete(idEvento) {
    try {
      const retorno = await api.delete(`/TiposEvento/${idEvento}`);

      alert("Registro apagado com sucesso");

      const retornoGet = await api.get("/TiposEvento");

      setTipoEventos(retornoGet.data);
    } catch (error) {
      console.log("Erro ao excluir");
    }
  }

  //********************ShowUpdateForm *********************/

  async function showUpdateForm(idElemento) {
    setFrmEdit(true);

    try {
      const retorno = await api.get("/TiposEvento" + idElemento)

      setTitulo(retorno.data.titulo);
      setIdEvento(retorno.data.idTipoEvento);

    } catch (error) {

      alert("Não foi possivel mostrar a tela de edição. tente novamente"); 

    }

  }

  //********************EdicActionAbort *********************/

  function editActionAbort() {
    alert("Cancelar a tela de edição de dados");
    setFrmEdit(false);
    setTitulo=("");
    setIdEvento(null);
  }

  //***********************UseEffect *************************/

  useEffect(() => {
    async function getTiposEvento() {
      try {
        const promise = await api.get("/TiposEvento");
        setTipoEventos(promise.data);
      } catch (error) {
        alert(`Deu ruim na api ${error})`)
      }
    }
    getTiposEvento();
  }, []);

  //***********************Return ***************************/

  return (
    <MainContent>
      <Notification {...notifyUser} setNotifyUser={setNotifyUser} />
      { showSpinner  ?  <Spinner /> : null}

      <Spinner />
      {/* Cadastro tipo de eventos */}
      <section className="cadastro-evento-section">
        <Container>
          <div className="cadastro-evento__box">
            <Title titleText={"Página Tipos de Eventos"} />
            <ImageIllustrator
              alterText={"?????"}
              imageRender={eventTypeImage}
            />

            <form
              className="ftipo-evento"
              onSubmit={frmEdit ? handleUpdate : handleSubmit}
            >
              {!frmEdit ? (
                <>
                  <Input
                    type={"text"}
                    id={"titulo"}
                    name={"titulo"}
                    placeholder={"Título"}
                    required={"required"}
                    value={titulo}
                    manipulationFunction={(e) => {
                      setTitulo(e.target.value);
                    }}
                  />
                  <span>{titulo}</span>
                  <Button
                    type={"submit"}
                    id={"Cadastrar"}
                    name={"Cadastrar"}
                    textButton={"Cadastrar"}
                  />
                </>
              ) : (
                <>
                  <Input
                    id={"titulo"}
                    placeholder={"Título"}
                    name={"titulo"}
                    types={"text"}
                    required="required"
                    value={titulo}
                    manipulationFunction={(e) => {
                      setTitulo(e.target.value);
                    }}
                  />

                  <div className="buttonsp-editbox">
                    <Button
                      textButton="Atualizar"
                      id="atualizar"
                      name="atualizar"
                      type="submit"
                      additionalClass="button-component--middle"
                    />
                    <Button
                      textButton="cancelar"
                      id="cancelar"
                      name="cancelar"
                      type="button"
                      manipulationFunction={editActionAbort}
                      additionalClass="button-component--middle"
                    />
                  </div>
                </>
              )}
            </form>
          </div>
        </Container>
      </section>

      <section className="lista-eventos-section">
        <Container>
          <Title titleText={"Lista Tipo de Evento"} color="white" />

          <TableTp
            dados={tipoEventos}
            fnUpdate={(e) => {
              showUpdateForm(e.target.value);
            }}
            fnDelete={handleDelete}
          />
        </Container>
      </section>
    </MainContent>
  );
};

export default TipoEventosPage;
