import React, { useContext, useState } from "react";
import { toast } from "react-toastify";
import NTIQuestionCard from "../components/NTIQuestionCard";
import ScoreDisplay from "../components/ScoreDisplay";
import { Button, Card, Col } from "reactstrap";
import "./NTIGame.css";
import 'bootstrap/dist/css/bootstrap.min.css';
import { UserProfileContext } from "../providers/UserProfileProvider";
import KeySelect from "../components/KeySelect";


const NTIGame = () => {
    const { getToken } = useContext(UserProfileContext)
    const [game, setGame] = useState(false)
    const [key, setKey] = useState("C")
    const [result, setResult] = useState({})

    const startGame = () => {
        setGame(true)
        getToken()
            .then(token =>
                fetch(`/api/Game?key=${key}`, {
                    method: "GET",
                    headers: {
                        Authorization: `Bearer ${token}`,
                    },
                })
            ).then(res => res.json())
            .then(res => {
                console.log(res)
                setResult(res)
            }
            )
    }
    const onSelect = () => {


    }

    return (
        <div className="game-area">
            <div className="score-container">
                <ScoreDisplay />
            </div>
            <div className="card-area">
                <Col sm="12" md={{ size: 6, offset: 3 }}>
                    {game ?
                        <NTIQuestionCard result={result} />
                        : <>
                            <KeySelect setKey={setKey} />
                            <Button onClick={startGame}>Start Game</Button>
                        </>
                    }
                </Col>
            </div>
            <div className="button-container">
                <Button value="1">1</Button>
                <Button value="2">b2</Button>
                <Button value="3">2</Button>
                <Button value="4">b3</Button>
                <Button value="5">3</Button>
                <Button value="6">4</Button>
                <Button value="7">b5</Button>
                <Button value="8">5</Button>
                <Button value="9">b6</Button>
                <Button value="10">6</Button>
                <Button value="11">b7</Button>
                <Button value="12">7</Button>


            </div>
        </div>



    )


};
export default NTIGame;