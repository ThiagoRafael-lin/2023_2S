import { useState, useEffect } from "react";
import Title from "../../Components/Title/Title";
import "./TipoEventosPage.css";
import MainContent from "../../Components/MainContent/MainContent";
import ImageIllustrator from "../../Components/ImageIllustrator/ImageIllustrator";

import "../../Components/FormComponents/FormComponents"
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

//***********************UseEffect *************************/

useEffect(() => {
  async function getTiposEvento() {

    setShowSpinner(true);

    try {
      const promise = await api.get("/TiposEvento");
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
  getTiposEvento();
  console.log("A home foi montada!");
}, []);

  // **********************getState**********************

  async function getState()
  {
    const retornoGet = await api.get("/TiposEvento");
    console.log(retornoGet.data);
    setTipoEventos(retornoGet.data)
  }

  //  *************************EDITAR*****************************

  async function handleSubmit(e) {
    //para o submit da página
    e.preventDefault();

    if (titulo.trim().length < 3) {
      alert("o Titulo deve ter no minimo 3 caracteres");
      return;
    }
    try {
      const retorno = await api.post("/TiposEvento", { titulo: titulo }); //{titulo:titulo} para {titulo} quando o valor da propriedade tiver o mesmo nome pode ser usado uma vez apenas

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

   //********************EdicActionAbort *********************/

   function editActionAbort() {
    setFrmEdit(false);
    setTitulo=("");
    setIdEvento(null);
  }

  //********************Update *********************/

  async function handleUpdate(e) {
    //para o submit da página
    e.preventDefault();

    try {
      
      const retorno = await api.put('/TiposEvento/' + idEvento, {
        titulo: titulo
      });

      setNotifyUser({
        titleNote: "Sucesso",
        textNote: `Atualizado com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });

      setTitulo("")
      getState();

      editActionAbort();

    } catch (error) {
      
      setNotifyUser({
        titleNote: "Atenção",
        textNote: `Falha na atualização`,
        imgIcon: "danger",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
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

  //********************Delete *********************/

  async function handleDelete(idEvento) {
    try {
      const retorno = await api.delete(`/TiposEvento/${idEvento}`);

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
                    type={"text"}
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
