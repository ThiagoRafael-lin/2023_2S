import React, {useEffect, useState} from 'react';
import MainContent from '../../Components/MainContent/MainContent';
import './HomePage.css'

import Banner from '../../Components/Banner/Banner';
import VisaoSection from '../../Components/VisaoSection/VisaoSection';
import ContactSection from '../../Components/ContactSection/ContactSection';
import NextEvent from '../../Components/NextEvent/NextEvent';
import Title from '../../Components/Title/Title';
import Container from "../../Components/Container/Container"
import api from '../../Services/Services';

const HomePage = () => {

    useEffect(() => {
        async function getProximosEventos() {
            try {
                const promise = await api.get("https://localhost:7118/api/Evento/ListarProximos");
                setNextEvents(promise.data);

            } catch (error) {
                console.log("deu ruim na api");
            }
        }
        getProximosEventos();
    })


    const [nextEvents, setNextEvents] = useState([
        // {id: 1, title: "Evento X", descricao: "bora codar JS", data: "11/11/2023" },
        // {id: 2, title: "Evento y", descricao: "bora codar Java", data: "10/11/2023" },
        // {id: 3, title: "Evento z", descricao: "bora codar c#", data: "09/11/2023" },
        // {id: 4, title: "Evento w", descricao: "bora codar C++", data: "08/11/2023" }
    ]);


    return (
        <MainContent>
            <Banner />
            {/* Next Event  */}
            <section className='proximos-eventos'>
            <Container>
                <Title titleText={"Proximos Eventos"}/>

            <div className='events-box'>

            {
                nextEvents.map((e) => {

                    return(
                        <NextEvent
                            title={e.nomeEvento}
                            description={e.descricao.substr(0,20)} //subsrt limita os caracteres que aparecem
                            eventDate={e.dataEvento}
                            idEvento={e.idEvento}
                        />
                    )
                })        
            }
            </div>
            </Container>
            </section>
       
            <VisaoSection />
            <ContactSection />
        </MainContent>
    );
};

export default HomePage;