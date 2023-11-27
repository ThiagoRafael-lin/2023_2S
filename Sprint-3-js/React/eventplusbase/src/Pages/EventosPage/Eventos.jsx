import { useEffect, useState } from "react";
import Title from "../../Components/Title/Title";
import "./Eventos.css";
import MainContent from "../../Components/MainContent/MainContent";
import ImageIllustrator from "../../Components/ImageIllustrator/ImageIllustrator";
import "../../Components/FormComponents/FormComponents";
import eventTypeImage from "../../assets/images/evento.svg";
import Container from "../../Components/Container/Container";
import {
  Input,
  Button,
  Select,
} from "../../Components/FormComponents/FormComponents";
import api from "../../Services/Services";
import TableEv from "./TableEv/TableEv";

import Notification from "../../Components/Notification/Notification";
import Spinner from "../../Components/Spinner/Spinner";
import { dateFormatDdToViewR } from "../../Utils/stringFunction";


const Eventos = () => {
  const [notifyUser, setNotifyUser] = useState({});
  const [showSpinner, setShowSpinner] = useState(false);

  const [nomeEvento, setNomeEvento] = useState("");
  const [descricao, setDescricao] = useState("");
<<<<<<< HEAD
  const [data, setData] = useState("");
=======
  const [dataEvento, setDataEvento] = useState();
  const [idTipoEvento, setIdTipoEvento] = useState();
>>>>>>> b90c40df64147a7ff0096f2456d984b132d02362

  const [eventos, setEventos] = useState([]);

  const [frmEdit, setFrmEdit] = useState(false);

  const [tipoEvento, setTipoEvento] = useState([]);
  //Value do Select
  const [idTipoEvento, setIdTipoEvento] = useState("");
  const [idEvento, setIdEvento] = useState(null)
  const [idInstituicao, setIdInstituicao] = useState("");

  //************************useEffect ******************************/

  //ao carregar a pagina
  useEffect(() => {
    async function getEvento() {
      setShowSpinner(true);
      try {
        const promise = await api.get("/Evento");
<<<<<<< HEAD
        setEventos(promise.data);
=======
        console.log(promise.dataEvento);
        setEvento(promise.dataEvento);
>>>>>>> b90c40df64147a7ff0096f2456d984b132d02362
      } catch (error) {
        setNotifyUser({
          titleNote: "Erro",
          textNote: `Deu ruim na api!`,
          imgIcon: "warning",
          imgAlt:
            "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
          showMessage: true,
        });
      }
      setShowSpinner(false);
    }
    async function getTiposEvento() {
      try {
        const promise = await api.get("/TiposEvento");
        setTipoEvento(promise.data);
      } catch (error) {
        setNotifyUser({
          titleNote: "Erro",
          textNote: `Deu ruim na api!`,
          imgIcon: "warning",
          imgAlt:
            "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
          showMessage: true,
        });
      }
    }

    async function getInstituicao() {
      try {
        const promise = await api.get("/Instituicao");
        setIdInstituicao(promise.data[0].idInstituicao);
      } catch (error) {
        console.log("se fudeu Tinas HAHAHAHAHA");
      }
    }
    getInstituicao();
    getEvento();
    getTiposEvento();
  }, []);

  // useEffect(() => {
  //   async function getEventos() {
  //     try {
  //       const promise = await api.get("/Evento");
  //       console.log(promise.data);
  //       setEvento(promise.data);
  //     } catch (error) {
  //       setNotifyUser({
  //         titleNote: "Atenção",
  //         textNote: `Deu ruim na api`,
  //         imgIcon: "danger",
  //         imgAlt:
  //           "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
  //         showMessage: true,
  //       });
  //     }

  //     async function getTiposEvento() {
  //       try {
  //         const promise = await api.get("/TiposEvento");
  //         setTipoEvento(promise.data);
  //       } catch (error) {
  //         console.log("deu merda");
  //       }
  //     }

  //     setShowSpinner(true);
  //     getTiposEvento();
  //   }
  //   getEventos();
  // }, []);

  //************************getState ******************************/

  async function getState() {
    const retornoGet = await api.get("/Evento");
<<<<<<< HEAD
    console.log(retornoGet.data);
    setEventos(retornoGet.data);
=======
    console.log(retornoGet.dataEvento);
    setEvento(retornoGet.dataEvento);
>>>>>>> b90c40df64147a7ff0096f2456d984b132d02362
  }

  //************************Submit ******************************/

  async function handleSubmit(e) {
    //para o submit da pagina
    e.preventDefault();

    if (nomeEvento.trim().length < 3) {

      setNotifyUser({
        titleNote: "Erro",
        textNote: `O titulo deve conter no minimo 3 caracteres!`,
        imgIcon: "danger",
        imgAlt:
        "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
      return;
    }
    
    try {
<<<<<<< HEAD
      const retorno = await api.post("/Evento", {
        nomeEvento: nome,
        descricao: descricao,
        dataEvento: data,
        idTipoEvento: idTipoEvento,
        idInstituicao: idInstituicao
      });
=======
      const retorno = await api.post("/Evento", { 
>>>>>>> b90c40df64147a7ff0096f2456d984b132d02362

        nomeEvento : nomeEvento,
        descricao : descricao,
        dataEvento : dataEvento,
        idTipoEvento : idTipoEvento
      });
      
      setNotifyUser({
        titleNote: "Sucesso",
        textNote: `Cadastrado com sucesso!`,
        imgIcon: "success",
        imgAlt:
        "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });


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
  
  // async function handleSubmit(e) {
  //   //para o submit da pagina
  //   e.preventDefault();

  //   if (nome.trim().length < 3) {
  //     alert("O nome deve ter no minimo 3 caracteres");
  //     return;
  //   }
  //   try {
  //     const retorno = await api.post("/Evento", { nome : nome});

  //     setNotifyUser({
  //       titleNote: "Sucesso",
  //       textNote: `Cadastrado com sucesso!`,
  //       imgIcon: "success",
  //       imgAlt:
  //         "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
  //       showMessage: true,
  //     });

  //     console.log(retorno.data);
  //     setNome("");
  //     getState();
  //   } catch (e) {
  //     setNotifyUser({
  //       titleNote: "Atenção",
  //       textNote: `Erro ao cadastrar`,
  //       imgIcon: "danger",
  //       imgAlt:
  //         "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
  //       showMessage: true,
  //     });
  //   }
  // }

  //************************EdictAbort ******************************/

  function editActionAbort() {
    setFrmEdit(false);
<<<<<<< HEAD
    setNome("");
    setData("");
    setDescricao("");
    setIdTipoEvento("");
=======
    setNomeEvento = "";
>>>>>>> b90c40df64147a7ff0096f2456d984b132d02362
    setIdEvento(null);
  }

  //************************Update ******************************/

  async function handleUpdate(e) {
    //parar o submit da página
<<<<<<< HEAD
     e.preventDefault();

    try {
      const retorno = await api.put("/Evento/" + idEvento, {
        nomeEvento: nome,
        descricao: descricao,
        dataEvento: data,
        idTipoEvento: idTipoEvento,
        idInstituicao: idInstituicao
      });
      
=======
    e.preventDefault();

    try {
      const retorno = await api.put("/Evento" + idEvento, {
        nomeEvento: nomeEvento,
        descricao : descricao,
        dataEvento : dataEvento,
        idTipoEvento : idTipoEvento
      });

      const retornoGet = await api.get("/Evento")
      setEvento(retornoGet.data)
      
      console.log(retorno.dataEvento);

>>>>>>> b90c40df64147a7ff0096f2456d984b132d02362
      setNotifyUser({
        titleNote: "Sucesso",
        textNote: `Atualizado com sucesso!`,
        imgIcon: "success",
        imgAlt:
        "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
<<<<<<< HEAD
      console.log(retorno.data);

      editActionAbort();
      getState();

      // editActionAbort();
=======

      editActionAbort();
      
>>>>>>> b90c40df64147a7ff0096f2456d984b132d02362
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
  
  // async function handleUpdate(e) {
  //   //parar o submit da página
  //   // e.preventDefault();

  //   try {
  //     const retorno = await api.put("/Evento" + idEvento, {
  //       nomeEvento: nomeEvento
  //     });
  //     console.log(retorno.dataEvento);

  //     setNotifyUser({
  //       titleNote: "Sucesso",
  //       textNote: `Atualizado com sucesso!`,
  //       imgIcon: "success",
  //       imgAlt:
  //         "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
  //       showMessage: true,
  //     });

  //     setNomeEvento("");
  //     getState();

  //     editActionAbort();
  //   } catch (e) {
  //     setNotifyUser({
  //       titleNote: "Atenção",
  //       textNote: `Erro ao cadastrar`,
  //       imgIcon: "danger",
  //       imgAlt:
  //         "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
  //       showMessage: true,
  //     });
  //   }
  // }
  //************************ShowUpdateForm ******************************/

  async function showUpdateForm(idElemento) {
    setFrmEdit(true);
    try {
      const retorno = await api.get("/Evento/" + idElemento);

<<<<<<< HEAD
      setNome(retorno.data.nomeEvento);
      setDescricao(retorno.data.descricao);
      setIdTipoEvento(retorno.data.idTiposEvento)
      setData(dateFormatDdToViewR(retorno.data.dataEvento));
      setIdEvento(retorno.data.idEvento)
=======
      setNomeEvento(retorno.dataEvento.nomeEvento);
      setIdEvento(retorno.dataEvento.idTipoEvento);
>>>>>>> b90c40df64147a7ff0096f2456d984b132d02362

      setIdTipoEvento(retorno.data.idTipoEvento);
    } catch (error) {
      alert("Não foi possivel mostrar a tela de edição. tente novamente");
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
              onSubmit={frmEdit ? handleUpdate : handleSubmit}
            >
              {!frmEdit ? (
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

<<<<<<< HEAD
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
=======
              <>
                <Input
                  type={"text"}
                  id={"nome"}
                  name={"nome"}
                  placeholder={"Nome"}
                  required={"required"}
                  value={nomeEvento}
                  manipulationFunction={(e) => {
                    setNomeEvento(e.target.value);
                  }}
                />
>>>>>>> b90c40df64147a7ff0096f2456d984b132d02362

                  <Select
                    id={"tipoEvento"}
                    name={"tipoEvento"}
                    required={"required"}
                    tipoEventos={tipoEvento}
                    manipulationFunction={(e) => {
                      setIdTipoEvento(e.target.value);
                    }}
                    defaultvalue={idTipoEvento}
                  />

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

<<<<<<< HEAD
                  <Button
                    type={"submit"}
                    id={"botao"}
                    name={"botao"}
                    textButton={"Cadastrar"}
                  />
                </>
              ) : (
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

                  <Select
                    id={"tipoEvento"}
                    name={"tipoEvento"}
                    required={"required"}
                    tipoEventos={tipoEvento}
                    manipulationFunction={(e) => {
                      setIdTipoEvento(e.target.value);
                    }}
                    defaultvalue={idTipoEvento}
                  />
=======
                <Input
                  type={"date"}
                  id={"data"}
                  name={"data"}
                  placeholder={"dd / mm / aaaa"}
                  required={"required"}
                  value={dataEvento}
                  manipulationFunction={(e) => {
                    setDataEvento(e.target.value);
                  }}
                />

                <Button
                  type={"submit"}
                  id={"botao"}
                  name={"botao"}
                  textButton={"Cadastrar"}
                />
              </>
             ) : (
              <>
              
              <Input
                  type={"text"}
                  id={"nome"}
                  name={"nome"}
                  placeholder={"Nome"}
                  required={"required"}
                  value={nomeEvento}
                  manipulationFunction={(e) => {
                    setNomeEvento(e.target.value);
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
                  value={dataEvento}
                  manipulationFunction={(e) => {
                    setDataEvento(e.target.value);
                  }}
                />
                <div className="buttonsp-editbox">

                <Button
                  type={"submit"}
                  id={"atualizar"}
                  name={"atualizar"}
                  textButton={"atualizar"}
                  manipulationFunction={handleUpdate}
                />
                <Button
                  type={"button"}
                  id={"cancelar"}
                  name={"cancelar"}
                  textButton={"cancelar"}
                  manipulationFunction={editActionAbort}
                />
                </div>

              </>
             )}
>>>>>>> b90c40df64147a7ff0096f2456d984b132d02362

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
                  <div className="buttons-editbox">
                    <Button
                      type={"submit"}
                      id={"atualizar"}
                      name={"atualizar"}
                      textButton={"Atualizar"}
                      manipulationFunction={handleUpdate}
                      additionalClass="button-component--middle"
                    />
                    <Button
                      type={"button"}
                      id={"cancelar"}
                      name={"cancelar"}
                      textButton={"Cancelar"}
                      // manipulationFunction={editActionAbort}
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
          <Title titleText={"Lista de Evento"} color="white" />
          <TableEv
            dados={eventos}
            fnUpdate={showUpdateForm}
            fnDelete={handleDelete}
          />
        </Container>
      </section>
    </MainContent>
  );
};

export default Eventos;
