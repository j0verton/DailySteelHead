import React, { useContext, useState } from "react";
import { toast } from "react-toastify";
import { Button, Card, Col } from "reactstrap";
import ReactCardFlip from 'react-card-flip';
import "./NTIQuestionCard.css"


const NTIQuestionCard = ({ result, isFlipped }) => {
    // const [isFlipped, setIsFlipped] = useState(false)

    const [vertFlip, setFlip] = useState(true)

    // const handleClick = (e) => {
    //     flipRandomizer()
    //     e.preventDefault();
    //     setCorrect(false);
    //     setIsFlipped(!isFlipped);
    // }

    const flipRandomizer = () => {
        const num = Math.floor(Math.random() * 10)
        if (num >= 4) {
            console.log("if")
        } else {
            console.log("else")

            setFlip(!vertFlip);
        }
    }
    return (
        <Col sm="12" md={{ size: 6, offset: 3 }}>
            <ReactCardFlip
                isFlipped={isFlipped}
                flipDirection={vertFlip ? "vertical" : "horizontal"}>
                <Card className="gameCard">
                    What interval of <br />
                    <h2>{result.result.key}</h2><br />
                is at<br />
                    <h2>fret {result.questionsNumbers.reverse()[0][0]}</h2><br />
                on the <br />
                    <h2>string {result.questionsNumbers.reverse()[0][1]}</h2>
                </Card>
                <Card id="gameCard" className={result.outcomes.reverse()[0] ? "isCorrect" : "isIncorrect"}>
                    <h2>fret {result.questionsNumbers.reverse()[1][0]}</h2><br />
                on the <br />
                    <h2>string {result.questionsNumbers.reverse()[1][1]}</h2>
                    is the<br />
                    <h2>{result.answers ? result.answerList.reverse()[0] : null}</h2><br />
                degree of the {result.key} scale<br />
                </Card>
            </ReactCardFlip>
        </Col >

        //give correct/incorrect via toast or a flipping card

    )
};
export default NTIQuestionCard