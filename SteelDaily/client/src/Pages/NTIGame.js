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
    const [isFlipped, setIsFlipped] = useState(false)
    const [correct, setCorrect] = useState(true)
    const scale = [
        { steps: 1, interval: "1" },
        { steps: 2, interval: "b2" },
        { steps: 3, interval: "2" },
        { steps: 4, interval: "b3" },
        { steps: 5, interval: "3" },
        { steps: 6, interval: "4" },
        { steps: 7, interval: "b5" },
        { steps: 8, interval: "5" },
        { steps: 9, interval: "b6" },
        { steps: 10, interval: "6" },
        { steps: 11, interval: "b7" },
        { steps: 12, interval: "7" }
    ]
    const startGame = () => {
        return getToken()
            .then(token =>
                fetch(`/api/Game?key=${key}`, {
                    method: "GET",
                    headers: {
                        Authorization: `Bearer ${token}`,
                    },
                })
            ).then(res => res.json())
            .then(res => {
                console.log(res.value)
                setResult(res.value)
            }
            )
    }
    const answerQuestion = (answer) => {
        const priorAnswers = result.answers ? result.answers + "," : null
        const game = {
            result: {
                id: result.id,
                answers: `${priorAnswers}${answer}`
            }
        }
        return getToken()
            .then(token =>
                fetch(`/api/Game`, {
                    method: "POST",
                    headers: {
                        Authorization: `Bearer ${token}`,
                    },
                    body: JSON.stringify(game)
                })
            ).then(res => res.json())
            .then(res => {
                console.log(res.value)
                setResult(res.value)
            })
    }

    async function startHandler() {
        await startGame()
        setGame(true)
    }
    async function AnswerHandler(e) {
        console.log(e.target.value)
        answerQuestion()
        setIsFlipped(!isFlipped)
    }

    return (
        <div className="game-area">
            <div className="score-container">
                <ScoreDisplay />
            </div>
            <div className="card-area">
                <Col sm="12" md={{ size: 6, offset: 3 }}>
                    {game ?
                        <NTIQuestionCard result={result} isFlipped={isFlipped} correct={correct} />
                        : <>
                            <KeySelect setKey={setKey} />
                            <Button onClick={startHandler}>Start Game</Button>
                        </>
                    }
                </Col>
            </div>
            <div className="button-container">
                {scale.map(interval => (
                    <Button key={interval.steps} value={interval.steps}
                        onClick={AnswerHandler}
                    >{interval.interval}</Button>
                ))}
            </div>
        </div >



    )


};
export default NTIGame;