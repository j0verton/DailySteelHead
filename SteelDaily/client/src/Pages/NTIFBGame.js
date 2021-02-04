import React, { useContext, useState } from "react";
import { toast } from "react-toastify";
import ScoreDisplay from "../components/ScoreDisplay";
import { Button, Card, Col } from "reactstrap";
import "./NTIGame.css";
import 'bootstrap/dist/css/bootstrap.min.css';
import { UserProfileContext } from "../providers/UserProfileProvider";
import KeySelect from "../components/KeySelect";
import fretboard from "../images/fretboard.svg"
import Fretboard from "../components/Fretboard";
import DisplayQuestionDot from "../components/DisplayQuestionDot";

const NTIFBGame = () => {
    const { getToken } = useContext(UserProfileContext)
    const [game, setGame] = useState(false)
    const [key, setKey] = useState("C")
    const [result, setResult] = useState({})
    const [isFlipped, setIsFlipped] = useState(false)
    const scale = [
        { steps: 1, buttonName: "1", interval: "1st", stringName: "One" },
        { steps: 2, buttonName: "b2", interval: "b2nd", stringName: "FlatTwo" },
        { steps: 3, buttonName: "2", interval: "2nd", stringName: "Two" },
        { steps: 4, buttonName: "b3", interval: "b3rd", stringName: "FlatThree" },
        { steps: 5, buttonName: "3", interval: "3rd", stringName: "Three" },
        { steps: 6, buttonName: "4", interval: "4th", stringName: "Four" },
        { steps: 7, buttonName: "b5", interval: "b5th", stringName: "FlatFive" },
        { steps: 8, buttonName: "5", interval: "5th", stringName: "Five" },
        { steps: 9, buttonName: "b6", interval: "b6th", stringName: "FlatSix" },
        { steps: 10, buttonName: "6", interval: "6th", stringName: "Six" },
        { steps: 11, buttonName: "b7", interval: "b7th", stringName: "FlatSeven" },
        { steps: 12, buttonName: "7", interval: "7th", stringName: "Seven" }
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
                console.log(res)
                setResult(res)
            }
            )
    }
    const answerQuestion = (answer) => {
        const gameReturn = {
            resultId: result.result.id,
            questionNumbers: result.questions.slice(-1).join(","),
            answer: answer
        }
        console.log("game", gameReturn)
        return getToken()
            .then(token =>
                fetch(`/api/game/`, {
                    method: "POST",
                    headers: {
                        Authorization: `Bearer ${token}`,
                        "Content-Type": "application/json"
                    },
                    body: JSON.stringify(gameReturn)
                })
            ).then(res => res.json())
            .then(res => {
                console.log("ans response", res)
                setResult(res)
            })
    }

    async function startHandler() {
        await startGame()
        setGame(true)
    }
    async function AnswerHandler(e) {
        console.log("answer steps", e.target.value)
        await answerQuestion(e.target.value)
        setIsFlipped(!isFlipped)
    }

    return (
        <div className="game-area">
            <div className="score-container">
            </div >
            <div className="fretboard-container">
                {game ? null : <>
                    <KeySelect setKey={setKey} />
                    <Button onClick={startHandler}>Start Game</Button>
                </>
                }
                <Fretboard result={result} gameComponent={DisplayQuestionDot} />
                {/* <img
                    id="fretboard"
                    src={fretboard}
                    alt="steelguitar fretboard" /> */}
            </div>
            <div className="button-container">
                {
                    isFlipped ? <Button onClick={() => setIsFlipped(false)}>Next</Button> :

                        scale.map(interval => (
                            <Button key={interval.steps} value={interval.stringName}
                                onClick={AnswerHandler}
                            >{interval.buttonName}</Button>
                        ))
                }
            </div>
        </div >
    )
};
export default NTIFBGame;