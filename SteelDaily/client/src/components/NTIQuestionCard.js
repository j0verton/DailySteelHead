import React, { useContext, useState } from "react";
import { toast } from "react-toastify";
import { Button, Card, Col } from "reactstrap";
import ReactCardFlip from 'react-card-flip';
import "./NTIQuestionCard.css"


const NTIQuestionCard = ({ result, isFlipped, correct }) => {
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
                    <h2>{result.key}</h2><br />
                is at<br />
                    <h2>fret {result.questions.split(",")[0]}</h2><br />
                on the <br />
                    <h2>string {result.questions.split(",")[1]}</h2>
                </Card>
                <Card className="gameCard" id={correct ? "isCorrect" : "isIncorrect"}>
                    <h2>8th fret</h2><br />
                on the <br />
                    <h2>8th string</h2>
                    is the<br />
                    <h2>1st</h2><br />
                degree of the C scale<br />
                </Card>
            </ReactCardFlip>
        </Col >

        //give correct/incorrect via toast or a flipping card

    )
};
export default NTIQuestionCard