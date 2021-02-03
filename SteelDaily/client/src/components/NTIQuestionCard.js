import React, { useContext, useState } from "react";
import { toast } from "react-toastify";
import { Button, Card, Col } from "reactstrap";
import ReactCardFlip from 'react-card-flip';
import "./NTIQuestionCard.css"


const NTIQuestionCard = ({ result, isFlipped, scale }) => {
    // const [isFlipped, setIsFlipped] = useState(false)

    const [vertFlip, setFlip] = useState(true)

    // const handleClick = (e) => {
    //     flipRandomizer()
    //     e.preventDefault();
    //     setCorrect(false);
    //     setIsFlipped(!isFlipped);
    // }
    const convertCharIntervalToNumericInterval = (intString) => {
        const correctObj = scale.find(interval => interval.stringName === intString)
        return correctObj.interval;
    }

    const convertHalfStepsToInterval = (intString) => {
        const correctObj = scale.find(interval => interval.stringName === intString)
        return correctObj.interval;
    }

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
                    <h2>fret {result.questions.reverse()[0][0]}</h2><br />
                        on the <br />
                    <h2>string {result.questions.reverse()[0][1]}</h2>
                </Card>

                {//Back of car with answer
                }
                <Card id="gameCard" className={result.outcomes ? result.outcomes.reverse()[0] ? "isCorrect" : "isIncorrect" : null}>
                    {result.outcomes ? (<>
                        <h2>fret {result.questions.reverse()[1][0]}</h2><br />
                        on the <br />
                        <h2>string {result.questions.reverse()[1][1]}</h2>
                        is the<br />
                        {result.outcomes.reverse()[0] ?
                            //display correct answer
                            (
                                <h2 className="isCorrectAns">
                                    {convertCharIntervalToNumericInterval(result.answerList.reverse()[0])}
                                </h2>) :
                            //displays incorrect and correct answer
                            (
                                <>
                                    <h2 className="isIncorrectAns">
                                        {convertCharIntervalToNumericInterval(result.answerList.reverse()[0])}
                                    </h2>
                                    <h2>
                                        {convertCharIntervalToNumericInterval(result.correctAnswerList.reverse()[1])}
                                    </h2>

                                </>)}
                        < br />
                        degree of the {result.key} scale<br />
                    </>) : null}
                </Card>
            </ReactCardFlip>
        </Col >

        //give correct/incorrect via toast or a flipping card

    )
};
export default NTIQuestionCard